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
	public class FeedbackService : IFeedbackService
	{
		private readonly IUnitOfWork _unitOfWork;
		public FeedbackService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task AddFeedbackAsync(Feedback feedback)
		{
			await _unitOfWork._feedbacksRepository.AddEntityAsync(feedback);
		}

		public async Task DeleteFeedbackAsync(string id)
		{
			await _unitOfWork._feedbacksRepository.DeleteEntityAsync(id);
		}
		public async Task<IEnumerable<Feedback>> GetAllfeedbacksAsync()
		{
			return await _unitOfWork._feedbacksRepository.GetAllEntityAsync();

		}

		public async Task<Feedback> GetFeedbackByIdAsync(string id)
		{
			return await _unitOfWork._feedbacksRepository.GetEntityByIdAsync(id);
		}
	}
}