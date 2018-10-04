using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SuperSaiyanBros
{
    public class Animation
    {
        public bool Continuous;
        public double Index;
        public double Speed;
        protected List<Image> frames = new List<Image>();
        protected int width, height;
        public int Width
        {
            get
            {
                // insert McKenzie's code when he's done
                return width;
            }
        }

        public int Height
        {
            get
            {
                // insert McKenzie's code when he's done
                return height;
            }
        }

        public Image Frame
        {
            get
            {
                Index += Speed;
                if (Index >= frames.Count)
                {
                    if (Continuous)
                    {
                        Index = 0;// if beyond last frame, then reset to 1st frame...
                    }
                    else
                    {
                        Index = frames.Count - 1;// give picasso the last frame (again)
                    }
                }
                return frames[(int)Index];
            }
        }

        public Animation(Image spriteMap, int width, int height, int xStart, int yStart, int rows, int cols, double scale, double speed, bool continuous)
        {
            Continuous = continuous;
            this.width = (int)(scale * width);
            this.height = (int)(scale * height);
            Index = 0;
            Speed = speed;// how fast to run the animation
            Bitmap orig = new Bitmap(spriteMap, (int)(scale * spriteMap.Width), (int)(scale * spriteMap.Height));
            for (int y = yStart; y < yStart + rows * Height; y += Height)
            {
                for (int x = xStart; x < xStart + cols * Width; x += Width)
                {
                    Rectangle rect = new Rectangle(x, y, Width, Height);
                    Image frame = orig.Clone(rect, spriteMap.PixelFormat);
                    frames.Add(frame);
                }
            }
        }

    }
}
