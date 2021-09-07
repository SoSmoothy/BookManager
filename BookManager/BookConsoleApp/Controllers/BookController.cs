namespace BookConsoleApp.Controllers
{
    using BookConsoleApp.Models;
    using BookConsoleApp.Views;
    public class BookController
    {
        public void Single()
        {
            Book book = new Book("Ối dồi ôi", 1, "Kim Đồng", 2021, 1, "Hello World");
            ReadSingleBook readSingleBook = new ReadSingleBook(book);
            readSingleBook.Read();
        }

        public void Create()
        {
            CreateBook createBook = new CreateBook();
            createBook.Render();
        }
    }
}