﻿using EduUp.DataAccess.Interfaces.Common;
using EduUp.Domain.Entities.Orders;
using EduUp.Service.Dtos.Orders;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Services.Orders
{
	public class OrderService : IOrderService
	{
		private readonly IUnitOfWork _unitOfWork;

		public OrderService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}
		public async Task<bool> CreateOrderAsync(CreateOrderDto createOrderDto)
		{
			var user = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.Id == 0);
			if(user is null)
				throw new ModelErrorException(nameof(createOrderDto), "User not found");

			var course = await _unitOfWork.Courses.FirstOrDefaultAsync(x => x.Id == createOrderDto.CourseId);
			if (course is null)
				throw new ModelErrorException(nameof(createOrderDto), "Course not found");
			
			Order order = (Order)createOrderDto;
			order.Price = course.Price;

			_unitOfWork.Orders.Add(order);
			var result = await _unitOfWork.SaveChangesAsync();
			return result > 0;
		}
	}
}
