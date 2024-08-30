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
    public class MovingAnimatedSprite : ISprite
    {
        private readonly Texture2D[] frames;
        private Vector2 position;
        private Vector2 velocity;
        private int currentFrame;
        private int frameCounter;
        private readonly int framesPerUpdate;

        private readonly int screenWidth;
        //private readonly int screenHeight;

        public MovingAnimatedSprite(Texture2D[] frames, Vector2 position, Vector2 velocity, int framesPerUpdate, int screenWidth)
        {
            this.frames = frames;
            this.position = position;
            this.velocity = velocity;
            this.framesPerUpdate = framesPerUpdate;
            this.screenWidth = screenWidth;
            frameCounter = 0;
            currentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {
 
            position += velocity;

            // Check for boundaries and reverse direction if necessary
            if (position.X < 0 || position.X > screenWidth - frames[0].Width)
            {
                velocity.X = -velocity.X; // Reverse direction
            }

            // Use this if the object has velocity on y direction, could be useful later
            // 
            //if (position.Y < 0 || position.Y > screenHeight - frames[0].Height)
            //{
            //    velocity.Y = -velocity.Y; // Reverse direction
            //}

            // Frame update
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
