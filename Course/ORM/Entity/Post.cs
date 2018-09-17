using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entity
{
    public class Post
    {
        [Required]
        public int PostId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int NumberOfLikes { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }

        [Required]
        public int UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public virtual List<Tag> Tags { get; set; }

        public virtual List<UserLikesEntity> UserLikesEntity { get; set; }

        [Required]
        public byte[] Image { get; set; }
    }
}
