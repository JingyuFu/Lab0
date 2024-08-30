using Lab0.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Reference: http://rbwhitaker.wikidot.com/monogame-texture-atlases-3
namespace Lab0.Sprites
{
    public class AnimatedSprite : ISprite
    {
        private readonly Texture2D[] frames;
        private readonly Vector2 position;
        private int currentFrame;
        private int frameCounter;
        private readonly int framesPerUpdate;

        public AnimatedSprite(Texture2D[] frames, Vector2 position, int framesPerUpdate)
        {
            this.frames = frames;
            this.position = position;
            currentFrame = 0;
            this.framesPerUpdate = framesPerUpdate; // How often to change the frame, for example 10 means it changes frame every 10 updates
            frameCounter = 0;
        }

        public void Update(GameTime gameTime)
        {
            frameCounter++;

            if (frameCounter >= framesPerUpdate)
            {
                currentFrame = (currentFrame + 1) % frames.Length;
                frameCounter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(frames[currentFrame], position, Color.White);
        }
    }
}
