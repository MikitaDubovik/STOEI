using System;

namespace DAL.Interface.DTO
{
    public class DalComment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public DateTime Posted { get; set; }
        public string Text { get; set; }
        public DalUser User { get; set; }
    }
}
