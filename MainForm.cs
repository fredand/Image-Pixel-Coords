using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PixelCoords
{
    
    public partial class MainForm : Form
    {
        public int iLabelCounter = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|Png files (*.png)|*.png|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            iLabelCounter = -1;
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(iLabelCounter != 0) { 
                if(iLabelCounter < 0)
                {
                    iLabelCounter = 0;
                }
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = iLabelCounter.ToString();
                row.Cells[1].Value = e.X.ToString();
                row.Cells[2].Value = e.Y.ToString();
                dataGridView1.Rows.Add(row);

                Bitmap bitmap = (Bitmap)pictureBox1.Image;
                Graphics graphics = Graphics.FromImage(bitmap);
                Font font = new Font("Arial",24,FontStyle.Bold);
                graphics.DrawString(iLabelCounter.ToString(), font,Brushes.Black,e.X,e.Y);

                pictureBox1.Image = bitmap;

                iLabelCounter++;
            }
        }

    }
}
