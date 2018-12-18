using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_redactor
{
    public partial class ChildForm : Form
    {
        private Point pointCaret = new Point(0,0);       
        public ChildForm()
        {
            InitializeComponent();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if(font.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = font.Font;
        }

        private void цветШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();           
            if (color.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = color.Color;                               
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color1 = new ColorDialog();
            if (color1.ShowDialog() == DialogResult.OK)
                richTextBox1.BackColor = color1.Color;
        }

        private void копироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void вырезатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void отменитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {            
            pointCaret.X = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            pointCaret.Y = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine();
            Form1 form = (Form1)MdiParent;
            foreach (var item in form.Controls)
            {
                StatusStrip strip = item as StatusStrip;
                if(strip!=null&&strip.Visible==true)
                {
                    foreach (var item2 in strip.Items)
                    {
                        ToolStripStatusLabel label = item2 as ToolStripStatusLabel;
                        if(label!=null)
                            label.Text = $"Стр {pointCaret.X+1} Стлб {pointCaret.Y+1}";
                    }
                }
            }
        }
    }
}
