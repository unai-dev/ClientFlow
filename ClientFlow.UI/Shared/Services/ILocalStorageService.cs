namespace ClientFlow.UI.Shared.Services
{
    public interface ILocalStorageService
    {
        Task<string?> GetItemLocalStorageAsync(string key);
        Task RemoveItemLocalStorage(string key);
        Task SetItemLocalStorageAsync(string key, string value);
    }
}