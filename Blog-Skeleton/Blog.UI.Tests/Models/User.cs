using System;


namespace Blog.UI.Tests.Models
{
    public class User
    {
        //default values in case setter are omitted by the data access layer
        private string fullName = "";
        private string email = "";
        private string password = "";
        private string confirmPassword = "";
        private bool isAdmin=false;
        private bool isUser=true;

        public User()
        {
        }


        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }


        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }


        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string ConfirmPassword
        {
            get { return this.confirmPassword; }
            set { this.confirmPassword = value; }
        }

        public bool IsAdmin
        {
            get { return this.isAdmin; }
            set { this.isAdmin = value; }
        }

        public bool IsUser
        {
            get { return this.isUser; }
            set { this.isUser = value; }
        }
    }
}
