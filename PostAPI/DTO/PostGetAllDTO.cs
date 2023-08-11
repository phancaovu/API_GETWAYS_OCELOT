﻿using System.ComponentModel.DataAnnotations;

namespace PostAPI.DTO
{
    public class PostGetAllDTO
    {
        [Key]
        [Required]
        public int PostID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
