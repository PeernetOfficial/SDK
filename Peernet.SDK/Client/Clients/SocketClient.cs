using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Peernet.SDK.Client.Clients
{
    internal class SocketClient : ISocketClient
    {
        private const int ReceiveBufferSize = 8192;
        private ClientWebSocket socket;
        private readonly Uri socketUrl;

        public event EventHandler<string> MessageArrived;

        private CancellationTokenSource cancellationTokenSource;

        public SocketClient(Uri socketUrl)
        {
            this.socketUrl = socketUrl;
        }

        public async Task Connect()
        {
            socket = new();
            await socket.ConnectAsync(socketUrl, CancellationToken.None);
        }

        public async Task Send(string data)
        {
            await socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(data)), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task StartReceiving(CancellationTokenSource cancellationTokenSource)
        {
            this.cancellationTokenSource = cancellationTokenSource;
            var cancellationToken = cancellationTokenSource.Token;
            MemoryStream outputStream = null;
            var buffer = WebSocket.CreateClientBuffer(ReceiveBufferSize, ReceiveBufferSize);
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    outputStream = new MemoryStream(ReceiveBufferSize);
                    WebSocketReceiveResult receiveResult;
                    do
                    {
                        receiveResult = await socket.ReceiveAsync(buffer, cancellationToken);
                        if (receiveResult.MessageType != WebSocketMessageType.Close)
                        {
                            outputStream.Write(buffer.Array, 0, receiveResult.Count);
                        }
                    }
                    while (!receiveResult.EndOfMessage);
                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }

                    var message = Encoding.UTF8.GetString(outputStream.ToArray(), 0, (int)outputStream.Length);
                    MessageArrived?.Invoke(null, message);
                    outputStream.Position = 0;
                }
            }
            finally
            {
                outputStream?.Dispose();
            }
        }

        public void Disconnect()
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Token.WaitHandle.WaitOne();
            socket.Dispose();
        }
    }
}