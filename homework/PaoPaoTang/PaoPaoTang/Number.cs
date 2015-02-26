using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Bomb
{
    public class Number
    {
        private Vector2 _pos;
        private Texture2D _numTexture;
        private int _width;
        private int _height;
        private int _number;
        public Number(GraphicsDevice device,string fileName,Vector2 pos,int width,int height)
        {
            _numTexture = Texture2D.FromFile(device, fileName);
            _width = width;
            _height = height;
            _pos = pos;
        }
        public int number
        {
            set
            {
                _number = value;
            }
            get
            {
                return _number;
            }
        }
        public void Draw()
        {
            Rectangle rect;
            Vector2 pos;
            pos=_pos;
            rect = new Rectangle(0, 0, _width, _height);

            int n = _number;
            do
            {
                rect.X = (n % 10) * _width;
                MyHelp.foreSpriteBatch.Draw(_numTexture, pos, rect, Color.White);
                pos.X -= _width;
                n /= 10;
            }
            while (n != 0);
            
        }
    }
}
