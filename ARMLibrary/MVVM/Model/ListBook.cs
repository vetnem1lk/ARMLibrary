using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ARMLibrary.MVVM.Model
{
    internal class ListBook : ObservableCollection<Book>
    {
        public static ARM_B023Context dbContext { get; set; }
        public ListBook()
        {
            dbContext = new ARM_B023Context();
            DbSet<Book> books = dbContext.Books;
            var queryBook = from book in books select book;
            foreach (Book book in queryBook)
            {
                Add(book);
            }
        }
    }
}
