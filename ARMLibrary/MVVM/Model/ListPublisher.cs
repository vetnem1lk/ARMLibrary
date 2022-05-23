using ARMLibrary.MVVM.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace ARMLibrary.MVVM.Model
{
    internal class ListPublisher : ObservableCollection<Publisher>
    {
        public ListPublisher()
        {
            DbSet<Publisher> publishers = DiscoveryView.dbContext.Publishers;
            var queryPublisher = from publisher in publishers select publisher;
            foreach (Publisher pub in queryPublisher)
            {
                Add(pub);
            }
        }
        
    }
}
