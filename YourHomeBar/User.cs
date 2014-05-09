using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourHomeBar
{
    class User
    {

        string id;
        string name;
        string email;
        string password;
        string loginAttempts;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string LoginAttempts
        {
            get { return loginAttempts; }
            set { loginAttempts = value; }
        }

    }
}
