using System;
namespace ApsNetWebApp.Parser
{
    public sealed class Parser
    {
        private static Parser instance = null;
        private static string text = null;
        private Dimensions shape;
        private Parser()
        {
        }

        public static Parser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Parser();
                }

                return instance;
            }
        }

        public void SetInput(string input)
        {
            text = input;
            ParseInput();
        }

        public Dimensions GetShape()
        {
            return shape;
        }

        private void ParseInput()
        {
            if (String.IsNullOrEmpty(text))
                throw new InvalidOperationException("Input text is invalid");

            string[] splitted = text.Split();
            ValidateInput(splitted);
            shape = new Dimensions();
            int index = FillShapeAndDimension(splitted, ref shape);
            
            
        }

        private void ValidateInput(string[] input)
        {
            if (input == null || input.Length < 8)
                throw new InvalidOperationException("Input text is invalid input");
            if (!input[0].ToLower().Equals("draw") || !input[1].ToLower().Equals("a") || input[1].ToLower().Equals("an"))
                throw new InvalidOperationException("Input text is invalid input");
        }

        /// <summary>
        /// This function fills in Shape and returns the index of next to shape in input string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        private int FillShapeAndDimension(string[] input, ref Dimensions shape)
        {
            // This assumes that input string is validated
            string shp = input[2].ToLower();
            int index = 3;
            switch(shp)
            {
                case "square":
                    shape.shape = Shape.SQUARE;
                    shape.dim1 = shape.dim2 = int.Parse(input[input.Length - 1]);
                    break;
                case "rectangle":
                    shape.shape = Shape.RECTANGLE;
                    shape.dim1 = int.Parse(input[input.Length - 1]);
                    shape.dim2 = int.Parse(input[7]);
                    break;
                case "circle":
                    shape.shape = Shape.CIRCLE;
                    shape.dim1 = shape.dim2 = int.Parse(input[input.Length - 1]);
                    break;
                case "equilateral":
                    shape.shape = Shape.EQUITRANGLE;
                    shape.dim1 = shape.dim2 = int.Parse(input[input.Length - 1]);
                    break;
                case "isosceles":
                    shape.shape = Shape.ISOTRIANGLE;
                    shape.dim2 = int.Parse(input[input.Length - 1]); //width
                    shape.dim1 = int.Parse(input[8]); // height
                    break;
                case "oval":
                    shape.shape = Shape.OVAL;
                    shape.dim2 = int.Parse(input[input.Length - 1]);
                    shape.dim1 = int.Parse(input[7]);
                    break;
                default:
                    throw new NotSupportedException(String.Format("Shape {0} is not supported", shp));
            }

            return index;
        }
    }
}
