using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Domain.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> ObtenirParIdAsync(Guid id);
        Task<IEnumerable<T>> ObtenirToutAsync();
        Task<IEnumerable<T>> RechercherAsync(Expression<Func<T, bool>> predicate);
        Task<T> AjouterAsync(T entity);
        Task ModifierAsync(T entity);
        Task SupprimerAsync(Guid id);
        Task<bool> ExisteAsync(Guid id);
        Task<int> CompterAsync();
    }
} 