using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicBoxTest
{
    public class ListViewManager
    {
        private List<Tile> tileList;
        private ListView listView;
        public ListViewManager(ListView listView, List<Tile> tileList)
        {
            this.tileList = tileList;
            this.listView = listView;
        }

        public void RefreshList()
        {
            //Temporary clear.
            ClearListBox();
            
            foreach (var tile in tileList.OrderByDescending(x => x.TravelDistance))
            {
                ListViewItem item = new ListViewItem(tile.ID.ToString(), 0);

                item.SubItems.Add(tile.Location.X.ToString() + ", " + tile.Location.Y.ToString());
                item.SubItems.Add(tile.TravelDistance.ToString());

                listView.Items.Add(item);
            }
        }

        public void ClearListBox()
        {
            listView.Items.Clear();
        }
    }
}
