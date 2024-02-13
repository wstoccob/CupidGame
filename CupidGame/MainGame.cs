using System.Collections.Generic;
using System.Linq;
using CupidGame.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CupidGame;

public class MainGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Canvas _canvas;
    private List<Sprite> _spriteList;

    private Sprite _mainMenu;
    private Sprite _heartOne;
    private Sprite _heartTwo;
    private Sprite _menuText;

    public MainGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _graphics.ApplyChanges();
        
        _canvas = new Canvas(_graphics.GraphicsDevice, 1920, 1080);
        _spriteList = new List<Sprite>();
        _mainMenu = new Sprite(LoadTexture("mainMenu"), new Vector2(0, 0), 0);
        _heartOne = new Sprite(LoadTexture("heart"), new Vector2(10, 10), 1);
        _heartTwo = new Sprite(LoadTexture("heart"), new Vector2(500, 500), 1);
        _mainText = 
        
        _canvas.SetDestinationRectangle();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _spriteList.Add(_mainMenu);
        _spriteList.Add(_heartOne);
        _spriteList.Add(_heartTwo);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _canvas.Activate();
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        foreach (var sprite in _spriteList.OrderBy(a => a._zIndex))
        {
            sprite.Render(_spriteBatch);
        }
        
        _spriteBatch.End();
        
        _canvas.Draw(_spriteBatch);
        
        base.Draw(gameTime);
    }

    private Texture2D LoadTexture(string assetName)
    {
        return Content.Load<Texture2D>(assetName);
    }
}