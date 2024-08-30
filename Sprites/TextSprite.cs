using Lab0.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0.Sprites
{
    public class TextSprite : ISprite
    {
        private readonly string text;
        private readonly SpriteFont font;
        private readonly Vector2 position;

        public TextSprite(string text, SpriteFont font, Vector2 position)
        {
            this.text = text;
            this.font = font;
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, Color.White);
        }
    }
}
