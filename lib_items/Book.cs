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

        public Book(string title, Guid barrower, bool isCheckedOut, string author, int pageNum, Guid id){
            this.title = title;
            this.barrower = barrower;
            this.isCheckedOut = isCheckedOut;
            authors.Add(author);
            this.pageNum = pageNum;
            this.id = id; 
        }
        public Book(string title, Guid barrower, bool isCheckedOut, string author, int pageNum){
            this.title = title;
            this.barrower = barrower;
            this.isCheckedOut = isCheckedOut;
            authors.Add(author);
            this.pageNum = pageNum;
            id = Guid.NewGuid(); 
        }
        public Book(string title, Guid barrower, bool isCheckedOut, List<string> authors, int pageNum, Guid id){
            this.title = title;
            this.barrower = barrower;
            this.isCheckedOut = isCheckedOut;
            this.authors = authors;
            this.pageNum = pageNum;
            this.id = id; 
        }
        public Book(string title, Guid barrower, bool isCheckedOut, List<string> authors, int pageNum){
            this.title = title;
            this.barrower = barrower;
            this.isCheckedOut = isCheckedOut;
            this.authors = authors;
            this.pageNum = pageNum;
            id = Guid.NewGuid(); 
        }
        public Book(string title, List<string> authors, int pageNum, Guid id){
            this.title = title;
            this.authors = authors;
            this.pageNum = pageNum;
            this.id = id; 

        }
        public Book(string title, List<string> authors, int pageNum){
            this.title = title;
            this.authors = authors;
            this.pageNum = pageNum;
            id = Guid.NewGuid(); 

        }
         public Book(string title, string author, int pageNum, Guid id){
            this.title = title;
            authors.Add(author);
            this.pageNum = pageNum;
            this.id = id; 
        }
        public Book(string title, string author, int pageNum){
            this.title = title;
            authors.Add(author);
            this.pageNum = pageNum;
            id = Guid.NewGuid(); 
        }
    }
}