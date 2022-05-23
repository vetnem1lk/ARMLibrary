using System;
using System.Collections.Generic;

#nullable disable

namespace ARMLibrary
{
    public partial class Book
    {
        private static Book _book;

        public static Book CreateBook(string name, string author, DateTime release, int publisherId)
        {
            _book = new Book
            {
                Name = name,
                Author = author,
                Release = release,
                PublisherId = publisherId
            };
            return _book;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Release { get; set; }
        public int? PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}
