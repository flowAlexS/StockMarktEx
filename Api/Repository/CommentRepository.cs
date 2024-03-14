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

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await this._context.Comments.AddAsync(commentModel);
            await this._context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        => await this._context.Comments.ToListAsync();

        public async Task<Comment?> GetByIdAsync(int id)
        => await this._context.Comments.FindAsync(id);
    }
}
