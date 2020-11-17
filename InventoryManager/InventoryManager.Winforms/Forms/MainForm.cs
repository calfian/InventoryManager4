
using System.Windows.Forms;
using Newtonsoft.Json;
using InventoryManager.Data;
using System.IO;
using InventoryManager.Winforms.ViewModels;
using InventoryManager.Winforms.Forms;
using System.Reflection;
using System.Linq;
using System;
using System.Collections.Generic;
using InventoryManager.Winforms.Controls;

namespace InventoryManager.Winforms.Forms

{
    public partial class MainForm : Form
    {
        public static string AssemblyTitle = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
        private WorldViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                if (mViewModel != value)
                {
                    mViewModel = value;
                    worldViewModelBindingSource.DataSource = mViewModel;
                }
            }
        }


        private bool IsWorldLoaded
        {
            get => mIsWorldLoaded;
            set
            {
                mIsWorldLoaded = value;
                mainTabControl.Enabled = mIsWorldLoaded;
            }
        }
        public MainForm()
        {
            InitializeComponent();
            ViewModel = new WorldViewModel();
            IsWorldLoaded = false;

            mEquippedItemControlMap = new Dictionary<EquipLocations, EquippedItemControl>
            {
                { EquipLocations.LeftHand, leftHandEquippedItemControl },
                { EquipLocations.RightHand, rightHandEquippedItemControl},
                { EquipLocations.Feet, feetEquippedItemControl },
                { EquipLocations.Head, headEquippedItemControl }
            };
        }
        
        private void playerNameTextBox_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void AddPlayerButton_Click(object sender, System.EventArgs e)
        {
            using (AddPlayerForm addPlayerForm = new AddPlayerForm())
            {
                if (addPlayerForm.ShowDialog() == DialogResult.OK)
                {

                    Player player = new Player { Name = addPlayerForm.PlayerName };
                    ViewModel.Players.Add(player);
                }
            }
        }
        //Add Item Button v
        private void button2_Click(object sender, EventArgs e)
        {
            using (AddItemForm addItemForm = new AddItemForm())
            {
                if(addItemForm.ShowDialog()== DialogResult.OK)
                {
                    Item item = new Item { Name = addItemForm.ItemName };
                    ViewModel.Items.Add(item);
                }
            }
        }


        private void DeletePlayerButton_Click(object sender, System.EventArgs e)
        {
           if(MessageBox.Show("Delete this player?", AssemblyTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ViewModel.Players.Remove((Player)playersListBox.SelectedItem);
                playersListBox.SelectedItem = ViewModel.Players.FirstOrDefault();
            }
        }
        //Delete Item Button v
        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Delete this item?", AssemblyTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ViewModel.Items.Remove((Item)itemsListBox.SelectedItem);
                itemsListBox.SelectedItem = ViewModel.Items.FirstOrDefault();
            }
        }

        #region Main Menu

        private void PlayersListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            deletePlayerButton.Enabled = playersListBox.SelectedItem != null;
            Player selectedPlayer = playersListBox.SelectedItem as Player;
            foreach (var control in mEquippedItemControlMap.Values)
            {
                control.Player = selectedPlayer;
            }
        }
        private void OpenWorldToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.World = JsonConvert.DeserializeObject<World>(File.ReadAllText(openFileDialog.FileName));
                ViewModel.Filename = openFileDialog.FileName;

                Player selectedPlayer = playersListBox.SelectedItem as Player;
                foreach(var control in mEquippedItemControlMap.Values)
                {
                    control.Player = selectedPlayer;
                }

                IsWorldLoaded = true;
            }
        }
        private void SaveToolStripMenuItem_Click(object sender, System.EventArgs e) => ViewModel.SaveWorld();

        private void SaveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if(saveFileDialog.ShowDialog()== DialogResult.OK)
            {
                ViewModel.Filename = saveFileDialog.FileName;
                ViewModel.SaveWorld();
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        #endregion Main Menu



        private WorldViewModel mViewModel;
        private bool mIsWorldLoaded;
        private readonly Dictionary<EquipLocations, EquippedItemControl> mEquippedItemControlMap;

        private void playersTabPage_Click(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

    }
}
