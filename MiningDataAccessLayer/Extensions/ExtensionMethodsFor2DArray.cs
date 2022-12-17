using System;
using System.Collections.Generic;
using System.Drawing;

namespace MiningDataAccessLayer.Extensions
{
    public static class ExtensionMethodsFor2DArray
    {

        static Random _rnd = new Random();

        public static void SetAllToValue<T>(this T[,] array2D, T value)
        {
            foreach (var position in array2D.GetAllPositions())
            {
                array2D[position.X, position.Y] = value;
            }
        }

        public static void Clear<T>(this T[,] array2D)
        {
            SetAllToValue<T>(array2D, default(T));
        }


        public static T ContentsOfCell<T>(this T[,] array2D, Point positionOfCell)
        {
            return array2D[positionOfCell.X, positionOfCell.Y];
        }

        /// <summary>
        /// Gets the coordinates of all the existing neigbors of a given tile
        /// </summary>
        /// <typeparam name="T">The type of The two-dimensional array contents</typeparam>
        /// <param name="array2D">The two-dimensional array to work on</param>
        /// <param name="x">The x-coordinate of the cell to get neigbors for</param>
        /// <param name="y">The y-coordinate of the cell to get neighbors for</param>
        /// <param name="distance">how far above/below and to the sides to get neighbors for - default is 1</param>
        /// <param name="onlyXYaxis">Whether to only get neighbors directly on the same row/column - default is false (get a square of tiles (9), not a cross (5))</param>

        /// <returns>An enumeration of the neigbors' coordinates</returns>
        public static IEnumerable<Point> GetNeighborCoordinates<T>(this T[,] array2D, int x, int y, bool onlyXYaxis = false, int distance = 1)
        {
            //for the column on the left to the column on the right of the tile
            for (int deltaX = -distance; deltaX <= distance; deltaX++)
            {

                //for the row above to the row below the tile
                for (int deltaY = -distance; deltaY <= distance; deltaY++)
                {
                    //if we are only looking at the cells directly above/below and beside the cell
                    //we skip diagonal neighbors
                    if (onlyXYaxis && deltaY * deltaX != 0) { continue; }

                    //the potential neighbor's coordinates
                    int neighborX = x + deltaX;
                    int neighborY = y + deltaY;

                    //if the coordinate is within the map
                    if (array2D.ContainsCoordinate(neighborX, neighborY))
                    {
                        //and we aren't looking at the tile itself
                        if (!(x == neighborX && y == neighborY))
                        {
                            yield return new Point(neighborX, neighborY);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the contents of the neighboring positions in the array
        /// </summary>
        /// <typeparam name="T">The type of The two-dimensional array</typeparam>
        /// <param name="array2D">The two-dimensional array to work on</param>
        /// <param name="x">The x-coordinate of the cell to get neigbors for</param>
        /// <param name="y">The y-coordinate of the cell to get neighbors for</param>
        /// <param name="distance">how far above/below and to the sides to get neighbors for - default is 1</param>
        /// <param name="onlyXYaxis">Whether to only get neighbors directly on the same row/column - default is false (get a square of tiles, not a cross)</param>
        /// <returns>An enumeration of the neighbors' contents</returns>
        public static IEnumerable<T> GetNeighborsContents<T>(this T[,] array2D, int x, int y, bool onlyXYaxis = false, int distance = 1 )
        {
            foreach (var position in array2D.GetNeighborCoordinates(x, y, onlyXYaxis, distance))
            {
                yield return array2D[position.X, position.Y];
            }
        }


        public static IEnumerable<T> GetNeighborsContents<T>(this T[,] array2D, Point position, bool onlyXYaxis = false, int distance = 1)
        {
            return GetNeighborsContents(array2D, position.X, position.Y, onlyXYaxis, distance);
        }


        /// <summary>
        /// Determines whether a given coordinate set (given by a Point) is within a array2D
        /// </summary>
        /// <typeparam name="T">The type of The two-dimensional array</typeparam>
        /// <param name="array2D">The two-dimensional array to work on</param>
        /// <param name="coordinates">The coordinates of the cell to check for</param>
        /// <returns>Whether the coordinates are within the double array</returns>
        public static bool ContainsCoordinate<T>(this T[,] array2D, Point coordinates)
        {
            return array2D.ContainsCoordinate(coordinates.X, coordinates.Y);
        }


        /// <summary>
        /// Determines whether a given coordinate is within a array2D
        /// </summary>
        /// <typeparam name="T">The type of The two-dimensional array</typeparam>
        /// <param name="array2D">The two-dimensional array to work on</param>
        /// <param name="x">The x-coordinate of the cell to check for</param>
        /// <param name="y">The y-coordinate of the cell to check for</param>
        /// <returns>Whether the coordinate is within the double array</returns>
        public static bool ContainsCoordinate<T>(this T[,] array2D, int x, int y)
        {
            return x >= 0 && x < array2D.GetLength(0) && y >= 0 && y < array2D.GetLength(1);
        }


        /// <summary>
        /// Gets the positions of the bordercells in The two-dimensional array
        /// </summary>
        /// <typeparam name="T">The type of The two-dimensional array</typeparam>
        /// <param name="array2D">The two-dimensional array to work on</param>
        /// <param name="borderWidth">How many cells in from the border to use (default 1)</param>
        /// <returns>An enumeration of the positions of the bordercells in The two-dimensional array</returns>
        public static IEnumerable<Point> GetBorderCellPositions<T>(this T[,] array2D, int borderWidth = 1)
        {
            int width = array2D.GetLength(0);
            int height = array2D.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x < borderWidth || y < borderWidth || x > width - borderWidth - 1 || y > height - borderWidth - 1)
                    {
                        yield return new Point(x, y);
                    }
                }
            }
        }

        /// <summary>
        /// Gets all the elements around the border, to a specified thickness
        /// </summary>
        /// <typeparam name="T">The type of the contents of The two-dimensional array</typeparam>
        /// <param name="array2D">The two-dimensional array to work on</param>
        /// <param name="borderWidth">How "thick" the border should be in tiles. "1" would only be the outher border, "2" would be the outer border and one layer inside, etc.</param>
        /// <returns>Yields all elements in The two-dimensional array, one by one</returns>
        public static IEnumerable<T> GetBorderElements<T>(this T[,] array2D, int borderWidth = 1)
        {
            foreach (var cellPos in GetBorderCellPositions(array2D, borderWidth))
            {
                yield return array2D[cellPos.X, cellPos.Y];
            }
        }


        /// <summary>
        /// Gets the coordinate of a random cell in The two-dimensional array
        /// </summary>
        /// <typeparam name="T">The type of the contents of The two-dimensional array</typeparam>
        /// <param name="array2D">The two-dimensional array to work on</param>
        /// <returns>The coordinates of a random cell within The two-dimensional array</returns>
        public static Point GetRandomCellPosition<T>(this T[,] array2D)
        {
            return new Point(_rnd.Next(array2D.GetLength(0)), _rnd.Next(array2D.GetLength(1)));
        }


        /// <summary>
        /// Gets the coordinates of all cells in The two-dimensional array
        /// </summary>
        /// <typeparam name="T">The type of the contents of The two-dimensional array</typeparam>
        /// <param name="array2D">The two-dimensional array to work on</param>
        /// <returns>The coordinates of a random cell within The two-dimensional array</returns>
        public static IEnumerable<Point> GetAllPositions<T>(this T[,] array2D)
        {
            int width = array2D.GetLength(0);
            int height = array2D.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    yield return new Point(x, y);
                }
            }
        }

        /// <summary>
        /// Returns all the elements in The two-dimensional array which fulfill the criteria in the predicate
        /// </summary>
        /// <typeparam name="T">The type of the contents of The two-dimensional array</typeparam>
        /// <param name="array2D">The two-dimensional array to work on</param>
        /// <param name="predicate">The predicate the items must fulfill (filterexpression)</param>
        /// <returns>Yields all elements in The two-dimensional array which fulfill the predicate, one by one</returns>
        public static IEnumerable<T> Where<T>(this T[,] array2D, Func<T, bool> predicate)
        {
            foreach (var item in array2D)
            {
                if (predicate(item)) { yield return item; }
            }
        }

        /// <summary>
        /// Iterates over all elements in The two-dimensional array
        /// </summary>
        /// <typeparam name="T">The type of the contents of The two-dimensional array</typeparam>
        /// <param name="array2D">The two-dimensional array to work on</param>
        /// <returns>Yields all elements in The two-dimensional array, one by one</returns>
        public static IEnumerable<T> GetAll<T>(this T[,] array2D)
        {
            foreach (var item in array2D)
            {
                yield return item;
            }
        }


        /// <summary>
        /// This method fills from a tile and out based on criteria in the Func parameter.
        /// </summary>
        /// <typeparam name="T">The type of The two-dimensional array to work on</typeparam>
        /// <param name="array2D">The two-dimensional array to work on</param>
        /// <param name="startingPosition">Where this round of fills should start from</param>
        /// <param name="checkAndChangeTile">The function which is passed the tile
        /// and can change the tile any which way it want to (e.g. set it to 'filled') 
        /// and returns whether to let the flooding continue on from this tile</param>
        /// <param name="canMoveDiagonally">Whether to try moving diagonally (default is false)</param>
        /// <param name="iterations">How many iterations to perform (default is int.MaxValue)</param>
        public static void FloodFill<T>(this T[,] array2D, Point startingPosition, Func<T[,], Point, bool> checkAndChangeTile, bool canMoveDiagonally = false, int iterations = int.MaxValue)
        {
            if (checkAndChangeTile(array2D, startingPosition))
            {
                foreach (var neighbor in array2D.GetNeighborCoordinates<T>(startingPosition.X, startingPosition.Y, !canMoveDiagonally, 1))
                {
                    array2D.FloodFill(neighbor, checkAndChangeTile, canMoveDiagonally, iterations);
                }
            }
        }


        //sample implementation of the checkAndChangeTile
        private static bool F<T>(T[,] array, Point p)
        {
            if (!array[p.X, p.Y].Equals(default(T)))
            {
                array[p.X, p.Y] = default(T);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Defines how to manipulate an array
        /// </summary>
        public enum ArrayManipulation
        {
            /// <summary>
            /// Moves all values around the array clockwise
            /// </summary>
            RotateClockwise,

            /// <summary>
            /// Moves all values around the array counterclockwise
            /// </summary>
            RotateCounterClockwise,

            /// <summary>
            /// Swaps all values from the top to bottom and vice-versa
            /// </summary>
            FlipTopToBottom,

            /// <summary>
            /// Swaps all values from left to right and vice-versa
            /// </summary>
            FlipRightToLeft
        }

        /// <summary>
        /// Implements easy array2D manipulations
        /// </summary>
        /// <typeparam name="T">The type of the values in the array</typeparam>
        /// <param name="matrix">The two-dimensional array</param>
        /// <param name="manipulation">How to manipulate the array</param>
        /// <returns>A copy of the array with the values as ordered</returns>
        public static T[,] GetManipulatedCopy<T>(this T[,] matrix, ArrayManipulation manipulation)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            T[,] ret = null;
            switch (manipulation)
            {
                //if we are rotating the matrix,
                //we need to swap width and height sizes
                case ArrayManipulation.RotateClockwise:
                case ArrayManipulation.RotateCounterClockwise:
                    ret = new T[height, width];
                    break;

                //otherwise we create an array with the same size
                case ArrayManipulation.FlipTopToBottom:
                case ArrayManipulation.FlipRightToLeft:
                    ret = new T[width, height];
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid manipulation : " + manipulation);
            }

            //for all values in the source matrix...
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    //copy the values to the new array
                    //choosing position depending on the wanted manipulation
                    switch (manipulation)
                    {
                        case ArrayManipulation.RotateCounterClockwise:
                            ret[y, width - x - 1] = matrix[x, y];
                            break;
                        case ArrayManipulation.RotateClockwise:
                            ret[height - y - 1, x] = matrix[x, y];
                            break;
                        case ArrayManipulation.FlipTopToBottom:
                            ret[x, height - 1 - y] = matrix[x, y];
                            break;
                        case ArrayManipulation.FlipRightToLeft:
                            ret[width - 1 - x, y] = matrix[x, y];
                            break;
                    }
                }
            }

            //return the new array
            return ret;
        }

        public static IEnumerable<Point> GetCellPositionsInRow<T>(this T[,] array2D, int row)
        {
            for (int x = 0; x < array2D.GetLength(1); x++)
            {
                yield return new Point(x, row);
            }
        }

        public static IEnumerable<T> GetContentsOfRow<T>(this T[,] array2D, int row)
        {
            foreach (var position in GetCellPositionsInRow(array2D, row))
            {
                yield return array2D[position.X, position.Y];
            }
        }

        public static IEnumerable<Point> GetCellPositionsInColumn<T>(this T[,] array2D, int column)
        {
            for (int y = 0; y < array2D.GetLength(0); y++)
            {
                yield return new Point(column, y);
            }
        }

        public static IEnumerable<T> GetContentsOfColumn<T>(this T[,] array2D, int column)
        {
            foreach (var position in GetCellPositionsInColumn(array2D, column))
            {
                yield return array2D[position.X, position.Y];
            }
        }
    }
}