using System.Windows.Forms;

namespace EgyptianKeyboard
{
    partial class EgyptianKeyboard
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.betterListView1 = new BetterListView.BetterListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.betterListView3 = new BetterListView.BetterListView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.betterListView2 = new BetterListView.BetterListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.betterListView4 = new BetterListView.BetterListView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(14, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(319, 240);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.betterListView1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(311, 214);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Keywords";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // betterListView1
            // 
            this.betterListView1.HideSelection = false;
            this.betterListView1.Location = new System.Drawing.Point(6, 35);
            this.betterListView1.Name = "betterListView1";
            this.betterListView1.OwnerDraw = true;
            this.betterListView1.Size = new System.Drawing.Size(299, 171);
            this.betterListView1.TabIndex = 1;
            this.betterListView1.TileSize = new System.Drawing.Size(64, 64);
            this.betterListView1.UseCompatibleStateImageBehavior = false;
            this.betterListView1.View = System.Windows.Forms.View.Tile;
            this.betterListView1.ItemActivate += new System.EventHandler(this.itemActivation);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(299, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.filterKeywords);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.betterListView3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.betterListView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(311, 214);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Numbers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // betterListView3
            // 
            this.betterListView3.HideSelection = false;
            this.betterListView3.Location = new System.Drawing.Point(182, 6);
            this.betterListView3.Name = "betterListView3";
            this.betterListView3.OwnerDraw = true;
            this.betterListView3.Size = new System.Drawing.Size(112, 193);
            this.betterListView3.TabIndex = 2;
            this.betterListView3.TileSize = new System.Drawing.Size(64, 64);
            this.betterListView3.UseCompatibleStateImageBehavior = false;
            this.betterListView3.View = System.Windows.Forms.View.Tile;
            this.betterListView3.ItemActivate += new System.EventHandler(this.itemActivation);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Webdings", 14.25F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(88, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "4";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Webdings", 14.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(49, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "3";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // betterListView2
            // 
            this.betterListView2.HideSelection = false;
            this.betterListView2.Location = new System.Drawing.Point(6, 6);
            this.betterListView2.Name = "betterListView2";
            this.betterListView2.OwnerDraw = true;
            this.betterListView2.Size = new System.Drawing.Size(153, 153);
            this.betterListView2.TabIndex = 0;
            this.betterListView2.TileSize = new System.Drawing.Size(64, 64);
            this.betterListView2.UseCompatibleStateImageBehavior = false;
            this.betterListView2.View = System.Windows.Forms.View.Tile;
            this.betterListView2.ItemActivate += new System.EventHandler(this.itemActivation);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.betterListView4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(311, 214);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Other";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // betterListView4
            // 
            this.betterListView4.HideSelection = false;
            this.betterListView4.Location = new System.Drawing.Point(6, 6);
            this.betterListView4.Name = "betterListView4";
            this.betterListView4.OwnerDraw = true;
            this.betterListView4.Size = new System.Drawing.Size(299, 202);
            this.betterListView4.TabIndex = 0;
            this.betterListView4.TileSize = new System.Drawing.Size(64, 64);
            this.betterListView4.UseCompatibleStateImageBehavior = false;
            this.betterListView4.View = System.Windows.Forms.View.Tile;
            this.betterListView4.ItemActivate += new System.EventHandler(this.itemActivation);
            // 
            // EgyptianKeyboard
            // 
            this.Controls.Add(this.tabControl1);
            this.Name = "EgyptianKeyboard";
            this.Size = new System.Drawing.Size(348, 258);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBox1;
        private TabPage tabPage3;
        private BetterListView.BetterListView betterListView1;
        private BetterListView.BetterListView betterListView2;
        private Button button2;
        private Button button1;
        private BetterListView.BetterListView betterListView3;
        private BetterListView.BetterListView betterListView4;
    }
}