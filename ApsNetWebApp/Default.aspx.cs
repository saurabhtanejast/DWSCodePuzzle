using System;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ApsNetWebApp
{

    public partial class Default : System.Web.UI.Page
    {
        private static string userInputText;
        private Parser.Parser parser = Parser.Parser.Instance;
        private readonly string imagePath = "./DrawRectangle.jpg";
        public void button1Clicked(object sender, EventArgs args)
        {
            userInputText = inputBox.Text;
            parser.SetInput(userInputText);
            Parser.Dimensions shape = parser.GetShape();
            DrawShape(shape, args);
        }

        private void DrawShape(Parser.Dimensions shape, EventArgs args)
        {            
            Bitmap bmp = new Bitmap(shape.dim1, shape.dim2, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmp);

            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 3);
            switch (shape.shape)
            {
                case Parser.Shape.CIRCLE:
                    g.DrawEllipse(pen, 0, 0, shape.dim1, shape.dim2);
                    break;
                case Parser.Shape.SQUARE:
                    g.DrawRectangle(pen, 0, 0, shape.dim1, shape.dim1);
                    break;
                case Parser.Shape.RECTANGLE:
                    g.DrawRectangle(pen, 0, 0, shape.dim1, shape.dim2);
                    break;
                case Parser.Shape.OVAL:
                    g.DrawEllipse(pen, 0, 0, shape.dim1, shape.dim2);
                    break;
                case Parser.Shape.EQUITRANGLE:
                case Parser.Shape.ISOTRIANGLE:
                    g.DrawPolygon(pen, TrianglePoints(shape));
                    break;
                default:
                    throw new InvalidOperationException();
            }

            String path = Server.MapPath(imagePath);
            bmp.Save(path, ImageFormat.Jpeg);
            Image1.ImageUrl = imagePath;
            g.Dispose();
            bmp.Dispose();
        }

        // This can be refactored into an interface and shapes.
        private Point[] TrianglePoints(Parser.Dimensions shape)
        {
            Point[] points = new Point[3];
            points[0] = new Point(0, 0);

            switch(shape.shape)
            {
                case Parser.Shape.EQUITRANGLE:
                    points[1] = new Point(shape.dim1, 0);
                    var half = shape.dim1 / 2;
                    var full = shape.dim1;
                    points[2] = new Point(half, (int)Math.Sqrt(full * full - half * half));
                    break;
                case Parser.Shape.ISOTRIANGLE:
                    points[1] = new Point(shape.dim1, 0);
                    points[2] = new Point(shape.dim1 / 2, shape.dim2);
                    break;
                default:

                    break;
            }

            return points;
        }

    }
}
