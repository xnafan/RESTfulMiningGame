using ServiceClientClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace MiningClient.CustomControls;
public class ProspectingPanel : Panel
{
    private float tileSizeInPixels;
    private int mapSideLength = 1;
    private Brush[] palette = new Brush[] {new SolidBrush(Color.FromArgb(25,Color.Red)), new SolidBrush(Color.FromArgb(50, Color.Red)),
    new SolidBrush(Color.FromArgb(75,Color.Red)),
    new SolidBrush(Color.FromArgb(100,Color.Red)),
    new SolidBrush(Color.FromArgb(125,Color.Red)),
    new SolidBrush(Color.FromArgb(150,Color.Red)),
    new SolidBrush(Color.FromArgb(175,Color.Red)),
    new SolidBrush(Color.FromArgb(200,Color.Red)),
    new SolidBrush(Color.FromArgb(225,Color.Red)),
    new SolidBrush(Color.FromArgb(255,Color.Red)), };
    public int MapSideLength { get => mapSideLength; set {mapSideLength = value; RecalculateScaling(); }
}

    public List<MapSquareDto> KnownMapSquares {get; set; } = new List<MapSquareDto>();

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
        var tileHeight = Height / MapSideLength;
        var tileWidth = Width / MapSideLength;
        tileSizeInPixels = Math.Min(tileHeight, tileWidth);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        DrawMap(e.Graphics);
        foreach (var mapSquare in KnownMapSquares)
        {
            DrawQuadrant(e.Graphics, mapSquare);
        }
    }

    private void DrawQuadrant(Graphics g, MapSquareDto quadrant)
    {
        g.FillRectangle(palette[quadrant.Value/10], tileSizeInPixels * quadrant.X-1, tileSizeInPixels * quadrant.Y-1, tileSizeInPixels, tileSizeInPixels);
    }

    private void DrawMap(Graphics graphics)
    {
        for (int x = 0; x < MapSideLength; x++)
        {
            for (int y = 0; y < MapSideLength; y++)
            {
                graphics.DrawRectangle(Pens.Black, tileSizeInPixels * x, tileSizeInPixels * y, tileSizeInPixels, tileSizeInPixels);
            }
        }
    }

    private void DrawGrid(Graphics graphics)
    {
        throw new NotImplementedException();
    }
}