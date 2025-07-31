using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task SaveAsync(Sale sale);
        Task<Sale> GetByIdAsync(Guid id);
        Task<List<Sale>> GetAllAsync();
        Task UpdateAsync(Sale sale);
        Task DeleteAsync(Guid id);
    }
}
