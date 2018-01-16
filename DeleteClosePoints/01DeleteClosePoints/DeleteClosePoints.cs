namespace DeleteClosePoints
{
    using System;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = File.ReadAllLines("input.txt");

            File.Delete("output.txt");

            double[] distanceHeight = input[0]
            .Trim()
            .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions
            .RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

            string previous = input[1];

            for (int i = 2; i < input.Length; i++)
            {
                double[] previousPointArgs = previous
            .Trim()
            .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions
            .RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

                if (i == 2)
                {
                    File.AppendAllText("output.txt", string.Join($"\t", previousPointArgs) + Environment.NewLine);
                    continue;
                }

                Point previousPoint = new Point();
                previousPoint.X = previousPointArgs[0];
                previousPoint.Y = previousPointArgs[1];
                previousPoint.Z = previousPointArgs[2];

                double[] currentPointArgs = input[i]
            .Trim()
            .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions
            .RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

                if (i == input.Length - 1)
                {
                    File.AppendAllText("output.txt", string.Join($"\t", currentPointArgs) + Environment.NewLine);
                    break;
                }

                Point currentPoint = new Point();
                currentPoint.X = currentPointArgs[0];
                currentPoint.Y = currentPointArgs[1];
                currentPoint.Z = currentPointArgs[2];

                double distance = Math.Sqrt(Math.Pow(currentPoint.X - previousPoint.X, 2)
                    + Math.Pow(currentPoint.Y - previousPoint.Y, 2)
                    + Math.Pow(currentPoint.Z - previousPoint.Z, 2));

                if (distance > distanceHeight[0]
                    || Math.Abs(currentPoint.Z - previousPoint.Z) > distanceHeight[1])
                {
                    File.AppendAllText("output.txt", string.Join($"\t", currentPointArgs) + Environment.NewLine);
                    previous = input[i];
                }
            }
        }
    }

    internal class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}