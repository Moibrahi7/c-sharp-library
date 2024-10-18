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

        public Book(string title, string owner, bool isCheckedOut, string author, int pageNum){
            this.title = title;
            this.owner = owner;
            this.isCheckedOut = isCheckedOut;
            this.authors.Add(author);
            this.pageNum = pageNum;
        }

        public Book(string title, string owner, bool isCheckedOut, List<string> authors, int pageNum){
            this.title = title;
            this.owner = owner;
            this.isCheckedOut = isCheckedOut;
            this.authors = authors;
            this.pageNum = pageNum;
        }

        public Book(string title, List<string> authors, int pageNum){
            this.title = title;
            this.authors = authors;
            this.pageNum = pageNum;
        }
         public Book(string title, string author, int pageNum){
            this.title = title;
            this.authors.Add(author);
            this.pageNum = pageNum;
        }
    }
}