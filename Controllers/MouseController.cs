using Lab0.Interfaces;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0.Controllers
{
    public class MouseController : IController
    {
        private readonly Game1 game;
        private readonly ISprite sprite1;
        private readonly ISprite sprite2;
        private readonly ISprite sprite3;
        private readonly ISprite sprite4;

        public MouseController(Game1 game, ISprite staticSprite, ISprite animatedSprite, ISprite movingSprite, ISprite movingAnimatedSprite)
        {
            this.game = game;
            sprite1 = staticSprite;
            sprite2 = animatedSprite;
            sprite3 = movingSprite;
            sprite4 = movingAnimatedSprite;
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();

            int screenWidth = game.GraphicsDevice.Viewport.Width;
            int screenHeight = game.GraphicsDevice.Viewport.Height;

            if (mouseState.LeftButton == ButtonState.Pressed)
            {


                if (mouseState.X < screenWidth / 2 && mouseState.Y < screenHeight / 2)
                {
                    // Top left quarter - display sprite 1
                    game.SetCurrentSprite(sprite1);
                }
                else if (mouseState.X >= screenWidth / 2 && mouseState.Y < screenHeight / 2)
                {
                    // Top right quarter - display sprite 2
                    game.SetCurrentSprite(sprite2);
                }
                else if (mouseState.X < screenWidth / 2 && mouseState.Y >= screenHeight / 2)
                {
                    // Bottom left quarter - display sprite 3
                    game.SetCurrentSprite(sprite3);
                }
                else if (mouseState.X >= screenWidth / 2 && mouseState.Y >= screenHeight / 2)
                {
                    // Bottom right quarter - display sprite 4
                    game.SetCurrentSprite(sprite4);
                }
            }

            if (mouseState.RightButton == ButtonState.Pressed)
            {
                game.Exit();
            }
        }

        public void ProcessInput()
        {

        }
    }
}
