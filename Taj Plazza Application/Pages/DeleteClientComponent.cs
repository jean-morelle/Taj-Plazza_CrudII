using Microsoft.AspNetCore.Components;
using Taj_Plazza.Core.Interfaces;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza_Application.Pages
{
    public class DeleteClientComponent : ComponentBase
    {
        [Parameter]

        public int Id { get; set; }
        [Parameter]

        public string Message { get; set; }
        [Inject]

        public IclientServicesCore clientServicesCore { get; set; }

        [Parameter]

        public Client client { get; set; } = new Client();

        protected override async Task OnInitializedAsync()
        {
            await LoadClient();
        }
        public async Task LoadClient()
        {
            client = await clientServicesCore.GetClientAsync(Id);
        }

        [Inject]
        NavigationManager navigationManager { get; set; }
        public async Task DeleteClient()
        {
            var result = clientServicesCore.DeleteClientAsync(Id);
            navigationManager.NavigateTo("ClientList");
        }
        public void Cancel()
        {
            navigationManager.NavigateTo("ClientList");
        }
        protected void HandleFailedRequest()
        {
            Message = "Une erreur s'est produite, le formulaire n'a pas été soumis.";
        }
    }
}
