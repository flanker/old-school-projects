using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bomb
{
    static public class MyHelp
    {
        static public int[] moveLen ={ 0, -1, 0, 1, -1, 0, 1, 0 };    //�ϣ��£������ƶ�����
        static public int[] posLen ={ -9, 9, -1, 1 };   //MAP�ϣ��������ƶ�����
        
        static public Vector2 StartPos=new Vector2(21, 47);     //��Ϸ�������Ͻ�
        static public Vector2 mapDataCenter = new Vector2(0, 40);     //��ͼ��������
        static public Vector2 leiCenter = new Vector2(25, 25);         //�׻�������
        static public Vector2 acticleCenter = new Vector2(5, 5);        //��Ʒ����
        static public Vector2 personCenter = new Vector2(13, 30);       //��������
        static public Vector2 baoCenter = new Vector2(16, 28);
        static public Vector2 masterStartPos = new Vector2();

        public const byte WIDTH = 9;          //��Ϸ�� 
        public const byte HEIGHT = 7;          //��Ϸ��
        public const byte LENGTH = (byte)(WIDTH * HEIGHT);
        public const byte maxLei = 8;             //���ɷŵ�����
        public const byte maxEnemy = 5;             //��Ϸ����������
        public const byte maxActicle = 10;          //��Ϸ��������Ʒ��

        static public SpriteBatch bgSpriteBatch;         //���� 
        static public SpriteBatch foreSpriteBatch;        //ǰ��

        static public Texture2D mapSprite;      //��ͼ
        static public Texture2D articleTexture; //��Ʒ����
        static public Texture2D bgSprite;         //��������
        static public Texture2D leiSprite;            //�׶��� 
        static public Texture2D wuguiSprite;
        static public Texture2D baoSprite;
        static public Texture2D winSprite;
        static public Texture2D loseSprite;
        
        static public Rectangle bgRect=new Rectangle(0,0,400,385);

        static private Random rnd = new Random(0xFFFF); //�������
        //ȡ��һ�������
        static public int Random(int seed)
        {
            return rnd.Next(seed);
        }

        //����ת����MAP�е�λ��
        static public int Vector2ToPos(Vector2 vec)
        {
            return (int)(vec.X - StartPos.X) / 40 + (int)(vec.Y - StartPos.Y) / 40 * WIDTH;
        }
        //����ת����MAP�е�λ�ã���ƫ�ƣ�
        static public int Vector2ToPos(Vector2 vec, int office)
        {
            return (int)(vec.X - StartPos.X + office) / 40 + (int)(vec.Y - StartPos.Y + office) / 40 * WIDTH;
        }
        //MAP�е�λ��ת���ɶ���
        static public void PosToVector2(int pos,out Vector2 vector)
        {
            vector.X = (pos % WIDTH) * 40 + StartPos.X;
            vector.Y = (pos / WIDTH) * 40 + StartPos.Y;
        }

        //�ж�һ���Ƿ�����PATTEN��
        static public bool isInPatten(Vector2 vect)
        {
            if ((vect.X - StartPos.X) % 40 == 0 && (vect.Y - StartPos.Y) % 40 == 0)
                return true;
            return false;
        }

        //XYת����MAP�е�λ��
        static public int mapPos(int x, int y)
        {
            return x * WIDTH + y;
        }
        //��ײ���
        static public bool checkHit(Vector2 source,Vector2 dect, int len)
        {
            if (Math.Abs(source.X - dect.X) < len && Math.Abs(source.Y - dect.Y) < len)
                return true;
            
            return false;
        }
        static public int Min(int a, int b)
        {
            return a > b ? b : a;
        }
        static public int changSpeed(ref Vector2 vect,int speed)
        {
            vect.X = ((int)(vect.X - StartPos.X + speed / 2) / speed) * speed + StartPos.X;
            vect.Y = ((int)(vect.Y - StartPos.Y + speed / 2) / speed) * speed + StartPos.Y;
            return speed;
        }
        static public bool isInBound(ref int pos,int dir)
        {
            int nextPos;
            nextPos=pos+posLen[dir];
            if ((dir < 2 && nextPos >= 0 && nextPos < LENGTH) || (dir >= 2 && nextPos >=(pos / WIDTH) * WIDTH && nextPos < (pos / WIDTH + 1) * WIDTH))
            {
                pos = nextPos;
                return true;
            }
            return false;
            
        }
        static private void mapPosToXY(int pos, out int x, out int y)
        {
            x = pos % WIDTH;
            y = pos / WIDTH;
        }
        static public bool isInLine(int pos1, int pos2,int len)
        {
            int x1, x2, y1, y2;
            mapPosToXY(pos1, out x1, out y1);
            mapPosToXY(pos2,out x2,out y2);
            return (x1 == x2 && Math.Abs(y1 - y2) <= len) || (y1 == y2 && Math.Abs(x1 - x2)<=len);

        }
        static public bool isSafe(int pos1, int pos2, int len,int dir)
        {
            int x1, x2, y1, y2;
            mapPosToXY(pos1, out x1, out y1);
            mapPosToXY(pos2, out x2, out y2);
            if (y1 == y2 && ((x1 > x2 && dir == 2) || (x1 < x2 && dir == 3)))
            {
                return true;
            }
            if (x1 == x2 && ((y1 > y2 && dir == 0) || (y1 < y2 && dir == 1)))
                return true ;
            return false;
        }

    }
    static public class moveDir
    {
        static public byte count=0;
        static public byte canMove=0;
        static public byte[] dirLen=new byte[4];
    }
}
