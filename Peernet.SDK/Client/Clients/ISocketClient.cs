using System;
using System.Threading;
using System.Threading.Tasks;

namespace Peernet.SDK.Client.Clients
{
    public interface ISocketClient
    {
        Task Connect();

        void Disconnect();

        Task Send(string data);

        Task StartReceiving(CancellationTokenSource cancellationTokenSource);

        event EventHandler<string> MessageArrived;
    }
}