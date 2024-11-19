using Microsoft.AspNetCore.Components;
using Taj_Plazza.Core.Interfaces;
using Taj_Plazza.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taj_Plazza_Application.Pages
{
    public class ClientListComponent : ComponentBase
    {
        [Inject]
        public IclientServicesCore ClientServicesCore { get; set; }

        public List<Client> AllClients { get; set; } = new List<Client>();
        public List<Client> DisplayedClients { get; set; } = new List<Client>();

        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 7;
        public int TotalPages => (int)Math.Ceiling((double)AllClients.Count / PageSize);

        protected override async Task OnInitializedAsync()
        {
            AllClients = await ClientServicesCore.GetClientsAsync();
            PaginateClients();
        }

        public void PaginateClients()
        {
            DisplayedClients = AllClients
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            if (DisplayedClients.Count >= PageSize)
            {
                NextPage();
            }
        }

        protected void NextPage()
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                DisplayedClients = AllClients
                    .Skip((CurrentPage - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();
            }
        }

        protected void PreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                DisplayedClients = AllClients
                    .Skip((CurrentPage - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();
            }
        }
    }
}
