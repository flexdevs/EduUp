using EduUp.Domain.Entities.Orders;
using EduUp.Service.Common.Helpers;
using Npgsql.Internal.TypeHandlers.DateTimeHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Dtos.Orders
{
	public class CreateOrderDto
	{
		public long CourseId { get; set; }

		public static implicit operator Order(CreateOrderDto dto)
		{
			return new Order()
			{
				CourseId = dto.CourseId,
				CreatedAt = TimeHelper.GetCurrentServerTime()
			};
		}
	}
}
