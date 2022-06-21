using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterListView
{ 
  public sealed class BetterListView : ListView
    {
        public BetterListView() 
        { 
            this.OwnerDraw = true;
            this.TileSize = new Size(64, 64);
            this.View = View.Tile;
            this.Activation = ItemActivation.Standard;
        }

        public void increaseFont(int size)
        {
            this.Font = new Font(this.Font.FontFamily,
                this.Font.Size + size,
                FontStyle.Bold,
                this.Font.Unit,
                this.Font.GdiCharSet,
                this.Font.GdiVerticalFont);
        }
        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            Color textColor = SystemColors.WindowText;
            if (e.Item.Selected)
            {
                if (this.Focused)
                {
                    textColor = SystemColors.ControlText;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Lavender), e.Bounds);
                }
                else if (!this.HideSelection)
                {
                    textColor = SystemColors.ControlText;
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), e.Bounds);
                }
            }
            else
            {
                using (SolidBrush br = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillRectangle(br, e.Bounds);
                }
            }

            e.Graphics.DrawRectangle(Pens.LightGray, e.Bounds);
            Font bigFont = new Font(this.Font.FontFamily,
                this.Font.Size + 12,
                FontStyle.Bold,
                this.Font.Unit,
                this.Font.GdiCharSet,
                this.Font.GdiVerticalFont);
            if (e.Item.SubItems.Count <= 1) 
            {
                TextRenderer.DrawText(e.Graphics, e.Item.Text, bigFont, e.Bounds,
                                  textColor, Color.Empty,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            else
            {
                TextRenderer.DrawText(e.Graphics, e.Item.Text + "\n\n", bigFont, e.Bounds,
                                  textColor, Color.Empty,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                TextRenderer.DrawText(e.Graphics, "\n\n" + e.Item.SubItems[1].Text, this.Font, e.Bounds,
                                      textColor, Color.Empty,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            base.OnDrawItem(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
