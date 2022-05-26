

#nullable disable

using System;
using System.Collections.Generic;
using ARMLibrary.MVVM.Model;

namespace ARMLibrary
{
    public partial class History
    {
        public int Id { get; set; }
        public string Item { get; set; }

        private static History _item;
        public static History CreateBookHistory(string name, string author)
        {
            _item = new History
            {
                Item = "Book \"" + name + "\" by " + author + " is added to library."
            };
            return _item;
        }
        public static History CreateReaderHistory(string lastName, string firstName)
        {
            _item = new History
            {
                Item =  lastName + " " + firstName + " become a reader!"
            };
            return _item;
        }

        public static History CreateRemoveHistory(int id, string reason)
        {
            ListBook listBook = new ListBook();
            _item = new History
            {
                Item = "Book \"" + listBook[id].Name + "\" written off! Reason: " + reason
            };
            return _item;
        }
    }
}
