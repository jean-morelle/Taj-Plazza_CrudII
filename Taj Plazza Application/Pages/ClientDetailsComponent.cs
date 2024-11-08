using Microsoft.AspNetCore.Components;
using Taj_Plazza.Core.Interfaces;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza_Application.Pages
{
    public class ClientDetailsComponent :ComponentBase
    {
        protected string Message = string.Empty;
        public Client client { get; set; } = new Client();
        [Parameter]
        public string Id {  get; set; }
        [Inject]

        private IclientServicesCore clientServicesCore { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (string.IsNullOrEmpty(Id))
            {
                // adding a neuw client
            }
            else
            {
                //Update a new client
                var clientId = Convert.ToInt32(Id);
                var apiClient = await clientServicesCore.GetClient(clientId);
                if (apiClient != null)
                {
                    client = apiClient;
                }
            }
        }
         protected void HandleFailedRequest()
        {
            Message = "Something went wrong, form not submited.";
        }
        protected void GoToClients()
        {
            navigationManager.NavigateTo("/Clients");
        }

        protected async Task DeleteClient()
        {
            if(!string.IsNullOrEmpty(Id))
            {
                var clientId = Convert.ToInt32(Id);
                var result = clientServicesCore.DeleteClient(clientId);
                if (result is not null)
                {
                    navigationManager.NavigateTo("/Clients");
                }
                else
                {
                    Message = "something went wrong, client not delete";
                }
            }
           
        }
        protected async void HandleValidRequest()
        {
            if (string.IsNullOrEmpty(Id))
            {
                // add client
                var result = clientServicesCore.AddClient(client);
                if(result is not null)
                {
                    navigationManager.NavigateTo("/Clients");
                }
                else
                {
                    Message = "something went wrong, client not add:()";
                }
            }
            else
            {
                //update client
                var result = clientServicesCore.AddClient(client);
                if (result is not null)
                {
                    navigationManager.NavigateTo("/Clients");
                }
                else
                {
                    Message = "something went wrong, client not update:()";
                }
            }
        }
    }
}
