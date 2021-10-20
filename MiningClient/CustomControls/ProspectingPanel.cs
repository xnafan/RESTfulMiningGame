using ServiceClientClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiningClient.CustomControls
{
    public class ProspectingPanel : Panel
    {
        private float _quadrantHeight, _quadrantWidth;
        private int widthInQuadrants = 1, heightInQuadrants = 1;
        private Brush[] palette = new Brush[] {new SolidBrush(Color.FromArgb(25,Color.Red)), new SolidBrush(Color.FromArgb(50, Color.Red)),
        new SolidBrush(Color.FromArgb(75,Color.Red)),
        new SolidBrush(Color.FromArgb(100,Color.Red)),
        new SolidBrush(Color.FromArgb(125,Color.Red)),
        new SolidBrush(Color.FromArgb(150,Color.Red)),
        new SolidBrush(Color.FromArgb(175,Color.Red)),
        new SolidBrush(Color.FromArgb(200,Color.Red)),
        new SolidBrush(Color.FromArgb(225,Color.Red)),
        new SolidBrush(Color.FromArgb(255,Color.Red)), };
        public int WidthInQuadrants { get => widthInQuadrants; set {widthInQuadrants = value; RecalculateScaling(); }
}
        public int HeightInQuadrants { get => heightInQuadrants; set  { heightInQuadrants = value; RecalculateScaling(); } }

        public List<Quadrant> KnownQuadrants { get; set; } = new List<Quadrant>();


        public ProspectingPanel()
        {
            Resize += ProspectingPanel_Resize; ;
            DoubleBuffered = true;
        }

        private void ProspectingPanel_Resize(object sender, EventArgs e)
        {
            RecalculateScaling();
        }

        private void RecalculateScaling()
        {
            _quadrantHeight = Height / HeightInQuadrants;
            _quadrantWidth = Width / WidthInQuadrants;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawMap(e.Graphics);
            foreach (var quadrant in KnownQuadrants)
            {
                DrawQuadrant(e.Graphics, quadrant);
            }
        }

        private void DrawQuadrant(Graphics g, Quadrant quadrant)
        {
            g.FillRectangle(palette[quadrant.Content/10], _quadrantWidth * quadrant.X-1, _quadrantHeight * quadrant.Y-1, _quadrantWidth, _quadrantHeight);
        }

        private void DrawMap(Graphics graphics)
        {
            for (int x = 0; x < widthInQuadrants; x++)
            {
                for (int y = 0; y < heightInQuadrants; y++)
                {
                    graphics.DrawRectangle(Pens.Black, _quadrantWidth * x, _quadrantHeight * y, _quadrantWidth, _quadrantHeight);
                }
            }
        }

        private void DrawGrid(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
