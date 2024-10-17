using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Persistance.Repository
{
	public class FeedbackRepository : IGenericRepository<Feedback>
	{
		private readonly ApplicationDbContext _context
            ;
		public FeedbackRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task AddEntityAsync(Feedback entity)
		{
			_context.feedbacks.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteEntityAsync(string id)
		{
			var feedback = await GetEntityByIdAsync(id);
			if (feedback != null)
			{
				_context.feedbacks.Remove(feedback);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Feedback>> GetAllEntityAsync()
		{
			return await _context.feedbacks.Include(n => n.ApplicationUser)
				.OrderByDescending(n => n.DateFeedback).ToListAsync();
		}

		public async Task<Feedback?> GetEntityByIdAsync(string id)
		{
			return await _context.feedbacks.FindAsync(id);
		}

		public Task UpdateEntityAsync(Feedback entity)
		{
			throw new NotImplementedException();
		}
	}
}
