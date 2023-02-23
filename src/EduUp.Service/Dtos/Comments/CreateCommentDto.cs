using EduUp.Domain.Entities.Comments;
using EduUp.Service.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Dtos.Comments
{
	public class CreateCommentDto
	{
		[Required]
		public long CourseId { get; set; }
		[Required, MaxLength(255), MinLength(2)]
		public string Comment { get; set; } = string.Empty;

		public static implicit operator Comment(CreateCommentDto dto)
		{
			return new Comment()
			{
				CommentText = dto.Comment,
				CourseId = dto.CourseId,
				CreatedAt = TimeHelper.GetCurrentServerTime()
			};
		}
	}
}
