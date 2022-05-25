using ARMLibrary.MVVM.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace ARMLibrary.MVVM.Model
{
    internal class ListPublisher : ObservableCollection<Publisher>
    {
        public static ARM_B023Context dbContext { get; set; }


        public ListPublisher()
        {
            dbContext = new ARM_B023Context();
            DbSet<Publisher> publishers = dbContext.Publishers;
            var queryPublisher = from publisher in publishers select publisher;
            foreach (Publisher pub in queryPublisher)
            {
                Add(pub);
            }
        }
        
    }
}
