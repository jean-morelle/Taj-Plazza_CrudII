using Microsoft.AspNetCore.Components;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Interfaces;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza_Application.Pages
{
    public class ClientListComponent :ComponentBase
    {
        public List<Client> getAllclients { get; set; } = new();  

        [Inject]
        IclientServicesCore clientServicesCore { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await LoadAllClient();
        }
       public async Task LoadAllClient()
        {
            var clients = await clientServicesCore.GetClientsAsync();
            getAllclients.Clear();
            if( clients is null) return;
            foreach(var client in clients)
            {
                getAllclients.Add(client);
            }
            
        }
        
        public void EditClient(int id)
        {
            navigationManager.NavigateTo($"/client/edit/{id}");
        }

        public async Task DeleteClient(int id)
        {
            var result =  clientServicesCore.DeleteClientAsync(id);
            await LoadAllClient();
        }
    }
}
