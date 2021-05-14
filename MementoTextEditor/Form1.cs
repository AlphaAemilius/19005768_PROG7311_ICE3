using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MementoTextEditor
{
    public partial class Form1 : Form
    {

        public Originator originObject = new Originator();
        public Caretaker careT = new Caretaker();
        private string state;
        public Form1()
        {
            InitializeComponent();
            state = richTextBox1.Text;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open some text files my bru";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();

                }
            }

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {

                StreamWriter txtOutput = new StreamWriter(saveFile.FileName);
                txtOutput.Write(richTextBox1.Text);
                txtOutput.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //save
        {
            originObject.setState(richTextBox1.Text);       // capture state
            careT.add(originObject.saveStateToMemento());   // create memento in origin and pass to storage


        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e) 
         //undo by getting last memento from caretaker and feeding it to the originator to convert into a resetable state
        {
            if (careT.getMementoListLength() > 0)
            {
                originObject.getStateFromMemento(careT.get(careT.getMementoListLength()-1));    //gets the last element on the array
            }
            
            //careT.removeRestoredState();                                                     //cleans up list
            richTextBox1.Text = originObject.getState();                                    //restores the save
        }
    }
}
