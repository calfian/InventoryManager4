namespace InventoryManager.Winforms.Controls
{
    partial class EquippedItemControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.equippedItemsTextBox = new System.Windows.Forms.TextBox();
            this.equippedItemsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // equippedItemsTextBox
            // 
            this.equippedItemsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.equippedItemsTextBox.Location = new System.Drawing.Point(3, 3);
            this.equippedItemsTextBox.Name = "equippedItemsTextBox";
            this.equippedItemsTextBox.ReadOnly = true;
            this.equippedItemsTextBox.Size = new System.Drawing.Size(101, 20);
            this.equippedItemsTextBox.TabIndex = 0;
            this.equippedItemsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // equippedItemsComboBox
            // 
            this.equippedItemsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.equippedItemsComboBox.DisplayMember = "Name";
            this.equippedItemsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.equippedItemsComboBox.FormattingEnabled = true;
            this.equippedItemsComboBox.Location = new System.Drawing.Point(3, 29);
            this.equippedItemsComboBox.Name = "equippedItemsComboBox";
            this.equippedItemsComboBox.Size = new System.Drawing.Size(101, 21);
            this.equippedItemsComboBox.TabIndex = 0;
            this.equippedItemsComboBox.SelectedIndexChanged += new System.EventHandler(this.EquippedItemsComboBox_SelectedIndexChanged);
            // 
            // EquippedItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.equippedItemsTextBox);
            this.Controls.Add(this.equippedItemsComboBox);
            this.Name = "EquippedItemControl";
            this.Size = new System.Drawing.Size(108, 54);
            this.Load += new System.EventHandler(this.EquippedItemControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox equippedItemsTextBox;
        private System.Windows.Forms.ComboBox equippedItemsComboBox;
    }
}
