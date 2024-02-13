using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CupidGame;

public class Sprite
{
    public Vector2 Position { get; set; }
    private Texture2D _texture;
    public int _zIndex;

    public Sprite(Texture2D texture, Vector2 position, int zIndex)
    {
        _texture = texture;
        Position = position;
        _zIndex = zIndex;
    }

    public void Render(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Position, Color.White);
    }
}