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
    private Sprite _sprite;

    public MainGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
    }

    protected override void Initialize()
    {
        _canvas = new Canvas(_graphics.GraphicsDevice, 300, 200);
        _sprite = new Sprite(Content.Load<Texture2D>("mainMenu"), new Vector2(0, 0), 0);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
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
        _spriteBatch.Begin();
        // TODO: add your drawing logic to the target
        _sprite.Render(_spriteBatch);
        _spriteBatch.End();
        _canvas.Draw(_spriteBatch);
        
        base.Draw(gameTime);
    }
}