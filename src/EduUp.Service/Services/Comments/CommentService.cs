using EduUp.DataAccess.Interfaces.Common;
using EduUp.Domain.Entities.Comments;
using EduUp.Service.Dtos.Comments;
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
	}
}
