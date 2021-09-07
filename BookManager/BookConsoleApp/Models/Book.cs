using System;

namespace BookConsoleApp.Models
{
    /// <summary>
    /// Lớp Mô tả sách
    /// </summary>
    public class Book
    {
        private string _bookTitle;
        private int _idBook;
        private string _publisher;
        private int _yearRealease;
        private int _edition;
        private string _description;
        
        public Book() {}

        public Book(string bookTitle)
        {
            BookTitle = bookTitle;
        }

        public Book(string bookTitle, int idBook) : this(bookTitle)
        {
            IdBook = idBook;
        }

        public Book(string bookTitle, int idBook, string publisher) : this(bookTitle, idBook)
        {
            Publisher = publisher;
        }

        public Book(string bookTitle, int idBook, string publisher, int yearRealease) : this(bookTitle, idBook,
            publisher)
        {
            YearRealease = yearRealease;
        }
        public Book(string bookTitle, int idBook, string publisher, int yearRealease, int edition) : this(bookTitle, idBook, publisher, yearRealease)
        {
            Edition = edition;
        }

        public Book(string bookTitle, int idBook, string publisher, int yearRealease, int edition, string description) : this(bookTitle,
            idBook, publisher, yearRealease, edition)
        {
            Description = description;
        }
        
        /// <summary>
        /// Tiêu đề sách
        /// </summary>
        /// <exception cref="Exception"></exception>
        public string BookTitle
        {
            get => _bookTitle;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _bookTitle = value;
                }
                else
                {
                    throw new Exception("Lỗi tiêu đề không được bỏ trống!");
                }
            }
        }
        
        /// <summary>
        /// Mã số định danh của sách
        /// </summary>
        /// <exception cref="Exception"></exception>
        public int IdBook
        {
            get => _idBook;
            set
            {
                if (value >= 0)
                {
                    _idBook = value;
                }
                else
                {
                    throw new Exception("Lỗi ID không được là số âm!");
                }
            }
        }
        
        /// <summary>
        /// Nhà xuất bản sách
        /// </summary>
        public string Publisher
        {
            get => _publisher;
            set => _publisher = value;
        }
        
        /// <summary>
        /// Năm xuất bản
        /// </summary>
        /// <exception cref="Exception"></exception>
        public int YearRealease
        {
            get => _yearRealease;
            set
            {
                if (value <= 2021)
                {
                    _yearRealease = value;
                }
                else
                {
                    throw new Exception("Năm xuất bản không hợp lệ!");
                }
            }
        }
        
        /// <summary>
        /// Số lần tái bản của sách
        /// </summary>
        /// <exception cref="Exception"></exception>
        public int Edition
        {
            get => _edition;
            set
            {
                if (value >= 0)
                {
                    _edition = value;
                }
                else
                {
                    throw new Exception("Số lần tái bản không thể nhỏ hơn 0");
                }
            }
        }
        
        /// <summary>
        /// Mô tả của sách
        /// </summary>
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public override string ToString()
        {
            return $"Title: {_bookTitle}\nID: {_idBook}\nNhà xuất bản: {_publisher}\nNăm xuất bản: {_yearRealease}\nTái bản lần: {_edition}";
        }
    }
}