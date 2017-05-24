using System;


namespace Blog.UI.Tests.Models
{
    public class User
    {
        
        private string fullName;
        private string email;
        private string password;
        private string confirmPassword;

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
    }
}
