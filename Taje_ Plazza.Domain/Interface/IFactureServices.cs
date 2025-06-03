using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;

namespace Taje__Plazza.Domain.Interface
{
    public interface IFactureServices
    {
        // Méthodes de recherche et consultation
        Task<IEnumerable<Facture>> ObtenirFacturesParClientAsync(Guid clientId);
        Task<IEnumerable<Facture>> ObtenirFacturesParPeriodeAsync(DateTime dateDebut, DateTime dateFin);
        Task<IEnumerable<Facture>> ObtenirFacturesImpayeesAsync();
        Task<IEnumerable<Facture>> ObtenirFacturesEnRetardAsync();
        Task<IEnumerable<Facture>> ObtenirFacturesParStatutAsync(string statut);

        // Méthodes de calcul
        Task<decimal> CalculerTotalFacturesAsync(DateTime dateDebut, DateTime dateFin);
        Task<decimal> CalculerTotalImpayeAsync();
        Task<decimal> CalculerMontantTotalAsync(Guid factureId);
        Task<decimal> CalculerMontantRestantAsync(Guid factureId);

        // Méthodes de gestion des paiements
        Task<Facture> GenererFactureAsync(Guid reservationId);
        Task EnregistrerPaiementAsync(Guid factureId, decimal montant, string methodePaiement);
        Task<bool> UpdateStatutPaiementAsync(Guid factureId, string nouveauStatut);
        Task<bool> AnnulerFactureAsync(Guid factureId, string motifAnnulation);

        // Méthodes de statistiques
        Task<Dictionary<string, decimal>> ObtenirStatistiquesPaiementAsync(DateTime dateDebut, DateTime dateFin);
        Task<Dictionary<string, decimal>> ObtenirRevenusParMethodePaiementAsync(DateTime debut, DateTime fin);
        Task<Dictionary<DateTime, decimal>> ObtenirChiffreAffaireParJourAsync(DateTime debut, DateTime fin);
        Task<double> ObtenirTauxReglementAsync(DateTime debut, DateTime fin);
    }
}
