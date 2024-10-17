using HospitalSystem.Application.Interfaces;
using HospitalSystem.Application.IServices;
using HospitalSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Application.Services
{
	public class NewsService : INewsService
	{
		private readonly IUnitOfWork _unitOfWork;
		public NewsService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task AddNewsAsync(NewsPost news)
		{
			await _unitOfWork._newsRepository.AddEntityAsync(news);
		}

		public async Task DeleteNewsAsync(string id)
		{
			await _unitOfWork._newsRepository.DeleteEntityAsync(id);
		}

		public async Task<IEnumerable<NewsPost>> GetAllNewsAsync()
		{
			return await _unitOfWork._newsRepository.GetAllEntityAsync();
		}

		public async Task<NewsPost> GetNewsByIdAsync(string id)
		{
			return await _unitOfWork._newsRepository.GetEntityByIdAsync(id);
		}
	}
}