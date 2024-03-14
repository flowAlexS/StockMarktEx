namespace Api.Repository
{
    using Api.Data;
    using Api.Interfaces;
    using Api.Models;
    using Microsoft.EntityFrameworkCore;

    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        => this._context = context;

        public async Task<List<Comment>> GetAllAsync()
        => await this._context.Comments.ToListAsync();
    }
}
