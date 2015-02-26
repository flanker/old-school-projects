using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Bomb
{
    public class Article
    {

        private Vector2 _pos;
        private byte _Frame;
        private byte _delay;
        private byte _ID;
        private bool Active;
        private Rectangle _rect;
        public byte hasDraw;

        public Article()
        {
            _Frame = 0;
            _delay = 0;
            Active = false;
            _rect = new Rectangle(0, 0, 50, 50);
        }

        public bool active
        {
            get
            {
                return Active;
            }
            set
            {
                Active = value;
            }
        }
        public int postion
        {
            get
            {
                return MyHelp.Vector2ToPos(_pos);
            }
        }
        public void Create(byte ID, byte pos)
        {
            _ID = ID;
            Active = true;
            _Frame = 0;
            _delay = 0;
            hasDraw = 0;

            _pos.X = MyHelp.StartPos.X + (pos % MyHelp.WIDTH) * 40;
            _pos.Y = MyHelp.StartPos.Y + (pos / MyHelp.WIDTH) * 40;
            OurGame.map[pos].canMove |= 0x10;
        }
        public int Y
        {
            get
            {
                return (int)_pos.Y;
            }
        }
        public int X
        {
            get
            {
                return (int)_pos.X;
            }
        }
        public void updata()
        {
            if (_delay == 0)
            {
                _delay = 2;
                if (_ID > 3)
                {
                    ++_Frame;
                    if (_Frame >= 8)
                        _Frame = 0;
                    _rect.X = _Frame * 50;
                    _rect.Y = _ID * 50;
                }
                else
                {
                    _delay = 5;
                    ++_Frame;
                    if ((_Frame & 1) != 0)
                        _rect.Y = _ID * 50 + 2;
                    else
                        _rect.Y = _ID * 50;
                    _rect.X = 0;

                }

            }
            else
                --_delay;
            check();
        }
        private void check()
        {
            if (MyHelp.checkHit(OurGame.Master.pos, _pos, 5))
            {
                switch (_ID)
                {
                    case 0:     //增加雷数
                        OurGame.Master.maxLei = MyHelp.Min(OurGame.Master.maxLei + 1, 3);
                        break;
                    case 1:     //增加长度
                        OurGame.Master.leiLen = MyHelp.Min(OurGame.Master.leiLen + 1, 3);
                        break;
                    case 2:     //数度为4
                        if (OurGame.Master.speed == 2)
                            OurGame.Master.speed = 4;
                        break;
                    case 3:     //加龟
                        if (OurGame.Master.speed == 2 || OurGame.Master.speed == 4)
                        {
                            if (MyHelp.Random(20) <= 10)
                            {
                                OurGame.Master.speed = 5;
                                OurGame.Master.Active = 0x11;
                            }
                            else
                            {
                                OurGame.Master.speed = 1;
                                OurGame.Master.Active = 0x10;
                            }
                        }
                        break;
                    case 4:     //加分4
                        break;
                    case 5:     //加分1
                        break;
                    case 6:     //加分2
                        break;
                }
                Active = false;
                return;
            }
            for (int i = 0; i < MyHelp.maxEnemy; ++i)
            {
                if (MyHelp.checkHit(OurGame.Enemy[i].pos, _pos, 5))
                {
                    switch (_ID)
                    {
                        case 0:     //增加雷数
                            OurGame.Enemy[i].maxLei = MyHelp.Min(OurGame.Enemy[i].maxLei + 1, 3);
                            break;
                        case 1:     //增加长度
                            OurGame.Enemy[i].leiLen = MyHelp.Min(OurGame.Enemy[i].leiLen + 1, 3);
                            break;
                        case 2:     //数度为4
                            if (OurGame.Enemy[i].speed == 2)
                                OurGame.Enemy[i].speed = 4;
                            break;
                        case 3:     //加龟
                            if (OurGame.Enemy[i].speed == 2 || OurGame.Enemy[i].speed == 4)
                            {
                                if (MyHelp.Random(20) <= 10)
                                {
                                    OurGame.Enemy[i].speed = 5;
                                    OurGame.Enemy[i].Active = 0x11;
                                }
                                else
                                {
                                    OurGame.Enemy[i].speed = 1;
                                    OurGame.Enemy[i].Active = 0x10;
                                }
                            }
                            break;

                    }
                    Active = false;
                    return;
                }
            }


        }
        public void Draw()
        {
            MyHelp.foreSpriteBatch.Draw(MyHelp.articleTexture, _pos, _rect, Color.White, 0, MyHelp.acticleCenter, 1, SpriteEffects.None, 0);
            hasDraw = 0xff;
        }

    }
}
