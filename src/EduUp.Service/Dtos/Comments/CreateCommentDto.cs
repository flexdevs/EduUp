using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Dtos.Comments
{
	public class CreateCommentDto
	{
		public long CourseId { get; set; }
		public string Comment { get; set; } = string.Empty;
	}
}
