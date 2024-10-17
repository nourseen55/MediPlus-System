using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Persistance.Repository
{
	public class NewsRepository : IGenericRepository<NewsPost>
	{
		private readonly ApplicationDbContext 

			_context;
		public NewsRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task AddEntityAsync(NewsPost entity)
		{
			_context.NewsPosts.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteEntityAsync(string id)
		{
			var news = await GetEntityByIdAsync(id);
			if (news != null)
			{
				_context.NewsPosts.Remove(news);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<NewsPost>> GetAllEntityAsync()
		{
			return await _context.NewsPosts
				.Include(n => n.User)
				.OrderByDescending(n => n.DatePosted).ToListAsync();
		}

		public async Task<NewsPost?> GetEntityByIdAsync(string id)
		{
			return await _context.NewsPosts.FindAsync(id);
		}

		public Task UpdateEntityAsync(NewsPost entity)
		{
			throw new NotImplementedException();
		}
	}
}
