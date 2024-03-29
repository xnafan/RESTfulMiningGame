﻿namespace ServiceClientClassLibrary.Model;
public class MapSquareDto
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Value { get; set; }

    public override string ToString()
    {
        return $"({X},{Y})={Value}";
    }
}