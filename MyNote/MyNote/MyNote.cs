using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNote
{
    public partial class MyNote : Form
    {
        const string NazwaProgramu = "MyNote";
        private bool CzyZmodyfikowany;
        DateTime CzasStartu;
        public MyNote()
        {
           
            InitializeComponent();
            this.Text = NazwaProgramu;
            toolStripComboBox1.SelectedIndex = 0;
            splitContainer1.Panel2Collapsed = true;
            CzasStartu = DateTime.Now;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void plikToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionBackColor = colorDialog1.Color;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            richTextBox1.LoadFile(openFileDialog1.FileName);
            this.Text = NazwaProgramu + " - " + openFileDialog1.SafeFileName;
            CzyZmodyfikowany = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            richTextBox1.SaveFile(saveFileDialog1.FileName);
            this.Text = NazwaProgramu + " - " + saveFileDialog1.FileName;
            CzyZmodyfikowany = false;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            OProgramie okno = new OProgramie();
            okno.ShowDialog();
            // OProgramie okno = new OProgramie();
           //okno.Show(); //Nie blokuje programu
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0) return;
            if (MessageBox.Show("Na pewno chcesz wyczyścić notatke?", "Jesteś pewien?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            richTextBox1.Clear();
            this.Text = NazwaProgramu;
            CzyZmodyfikowany = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void kopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void wytnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void ponówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int min = (int)(DateTime.Now - CzasStartu).TotalMinutes;
            toolStripStatusLabel1.Text = "[Pracujesz " + min + " minut] ";
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() != DialogResult.OK) return;
            IDataObject org = Clipboard.GetDataObject();
            Image img = Image.FromFile(openFileDialog2.FileName);
            Clipboard.SetImage(img);
            richTextBox1.Paste();
            Clipboard.SetDataObject(org);
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length == 0)
            {
                MessageBox.Show("Najpierw zaznacz fragment tekstu, którego dotyczy wyszukiwanie.");
                return;
            }
            string text = richTextBox1.SelectedText.Replace(" ", "%20");
            splitContainer1.Panel2Collapsed = false;
            int ind = toolStripComboBox1.SelectedIndex;
            if (ind == 0) webBrowser1.Navigate("https://pl.wikipedia.org/wiki/" + text);
            if (ind == 1) webBrowser1.Navigate("https://translate.google.pl/?hl=pl" + text);
            if (ind == 2) webBrowser1.Navigate("https://www.bing.com/search?q=" + text);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int akapitow = richTextBox1.Lines.Length;
            int znakow = richTextBox1.Text.Length;
            toolStripStatusLabel2.Text = "Akapitów: " + akapitow + ", Znaków: " + znakow;
            CzyZmodyfikowany = true;
        }

        private void MyNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CzyZmodyfikowany) return;
            DialogResult r = MessageBox.Show("Czy chcesz zapisać przed wyjściem?", "Zapisać?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (r == DialogResult.Cancel) e.Cancel = true;
            if (r == DialogResult.Yes) toolStripButton3_Click(sender, e);
        }

        private void koniecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
