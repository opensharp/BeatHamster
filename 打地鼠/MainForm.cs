using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 打地鼠
{
    public partial class MainForm : Form
    {
        PictureBox[] Mouse = new PictureBox[9];
        int Count = 80;
        int Position = 10;
        bool Appear = false;
        public MainForm()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                Mouse[i] = new PictureBox();
                Mouse[i].Location = new Point(120 * (i % 3), 117 * (i / 3));
                Mouse[i].Size = new Size(120, 117);
                Mouse[i].Tag = i;
                Mouse[i].Cursor = new Cursor(new Bitmap(Properties.Resources.Hammer).GetHicon());
                Mouse[i].Click += new EventHandler(Mouse_Click);
                Mouse[i].Image = Properties.Resources.Mouse1;
                Controls.Add(Mouse[i]);
            }
        }
        private void Mouse_Click(object sender, EventArgs e)
        {
            int i = (int)((PictureBox)sender).Tag;
            if (i == Position)
            {
                new SoundPlayer(Properties.Resources.Point).Play();
                Mouse[i].Image = Properties.Resources.Mouse1;
                Position = 10;
                Count = 80;
                Appear = false;
            }
        }
        private void Clock_Tick(object sender, EventArgs e)
        {
            if (!Appear)
            {
                if (++Count > 100)
                {
                    Count = 0;
                    while (true)
                    {
                        int i = new Random().Next() % 9;
                        if (i!= Position)
                        {
                            Mouse[i].Image = Properties.Resources.Mouse2;
                            Appear = true;
                            Position = i;
                            return;
                        }
                    }
                }
            }
        }
    }
}