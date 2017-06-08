namespace Blog.UI.Tests.Models
{
    public class Post
    {

        private string title;
        private string content;


        public Post()
        {
        }


        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }


        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }
    }
}
