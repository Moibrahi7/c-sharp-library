using System;
using System.Collections.Generic;

namespace library{
    class Guest {
        
        private string name;

        Guid id;

        private string email;

        private string password;

        List<MediaItem> checkedOutBooks = new List<MediaItem>();


        public Guest (string name, Guid id, string email, string password, List<MediaItem> checkedOutBooks){
            this.name = name;
            this.id = id;
            this.email = email;
            this.password = password;
            this.checkedOutBooks = checkedOutBooks;
        }

        public Guest (string name, string email, string password, List<MediaItem> checkedOutBooks){
            this.name = name;
            this.id = Guid.NewGuid();
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
            this.id = Guid.NewGuid();
            this.email = email;
            this.password = password;
        }

    }
}