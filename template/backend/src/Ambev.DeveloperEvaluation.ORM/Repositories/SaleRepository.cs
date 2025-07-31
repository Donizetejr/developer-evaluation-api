using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
        }

        public async Task<Sale?> GetByIdAsync(Guid id)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _context.Sales
                .Include(s => s.Items)
                .ToListAsync();
        }

        public async Task UpdateAsync(Sale sale)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
        }

        Task<List<Sale>> ISaleRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}