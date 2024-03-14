using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be minimum 5 characters")]
        [MaxLength(280, ErrorMessage = "Title cannot be larger thatn 200 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Content must be minimum 5 characters")]
        [MaxLength(280, ErrorMessage = "Content cannot be larger thatn 200 characters")]
        public string Content { get; set; } = string.Empty;
    }
}
