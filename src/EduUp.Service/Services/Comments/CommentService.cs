using EduUp.DataAccess.Interfaces.Common;
using EduUp.Domain.Entities.Comments;
using EduUp.Service.Dtos.Comments;
using EduUp.Service.Dtos.Rates;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces.Comments;
using EduUp.Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Services.Comments
{
	public class CommentService : ICommentService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdentityService _identityService;

		public CommentService(IUnitOfWork unitOfWork, IIdentityService identityService)
		{
			this._unitOfWork = unitOfWork;
			this._identityService = identityService;
		}
		public async Task<bool> CreateCommentAsync(CreateCommentDto createCommentDto)
		{
			Comment comment = (Comment)createCommentDto;
			comment.UserId = _identityService.Id!.Value;

			_unitOfWork.Comments.Add(comment);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}


		public async Task<bool> DeleteCommentAsync(long id)
		{
			var res = _unitOfWork.Comments.FirstOrDefaultAsync(x => x.Id == id);
			if(res is null)
				throw new ModelErrorException(nameof(id),"Comment not found");

			_unitOfWork.Comments.Delete(id);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}

		public async Task<bool> UpdateCommentAsync(CreateCommentDto updatedCommentDto)
		{
			Comment comment = (Comment)updatedCommentDto;
			comment.UserId = _identityService.Id!.Value;

			_unitOfWork.Comments.Update(comment.CourseId,comment);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}
	}
}
