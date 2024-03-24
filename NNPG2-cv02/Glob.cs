using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNPG2
{
    static class Glob
    {
        public static int ScrMinX = 0;
        public static int ScrMaxX = 300;
        public static int ScrMinY = 0;
        public static int ScrMaxY = 150;
        public static double WorldMinX = 0;
        public static double WorldMaxX = 300;
        public static double WorldMinY = 0;
        public static double WorldMaxY = 150;

        public static int RToP_Y(double R)
        {
            return (int)Math.Round(ScrMinY + (WorldMaxY - R) * (ScrMaxY - ScrMinY) / Math.Abs(WorldMaxY - WorldMinY));
        }

        public static int RToP_X(double R)
        {
            return (int)Math.Round(ScrMinX + (R - WorldMinX) * (ScrMaxX - ScrMinX) / Math.Abs(WorldMaxX - WorldMinX));
        }
    }
}
