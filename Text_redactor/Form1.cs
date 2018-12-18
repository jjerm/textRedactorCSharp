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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childform = new ChildForm();            
            childform.MdiParent = this;
            childform.Text = $"Новый документ";
            childform.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            новыйToolStripMenuItem_Click(sender, e);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                foreach (var item in ActiveMdiChild.Controls)
                {
                    RichTextBox rich = item as RichTextBox;
                    if (rich != null)
                    {
                        OpenFileDialog fileDialog = new OpenFileDialog();
                        fileDialog.Filter = "text|*.txt|RTF|*.rtf|DOC|*.doc";
                        fileDialog.FilterIndex = 1;
                        if (fileDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                rich.LoadFile(fileDialog.FileName, RichTextBoxStreamType.PlainText);
                                ActiveMdiChild.Text = fileDialog.FileName;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            открытьToolStripMenuItem_Click(sender, e);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                foreach (var item in ActiveMdiChild.Controls)
                {
                    RichTextBox rich = item as RichTextBox;
                    if (rich != null)
                    {
                        if(ActiveMdiChild.Text == "Новый документ")
                            сохранитьКакToolStripMenuItem_Click(sender, e);
                        else
                            rich.SaveFile(ActiveMdiChild.Text, RichTextBoxStreamType.PlainText);     
                    }
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem_Click(sender, e);
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                foreach (var item in ActiveMdiChild.Controls)
                {
                    RichTextBox rich = item as RichTextBox;
                    if (rich != null)
                    {
                        SaveFileDialog Savefile = new SaveFileDialog();
                        Savefile.Filter = "text|*.txt|RTF|*.rtf|DOC|*.doc";
                        Savefile.FilterIndex = 1;
                        if (Savefile.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                rich.SaveFile(Savefile.FileName, RichTextBoxStreamType.PlainText);
                                ActiveMdiChild.Text = Savefile.FileName;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                foreach (var item in ActiveMdiChild.Controls)
                {
                    RichTextBox rich = item as RichTextBox;
                    if (rich != null)
                        rich.Copy();
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                foreach (var item in ActiveMdiChild.Controls)
                {
                    RichTextBox rich = item as RichTextBox;
                    if (rich != null)
                        rich.Cut();
                }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                foreach (var item in ActiveMdiChild.Controls)
                {
                    RichTextBox rich = item as RichTextBox;
                    if (rich != null)
                        rich.Paste();
                }
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                foreach (var item in ActiveMdiChild.Controls)
                {
                    RichTextBox rich = item as RichTextBox;
                    if (rich != null)
                        rich.Undo();
                }
            }
        }

        private void настройкиРедактораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {                
                foreach (var item in ActiveMdiChild.Controls)
                {
                    RichTextBox rich = item as RichTextBox;
                    if (rich != null)
                    {
                        FontDialog font = new FontDialog();
                        if (font.ShowDialog() == DialogResult.OK)
                            rich.Font = font.Font;
                    }                       
                }
            }
        }

        private void цветШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                foreach (var item in ActiveMdiChild.Controls)
                {
                    RichTextBox rich = item as RichTextBox;
                    if (rich != null)
                    {
                        ColorDialog color = new ColorDialog();
                        if (color.ShowDialog() == DialogResult.OK)
                            rich.ForeColor = color.Color;
                    }
                }
            }
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                foreach (var item in ActiveMdiChild.Controls)
                {
                    RichTextBox rich = item as RichTextBox;
                    if (rich != null)
                    {
                        ColorDialog color = new ColorDialog();
                        if (color.ShowDialog() == DialogResult.OK)
                            rich.BackColor = color.Color;
                    }
                }
            }
        }

        private void каскадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void плиткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void строкаСостоянияToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                if (строкаСостоянияToolStripMenuItem.Checked)                   
                    statusStrip1.Visible = true;
                else
                    statusStrip1.Visible = false;
            }
            else
            {
                строкаСостоянияToolStripMenuItem.Checked = false;
                statusStrip1.Visible = false;
            }
        }

        private void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                if (строкаСостоянияToolStripMenuItem.Checked)
                    statusStrip1.Visible = true;
                else
                    statusStrip1.Visible = false;
            }
            else
            {
                строкаСостоянияToolStripMenuItem.Checked = false;
                statusStrip1.Visible = false;
            }        
        }

        private void CommentButton_Click(object sender, EventArgs e)
        {
            if(ActiveMdiChild!=null)
            {
                foreach (var item in ActiveMdiChild.Controls)
                {
                    RichTextBox rich = item as RichTextBox;
                    if(rich != null)
                    {
                        int start = rich.SelectionStart;
                        int line = rich.GetLineFromCharIndex(start);
                        int charInd = rich.GetFirstCharIndexFromLine(line);
                        
                        string str = rich.SelectedText;
                        string str2 = rich.Text;
                        string str3 = str2.Insert(charInd, "//");
                        rich.Select(charInd, rich.Lines[line].Length);
                        string str4 = 
                        for (int i = 0; i < str.Length; i++)
                        {                            
                            line = rich.GetLineFromCharIndex(start);
                            charInd = rich.GetFirstCharIndexFromLine(line);
                        }
                        
                        rich.Get
                        //str.Insert
                        //str = ""
                        rich.SelectionColor = Color.Green;
                    }
                }
            }
        }
    }
}











/*
  public Form1()
        {
            InitializeComponent();
            richTextBox1.AppendText("Hello World!");  // Заполняем rtb текстом           
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Contains(textBox1.Text)) // проверяем есть ли в rtb такое слово которое (мы - пользователь) ввел для замены
            {
                int index = richTextBox1.Text.IndexOf(textBox1.Text);  // узнаем первое вхождение слова (которое будем заменять)
                string str1, str2;
                str1 = richTextBox1.Text.Substring(0, index); // вырезаем с rtb весь текст до слова (которое будем заменять)
                str2 = richTextBox1.Text.Substring((index + textBox1.TextLength), (richTextBox1.TextLength - (index +   textBox1.TextLength))); // вырезаем весь текст после слова (которое будем заменять)
                string result = str1 + textBox2.Text + str2; // соединяем 1 строку со 2, между ними вставляем уже новое слово
                richTextBox1.Clear(); // очищаем от текста rtb 
                richTextBox1.AppendText(result); // вставляем текст уже с новым словом
                richTextBox1.Select(str1.Length, textBox2.Text.Length); // выделяем наше новое слово
                richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))); // ну а тут уже выбираем (новому вставленному) слову любой шрифт, размер шрифта и тд и тп.
            }
            else 
                MessageBox.Show("Такого слова в RichTextBox не найдено"); // в противном случае сообщаем о не найденном слове 
        }





    private void richTextBox1_TextChanged(object sender, EventArgs e)
{
    var currentSelStart = richTextBox1.SelectionStart;
    var currentSelLength = richTextBox1.SelectionLength;

    richTextBox1.SelectAll();
    richTextBox1.SelectionColor = SystemColors.WindowText;

    var matches = Regex.Matches(richTextBox1.Text, @"\bclass\b");
    foreach (var match in matches.Cast<Match>())
    {
        richTextBox1.Select(match.Index, match.Length);
        richTextBox1.SelectionColor = Color.Blue;
    }

    richTextBox1.Select(currentSelStart, currentSelLength);
    richTextBox1.SelectionColor = SystemColors.WindowText;
}
     
     
     */
