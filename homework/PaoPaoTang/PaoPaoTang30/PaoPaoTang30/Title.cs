
#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace PaoPaoTang30
{
    public class Title
    {
        GraphicsDeviceManager graphics;
        ContentManager content;

        public SpriteFont sf;

        public SpriteBatch _sb;
        public Texture2D _sprite;

        public Title(GraphicsDeviceManager gdm, ContentManager cm)
        {
            graphics = gdm;
            content = cm;
        }

        public void Show()
        {
            _sb.Begin();
            _sb.Draw(_sprite, new Vector2(0.0f, 0.0f), Color.White);
            _sb.DrawString(sf, "Software School\r\nXi'an Jiaotong Univ.", new Vector2(0.0f, 360.0f), Color.White);
            _sb.End();
        }
























    }
}