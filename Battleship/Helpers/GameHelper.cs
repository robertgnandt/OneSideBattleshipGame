using System.Configuration;

namespace Battleship.App.Helpers
{
    public class GameHelper
    {
        public const int FirstLetterAscii = 65;

        private const int DefaultGridDimension = 10;

        public static int GetGridDimension()
        {
            var gridDimension = ConfigurationManager.AppSettings["GridDimension"];

            return int.TryParse(gridDimension, out var greedSize) ? greedSize : DefaultGridDimension;
        }
    }
}
