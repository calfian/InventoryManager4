using System.Windows.Forms;
using InventoryManager.Data;
using System.Collections.Generic;


namespace InventoryManager.Winforms.Controls
{
    public partial class EquippedItemControl : UserControl
    {

        public Player Player
        {
            get => mPlayer;
            set
            {
               if(mPlayer != value)
                {
                    mPlayer = value;
                    if(mPlayer != null)
                    {
                        var inventory = new List<Item>(mPlayer.Inventory);
                        inventory.Insert(0, NoItem);

                        equippedItemsComboBox.SelectedIndexChanged -= EquippedItemsComboBox_SelectedIndexChanged;
                       
                        equippedItemsComboBox.DataSource = inventory;
                        EquippedItem = mPlayer.EquippedItems.TryGetValue(EquipLocation, out Item equippedItem) ? equippedItem : NoItem;

                        equippedItemsComboBox.SelectedIndexChanged += EquippedItemsComboBox_SelectedIndexChanged;
                    }
                    else
                    {
                        equippedItemsComboBox.DataSource = null;
                    }
                }
            }
        }


        public EquipLocations EquipLocation
        {
            get => mEquipLocation;
            set
            {
                mEquipLocation = value;
                equippedItemsTextBox.Text = mEquipLocation.ToString();
            }
        }

        public EquippedItemControl()
        {
            InitializeComponent();
        }
        private static readonly Item NoItem = new Item() { Name = "None" };


        private EquipLocations mEquipLocation;
        private Player mPlayer;
        public Item EquippedItem 
        { 
            get=> (Item)equippedItemsComboBox.SelectedItem; 
            set => equippedItemsComboBox.SelectedItem = value;
        }

        private void EquippedItemControl_Load(object sender, System.EventArgs e)
        {

        }

        private void EquippedItemsComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if(mPlayer != null)
            {
                Item equippedItem = EquippedItem;
                if(equippedItem == NoItem)
                {
                    mPlayer.EquippedItems.Remove(EquipLocation);
                }
                else
                {
                    mPlayer.EquippedItems[EquipLocation] = equippedItem;
                }
            }
        }
    }
}
