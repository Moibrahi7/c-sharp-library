
namespace libraryException{
    class GuestNotFoundException : IOException{
        public GuestNotFoundException (string message) :
        base (message) { }
    }
}