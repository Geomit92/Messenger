using System;

namespace MyMessenger
{
    class Users
    {
        public Users() { }

        public int UsernameID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Boolean Deleted { get; set; }
    }
}
