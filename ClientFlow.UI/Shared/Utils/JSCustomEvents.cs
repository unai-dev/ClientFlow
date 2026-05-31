using Microsoft.JSInterop;

namespace ClientFlow.UI.Shared.Utils
{
    public class JSCustomEvents : IJSCustomEvents
    {
        private readonly IJSRuntime jSRuntime;

        public JSCustomEvents(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task CustomAlert(string message)
        {
            await jSRuntime.InvokeVoidAsync("alert", message);
        }
    }
}
