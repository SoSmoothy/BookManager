namespace BookConsoleApp.Controllers
{
    using BookConsoleApp.Models;
    using BookConsoleApp.Views;
    using DataServices;
    internal class BookController
    {
        protected Repository Repository;

        public BookController(SimpleDataAccess context)
        {
            Repository = new Repository(context);
        }
        public void Single(int id, string path = "")
        {
            var model = Repository.Select(id);
            ReadSingleBook readSingleBook = new ReadSingleBook(model);
            
            if(!string.IsNullOrEmpty(path)) { 
                readSingleBook.RenderToFile(path);
                return;
            }
            readSingleBook.Read();
        }

        public void Create()
        {
            CreateBook createBook = new CreateBook();
            createBook.Render();
        }

        public void Update(int id)
        {
            var model = Repository.Select(id);
            BookUpdateView bookUpdateView = new BookUpdateView(model);
            bookUpdateView.Render();
        }

        public void List(string path = "")
        {
            var model = Repository.Select();
            BookListView bookListView = new BookListView(model);
            if (!string.IsNullOrEmpty(path))
            {
                bookListView.RenderToFile(path);
                return;
            }
            bookListView.Render();
        }
    }
}