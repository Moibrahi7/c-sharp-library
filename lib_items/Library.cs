using System.Collections.Generic;
using System.Runtime.CompilerServices;
using libraryException;

namespace library{
    class Library{
        private string id;
        private List<Librarian> librarians = new List<Librarian>();
        // Possibly dont need this list due to  the use of the dictionary 
        // List<Guest> libGuests = new List<Guest>();
        private HashSet<Guid> checkedOutItems = new HashSet<Guid>();
        private Dictionary<Guid, MediaItem> mediaItemsById = new Dictionary<Guid, MediaItem>();
        private Dictionary<Guest, HashSet<MediaItem>> checkedOutBooksByGuest = new Dictionary<Guest, HashSet<MediaItem>>();
        private Dictionary<Guid, Guest> guestById = new Dictionary<Guid, Guest>(); 

        public string Id{
            get{
                return id;
            }
        }
        public List<Librarian> Librarians{
            get{
                return librarians;
            }
        }
        public HashSet<Guid> CheckedOutItems{
            get{
                return checkedOutItems;
            }
        }
        public Dictionary<Guid, MediaItem> MediaItemsById{
            get{
                return mediaItemsById;
            }
        }
         public Dictionary<Guest, HashSet<MediaItem>> CheckedOutBooksByGuest{
            get{
                return checkedOutBooksByGuest;
            }
         }
        public Library(string id, Librarian librarian){
            this.id = id;
            librarians.Add(librarian);
        }
        public Library(string id, List<Librarian> librarians){
            this.id = id;
            this.librarians = librarians;
        }
        // 13 lines of code
        public void AddMediaItem(MediaItem item){
            if(item.IsCheckedOut){
                mediaItemsById.Add(item.Id, item);
                if(guestById.ContainsKey(item.Barrower)){
                    checkedOutBooksByGuest[guestById[item.Barrower]].Add(item);
                }
                else{
                    Console.WriteLine("The borrower is not from this library");
                }
            }
            else{
                mediaItemsById.Add(item.Id, item);
            }
        }
        // 8 lines of code
        public void addGuest(Guest guest){
            if(guestById.ContainsValue(guest)){
                Console.WriteLine("This guest is already in the database");
                return;
            }
            checkedOutBooksByGuest.Add(guest, guest.CheckedOutBooks);
            guestById.Add(guest.Id, guest);
        }
        // 10 lines of code
        public void checkOutItem(Librarian librarian, Guest guest, MediaItem item){ 
            if(librarians.Contains(librarian)){
                if(item.IsCheckedOut){
                    Console.WriteLine("This item is already checked out");
                    return;
                }
                checkedOutItems.Add(item.Id);
                guest.checkOutItem(item);
                checkedOutBooksByGuest[guest].Add(item);
            }
        }
        // 10 lines of code
        public void returnItem(Librarian librarian ,Guest guest, MediaItem item){
            if(!librarians.Contains(librarian)){
                throw new LibrarianNotFoundException("This Librarian is not registered with this library");
            }
            if(checkedOutItems.Contains(item.Id) && checkedOutBooksByGuest[guest].Contains(item)){
                guest.returnItem(item);
                checkedOutBooksByGuest[guest].Remove(item);
                checkedOutItems.Remove(item.Id);
                return;
            }
            Console.WriteLine("This item is not checked out or is not checked out by this guest");
        }
        // 3 lines of code
        public MediaItem findItem(Guid id){
            return mediaItemsById[id];
        }
        // 9 lines of code
        public Guest findGuest(Librarian librarian, Guid guestId){
            if(!librarians.Contains(librarian)){
                throw new LibrarianNotFoundException("This Librarian is not registered with this library");
            }
            if(guestById.ContainsKey(guestId)){
                return guestById[guestId];
            }
            throw new GuestNotFoundException("This guest is not registered in with this library");
        }
    }
}