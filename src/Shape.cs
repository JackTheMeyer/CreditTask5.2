using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.IO;

namespace MyGame
{
    public abstract class Shape
    {
        private Color _color;
        private float _x, _y;
        bool _selected;

        public Shape()
        {
            _color = Color.Green;
            _x = 0;
            _y = 0;
            _selected = false;
        }

        public Shape(Color clr)
        {
            _color = clr;
            _x = 0;
            _y = 0;
            _selected = false;
        }

        public Shape(float x, float y)
        {
            _color = Color.Green;
            _x = x;
            _y = y;
            _selected = false;
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        public float PosX
        {
            set
            {
                _x = value;
            }
            get
            {
                return _x;
            }
        }
        public float PosY
        {
            set
            {
                _y = value;
            }
            get
            {
                return _y;
            }
        }

        public virtual void SaveTo(StreamWriter writer)
        {
            
            writer.WriteLine(_color.ToArgb());
            writer.WriteLine(PosX);
            writer.WriteLine(PosY);
            

        }

        public virtual void LoadFrom(StreamReader reader)
        {
            _color = Color.FromArgb(reader.ReadInteger());
            PosX = reader.ReadInteger();
            PosY = reader.ReadInteger();
        }
        public abstract void Draw();

        public abstract void DrawOutline();

        public abstract bool IsAt(Point2D pt);
    }
}
