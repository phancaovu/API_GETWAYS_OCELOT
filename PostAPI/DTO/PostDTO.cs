using System.ComponentModel.DataAnnotations;

namespace PostAPI.DTO
{
    public class PostDTO
    {
        [Key]
        [Required]
        public int PostID { get; set; }
        [Required]
        public int UserID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

}
