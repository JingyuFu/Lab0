using Lab0.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Reference: http://rbwhitaker.wikidot.com/monogame-texture-atlases-2
namespace Lab0.Sprites
{
    public class StaticSprite : ISprite
    {
        private readonly Texture2D texture;
        private readonly Vector2 position;

        public StaticSprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}