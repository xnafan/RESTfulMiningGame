using MiningDataAccessLayer.Model;
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
    private Font _font;
    private float tileSizeInPixels;
    private int mapSideLength = 1;
    private List<SolidBrush> palette = Enumerable.Range(0, 255).Select(no => new SolidBrush(Color.FromArgb(no, Color.Red))).ToList();
    private Point? _lastMouseLocation;
    public MapSquareDto CurrentSquare { get; set; }

    public int MapSideLength
    {
        get => mapSideLength; set { mapSideLength = value; RecalculateScaling(); }
    }
    public List<MapSquareDto> KnownMapSquares { get; set; } = new List<MapSquareDto>();

    public ProspectingPanel()
    {
        Resize += (_,_) => RecalculateScaling();
        MouseMove += (_, e) => SetCurrentSquare(e);
        MouseLeave += (_, _) => { _lastMouseLocation = null; Refresh(); };
        DoubleBuffered = true;
        FontFamily fontFamily = new FontFamily("Arial");
        _font = new Font(fontFamily,32,FontStyle.Bold,GraphicsUnit.Pixel);
    }

    private void SetCurrentSquare(MouseEventArgs e)
    {
        if (!IsOnMap(e.Location))
        {
            _lastMouseLocation = null;
            Refresh();
            return;
        }
        var tileX = (int)(e.Location.X / tileSizeInPixels);
        var tileY = (int)(e.Location.Y / tileSizeInPixels);
        CurrentSquare = KnownMapSquares.FirstOrDefault(square => square.X == tileX && square.Y == tileY);
        _lastMouseLocation = e.Location;
        Refresh();
    }

    private bool IsOnMap(Point location)
    {
        return location.X >= 0 && location.Y >= 0 && location.X < mapSideLength * tileSizeInPixels && location.Y < mapSideLength * tileSizeInPixels;
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
        if(_lastMouseLocation.HasValue && CurrentSquare != null)
        {
            DrawWithOutline(e, GetPositionForMapSquareInfo(e.Graphics));
        }
    }

    private void DrawWithOutline(PaintEventArgs e, Point position)
    {

        for (int deltaX = -2; deltaX <= 1; deltaX++)
        {
            for (int deltaY = -2; deltaY <= 1; deltaY++)
            {
                e.Graphics.DrawString(CurrentSquare.ToString(), _font, Brushes.White, position + new Size(deltaX, deltaY));
            }

        }
       
        e.Graphics.DrawString(CurrentSquare.ToString(), _font, Brushes.Black, position);
    }

    private void DrawMapSquare(Graphics g, MapSquareDto mapSquare)
    {
        var paletteIndex = (int)(mapSquare.Value / 101f * palette.Count());
        g.FillRectangle(palette[paletteIndex], tileSizeInPixels * mapSquare.X, tileSizeInPixels * mapSquare.Y , tileSizeInPixels, tileSizeInPixels);
        
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
                if (CurrentSquare?.X == x && CurrentSquare.Y == y)
                {
                    graphics.DrawRectangle(Pens.Black, tileSizeInPixels * x - 1, tileSizeInPixels * y - 1, tileSizeInPixels + 2, tileSizeInPixels + 2);
                    graphics.DrawRectangle(Pens.Black, tileSizeInPixels * x + 1, tileSizeInPixels * y + 1, tileSizeInPixels - 2, tileSizeInPixels - 2);
                }
            }
        }
    }

    private Point GetPositionForMapSquareInfo(Graphics g)
    {
        var stringSize = g.MeasureString("(00,00)=000", _font);

        if (!_lastMouseLocation.HasValue) {return new Point(0, 0); }

        var centerInPixels = tileSizeInPixels * MapSideLength / 2;
        var deltaX = centerInPixels - _lastMouseLocation.Value.X;
        var deltaY = centerInPixels - _lastMouseLocation.Value.Y;
        var xPos = Math.Sign(deltaX) * tileSizeInPixels*3;
        var yPos = Math.Sign(deltaY) * tileSizeInPixels;
        Point center = new Point(_lastMouseLocation.Value.X + (int)xPos, _lastMouseLocation.Value.Y + (int)yPos);
        center -= new Size((int)stringSize.Width/2, (int)stringSize.Height/2);
        Debug.WriteLine($"lastMousePos: {_lastMouseLocation.Value}, x:{xPos}, y:{yPos} = center:{center}");
        return center;
    }
}