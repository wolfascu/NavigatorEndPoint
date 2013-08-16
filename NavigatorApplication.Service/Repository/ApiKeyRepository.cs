namespace NavigatorApplication.Service.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using NavigatorApplication.Service.DTO.Authentication;

    public class ApiKeyRepository : IApiKeyRepository
    {
        private readonly List<APIKey> apiKeys;  

        public ApiKeyRepository()
        {
            apiKeys = new List<APIKey>
                {
                    new APIKey {Key = "12345678910"},
                    new APIKey {Key = "ABCDEFGHIJ"},
                    new APIKey {Key = "XYZ1234567"}
                };
        }

        public bool GetApiKey(string key)
        {
            return apiKeys.Any(x => x.Key == key);
        }

    }
}
