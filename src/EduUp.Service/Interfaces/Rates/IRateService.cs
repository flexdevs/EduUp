using EduUp.Service.Dtos.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Interfaces.Rates
{
	public interface IRateService
	{
		public Task<bool> CreateRateAsync(CreateRateDto createRateDto);
		public Task<bool> UpdateRateAsync(CreateRateDto updatedRateDto);
	}
}
