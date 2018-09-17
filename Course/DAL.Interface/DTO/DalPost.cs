using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalPost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfLikes { get; set; }
        public DateTime UploadDate { get; set; }
        public DalUser User { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<DalUserLikes> UserLikes { get; set; }
        public byte[] Image { get; set; }
    }
}
