namespace libraryException{
    public class LibrarianNotFoundException : IOException{
    public LibrarianNotFoundException (string message) :
        base (message) { }
    }
}