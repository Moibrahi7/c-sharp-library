using System;

namespace library{
    public class Librarian : Guest{
        private int employeeId;

        public Librarian (string name, string email, string password, int employeeId) 
        : base (name, email, password){ 
            this.employeeId = employeeId;
        }
    }
}