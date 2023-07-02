using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Peernet.SDK.Client.Http;
using Peernet.SDK.Models.Domain.Blockchain;
using Peernet.SDK.Models.Domain.Profile;

namespace Peernet.SDK.Client.Clients
{
    internal class ProfileClient : ClientBase, IProfileClient
    {
        private const string DeleteSegment = "delete";
        private const string WriteSegment = "write";

        private readonly IHttpExecutor httpExecutor;

        public ProfileClient(IHttpExecutor httpExecutor)
        {
            this.httpExecutor = httpExecutor;
        }

        public override string CoreSegment => "profile";

        public async Task<ApiBlockchainBlockStatus> UpdateUser(string userName, byte[] image)
        {
            var jsonContent = JsonContent.Create(new ApiProfileData
            {
                Fields = new List<ApiBlockRecordProfile>
                {
                    new()
                    {
                        Type = ProfileField.ProfileFieldName,
                        Text = userName
                    },
                    new()
                    {
                        Type = ProfileField.ProfilePicture,
                        Blob = image
                    }
                }
            });

            return await httpExecutor.GetResultAsync<ApiBlockchainBlockStatus>(HttpMethod.Post, GetRelativeRequestPath(WriteSegment), content: jsonContent);
        }

        public async Task<ApiProfileData> ReadProfile(ProfileField field, byte[]? node = null)
        {
            var parameters = new Dictionary<string, string>()
            {
                [nameof(field)] = field.ToString("d")
            };

            if (node != null)
            {
                parameters.Add(nameof(node), Convert.ToHexString(node));
            }

            return await httpExecutor.GetResultAsync<ApiProfileData>(HttpMethod.Post, GetRelativeRequestPath("read"), parameters);
        }

        public async Task<ApiBlockchainBlockStatus> DeleteUserImage()
        {
            var jsonContent = JsonContent.Create(new ApiProfileData
            {
                Fields = new List<ApiBlockRecordProfile>
                {
                    new()
                    {
                        Type = ProfileField.ProfilePicture,
                    }
                }
            });

            return await httpExecutor.GetResultAsync<ApiBlockchainBlockStatus>(HttpMethod.Post, GetRelativeRequestPath(DeleteSegment), content: jsonContent);
        }

        public async Task<ApiProfileData> GetProfileData(byte[]? node = null)
        {
            var parameters = new Dictionary<string, string>();

            if (node != null)
            {
                parameters.Add(nameof(node), Convert.ToHexString(node));
            }

            return await httpExecutor.GetResultAsync<ApiProfileData>(HttpMethod.Get, GetRelativeRequestPath("list"), parameters);
        }
    }
}