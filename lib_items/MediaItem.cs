

namespace library{
    public class MediaItem{

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

        public MediaItem(string title, string barrower, Guid id){
            this.title = title;        
            this.id = id;
            if(barrower != ""){
                this.barrower = Program.lib.findGuest(Program.librarian, new Guid(barrower)).Id;
                isCheckedOut = true;
            }
        }
        public MediaItem(string title, Guid id){
            this.title = title;
            this.id = id;
        } 
        public MediaItem(string title){
            this.title = title;
            id = Guid.NewGuid();
        } 

        // 5 lines of code
        public void checkOut(Guid id){
            isCheckedOut = true;
            barrower = id;
            Console.WriteLine(title + " was checked out by " + Program.lib.findGuest(Program.librarian, barrower).Name);
        }
        // 4 lines of code
        public void returnItem(){
            isCheckedOut = false;
            barrower = Guid.Empty; 
        }

        public override string ToString()
        {
            return "-Item Title: " + title + " | ID: " + id;
        }
    }
}