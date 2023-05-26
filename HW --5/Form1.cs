using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        private string currentFile = null;
        private bool isTextChanged = false;

        public object textBox1 { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the initial font and color of the text box
            textBox1.Font = new System.Drawing.Font("Arial", 12);
            textBox1.ForeColor = System.Drawing.Color.Black;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Set the isTextChanged flag to true when the text box is changed
            isTextChanged = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new file
            if (isTextChanged)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes to the current file?", "Text Editor", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            textBox1.Clear();
            currentFile = null;
            isTextChanged = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open an existing file
            if (isTextChanged)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes to the current file?", "Text Editor", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                textBox1.Text = reader.ReadToEnd();
                reader.Close();
                currentFile = openFileDialog.FileName;
                isTextChanged = false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save the current file
            if (currentFile == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
                    writer.Write(textBox1.Text);
                    writer.Close();
                    currentFile = saveFileDialog.FileName;
                    isTextChanged = false;
                }
            }
            else
            {
                StreamWriter writer = new StreamWriter(currentFile);
                writer.Write(textBox1.Text);
                writer.Close();
                isTextChanged = false;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save the current file with a new name
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
                writer.Write(textBox1.Text);
                writer.Close();
                currentFile = saveFileDialog.FileName;
                isTextChanged = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit the application
            if (isTextChanged)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes to the current file?", "Text Editor", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            Application.Exit();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Change the font of the text box
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Change the color of the text box
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog.Color;
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Select all text in the text box
            textBox1.SelectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cut selected text from the text box
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Copy selected text from the text box
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Paste text into the text box
            textBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Undo the last action
            textBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Redo the last undone action
            textBox1.Redo();
        }

        private void spellCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Spell check the text in the text box
            // Use a spell checking library such as NHunspell or NetSpell
        }
    }
}