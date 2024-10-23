using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace library{
    class Library{
        
        private string id;
        private List<Librarian> librarians = new List<Librarian>();
        // Possibly dont need this list due to  the use of the dictionary 
        // List<Guest> libGuests = new List<Guest>();
        private HashSet<Guid> checkedOutItems = new HashSet<Guid>();
        private Dictionary<Guid, MediaItem> mediaItemsById = new Dictionary<Guid, MediaItem>();
        private Dictionary<Guest, List<MediaItem>> checkedOutBooksByGuest = new Dictionary<Guest, List<MediaItem>>();
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
         public Dictionary<Guest, List<MediaItem>> CheckedOutBooksByGuest{
            get{
                return checkedOutBooksByGuest;
            }
         }
        public Library(string id){
            this.id = id;
        }
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
        public void addGuest(Guest guest){
            if(guestById.ContainsValue(guest)){
                Console.WriteLine("This guest is already in the database");
                return;
            }
            checkedOutBooksByGuest.Add(guest, guest.CheckedOutBooks);
            guestById.Add(guest.Id, guest);
        }
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
        public void returnItem(Guest guest, MediaItem item){
            if(checkedOutItems.Contains(item.Id) && checkedOutBooksByGuest[guest].Contains(item)){
                guest.returnItem(item);
                checkedOutBooksByGuest[guest].Remove(item);
                checkedOutItems.Remove(item.Id);
                return;
            }
            Console.WriteLine("This item is not checked out or is not checked out by this guest");
        }
    }
}