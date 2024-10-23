

namespace library{
    class MediaItem{

        protected string title; 

        protected bool isCheckedOut = false;

        protected Guid barrower;

        protected Guid id;

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

        public Guid Barrower{
            set{
                barrower = value;
            }
            get{
                return barrower;
            }
        }

        public Guid Id{
            get{
                return id;
            }
        }
        public void checkOut(Guid id){
            isCheckedOut = true;
            barrower = id;
            Console.WriteLine(this.title + " was checked out by " + barrower);
        }
        public void returnItem(){
            isCheckedOut = false;
            barrower = Guid.Empty; 
        }
    }
}