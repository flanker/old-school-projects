
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
    public class OurGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        ContentManager content;

        static public Person Master;                // 主角
        static public Person[] Enemy;
        static public Map[] map;        //高16位表示雷的状态，低8位表示地图数据 ，
        static public Lei[] lei;        //雷
        static public Article[] acticle;

        static public Number Life;                //生命
        private Number[] prop;              //属性


        private bool spaceUP;
        private Rectangle _mapDataRect;     //地图数据矩形
        private Rectangle _leiRect;         //雷矩形
        private Vector2 _pos;
        private Vector2 _leiPos;

        AudioEngine _audioEngine;
        WaveBank _waveBankBG;
        SoundBank _soundBankBG;

        const string _soundFolderPath = "Music\\";
        string _currSong = "title";
        bool _playingSong = false;
        Cue _currentCue;
        public static bool _lei = false;
        public static bool _drop = false;

        private bool paused = false;
        private bool pauseKeyDown = false;

        string _gameState = "title";
        Title _title;

        SpriteBatch _sbResult;
        SpriteFont _sf;
        bool _isWin;
        bool _hasEnter = false;


        public OurGame()
        {
            graphics = new GraphicsDeviceManager(this);
            content = new ContentManager(Services);
            graphics.PreferredBackBufferHeight = 385;
            graphics.PreferredBackBufferWidth = 400;
            prop = new Number[3];
            lei = new Lei[MyHelp.maxLei];
            map = new Map[MyHelp.LENGTH];
            acticle = new Article[MyHelp.maxActicle];
            Enemy = new Person[MyHelp.maxEnemy];

            _pos = new Vector2(0, 0);

            _mapDataRect = new Rectangle(0, 0, 40, 80);
            _leiRect = new Rectangle(0, 0, 50, 50);
            _leiPos = new Vector2();
            spaceUP = true;

            _audioEngine = new AudioEngine(string.Format("{0}music.xgs", _soundFolderPath));
            _waveBankBG = new WaveBank(_audioEngine, string.Format("{0}bg.xwb", _soundFolderPath));
            _soundBankBG = new SoundBank(_audioEngine, string.Format("{0}bg.xsb", _soundFolderPath));

            _title = new Title(graphics, content);


        }

        //开始新的一关
        private void InitLevel()
        {
            int n = 0;
            for (int i = 0; i < MyHelp.HEIGHT; ++i)
            {
                for (int j = 0; j < MyHelp.WIDTH; ++j)
                {
                    map[MyHelp.mapPos(i, j)].mapData = level1[MyHelp.mapPos(i, j)];
                    map[MyHelp.mapPos(i, j)].leiActive = false;
                    map[MyHelp.mapPos(i, j)].canMove = 0;
                    if (map[MyHelp.mapPos(i, j)].mapData < 0x10)
                    {
                        switch (map[MyHelp.mapPos(i, j)].mapData)
                        {
                            case 1:
                                Master.Active = 1;
                                Master.postion = MyHelp.mapPos(i, j);
                                MyHelp.masterStartPos = Master.pos;
                                break;
                            case 2:
                                Enemy[n].Active = 1;
                                Enemy[n].postion = MyHelp.mapPos(i, j);
                                ++n;
                                break;
                        }
                        map[MyHelp.mapPos(i, j)].mapData = 0;
                    }
                }
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.Window.Title = "泡泡堂 XNA Game";
        }

        protected override void LoadGraphicsContent(bool loadAllContent)
        {
            if (loadAllContent)
            {
                int i;

                _title._sb = new SpriteBatch(graphics.GraphicsDevice);
                _title._sprite = Texture2D.FromFile(graphics.GraphicsDevice, @"Images\title.jpg");
                _title.sf = content.Load<SpriteFont>("game");

                _sbResult = new SpriteBatch(graphics.GraphicsDevice);
                _sf = content.Load<SpriteFont>("game");



                MyHelp.foreSpriteBatch = new SpriteBatch(graphics.GraphicsDevice);
                MyHelp.bgSpriteBatch = new SpriteBatch(graphics.GraphicsDevice);

                MyHelp.leiSprite = Texture2D.FromFile(graphics.GraphicsDevice, @"Images\lei.png");
                MyHelp.bgSprite = Texture2D.FromFile(graphics.GraphicsDevice, @"Images\LevelBG.jpg");

                MyHelp.mapSprite = Texture2D.FromFile(graphics.GraphicsDevice, @"Images\patten.png");
                MyHelp.articleTexture = Texture2D.FromFile(graphics.GraphicsDevice, @"Images\article.png");
                MyHelp.wuguiSprite = Texture2D.FromFile(graphics.GraphicsDevice, @"Images\wugui.png");
                MyHelp.baoSprite = Texture2D.FromFile(graphics.GraphicsDevice, @"Images\bao.png");
                Master = new Person(graphics.GraphicsDevice, @"Images\master.png");

                MyHelp.winSprite = Texture2D.FromFile(graphics.GraphicsDevice, @"Images\win.png");
                MyHelp.loseSprite = Texture2D.FromFile(graphics.GraphicsDevice, @"Images\lose.png");

                for (i = 0; i < MyHelp.maxEnemy; ++i)
                {
                    Enemy[i] = new Person(graphics.GraphicsDevice, @"Images\Enemy.png");
                }
                Life = new Number(graphics.GraphicsDevice, @"Images\Num1.png", new Vector2(73, 343), 20, 26);
                for (i = 0; i < 3; ++i)
                    prop[i] = new Number(graphics.GraphicsDevice, @"Images\Num5.png", new Vector2(282 + i * 44, 365), 14, 12);
                for (i = 0; i < MyHelp.maxLei; ++i)
                    lei[i] = new Lei(graphics.GraphicsDevice, @"Images\lei.png");
                for (i = 0; i < MyHelp.maxActicle; ++i)
                    acticle[i] = new Article();
                InitLevel();
                for (i = 0; i < 3; ++i)
                    prop[i].number = 1;
                Life.number = 2;
                _hasEnter = false;

            }

        }

        protected override void UnloadGraphicsContent(bool unloadAllContent)
        {
            if (unloadAllContent == true)
            {
                content.Unload();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (Enemy[0].Active == 0)
            {
                _gameState = "result";
                _isWin = true;
            }

            if (_gameState == "title")
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    _gameState = "game";
                    _currSong = "background";
                    _currentCue.Stop(AudioStopOptions.Immediate);
                    _currentCue = _soundBankBG.GetCue(_currSong);
                    _currentCue.Play();
                    _playingSong = true;
                }
                if (keyboardState.IsKeyDown(Keys.Escape))
                {
                    this.Exit();
                }
                base.Update(gameTime);
            }
            else if (_gameState == "result")
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Space))
                {
                    _gameState = "title";
                    _currSong = "title";
                    _currentCue.Stop(AudioStopOptions.Immediate);
                    _currentCue = _soundBankBG.GetCue(_currSong);
                    _currentCue.Play();
                    _playingSong = true;
                    InitLevel();
                    for (int i = 0; i < 3; ++i)
                        prop[i].number = 1;
                    Life.number = 2;
                    _hasEnter = false;
                }
                base.Update(gameTime);
            }
            else
            {

                checkPauseKey();
                if (paused == false)
                {
                    int i;
                    ControlKey();
                    MoveEnemy();
                    Master.updata();
                    if (Master.Active == 0 && Life.number != 0)
                    {
                        Master.Active = 1;
                        Master.pos = MyHelp.masterStartPos;
                    }
                    if (Master.Active == 0 && Life.number == 0)
                    {
                        _gameState = "result";
                        _isWin = false;

                    }
                    for (i = 0; i < MyHelp.maxLei; ++i)
                    {
                        if (lei[i].Active != 0)
                            lei[i].updata();
                    }
                    for (i = 0; i < MyHelp.maxActicle; ++i)
                    {
                        if (acticle[i].active)
                            acticle[i].updata();
                    }

                    base.Update(gameTime);
                }
            }

            _audioEngine.Update();
            if (_playingSong == false)
            {
                _currentCue = _soundBankBG.GetCue(_currSong);
                _currentCue.Play();
                _playingSong = true;
            }
            if (_currentCue.IsStopped == true)
            {
                _playingSong = false;
            }
            if (_lei == true)
            {
                _soundBankBG.GetCue("lei").Play();
                _lei = false;
            }
            if (_drop == true)
            {
                _soundBankBG.GetCue("drop").Play();
                _drop = false;
            }
        }

        private void checkPauseKey()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.P))
            {
                pauseKeyDown = true;
            }
            else if (pauseKeyDown)
            {
                pauseKeyDown = false;
                paused = !paused;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            int i, j, k;
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            if (_gameState == "title")
            {
                _title.Show();
            }

            else
            {

                //开始绘制背景
                MyHelp.bgSpriteBatch.Begin();
                MyHelp.bgSpriteBatch.Draw(MyHelp.bgSprite, MyHelp.bgRect, Color.White);
                MyHelp.bgSpriteBatch.End();
                MyHelp.foreSpriteBatch.Begin(SpriteBlendMode.AlphaBlend);


                //绘制数字
                Life.Draw();
                for (i = 0; i < 3; ++i)
                    prop[i].Draw();
                //绘制地图
                for (i = 0; i < MyHelp.HEIGHT; ++i)
                {
                    _pos.Y = MyHelp.StartPos.Y + i * 40;
                    _leiPos.Y = MyHelp.StartPos.Y + i * 40 + 20;


                    //绘制雷
                    for (j = 0; j < MyHelp.WIDTH; ++j)
                    {
                        _leiPos.X = MyHelp.StartPos.X + j * 40 + 20;
                        if (map[MyHelp.mapPos(i, j)].leiActive)
                        {
                            _leiRect.X = 50 * map[MyHelp.mapPos(i, j)].leiFrame;
                            _leiRect.Y = 50 * map[MyHelp.mapPos(i, j)].leiID;
                            MyHelp.foreSpriteBatch.Draw(MyHelp.leiSprite, _leiPos, _leiRect, Color.White, map[MyHelp.mapPos(i, j)].leiDir, MyHelp.leiCenter, 1, SpriteEffects.None, 0);
                        }
                    }
                    //物品
                    for (k = 0; k < MyHelp.maxActicle; ++k)
                    {
                        if (acticle[k].active && (acticle[k].hasDraw == 0) && acticle[k].Y <= _pos.Y)
                            acticle[k].hasDraw = 1;
                    }

                    //主角
                    if (Master.Active != 0)
                        if ((Master.hasDraw == 0) && (Master.Y <= _pos.Y))
                            Master.hasDraw = 1;
                    //敌人
                    for (k = 0; k < MyHelp.maxEnemy; ++k)
                    {
                        if ((Enemy[k].Active != 0) && (Enemy[k].hasDraw == 0) && Enemy[k].Y <= _pos.Y)
                            Enemy[k].hasDraw = 1;
                    }
                    for (j = 0; j < MyHelp.WIDTH; ++j)
                    {
                        _pos.X = MyHelp.StartPos.X + j * 40;
                        //物品
                        for (k = 0; k < MyHelp.maxActicle; ++k)
                        {
                            if (acticle[k].active && (acticle[k].hasDraw == 1) && acticle[k].X <= _pos.X)
                                acticle[k].Draw();
                        }
                        //显示主角
                        if (Master.Active != 0)
                            if ((Master.hasDraw == 1) && (Master.X <= _pos.X + 35))
                                Master.Draw();

                        //敌人
                        for (k = 0; k < MyHelp.maxEnemy; ++k)
                        {
                            if ((Enemy[k].Active != 0) && (Enemy[k].hasDraw == 1) && (Enemy[k].X < _pos.X + 35))
                                Enemy[k].Draw();
                        }

                        //显示地图
                        if (map[MyHelp.mapPos(i, j)].mapData >= 0x10)
                        {
                            _mapDataRect.Y = 80 * (((map[MyHelp.mapPos(i, j)].mapData & 0xf0) >> 4) - 1);
                            _mapDataRect.X = 40 * (map[MyHelp.mapPos(i, j)].mapData & 0xf);
                            MyHelp.foreSpriteBatch.Draw(MyHelp.mapSprite, _pos, _mapDataRect, Color.White, 0, MyHelp.mapDataCenter, 1, SpriteEffects.None, 0);
                        }
                    }
                }


                if (Master.Active != 0)
                    if (Master.hasDraw != 0xff)
                        Master.Draw();
                for (k = 0; k < MyHelp.maxEnemy; ++k)
                    if ((Enemy[k].Active != 0) && (Enemy[k].hasDraw != 0xFF))
                        Enemy[k].Draw();
                for (k = 0; k < MyHelp.maxActicle; ++k)
                    if (acticle[k].active && acticle[k].hasDraw != 0xff)
                        acticle[k].Draw();

                if (_gameState == "result")
                {
                    if (_hasEnter == false)
                    {
                        _soundBankBG.GetCue("enter").Play();
                        _hasEnter = true;
                    }
                    if (_isWin == true)
                    {
                        MyHelp.foreSpriteBatch.Draw(MyHelp.winSprite, new Vector2(100.0f, 100.0f), Color.White);
                    }
                    else
                    {
                        MyHelp.foreSpriteBatch.Draw(MyHelp.loseSprite, new Vector2(100.0f, 100.0f), Color.White);
                    }
                }

                MyHelp.foreSpriteBatch.End();

                Master.hasDraw = 0;
                for (k = 0; k < MyHelp.maxEnemy; ++k)
                {
                    Enemy[k].hasDraw = 0;
                }
                for (k = 0; k < MyHelp.maxActicle; ++k)
                    if (acticle[k].active)
                        acticle[k].hasDraw = 0;
            }

            base.Draw(gameTime);
        }

        private void MoveEnemy()
        {
            for (int i = 0; i < MyHelp.maxEnemy; ++i)
            {
                if (Enemy[i].Active != 0)
                {

                    if ((Enemy[i].dir & 0x10) != 0)
                    {
                        Enemy[i].ChangDir();
                    }
                    Enemy[i].updata();

                }
            }
        }

        private void ControlKey()
        {
            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Escape))
                this.Exit();
            if (Master.Active == 1 || Master.Active == 0x10 || Master.Active == 0x11)
            {
                if (key.IsKeyDown(Keys.Space) && spaceUP)
                {
                    Master.createLei();
                    spaceUP = false;
                }
                if (key.IsKeyUp(Keys.Space))
                {
                    spaceUP = true;
                }
                if ((Master.dir & 0x10) != 0)
                {
                    Master.dir |= 0x10;
                    if (key.IsKeyDown(Keys.Up))
                        Master.dir = 0;
                    if (key.IsKeyDown(Keys.Down))
                        Master.dir = 1;
                    if (key.IsKeyDown(Keys.Left))
                        Master.dir = 2;
                    if (key.IsKeyDown(Keys.Right))
                        Master.dir = 3;
                }
            }
        }

        static public bool createArticle(byte pos)
        {
            if (MyHelp.Random(50) > 30)
                return false;
            for (int i = 0; i < MyHelp.maxActicle; ++i)
            {
                if (acticle[i].active == false)
                {
                    acticle[i].Create((byte)MyHelp.Random(7), pos);
                    return true;
                }
            }

            return false;
        }
        //加载资源

        static public Byte[] level1 ={ 
        0x00, 0x00, 0x10, 0x10, 0x00, 0x00, 0x53, 0x20, 0x21 ,
        0x00, 0x21, 0x30, 0x00, 0x00, 0x10, 0x30, 0x50, 0x10 ,
        0x00, 0x20, 0x53, 0x10, 0x10, 0x00, 0x00, 0x21, 0x20 ,
        0x30, 0x53, 0x30, 0x00, 0x02, 0x10, 0x30, 0x53, 0x30 ,
        0x20, 0x21, 0x00, 0x10, 0x00, 0x00, 0x53, 0x21, 0x52 ,
        0x10, 0x51, 0x30, 0x00, 0x10, 0x10, 0x30, 0x20, 0x00 ,
        0x21, 0x20, 0x53, 0x10, 0x00, 0x00, 0x53, 0x00, 0x01 };
    }

    public struct Map
    {
        public bool leiActive;
        public byte canMove;        //0x80：有人，0X40：箱子目标,0X20：有雷,0x10:有物品
        private Byte _leiID;
        public Byte leiFrame;
        public float leiDir;
        public Byte mapData;
        public byte leiID
        {
            get
            {
                return _leiID;
            }
            set
            {
                if (leiActive)
                {
                    switch (value)
                    {
                        case 0:
                            _leiID = 0;
                            break;
                        case 1:
                            _leiID = 1;
                            break;

                        case 2:
                            if (_leiID == 3)
                                _leiID = 2;
                            break;
                        case 3:
                            break;
                    }
                }
                else
                {
                    _leiID = value;
                    leiActive = true;
                }
            }
        }
    };


}