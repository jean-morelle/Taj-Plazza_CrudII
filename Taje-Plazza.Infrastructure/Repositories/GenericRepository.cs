using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Taj_Plazza.Core.DataAcess;
using Taje_Plazza.Domain.Interface;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T> ObtenirParIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("L'identifiant ne peut pas être vide.", nameof(id));

            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ObtenirToutAsync()
        {
            return await IncludeAll().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> RechercherAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await IncludeAll().Where(predicate).ToListAsync();
        }

        public virtual async Task<T> AjouterAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task ModifierAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task SupprimerAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("L'identifiant ne peut pas être vide.", nameof(id));

            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Aucune entité trouvée avec l'ID {id}");

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<bool> ExisteAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("L'identifiant ne peut pas être vide.", nameof(id));

            return await _dbSet.AnyAsync(e => e.Id == id);
        }

        public virtual async Task<int> CompterAsync()
        {
            return await _dbSet.CountAsync();
        }

        protected virtual IQueryable<T> IncludeAll()
        {
            return _dbSet;
        }
    }
} 