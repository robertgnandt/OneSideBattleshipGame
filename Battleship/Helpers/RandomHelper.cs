using System;

namespace Battleship.App.Helpers
{
    public class RandomHelper
    {
        private static readonly Random R = new Random();

        public static int GetShipCoordinate(int maxCoordinate)
        {
            return R.Next(1, maxCoordinate + 1);
        }

        public static bool IsHorizontalPlane()
        {
            return Convert.ToBoolean(R.Next(0,2));
        }
    }
}