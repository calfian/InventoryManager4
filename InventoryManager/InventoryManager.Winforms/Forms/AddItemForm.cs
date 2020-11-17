using System;
using System.Windows.Forms;

namespace InventoryManager.Winforms.Forms
{
    public partial class AddItemForm : Form
    {

        public string ItemName
        {
            get => nameTextBox.Text;
            set => nameTextBox.Text = value;
        }
        public AddItemForm()
        {
            InitializeComponent();
        }

        private void AddItemForm_Load(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !string.IsNullOrEmpty(ItemName);
        }
    }
}
