using Microsoft.AspNetCore.Components;
using Taj_Plazza.Core.Interfaces;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza_Application.Pages
{
    public class EditClientComponent : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IclientServicesCore ClientServicesCore { get; set; }

        [Parameter]
        public Client client { get; set; } = new Client();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadClient();
        }

        public async Task LoadClient()
        {
            client = await ClientServicesCore.GetClientAsync(Id);
        }

        public async Task UpdateClient()
        {
            var result =  ClientServicesCore.UpdateClientAsync(client);
            if (result != null)
            {
                NavigationManager.NavigateTo("ClientList");
            }
            else
            {
                // Gérer l'erreur de mise à jour ici
            }
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("ClientList");
        }

        protected void HandleFailedRequest()
        {
            // Gérer la soumission échouée
        }
    }
}
