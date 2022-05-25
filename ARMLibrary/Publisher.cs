using System;
using System.Collections.Generic;

#nullable disable

namespace ARMLibrary
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        private static Publisher _publisher;

        public static Publisher CreatePublisher(string name)
        {
            _publisher = new Publisher()
            {
                PublisherName = name

            };
            return _publisher;
        }
        public int Id { get; set; }
        public string PublisherName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
