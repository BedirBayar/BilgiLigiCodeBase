﻿using Microsoft.EntityFrameworkCore;
using BilgiLigiContestApi.DataAccess.Entities;

namespace BilgiLigiContestApi.DataAccess.Repositories.Category_
{
    public class CategoryRepository :ICategoryRepository
    {
        private readonly IContestDbContext _context;
        public CategoryRepository(IContestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Category cat)
        {
            _context.Categories.Add(cat);
            await _context.SaveChangesAsync();
            return cat.Id;
        }

        public async Task<List<Category>> GetAll() => await _context.Categories.IgnoreQueryFilters().ToListAsync();
        public async Task<List<Category>> GetAllActive() => await _context.Categories.Where(c=>c.IsActive).ToListAsync();

        public async Task<Category> GetById(int id) => await _context.Categories.IgnoreQueryFilters().SingleOrDefaultAsync(c=>c.Id==id);
        public async Task<Category> GetByName(string name) => await _context.Categories.FirstOrDefaultAsync(c=>c.Name.ToLower()==name.ToLower());

        public async Task<bool> Update(Category cat)
        {
            _context.Categories.Update(cat);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
