using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Taje__Plazza.Domain.Interface;
using Taje__Plazza.Domain.Models;
using Taj_Plazza.Core.DataAcess;
using Taj_Plazza.Core.Models;
using Org.BouncyCastle.Crypto.Generators;

namespace Taje_Plazza.Infrastructure.Repositories
{
    public class UtilisateurRepository : GenericRepository<Utilisateur>, IUtilisateurRepository
    {
        public UtilisateurRepository(ApplicationDbContext context) : base(context)
        {
        }

        protected override IQueryable<Utilisateur> IncludeAll()
        {
            return _dbSet;
        }

        public async Task<Utilisateur> ObtenirParEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("L'email ne peut pas être vide.", nameof(email));

            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> VerifierEmailExisteAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("L'email ne peut pas être vide.", nameof(email));

            return await _dbSet.AnyAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<Utilisateur>> ObtenirParRoleAsync(string role)
        {
            if (string.IsNullOrEmpty(role))
                throw new ArgumentException("Le rôle ne peut pas être vide.", nameof(role));

            return await _dbSet
                .Where(u => u.Role == role)
                .OrderBy(u => u.Nom)
                .ThenBy(u => u.Prenom)
                .ToListAsync();
        }

        public async Task<bool> VerifierMotDePasseAsync(Guid userId, string motDePasse)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("L'identifiant de l'utilisateur est invalide.", nameof(userId));
            if (string.IsNullOrEmpty(motDePasse))
                throw new ArgumentException("Le mot de passe ne peut pas être vide.", nameof(motDePasse));

            var utilisateur = await _dbSet.FindAsync(userId);
            if (utilisateur == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(motDePasse, utilisateur.MotDePasse);
        }

        public async Task ModifierMotDePasseAsync(Guid userId, string nouveauMotDePasse)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("L'identifiant de l'utilisateur est invalide.", nameof(userId));
            if (string.IsNullOrEmpty(nouveauMotDePasse))
                throw new ArgumentException("Le nouveau mot de passe ne peut pas être vide.", nameof(nouveauMotDePasse));

            var utilisateur = await _dbSet.FindAsync(userId);
            if (utilisateur == null)
                throw new KeyNotFoundException($"Aucun utilisateur trouvé avec l'ID {userId}");

            // Utiliser BCrypt pour hasher le mot de passe
            utilisateur.MotDePasse = BCrypt.Net.BCrypt.HashPassword(nouveauMotDePasse);
            utilisateur.DateModification = DateTime.Now;
            
            await _context.SaveChangesAsync();
        }

        public async Task ModifierRoleAsync(Guid userId, string nouveauRole)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("L'identifiant de l'utilisateur est invalide.", nameof(userId));
            if (string.IsNullOrEmpty(nouveauRole))
                throw new ArgumentException("Le nouveau rôle ne peut pas être vide.", nameof(nouveauRole));

            var utilisateur = await _dbSet.FindAsync(userId);
            if (utilisateur == null)
                throw new KeyNotFoundException($"Aucun utilisateur trouvé avec l'ID {userId}");

            utilisateur.Role = nouveauRole;
            utilisateur.DateModification = DateTime.Now;
            
            await _context.SaveChangesAsync();
        }

        public async Task DesactiverCompteAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("L'identifiant de l'utilisateur est invalide.", nameof(userId));

            var utilisateur = await _dbSet.FindAsync(userId);
            if (utilisateur == null)
                throw new KeyNotFoundException($"Aucun utilisateur trouvé avec l'ID {userId}");

            utilisateur.EstActif = false;
            utilisateur.DateModification = DateTime.Now;
            
            await _context.SaveChangesAsync();
        }

        public async Task ActiverCompteAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("L'identifiant de l'utilisateur est invalide.", nameof(userId));

            var utilisateur = await _dbSet.FindAsync(userId);
            if (utilisateur == null)
                throw new KeyNotFoundException($"Aucun utilisateur trouvé avec l'ID {userId}");

            utilisateur.EstActif = true;
            utilisateur.DateModification = DateTime.Now;
            
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Utilisateur>> ObtenirUtilisateursActifsAsync()
        {
            return await _dbSet
                .Where(u => u.EstActif)
                .OrderBy(u => u.Nom)
                .ThenBy(u => u.Prenom)
                .ToListAsync();
        }

        public async Task<DateTime?> ObtenirDerniereConnexionAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("L'identifiant de l'utilisateur est invalide.", nameof(userId));

            var utilisateur = await _dbSet.FindAsync(userId);
            if (utilisateur == null)
                throw new KeyNotFoundException($"Aucun utilisateur trouvé avec l'ID {userId}");

            return utilisateur.DerniereConnexion;
        }

        public async Task MettreAJourDerniereConnexionAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("L'identifiant de l'utilisateur est invalide.", nameof(userId));

            var utilisateur = await _dbSet.FindAsync(userId);
            if (utilisateur == null)
                throw new KeyNotFoundException($"Aucun utilisateur trouvé avec l'ID {userId}");

            utilisateur.DerniereConnexion = DateTime.Now;
            utilisateur.DateModification = DateTime.Now;
            
            await _context.SaveChangesAsync();
        }
    }
} 