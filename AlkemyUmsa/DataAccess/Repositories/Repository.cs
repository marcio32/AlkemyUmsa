﻿using AlkemyUmsa.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlkemyUmsa.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAll()
        {
            var prueba = await _context.Set<T>().ToListAsync();
            return prueba;
        }
    }
}