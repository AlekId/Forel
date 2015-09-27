using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forel
{
    public class ForelManager
    {
         public List<Point> points = new List<Point>();
        public List<List<Point>> result = new List<List<Point>>();
        public List<Point> centers = new List<Point>();
        public double R = 1.65;

        public void GetData()
        {
            String input = File.ReadAllText("inputFile.txt");
            int i = 0;
            int j = 0;
            double[,] resultArray = new double[17, 2];
            foreach (string row in input.Split('\n'))
            {
                j = 0;

                foreach (string col in row.Trim().Split(','))
                {
                    resultArray[i, j] = Double.Parse(col, CultureInfo.InvariantCulture);
                    j++;
                }
                i++;
            }

            for (int k = 0; k < resultArray.GetLength(0); k++)
            {
                for (int l = 0; l < resultArray.GetLength(1); l++)
                {
                    points.Add(new Point(resultArray[k, l], resultArray[k, l + 1]));
                    break;
                }
            }
        }

        public void Cluster()
        {
            
            while (points.Count > 0)
            {
                
                Random rnd = new Random();
                var index = rnd.Next(0, points.Count);
                Point center = points[index];
                Point newCenter = center;
                //inside points 
                List<Point> lst = new List<Point>();
                while (center == newCenter)
                {
                    foreach (var p in points)
                    {
                        if (Math.Sqrt(Math.Pow((p.X - center.X), 2) + Math.Pow((p.Y - center.Y), 2)) < R)
                        {
                            lst.Add(p);
                        }
                    }
                    //power center
                    double powerX = 0;
                    double powerY = 0;
                    foreach (var p in lst)
                    {
                        powerX += p.X;
                        powerY += p.Y;
                    }
                    double powerCenterX = powerX/lst.Count;
                    double powerCenterY = powerY/lst.Count;
                    newCenter = new Point(powerCenterX, powerCenterY);
                }
                result.Add(lst);
                centers.Add(newCenter);
                foreach (var p in lst)
                {
                    points.Remove(p);
                }
            }
        }
    }
}
