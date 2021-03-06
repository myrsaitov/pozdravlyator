using System.Threading;
using System.Threading.Tasks;
using SL2021.Application.Services.Comment.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SL2021.Application.Services.Contracts;

namespace SL2021.API.Controllers.Comment
{
    public partial class CommentController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPaged(
            [FromQuery] GetPagedCommentsRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _commentService.GetPaged(
                request.ContentId, 
                new Paged.Request
                {
                    PageSize = request.PageSize,
                    Page = request.Page
                }, 
                cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var found = await _commentService.GetById(new GetById.Request
            {
                Id = id
            }, cancellationToken);

            return Ok(found);
        }
        public class GetPagedCommentsRequest : GetPagedRequest
        {
            public int ContentId { get; set; }
        }
    }
}