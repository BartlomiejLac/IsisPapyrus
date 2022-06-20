using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EgyptianKeyboard
{
    public partial class EgyptianKeyboard : UserControl
    {
        private int powerDisplayed = 0;

        public event EventHandler OnCharacterSend;
        public EgyptianKeyboard()
        {
            InitializeComponent();
            foreach(var st in CharSource.keywords)
            {
                this.betterListView1.Items.Add(new ListViewItem(st, 0));
            }
            this.betterListView2.TileSize = new Size(48, 48);
            foreach(var st in CharSource.numberSigns[0])
            {
                this.betterListView2.Items.Add(new ListViewItem(st, 0));
            }
            this.betterListView3.TileSize = new Size(48, 48);
            foreach(var st in CharSource.otherNumberSigns)
            {
                this.betterListView3.Items.Add(new ListViewItem(st, 0));
            }
        }

        private void filterKeywords(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            string filter = tb.Text;
            Regex rg = new Regex(filter, RegexOptions.IgnoreCase);
            this.betterListView1.Items.Clear();
            foreach (var st in CharSource.keywords)
            {
                if (rg.IsMatch(st[1])) this.betterListView1.Items.Add(new ListViewItem(st, 0));
            }
        }

        private void itemActivation(object sender, EventArgs e)
        {
            var blv = sender as BetterListView.BetterListView;
            var item = blv.SelectedItems[0];
            OnCharacterSend.Invoke(this, new CharacterSendEventArgs(item.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
            if (powerDisplayed > 3) powerDisplayed = 3;
            if (powerDisplayed == 3) return;
            powerDisplayed++;
            this.betterListView2.Items.Clear();
            foreach (var st in CharSource.numberSigns[powerDisplayed])
            {
                this.betterListView2.Items.Add(new ListViewItem(st, 0));
            }
            if (powerDisplayed == 3) this.button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = true;
            if (powerDisplayed < 0) powerDisplayed = 0;
            if (powerDisplayed == 0) return;
            powerDisplayed--;
            this.betterListView2.Items.Clear();
            foreach (var st in CharSource.numberSigns[powerDisplayed])
            {
                this.betterListView2.Items.Add(new ListViewItem(st, 0));
            }
            if (powerDisplayed == 0) this.button1.Enabled = false;
        }
    }
}