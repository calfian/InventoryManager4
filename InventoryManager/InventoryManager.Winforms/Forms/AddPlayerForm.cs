using System;
using System.Windows.Forms;

namespace InventoryManager.Winforms.Forms
{
    public partial class AddPlayerForm : Form
    {
        public string PlayerName
        {
            get => nameTextBox.Text;
            set => nameTextBox.Text = value;
        }

        public AddPlayerForm()
        {
            InitializeComponent();
            
        }

        private void AddPlayerForm_Load(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !string.IsNullOrEmpty(PlayerName);
        }
    }
}
