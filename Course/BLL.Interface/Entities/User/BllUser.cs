﻿namespace BLL.Interface.Entities
{
    public class BllUser
    {
        public int UserId { get; set; }

        public string Roles { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public byte[] ProfilePhoto { get; set; }
    }
}
