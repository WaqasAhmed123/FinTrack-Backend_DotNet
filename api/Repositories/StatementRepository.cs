using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Model;

namespace api.Repositories
{
    public class StatementRepository : IStatementRepository
    {
        private readonly ApplicationDbContext _context;

        public StatementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Statement> GetStatementByIdAsync(int id)
        {
            return await _context.Statement.FindAsync(id);
        }
    }
}