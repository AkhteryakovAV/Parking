using System.Collections.ObjectModel;

namespace Parking.Domain.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void Update<T>(this ObservableCollection<T> items, T item)
        {
            if (items != null && items.Count > 0 && item != null)
            {
                int index = items.IndexOf(item);
                if (index != -1)
                {
                    items.Remove(item);
                    items.Insert(index, item);
                }
            }
        }
    }
}
