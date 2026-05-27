using Microsoft.JSInterop;

namespace ClientFlow.UI.Shared.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime jSRuntime;

        public LocalStorageService(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task SetItemLocalStorageAsync(string key, string value)
        {
            await jSRuntime.InvokeVoidAsync("setItemLocalStorage", key, value);
        }

        public async Task<string?> GetItemLocalStorageAsync(string key)
        {
            return await jSRuntime.InvokeAsync<string?>("getItemLocalStorage", key);
        }

        public async Task RemoveItemLocalStorage(string key)
        {
            await jSRuntime.InvokeVoidAsync("removeItemLocalStorage", key);
        }

    }
}
