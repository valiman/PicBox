using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicBoxTest
{
    public partial class Form1 : Form
    {
        DrawManager drawMgr;
        Timer gameLoop = new Timer();
        Timer tileLoop = new Timer();
        Timer infoLoop = new Timer();

        bool isRunning = false;

        public Form1()
        {
            InitializeComponent();

            drawMgr = new DrawManager(listView1, pictureBox1, label1);

            drawMgr.GenerateTiles();

            gameLoop.Tick += new EventHandler(drawMgr.UpdateScreen);
            tileLoop.Tick += new EventHandler(drawMgr.UpdateTiles);
            infoLoop.Tick += new EventHandler(drawMgr.UpdateListBox);

            gameLoop.Interval = 100;
            tileLoop.Interval = 100;
            infoLoop.Interval = 1000;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            drawMgr.Draw(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                gameLoop.Stop();
                tileLoop.Stop();
                infoLoop.Stop();

                isRunning = false;
                toolStripStatusLabel1.Text = "Stopped.";
            }
            else
            {
                gameLoop.Start();
                tileLoop.Start();
                infoLoop.Start();

                isRunning = true;
                toolStripStatusLabel1.Text = "Running.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ClearList
            drawMgr.tileList.Clear();

            //Generate new objects
            drawMgr.GenerateTiles();

            //Clear Listbox
            drawMgr.lbMgr.ClearListBox();

            //force picbox to Refresh
            pictureBox1.Refresh();
        }
    }
}