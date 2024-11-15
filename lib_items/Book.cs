using System.Collections.Generic;

namespace library{
    class Book : MediaItem
    {

        private int pageNum;

        private List<string> authors = new List<string>();


        public int PageNum{
            set{
                pageNum = value;
            }
            get{
                return pageNum;
            }
        }

        public List<string> Authors{
            set{
                authors = value;
            }
            get{
                return authors;
            }
        }

        public Book(string title, string barrower, string author, int pageNum, Guid id) 
        : base (title, barrower, id){
            authors.Add(author);
            this.pageNum = pageNum; 
        }
        public Book(string title, string barrower, List<string> authors, int pageNum, Guid id)
        : base (title, barrower, id){
            this.authors = authors;
            this.pageNum = pageNum;
        }
        public Book(string title, List<string> authors, int pageNum, Guid id) 
        : base (title, id){
            this.authors = authors;
            this.pageNum = pageNum;

        }
        public Book(string title, List<string> authors, int pageNum)
        : base (title){
            this.authors = authors;
            this.pageNum = pageNum;

        }
         public Book(string title, string author, int pageNum, Guid id)
         : base (title, id){
            authors.Add(author);
            this.pageNum = pageNum;
        }
        public Book(string title, string author, int pageNum)
        : base (title){
            authors.Add(author);
            this.pageNum = pageNum;
        }
        public override string ToString()
        {
            return "-Book Title: " + title + " | ID: " + id + " | Number of pages: " + pageNum;
        }
    }
}