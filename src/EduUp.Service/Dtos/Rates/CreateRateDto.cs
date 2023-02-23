using EduUp.Domain.Entities.Rates;
using EduUp.Service.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Dtos.Rates
{
	public class CreateRateDto
	{
		[Required]
		public long CourseId { get; set; }
		[Required]
		public double Rate { get; set; }

		public static implicit operator Rate(CreateRateDto dto)
		{
			return new Rate()
			{
				CourseId = dto.CourseId,
				Value = dto.Rate,
				CreatedAt = TimeHelper.GetCurrentServerTime()
			};
		}
	}
}
