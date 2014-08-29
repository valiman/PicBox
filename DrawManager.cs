using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PicBoxTest
{
    public class DrawManager
    {
        private readonly int ObjectCount = 5;

        //public Graphics graphicsObject;
        private Label lblObjCount;
        private PictureBox picBox;
        public List<Tile> tileList = new List<Tile>();
        public ListViewManager lbMgr; //new in ctor

        public DrawManager(ListView listView, PictureBox picBox, Label lblObjCount)
        {
            this.picBox = picBox;
            this.lblObjCount = lblObjCount;

            lbMgr = new ListViewManager(listView, tileList);
        }
        public void UpdateListBox(object sender, EventArgs e)
        {
            lbMgr.RefreshList();
        }
        public void UpdateScreen(object sender, EventArgs e)
        {
            picBox.Invalidate();
            lblObjCount.Text = tileList.Count.ToString();
        }
        public void UpdateTiles(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int rndTileIndex = rnd.Next(tileList.Count);
            Tile rndTile = tileList[rndTileIndex];

            if (rndTile.Direction == Direction.Right)
            {
                rndTile.Location = new Point(rndTile.Location.X + 2, rndTile.Location.Y);

                //Increase travel distance
                rndTile.TravelDistance += 2;

                //If current location is 300 or higher, change direction.
                if (rndTile.Location.X >= 300 - 5) //(-5) is tilesize.
                {
                    rndTile.Direction = Direction.Left;
                }
            }
            else //Direction.Left
            {
                rndTile.Location = new Point(rndTile.Location.X - 5, rndTile.Location.Y);

                //Increase travel distance
                rndTile.TravelDistance += 5;

                //If current location is 0 or lower, change direction.
                if (rndTile.Location.X <= 0)
                {
                    rndTile.Direction = Direction.Right;
                }
            }
        }
        public void Draw(Graphics graphicsObject)
        {
            foreach (var tile in tileList)
            {
                //Draw Title
                graphicsObject.DrawString(tile.ID.ToString(), new Font("Gotham Medium", 15, FontStyle.Bold), new SolidBrush(Color.Black), new PointF((int)tile.Location.X-20, (int)tile.Location.Y-20));

                //Draw Square
                graphicsObject.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(tile.Location, new Size(5, 5)));
            }
        }
        public void GenerateTiles()
        {
            Random rnd = new Random();
            for (int i = 0; i < ObjectCount; i++)
            {
                int x = 0; //rnd.Next(0, 300);
                int y = rnd.Next(0, 300);
                Point point = new Point(x, y);

                Tile tile = new Tile(i, point);

                tileList.Add(tile);
            }
        }
    }
}
