using System;
using System.Collections.Generic;

namespace library{
    class Guest {
        
        protected string name;
        private Guid id;
        protected string email;
        protected string password;
        private List<MediaItem> checkedOutBooks = new List<MediaItem>();

        public string Name{
            set{
                name = value;
            }
            get{
                return name;
            }
        }
        public Guid Id{
            get{
                return id;
            }
        }
        public string Email{
            set{
                email = value;
            }
            get{
                return email;
            }
        }
        public List<MediaItem> CheckedOutBooks{
            get{
                return checkedOutBooks;
            }
        }

        protected Guest (){  
        }
        public Guest (string name, Guid id, string email, string password, List<MediaItem> checkedOutBooks){
            this.name = name;
            this.id = id;
            this.email = email;
            this.password = password;
            this.checkedOutBooks = checkedOutBooks;
        }

        public Guest (string name, string email, string password, List<MediaItem> checkedOutBooks){
            this.name = name;
            id = Guid.NewGuid();
            this.email = email;
            this.password = password;
            this.checkedOutBooks = checkedOutBooks;
        }
        public Guest (string name, Guid id, string email, string password){
            this.name = name;
            this.id = id;
            this.email = email;
            this.password = password;
        }
        public Guest (string name, string email, string password){
            this.name = name;
            id = Guid.NewGuid();
            this.email = email;
            this.password = password;
        }

        public void checkOutItem(MediaItem item){
            if(checkedOutBooks.Contains(item)){
                Console.WriteLine("Item is already checked out");
                return;
            }
            checkedOutBooks.Add(item);
        }
    }
}