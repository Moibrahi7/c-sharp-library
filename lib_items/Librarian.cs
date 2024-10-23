using System;

namespace library{
    class Librarian : Guest{
        private int employeeId;

        public Librarian (string name, string email, string password, int employeeId) {
            this.name = name;
            this.email = email;
            this.password = password;
            this.employeeId = employeeId;
        }
    }
}