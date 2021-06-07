using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

class ListViewHandler
{
    public void set_position_and_size(ref ListView view, int posX, int posY, int width, int height)
    {
        view.Bounds = new Rectangle(new Point(posX, posY), new Size(width, height));
    }

    public void set_config_settings(ref ListView view, View viewSettings, bool labelEditON, bool allowColumnRecorderON,
        bool checkBoxesON, bool fullRowSelectON, bool gridLinesON, SortOrder sortOrder)
    {
        view.View = viewSettings;
        view.LabelEdit = labelEditON;
        view.AllowColumnReorder = allowColumnRecorderON;
        view.CheckBoxes = checkBoxesON;
        view.FullRowSelect = fullRowSelectON;
        view.GridLines = gridLinesON;
        view.Sorting = sortOrder;
    }

    public void add_column(ref ListView view, string txt, int width)
    {
        view.Columns.Add(txt, width);
    }
}
