using ClientFlow.UI.Shared.Services;
using System.Net.Http.Headers;

namespace ClientFlow.UI.Auth.Utils
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly ILocalStorageService localStorageService;

        public AuthHeaderHandler(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await localStorageService.GetItemLocalStorageAsync("token");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }


    }
}
