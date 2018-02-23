using System.Text;
using System.Text.RegularExpressions;

namespace PeopleNet
{
    public class MazeCalculator
    {
        private string _map;
        private int _maxRow;
        private int _maxColumn;
        private char[,] _maze;
        private bool[,] _hasVisited;

        public MazeCalculator(string value)
        {
            _map = Regex.Replace(value, @"\s+", ",");
            _maxRow = _map.Split(',').Length;
            _maxColumn = _map.Split(',')[0].Length;
            _maze = new char[_maxRow, _maxColumn];
            _hasVisited = new bool[_maxRow, _maxColumn];
        }
       
        public string RetriveRoute()
        {
            int row = 0; int column = 0;
            int rowPosition = 0; int columnPosition = 0;
            char[] mapArray = _map.ToCharArray();
            foreach (var c in mapArray)
            {
                if (c.ToString() == "A"){
                    rowPosition = row;
                    columnPosition = column;
                }

                if (c.ToString() == ","){
                    column = 0;
                    row++;
                }
                else{
                    _maze[row, column] = c;
                    column++;
                }
            }
            
            SolveMaze(rowPosition, columnPosition);
            return GetMapRoute();
        }

        private string GetMapRoute()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int x = 0; x < _maxRow; x++)
            {
                for (int y = 0; y < _maxColumn; y++)
                {
                    stringBuilder.Append(_maze[x, y]);
                }
                
                if (x != _maxRow - 1)
                {
                    stringBuilder.AppendLine();
                }
            }

            return stringBuilder.ToString();
        }

        private bool SolveMaze(int rowPosition, int columnPosition)
        {
            bool correctRoute = false;
            bool shouldContinue = true;
            if (rowPosition >= _maxRow || rowPosition < 0 || columnPosition >= _maxColumn || columnPosition < 0)
            {
                shouldContinue = false;
            }
            else
            {
                if (_maze[rowPosition, columnPosition] == 'B')
                {
                    correctRoute = true;
                    shouldContinue = false;
                }

                if (_maze[rowPosition, columnPosition] == '#')
                {
                    shouldContinue = false;
                }

                if (_hasVisited[rowPosition, columnPosition])
                {
                    shouldContinue = false;
                }
            }
            
            if (shouldContinue)
            {
                _hasVisited[rowPosition, columnPosition] = true;
                correctRoute = correctRoute || SolveMaze(rowPosition + 1, columnPosition);
                correctRoute = correctRoute || SolveMaze(rowPosition, columnPosition + 1);
                correctRoute = correctRoute || SolveMaze(rowPosition - 1, columnPosition);
                correctRoute = correctRoute || SolveMaze(rowPosition, columnPosition - 1);
            }

            if (correctRoute && _maze[rowPosition, columnPosition] != 'A' && _maze[rowPosition, columnPosition] != 'B')
            {
                _maze[rowPosition, columnPosition] = '@';
            }
            
            return correctRoute;
        }
    }
}