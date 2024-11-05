using Microsoft.AspNetCore.Components;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Interfaces;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza_Application.Pages
{
    public class ClientListComponent :ComponentBase
    {
        public IEnumerable<Client>clients ;
        [Inject]
        IclientServicesCore clientServicesCore { get; set; }

        protected override async Task OnInitializedAsync()
        {
            clients = await clientServicesCore.GetClients();
        }
    }
}
