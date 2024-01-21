using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_9_Collections_
{
    public class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Image(int id, string fileName, int width, int height)
        {
            Id = id;
            FileName = fileName;
            Width = width;
            Height = height;
        }

        public void Resize(int newWidth, int newHeight)
        {
            Width = newWidth;
            Height = newHeight;
        }
        public void RotateClockwise()
        {
            Console.WriteLine("Изображение повёрнуто по часовой стрелке");
        }

        public void RotateCounterClockwise()
        {
            Console.WriteLine("Изображение повёрнуто против часовой стрелке");
        }

        public override string ToString()
        {
            return $"Image ID: {Id}, File Name: {FileName}, Width: {Width}, Height: {Height}";
        }
    }
}
