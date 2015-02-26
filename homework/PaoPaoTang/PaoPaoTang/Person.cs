using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bomb
{
    public class Person
    {
        private Rectangle boxRect;

        private Texture2D _personTexture;
        public Vector2 pos;
        public int Active;
        private Rectangle rect;
        private int _dir;
        private int _frame;
        private int delay;
        private int _speed;
        public int hasDraw;
        private int mapX;
        private int mapY;
        private int mapPos;
        public int leiLen;
        public int maxLei;
        public int haveLei;
        private Rectangle guiRect;
        public int deadDelay;

        private Rectangle baoRect;
        private int boxAndTree;
        private Byte backData;
        private Vector2 boxAndTreePos;
        private int mapDelay;

        public Person(GraphicsDevice drivce, string fileName)
        {
            _personTexture = Texture2D.FromFile(drivce, fileName);
            pos = new Vector2();
            _dir = 0x10;
            hasDraw = 0;
            boxAndTree = 0;

            rect = new Rectangle(0, 0, 66, 80);
            guiRect = new Rectangle(0, 0, 66, 80);
            boxRect = new Rectangle(0, 0, 40, 80);
            baoRect = new Rectangle(0, 0, 72, 72);
            leiLen = 1;
            maxLei = 1;
            haveLei = 0;
            delay = 0;
            Active = 0;
            _speed = 2;
            deadDelay = 0;
            _frame = 0;
        }

        public int postion
        {
            set
            {
                MyHelp.PosToVector2(value, out pos);

            }
        }
        public int dir
        {
            set
            {
                _dir = value;
            }
            get
            {
                return _dir;
            }
        }
        public int X        //取得设置X坐标
        {
            get
            {
                return (int)pos.X;
            }
            set
            {
                pos.X = value;
            }
        }
        public int Y
        {
            get
            {
                return (int)pos.Y;
            }
            set
            {
                pos.Y = value;
            }
        }
        public int speed
        {
            set
            {
                switch (value)
                {
                    case 1:
                        _speed = 1;
                        break;
                    case 2:
                        _speed = MyHelp.changSpeed(ref pos, 2);
                        break;
                    case 4:
                        _speed = MyHelp.changSpeed(ref pos, 4);
                        break;
                    case 5:
                        _speed = MyHelp.changSpeed(ref pos, 5);
                        break;
                }

            }
            get
            {
                return _speed;
            }
        }

        private void checkMapPos()
        {
            mapX = (int)(pos.X - MyHelp.StartPos.X) / 40;
            mapY = (int)(pos.Y - MyHelp.StartPos.Y) / 40;
            mapPos = mapX + mapY * MyHelp.WIDTH;
        }

        private bool canMove()
        {
            checkMapPos();
            if ((_dir & 0x10) != 0)
                return false;
            int dir = _dir & 0xF;
            int nextPos = MyHelp.posLen[dir] + mapPos;
            if ((OurGame.map[nextPos].canMove & 0x6f) != 0)
                return false;
            int posData;
            if (nextPos >= 0 && nextPos < MyHelp.LENGTH)
            {
                posData = OurGame.map[nextPos].mapData & 0xF0;
                if (posData == 0)
                {
                    return true;
                }
                else
                {
                    if (posData == 0x30) //是否可以进入树中
                    {
                        mapDelay = 0;
                        boxAndTree = 2;
                        MyHelp.PosToVector2(mapPos + MyHelp.posLen[dir], out boxAndTreePos);
                        backData = OurGame.map[MyHelp.posLen[dir] + mapPos].mapData;
                        OurGame.map[nextPos].mapData = 0;
                        boxRect.X = 0;
                        boxRect.Y = 160;
                        return true;
                    }
                    else if (posData == 0x10)   //是否可以推箱子
                    {
                        nextPos += MyHelp.posLen[dir];
                        if (nextPos < 0 || nextPos >= MyHelp.LENGTH)
                            return false;
                        posData = OurGame.map[nextPos].mapData & 0xF0;
                        if ((OurGame.map[nextPos].canMove) != 0)
                            return false;
                        //可以推箱子
                        if (posData == 0)
                        {
                            OurGame.map[nextPos].canMove |= 0x40;
                            mapDelay = 0;
                            boxAndTree = 1;

                            MyHelp.PosToVector2(mapPos + MyHelp.posLen[dir], out boxAndTreePos);
                            backData = OurGame.map[MyHelp.posLen[dir] + mapPos].mapData;
                            OurGame.map[mapPos + MyHelp.posLen[dir]].mapData = 0;
                            boxRect.X = 0;
                            boxRect.Y = 0;
                            return true;
                        }
                        else
                            return false;
                    }
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public void createLei()
        {
            if (haveLei >= maxLei)
                return;
            int pos;
            int i;
            pos = MyHelp.Vector2ToPos(this.pos, 20);
            for (i = 0; i < MyHelp.maxLei; ++i)
            {
                if (OurGame.lei[i].Active != 0 && pos == OurGame.lei[i].Pos)
                    return;

            }
            for (i = 0; i < MyHelp.maxLei; ++i)
            {
                if (OurGame.lei[i].Active == 0)
                {
                    OurGame.lei[i].CreateLei(this);
                    ++haveLei;
                    break;
                }
            }
        }
        public void updata()
        {
            if (deadDelay != 0)
                --deadDelay;
            move();
            udataPerson();
            updataMap();
        }

        private void checkPeng()
        {
            int i;

            if (OurGame.Master != this && (OurGame.Master.Active == 1 || OurGame.Master.Active == 0x10 || OurGame.Master.Active == 0x11))
                if (MyHelp.checkHit(pos, OurGame.Master.pos, 30))
                {
                    _frame = 10;
                }
            for (i = 0; i < MyHelp.maxEnemy; ++i)
            {
                if (OurGame.Enemy[i] != this && (OurGame.Enemy[i].Active == 1 || OurGame.Enemy[i].Active == 0x10 || OurGame.Enemy[i].Active == 0x11))
                    if (MyHelp.checkHit(pos, OurGame.Enemy[i].pos, 30))
                    {
                        _frame = 10;
                    }

            }

        }
        private void udataPerson()
        {
            int dir = _dir & 0xf;
            switch (Active)
            {
                case 0:
                    break;
                case 1:  //正常移动
                    rect.X = _frame * 66;
                    rect.Y = dir * 80;
                    if (delay == 0)
                    {
                        delay = 8;
                        ++_frame;
                        if (_frame >= 5)
                            _frame = 0;
                    }
                    else
                        --delay;
                    break;
                case 2:
                    _frame = 0;
                    rect.X = _frame * 66;
                    rect.Y = dir * 80;
                    delay = 0;

                    Active = 3;
                    break;
                case 3:
                    baoRect.X = _frame * 72;
                    if (_frame < 10)
                        checkPeng();
                    if (delay == 0)
                    {
                        if (_frame < 10)
                            delay = 15;
                        else
                            delay = 5;
                        ++_frame;
                        if (_frame >= 14)
                        {
                            Active = 4;
                            _frame = 0;
                        }
                    }
                    else
                        --delay;
                    break;
                case 4:
                    Active = 0;
                    break;
                case 5:

                    break;
                case 0x10:   //慢龟

                    if (delay == 0)
                    {
                        delay = 10;
                        ++_frame;
                        if (_frame >= 4)
                            _frame = 0;
                    }
                    else
                        --delay;
                    rect.X = _frame * 66;
                    rect.Y = (dir + 4) * 80;
                    guiRect.X = _frame * 66;
                    guiRect.Y = dir * 80;
                    break;
                case 0x11:   //快龟
                    if (delay == 0)
                    {
                        delay = 5;
                        ++_frame;
                        if (_frame >= 4)
                            _frame = 0;
                    }
                    else
                        --delay;
                    guiRect.X = _frame * 66;
                    guiRect.Y = (dir + 4) * 80;
                    rect.X = _frame * 66;
                    rect.Y = (dir + 4) * 80;
                    break;
            }

        }

        private void updataMap()
        {
            switch (boxAndTree)
            {
                case 0:
                    break;
                case 1:
                    boxAndTreePos.X += MyHelp.moveLen[(_dir & 0xf) * 2] * 5;
                    boxAndTreePos.Y += MyHelp.moveLen[(_dir & 0xf) * 2 + 1] * 5;
                    if (MyHelp.isInPatten(boxAndTreePos))
                    {
                        boxAndTree = 0;
                        int nowpos = MyHelp.Vector2ToPos(boxAndTreePos);
                        OurGame.map[nowpos].mapData = backData;
                        OurGame.map[nowpos].canMove &= 0xBF;        //去掉箱子标志
                    }
                    break;
                case 0x10:
                    if (MyHelp.isInPatten(pos))
                    {
                        int nowpos = MyHelp.Vector2ToPos(boxAndTreePos);
                        OurGame.map[nowpos].mapData = backData;
                        boxAndTree = 0;
                    }
                    break;
                default:
                    if (mapDelay == 0)
                    {
                        mapDelay = 2;
                        ++boxAndTree;
                        if ((boxAndTree & 1) != 0)
                            ++boxAndTreePos.X;
                        else
                            --boxAndTreePos.X;
                        if (boxAndTree >= 4)
                        {
                            boxAndTree = 0x10;
                        }
                    }
                    else
                        --mapDelay;
                    break;
            }
        }

        public void ChangDir()
        {
            if (Active > 1 && Active < 0x10)
            {

                return;
            }
            int k;
            int newDir;
            if (canCreateLei())
                createLei();
            checkSafe();
            switch (moveDir.count)
            {
                case 0:
                    dir |= 0x10;
                    break;
                case 1:
                    for (k = 0; k < 4; ++k)
                        if ((moveDir.canMove & (1 << k)) != 0)
                        {
                            dir = k;
                            break;
                        }

                    break;
                default:
                    if (this.X > OurGame.Master.X)
                    {
                        if (this.Y > OurGame.Master.Y)
                        {
                            newDir = 5;
                        }
                        else if (this.Y == OurGame.Master.Y)
                        {
                            newDir = 4;
                        }
                        else
                        {
                            newDir = 6;
                        }
                    }
                    else if (this.X == OurGame.Master.X)
                    {
                        if (this.Y > OurGame.Master.Y)
                        {
                            newDir = 1;
                        }
                        else if (this.Y == OurGame.Master.Y)
                        {
                            newDir = 15;
                        }
                        else
                        {
                            newDir = 2;
                        }
                    }
                    else
                    {
                        if (this.Y > OurGame.Master.Y)
                        {
                            newDir = 9;
                        }
                        else if (this.Y == OurGame.Master.Y)
                        {
                            newDir = 8;
                        }
                        else
                        {
                            newDir = 10;
                        }
                    }
                    if (MyHelp.Random(50) < 40 && (newDir & moveDir.canMove) != 0)
                    {
                        for (k = 0; k < 4; ++k)
                        {
                            if ((newDir & moveDir.canMove & (1 << k)) != 0)
                            {
                                dir = k;
                                break;
                            }
                        }
                    }
                    else if (!(MyHelp.Random(50) > 10 && dir < 4 && (moveDir.canMove & (1 << dir)) != 0))
                    {
                        newDir = 0;
                        int part = MyHelp.Random(moveDir.count);
                        for (k = 0; k < 4; ++k)
                        {
                            if ((moveDir.canMove & (1 << k)) != 0)
                                ++newDir;
                            if (newDir > part)
                                break;
                        }
                        dir = k;
                    }
                    break;
            }


        }
        public void move()
        {
            //到边界，不可以向前走了。
            if ((pos.Y <= MyHelp.StartPos.Y && _dir == 0) || (pos.Y >= MyHelp.StartPos.Y + 240 && _dir == 1) || (pos.X <= MyHelp.StartPos.X && _dir == 2) || (pos.X >= MyHelp.StartPos.X + 320 && _dir == 3))
            {
                _dir |= 0x10;
                return;
            }
            //正常移动。
            if (MyHelp.isInPatten(pos))
            {
                if (!canMove())
                {
                    _dir |= 0x10;
                    return;
                }

            }
            if ((_dir & 0x10) != 0)
                return;

            pos.X += MyHelp.moveLen[_dir * 2] * _speed;
            pos.Y += MyHelp.moveLen[_dir * 2 + 1] * _speed;
            //是否到整Patten上，停步
            if (MyHelp.isInPatten(pos))
            {
                OurGame.map[MyHelp.Vector2ToPos(pos) - MyHelp.posLen[_dir]].canMove &= 0x7f;
                _dir |= 0x10;
            }

        }

        public void Draw()
        {
            bool flag;
            flag = (boxAndTree == 1 && _dir == 0);
            if (!flag)
            {
                if (Active >= 0x10)
                    MyHelp.foreSpriteBatch.Draw(MyHelp.wuguiSprite, pos, guiRect, Color.White, 0, MyHelp.personCenter, 1, SpriteEffects.None, 0);
                MyHelp.foreSpriteBatch.Draw(_personTexture, pos, rect, Color.White, 0, MyHelp.personCenter, 1, SpriteEffects.None, 0);
                if (Active == 3)
                    MyHelp.foreSpriteBatch.Draw(MyHelp.baoSprite, pos, baoRect, Color.White, 0, MyHelp.baoCenter, 1, SpriteEffects.None, 0);


            }
            hasDraw = 0xFF;
            switch (boxAndTree)
            {
                case 0:
                    break;
                case 1:
                    MyHelp.foreSpriteBatch.Draw(MyHelp.mapSprite, boxAndTreePos, boxRect, Color.White, 0, MyHelp.mapDataCenter, 1, SpriteEffects.None, 0);
                    break;
                default:
                    MyHelp.foreSpriteBatch.Draw(MyHelp.mapSprite, boxAndTreePos, boxRect, Color.White, 0, MyHelp.mapDataCenter, 1, SpriteEffects.None, 0);
                    break;
            }
            if (flag)
            {
                if (Active >= 0x10)
                    MyHelp.foreSpriteBatch.Draw(MyHelp.wuguiSprite, pos, guiRect, Color.White, 0, MyHelp.personCenter, 1, SpriteEffects.None, 0);
                MyHelp.foreSpriteBatch.Draw(_personTexture, pos, rect, Color.White, 0, MyHelp.personCenter, 1, SpriteEffects.None, 0);
                if (Active == 3)
                    MyHelp.foreSpriteBatch.Draw(MyHelp.baoSprite, pos, baoRect, Color.White, 0, MyHelp.baoCenter, 1, SpriteEffects.None, 0);
            }
            OurGame.map[MyHelp.Vector2ToPos(pos)].canMove |= 0x80;
        }

        private byte dirLen(int pos, int dir)
        {
            Vector2 temp = this.pos;
            this.postion = pos;
            byte len = dirLen(dir);
            this.pos = temp;
            return len;
        }
        private byte dirLen(int dir)
        {
            byte len = 0;
            bool flag = true;
            int nextPos = MyHelp.Vector2ToPos(pos);
            while (true)
            {
                if (MyHelp.isInBound(ref nextPos, dir))
                {
                    if (OurGame.map[nextPos].mapData == 0 || (OurGame.map[nextPos].mapData & 0xf0) == 0x30)
                        ++len;
                    else if (flag && (OurGame.map[nextPos].mapData & 0xf0) == 0x10)
                    {
                        if (MyHelp.isInBound(ref nextPos, dir))
                        {
                            if (OurGame.map[nextPos].mapData == 0)
                            {
                                ++len;
                                flag = false;
                            }
                            else
                                break;
                        }
                        else
                            break;
                    }
                    else
                        break;
                }
                else
                    break;
            }
            return len;
        }
        private bool canCreateLei()
        {
            int i, length, nextpos;
            for (i = 0; i < 4; ++i)
            {
                length = dirLen(i);
                if (leiLen >= length && OurGame.map[MyHelp.Vector2ToPos(pos) + MyHelp.posLen[i] * length].mapData < 0x40)
                    break;

            }
            if (i >= 4 && MyHelp.Random(50) > 20)
                return false;
            for (i = 0; i < 4; ++i)
            {

                nextpos = MyHelp.Vector2ToPos(pos);
                if (MyHelp.isInBound(ref nextpos, i))
                {
                    if (dirLen(i) != 0)
                    {
                        if (i == 0 || i == 1)
                        {
                            if (dirLen(nextpos, 2) != 0 || dirLen(nextpos, 3) != 0)
                                return true;
                        }
                        else
                        {
                            if (dirLen(nextpos, 1) != 0 || dirLen(nextpos, 0) != 0)
                                return true;
                        }
                    }
                }
            }
            for (i = 0; i < 4; ++i)
            {
                if (dirLen(i) > leiLen)
                    return true;
            }
            return false;
        }
        private void checkSafe()
        {
            int i, j, k, len;
            int nextPos;
            moveDir.canMove = 0;
            moveDir.count = 0;
            for (i = 0; i < 4; ++i)
                moveDir.dirLen[i] = dirLen(i);



            for (i = 0; i < 4; ++i)
            {
                nextPos = MyHelp.Vector2ToPos(pos);
                if (MyHelp.isInBound(ref nextPos, i))
                {
                    for (k = 0; k < MyHelp.maxLei; ++k)
                    {
                        if (OurGame.lei[k].Active != 0)
                        {
                            if (MyHelp.isInLine(nextPos, OurGame.lei[k].Pos, OurGame.lei[k].Len))
                                break;
                        }
                    }
                    //安全的地方，不会被炸

                    if (k >= MyHelp.maxLei)
                    {
                        if (moveDir.dirLen[i] != 0)
                        {
                            moveDir.canMove |= (byte)(1 << i);
                            ++moveDir.count;
                        }
                    }
                }
            }
            if (moveDir.count == 0)
            {
                nextPos = MyHelp.Vector2ToPos(pos);
                for (k = 0; k < MyHelp.maxLei; ++k)
                {
                    if (OurGame.lei[k].Active != 0)
                    {
                        if (MyHelp.isInLine(nextPos, OurGame.lei[k].Pos, OurGame.lei[k].Len))
                            break;

                    }
                }
                if (k >= MyHelp.maxLei)
                    return;
            }
            j = 0;
            if (moveDir.count == 0)
            {
                len = 0;

                for (i = 0; i < 4; ++i)
                {
                    if (moveDir.dirLen[i] > len)
                    {
                        len = moveDir.dirLen[i];
                        j = i;
                    }
                    else if (moveDir.dirLen[i] == len)
                    {
                        nextPos = MyHelp.Vector2ToPos(pos);
                        if (MyHelp.isInBound(ref nextPos, i))
                        {
                            if (i < 2)
                            {
                                if ((dirLen(nextPos, 2) != 0) || (dirLen(nextPos, 3) != 0))
                                    j = i;
                            }
                            else
                            {
                                if ((dirLen(nextPos, 0) != 0) || (dirLen(nextPos, 1) != 0))
                                    j = i;
                            }
                        }

                    }
                }
                if (len != 0)
                {
                    for (k = 0; k < MyHelp.maxLei; ++k)
                    {
                        nextPos = MyHelp.Vector2ToPos(pos);
                        if (OurGame.lei[k].Active != 0)
                        {
                            len = OurGame.lei[k].Len;
                            if (nextPos == OurGame.lei[k].Pos)
                                break;

                            if (MyHelp.isInBound(ref nextPos, j))
                            {
                                if (MyHelp.isInLine(nextPos, OurGame.lei[k].Pos, len))
                                {
                                    if (MyHelp.isSafe(nextPos, OurGame.lei[k].Pos, len, j))
                                        return;
                                }
                            }

                        }
                        if (k >= MyHelp.maxLei)
                            return;
                    }
                    moveDir.canMove |= (byte)(1 << j);
                    ++moveDir.count;
                }
            }
        }


    }

}
