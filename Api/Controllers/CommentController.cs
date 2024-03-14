using Api.Interfaces;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        => this._commentRepository = commentRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await this._commentRepository.GetAllAsync();

            var commentsDto = comments.Select(comm => comm.ToCommentDto());

            return Ok(commentsDto);
        }
    }
}
