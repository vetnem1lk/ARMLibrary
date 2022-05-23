using System;
using System.Collections.Generic;

#nullable disable

namespace ARMLibrary
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Release { get; set; }
        public int? PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}
