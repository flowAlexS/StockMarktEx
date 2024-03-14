﻿using Api.DTOs.Comment;
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
        private readonly IStockRepository _stockRepository;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            this._commentRepository = commentRepository;
            this._stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await this._commentRepository.GetAllAsync();

            var commentsDto = comments.Select(comm => comm.ToCommentDto());

            return Ok(commentsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await this._commentRepository.GetByIdAsync(id);

            return comment is null
                ? NotFound()
                : Ok(comment);
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto createCommentDto )
        {
            if (!await this._stockRepository.StockExists(stockId))
            {
                return BadRequest("Stock doesn't exist");
            }

            var commentModel = createCommentDto.ToCommentFromCreateDto(stockId);
            await this._commentRepository.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateCommentRequestDto)
        {
            var comment = await this._commentRepository.UpdateAsync(id, updateCommentRequestDto.ToCommentFromUpdateDto());

            return comment is null
                ? NotFound()
                : Ok(comment);
        }
    }
}
