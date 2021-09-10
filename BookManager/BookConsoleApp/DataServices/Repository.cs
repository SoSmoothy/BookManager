using System.Collections.Generic;

namespace BookConsoleApp.DataServices
{
    using Models;
    public class Repository
    {
        protected readonly SimpleDataAccess _context;

        public Repository(SimpleDataAccess context)
        {
            _context = context;
            _context.Load();
        }

        public void SaveChanges() => _context.SaveChanges();

        public List<Book> Books => _context.Books;

        public Book[] Select() => _context.Books.ToArray();

        public Book Select(int id)
        {
            foreach (var b in _context.Books)
            {
                if (b.IdBook == id) return b;
            }

            return null;
        }

        public Book[] Select(string key)
        {
            var temp = new List<Book>();
            var k = key.ToLower();

            foreach (var b in _context.Books)
            {
                var logic = b.BookTitle.ToLower().Contains(k) || b.Publisher.ToLower().Contains(k);
                
                if(logic) temp.Add(b);
            }

            return temp.ToArray();
        }

        public void Insert(Book book)
        {
            var lastIndex = _context.Books.Count - 1;
            var id = lastIndex < 0 ? 1 : _context.Books[lastIndex].IdBook + 1;
            book.IdBook = id;
            _context.Books.Add(book);
        }

        public bool Delete(int id)
        {
            var b = Select(id);
            if (b == null) return false;
            _context.Books.Remove(b);
            return true;
        }

        public bool Update(int id, Book book)
        {
            var b = Select(id);
            if (b == null) return false;
            b.BookTitle = book.BookTitle;
            b.Publisher = book.Publisher;
            b.YearRealease = book.YearRealease;
            b.Edition = book.Edition;
            b.Description = book.Description;
            return true;
        }
    }
}