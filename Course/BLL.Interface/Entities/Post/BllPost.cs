using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class BllPost
    {
        public int PostId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfLikes { get; set; }

        public DateTime UploadDate { get; set; }

        public BllUser User { get; set; }

        public IEnumerable<BllTag> Tags { get; set; }

        public IEnumerable<BllUserLikes> UserLikes { get; set; }

        public byte[] Image { get; set; }
    }
}
