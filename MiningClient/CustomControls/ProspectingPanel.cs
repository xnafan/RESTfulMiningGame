using ServiceClientClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace MiningClient.CustomControls;
public class ProspectingPanel : Panel
{
    private float tileSizeInPixels;
    private int mapSideLength = 1;
    private List<SolidBrush> palette = Enumerable.Range(0, 255).Select(no => new SolidBrush(Color.FromArgb(no, Color.Red))).ToList();
    public int MapSideLength
    {
        get => mapSideLength; set { mapSideLength = value; RecalculateScaling(); }
    }
    public List<MapSquareDto> KnownMapSquares { get; set; } = new List<MapSquareDto>();

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
    }

    private void DrawMapSquare(Graphics g, MapSquareDto mapSquare)
    {
        var paletteIndex = (int)(mapSquare.Value / 101f * palette.Count());
        g.FillRectangle(palette[paletteIndex], tileSizeInPixels * mapSquare.X - 1, tileSizeInPixels * mapSquare.Y - 1, tileSizeInPixels, tileSizeInPixels);
    }

    private void DrawMap(Graphics graphics)
    {
            foreach (var mapSquare in KnownMapSquares)
            {
                DrawMapSquare(graphics, mapSquare);
            }
            DrawGrid(graphics);
    }

    private void DrawGrid(Graphics graphics)
    {
        for (int x = 0; x < MapSideLength; x++)
        {
            for (int y = 0; y < MapSideLength; y++)
            {
                graphics.DrawRectangle(Pens.Black, tileSizeInPixels * x, tileSizeInPixels * y, tileSizeInPixels, tileSizeInPixels);
            }
        }
    }
}