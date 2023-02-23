using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Dtos.Rates
{
	public class CreateRateDto
	{
		public long CourseId { get; set; }
		public double rate { get; set; }
	}
}
