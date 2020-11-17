

using System.ComponentModel;

namespace InventoryManager.Data
{
    public class Item: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }

        public int Weight { get; set; }
    }
}
