using System;
using System.Collections.Generic;

namespace Problems
{
    //Incomplete 
    public class MaxVisiblePointsProblem
    {
        public int VisiblePoints(IList<IList<int>> points, int angle, IList<int> location) {
            if(points == null || points.Count == 0 || location == null || location.Count != 2)
            {
                return 0;
            }
            int maxVisible = 0;
            foreach(IList<int> point in points)
            {
                int transX = point[0] - location[0];
                int transY = point[1] - location[1];
                
                double pointAngle = Math.Atan2((double) transY, (double)transX)  * 180 / Math.PI;
                int visible = 0;
                foreach(IList<int> p in points)
                {
                    int tx = p[0] - location[0];
                    int ty = p[1] - location[1];

                    if(IsVisible(tx, ty, pointAngle, pointAngle+angle))
                    {
                        visible++;
                    }
                }
                maxVisible = Math.Max(maxVisible, visible);
            }

            
            return maxVisible;
        }
        private bool IsVisible(int transX, int transY, double angleFrom, double angreTo)
        {

            double angle = Math.Atan2((double) transY, (double)transX) * 180 / Math.PI;
            return angle >= angleFrom && angle <= angreTo;
        }
        // [[1,1],[2,2],[3,3],[4,4],[1,2],[2,1]]
        // 0
        // [1,1] => 4
        // public static void Main(string[] args)
        // {
        //     var points = new List<IList<int>>()
        //     {
        //         new List<int>{0,1},
        //         new List<int>{2,1},
        //     };
        //     int angle = 13;
        //     var location = new List<int>(){1,1};
        //     var result = new MaxVisiblePointsProblem().VisiblePoints(points, angle, location);
        //     Console.WriteLine($"{result}");
        // }


    }
}