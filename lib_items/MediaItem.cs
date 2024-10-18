

namespace library{
    class MediaItem{

        protected string title; 

        protected bool isCheckedOut = false;

        protected string owner = "";

         public string Title{
            set{
                title = value;
            }
            get{
                return title;
            }
        }
        public bool IsCheckedOut {
            set{
                isCheckedOut = value;
            }
            get{
                return isCheckedOut;
            }
        }

        public string Owner{
            set{
                owner = value;
            }
            get{
                return owner;
            }
        }

        public void checkOut(string owner){
            this.isCheckedOut = true;
            Console.WriteLine(this.title + " was checked out by " + owner);
        }
    }
}