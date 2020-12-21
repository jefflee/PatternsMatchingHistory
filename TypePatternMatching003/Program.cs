using System;
using System.Collections.Generic;

namespace TypePatternMatching003
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var shapes = new List<object>
            {
                { 0, 9, "rectangle1" },
                { 10, 11, "rectangle2" },
                { 3, 3, "rectangle3" },
                { 10, 10, "rectangle4"},
                new Circle () { Radius = 4, Name = "Circle"},
                new Line (),
                new object(),
                null,
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(Display(shape));
            }

            Console.ReadLine();
        }

        private static string Display<T>(T shape) where T : class
        {
            switch (shape)
            {
                case null:
                    return "Do not put null";
                case Rectangle r when r.Width <= 0 || r.Height <= 0:
                    return "Width or Height is not valid";
                case Rectangle r when r.Width * r.Height < 10:
                    return "small rectangle";
                case Rectangle r when r.Width * r.Height > 100:
                    return "big rectangle";
                case Rectangle _:
                    return "medium rectangle";
                default:
                    return "not rectangle";
            }
        }
    }

    /// <summary>
    /// 純粹為了偷懶
    /// </summary>
    internal static class ShapeExtensions
    {
        public static void Add(this ICollection<object> shapes, double width, double height, string name)
        {
            shapes.Add(new Rectangle { Width = width, Height = height, Name = name });
        }
    }

    internal interface IShape
    {
        string Name { get; set; }
    }

    internal class Rectangle : IShape
    {
        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

    }

    internal class Circle : IShape
    {
        public string Name { get; set; }

        public double Radius { get; set; }
    }

    internal class Line : IShape
    {
        public string Name { get; set; }

        public double Length { get; set; }
    }
}
