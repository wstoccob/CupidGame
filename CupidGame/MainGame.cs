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

    private Sprite _yesButton;
    private Sprite _noButton;

    private Vector2 _heartOneStartPosition;
    private Vector2 _heartTwoStartPosition;

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

        _heartOneStartPosition = new Vector2(-200, 400);
        _heartTwoStartPosition = new Vector2(1100, -200);
        
        _canvas = new Canvas(_graphics.GraphicsDevice, 1920, 1080);
        _spriteList = new List<Sprite>();
        _mainMenu = new Sprite(LoadTexture("mainMenu"), new Vector2(0, 0), 0);
        _heartOne = new Sprite(LoadTexture("heart"), _heartOneStartPosition, 4);
        _heartTwo = new Sprite(LoadTexture("heart"), _heartTwoStartPosition, 4);
        _menuText = new Sprite(LoadTexture("menuText"), new Vector2(754, 500), 2);

        _yesButton = new Sprite(LoadTexture("yesButton"), new Vector2(961, 552), 6);
        _noButton = new Sprite(LoadTexture("noButton"), new Vector2(860, 552), 6);
        
        _canvas.SetDestinationRectangle();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _spriteList.Add(_mainMenu);
        _spriteList.Add(_heartOne);
        _spriteList.Add(_heartTwo);
        _spriteList.Add(_menuText);
        _spriteList.Add(_yesButton);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        MoveHeart(_heartOne, _heartOneStartPosition);
        MoveHeart(_heartTwo, _heartTwoStartPosition);

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

    private void MoveHeart(Sprite heart, Vector2 startPosition)
    {
        int movingSpeed = 5;

        heart.Position = new Vector2(heart.Position.X + movingSpeed, heart.Position.Y + movingSpeed);

        if (heart.Position.Y >= 1200 || heart.Position.X >= 2100)
        {
            heart.Position = new Vector2(startPosition.X, startPosition.Y);
        }
        
    }
}