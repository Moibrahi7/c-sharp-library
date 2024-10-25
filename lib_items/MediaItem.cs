

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

        protected MediaItem(string title, Guid barrower, bool isCheckedOut, Guid id){
            this.title = title;
            this.barrower = barrower;
            this.isCheckedOut = isCheckedOut;
            this.id = id;
        } 
        protected MediaItem(string title, Guid barrower, bool isCheckedOut){
            this.title = title;
            this.barrower = barrower;
            this.isCheckedOut = isCheckedOut;
            id = Guid.NewGuid();
        }
        protected MediaItem(string title, Guid id){
            this.title = title;
            this.id = id;
        } 
        protected MediaItem(string title){
            this.title = title;
            id = Guid.NewGuid();
        } 


        // 5 lines of code
        public void checkOut(Guid id){
            isCheckedOut = true;
            barrower = id;
            Console.WriteLine(this.title + " was checked out by " + barrower);
        }
        // 4 lines of code
        public void returnItem(){
            isCheckedOut = false;
            barrower = Guid.Empty; 
        }
    }
}