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
        public void Single(int id)
        {
            var model = Repository.Select(id);
            ReadSingleBook readSingleBook = new ReadSingleBook(model);
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

        public void List()
        {
            var model = Repository.Select();

            BookListView bookListView = new BookListView(model);
            bookListView.Render();
        }
    }
}