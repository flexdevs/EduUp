using EduUp.DataAccess.Interfaces.Common;
using EduUp.Domain.Entities.Comments;
using EduUp.Domain.Entities.Rates;
using EduUp.Service.Dtos.Rates;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces.Common;
using EduUp.Service.Interfaces.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Services.Rates
{
	public class RateService : IRateService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdentityService _identityService;

		public RateService(IUnitOfWork unitOfWork, IIdentityService identityService)
		{
			this._unitOfWork = unitOfWork;
			this._identityService = identityService;
		}
		public async Task<bool> CreateRateAsync(CreateRateDto createRateDto)
		{
			Rate rate = (Rate)createRateDto;
			rate.UserId = _identityService.Id!.Value;

			_unitOfWork.Rates.Add(rate);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;

		}

		public async Task<bool> UpdateRateAsync(CreateRateDto updatedRateDto)
		{
			Rate rate = (Rate)updatedRateDto;
			rate.UserId = _identityService.Id!.Value;

			_unitOfWork.Rates.Update(rate.CourseId, rate);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}
	}
}
