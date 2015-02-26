using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PaoPaoTang30
{
    public class Lei
    {
        public int Active;
        private int _len;
        private int[] _dir;
        private Byte _frame;
        private Person parent;
        private int _delay;
        private byte _mapPos;
        static public float[] rotation ={ (float)Math.PI * 0.5f, (float)Math.PI * 1.5f, 0, (float)Math.PI };
        public Lei(GraphicsDevice drivce, string fileName)
        {
            _dir = new int[4];
            Active = 0;
        }
        public int Len
        {
            get
            {
                return _len;
            }
        }
        public void CreateLei(Person father)
        {
            for (int i = 0; i < 4; ++i)
                _dir[i] = 0;
            parent = father;
            _len = father.leiLen;
            _frame = 0;

            Active = 1;
            _delay = 0;
            _mapPos = (Byte)MyHelp.Vector2ToPos(father.pos, 20);
            OurGame.map[_mapPos].leiActive = true;
            OurGame.map[_mapPos].leiDir = 0;
            OurGame.map[_mapPos].leiID = 0;
            OurGame.map[_mapPos].leiFrame = 0;
            OurGame.map[_mapPos].canMove |= 0x20;

            OurGame._drop = true;
        }
        public int Delay
        {
            set
            {
                _delay = value;
            }
        }
        public int Pos
        {
            get
            {
                return _mapPos;
            }
        }
        private void checkPerson(int mappos)
        {

            if (OurGame.Master.deadDelay == 0 && OurGame.Master.Active != 0 && MyHelp.Vector2ToPos(OurGame.Master.pos, 20) == mappos)
            {

                OurGame.Master.speed = 2;
                OurGame.Master.deadDelay = 200;
                if (OurGame.Master.Active >= 0x10)
                {
                    OurGame.Master.Active = 1;
                }
                else
                {
                    OurGame.Master.Active = 2;
                    --OurGame.Life.number;
                }
            }

            for (int i = 0; i < MyHelp.maxEnemy; ++i)
                if (OurGame.Enemy[i].Active != 0 && OurGame.Enemy[i].deadDelay == 0 && MyHelp.Vector2ToPos(OurGame.Enemy[i].pos, 20) == mappos)
                {
                    OurGame.Enemy[i].speed = 2;
                    OurGame.Enemy[i].deadDelay = 200;
                    if (OurGame.Enemy[i].Active >= 0x10)
                    {
                        OurGame.Enemy[i].Active = 1;
                    }
                    else
                        OurGame.Enemy[i].Active = 2;
                }
        }
        public void updata()
        {
            int i, n, nextPos;
            byte data;
            switch (Active)
            {
                case 0:
                    break;
                case 1:     //ÅÝÅÝµÄÏÔÊ¾×´Ì¬
                    if (_delay == 0)
                    {
                        _delay = 5;
                        ++_frame;
                        if (_frame > 20)
                            Active = 2;
                        OurGame.map[_mapPos].leiFrame = (Byte)(_frame % 4);
                    }
                    else
                        --_delay;
                    break;
                case 2: //×ª»»µ½±¬Õ¨×´Ì¬

                    OurGame._lei = true;

                    _frame = 0xFF;
                    _delay = 0;
                    Active = 3;
                    OurGame.map[_mapPos].leiID = 1;
                    OurGame.map[_mapPos].leiFrame = 0;

                    if (OurGame.map[_mapPos].mapData != 0)
                        OurGame.createArticle((byte)_mapPos);

                    OurGame.map[_mapPos].mapData = 0;

                    for (i = 0; i < 4; ++i)
                    {
                        n = 0;
                        nextPos = _mapPos;
                        while (n < _len)
                        {

                            if (MyHelp.isInBound(ref nextPos, i))
                            {
                                ++n;
                                data = OurGame.map[nextPos].mapData;
                                if (data < 0x40)
                                {
                                    ++_dir[i];
                                    OurGame.map[nextPos].leiID = 3;
                                    if (n > 1)
                                        OurGame.map[nextPos - MyHelp.posLen[i]].leiID = 2;
                                    OurGame.map[nextPos].leiFrame = 0;
                                    OurGame.map[nextPos].mapData = 0;
                                    OurGame.map[nextPos].leiDir = rotation[i];
                                    for (int k = 0; k < MyHelp.maxActicle; ++k)
                                    {
                                        if (OurGame.acticle[k].active && OurGame.acticle[k].postion == nextPos)
                                            OurGame.acticle[k].active = false;
                                    }

                                    if (data != 0)
                                    {
                                        OurGame.map[nextPos].mapData = 0;
                                        OurGame.createArticle((byte)nextPos);
                                        break;
                                    }
                                }
                                else
                                    break;
                            }
                            else
                                break;
                        }

                    }
                    break;
                case 3: //±¬Õ¨×´Ì¬
                    if (_delay == 0)
                    {


                        ++_frame;
                        _delay = 1;
                        OurGame.map[_mapPos].leiID = 1;
                        OurGame.map[_mapPos].leiFrame = (byte)(_frame % 4);
                        checkPerson(_mapPos);

                        for (i = 0; i < 4; ++i)
                        {
                            n = 0;
                            nextPos = _mapPos;
                            while (n < _dir[i])
                            {
                                ++n;
                                nextPos += MyHelp.posLen[i];
                                checkPerson(nextPos);
                                OurGame.map[nextPos].leiID = 3;
                                if (OurGame.map[nextPos].leiID == 3)
                                    OurGame.map[nextPos].leiFrame = (byte)(_frame % 12);
                                if (n > 1)
                                {
                                    OurGame.map[nextPos - MyHelp.posLen[i]].leiID = 2;
                                    if (OurGame.map[nextPos - MyHelp.posLen[i]].leiID == 2)
                                        OurGame.map[nextPos - MyHelp.posLen[i]].leiFrame = (byte)(_frame % 2);
                                }
                                for (int k = 0; k < MyHelp.maxLei; ++k)
                                {
                                    if (OurGame.lei[k].Active == 1 && OurGame.lei[k].Pos == nextPos)
                                    {
                                        OurGame.lei[k].Active = 2;

                                    }
                                }

                            }

                        }
                        if (_frame >= 12)
                        {
                            Active = 0;
                            --parent.haveLei;
                            OurGame.map[_mapPos].leiActive = false;
                            OurGame.map[_mapPos].canMove &= 0xDF; //È¥µôÀ×±êÖ¾
                            for (i = 0; i < 4; ++i)
                            {
                                n = 0;
                                nextPos = _mapPos;
                                while (n < _dir[i])
                                {
                                    nextPos += MyHelp.posLen[i];
                                    OurGame.map[nextPos].leiActive = false;
                                    ++n;
                                }
                            }
                        }
                    }
                    else
                        --_delay;

                    break;
            }
        }
    }
}
