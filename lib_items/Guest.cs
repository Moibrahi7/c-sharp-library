using System;
using System.Collections.Generic;

namespace library{
    class Guest {
        
        protected string name;
        private Guid id;
        protected string email;
        protected string password;
        private  HashSet<MediaItem> checkedOutBooks = new  HashSet<MediaItem>();

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
        public  HashSet<MediaItem> CheckedOutBooks{
            get{
                return checkedOutBooks;
            }
        }
        public Guest (string name, Guid id, string email, string password,  HashSet<MediaItem> checkedOutBooks){
            this.name = name;
            this.id = id;
            this.email = email;
            this.password = password;
            this.checkedOutBooks = checkedOutBooks;
        }

        public Guest (string name, string email, string password,  HashSet<MediaItem> checkedOutBooks){
            this.name = name;
            id = Guid.NewGuid();
            this.email = email;
            this.password = password;
            this.checkedOutBooks = checkedOutBooks;
        }
        public Guest (string name,  string email, string password, Guid id){
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

        // 7 lines of code
        public void checkOutItem(MediaItem item){
            if(checkedOutBooks.Contains(item)){
                Console.WriteLine("Item is already checked out");
                return;
            }
            item.checkOut(id);
            checkedOutBooks.Add(item);
        }
        // 9 lines of code
        public void returnItem(MediaItem item){
            if(checkedOutBooks.Contains(item)){
                checkedOutBooks.Remove(item);
                item.returnItem();
            }
            else{
                Console.WriteLine("the item is not with this guest");
            }
        }
        // 8 Lines of code
        public void changePassword(string oldPassword, string newPassword){
            if(oldPassword == password){
                this.password = newPassword;
            }
            else{
                Console.WriteLine("Incorrect password was entered");
            }
        }
        public bool checkPassword(string pass){
            return pass == password;
        }
    }
}