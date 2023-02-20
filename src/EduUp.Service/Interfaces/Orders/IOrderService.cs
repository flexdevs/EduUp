using EduUp.Service.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Interfaces.Orders
{
	public interface IOrderService
	{
		public Task<bool> CreateOrderAsync(CreateOrderDto createOrderDto);
	}
}
