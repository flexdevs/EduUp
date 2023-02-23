using EduUp.Service.Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Interfaces.Comments
{
	public interface ICommentService
	{
		public Task<bool> CreateCommentAsync(CreateCommentDto createCommentDto);
		public Task<bool> UpdateCommentAsync(CreateCommentDto updatedCommentDto);
		public Task<bool> DeleteCommentAsync(long id);
	}
}
