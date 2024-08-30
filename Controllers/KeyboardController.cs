using Lab0.Commands;
using Lab0.Interfaces;
using Lab0.Sprites;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Reference: https://docs.monogame.net/api/Microsoft.Xna.Framework.Input.KeyboardInput.html
namespace Lab0.Controllers
{
    public class KeyboardController : IController
    {
        private readonly Dictionary<Keys, ICommand> KeyBindingMap;

        // Bind keys here
        public KeyboardController(Game1 game, ISprite staticSprite, ISprite animatedSprite, ISprite movingSprite, ISprite movingAnimatedSprite)
        {

            KeyBindingMap = new Dictionary<Keys, ICommand>();

            KeyBinding(Keys.D1, new SpriteCommand(game, staticSprite));
            KeyBinding(Keys.D2, new SpriteCommand(game, animatedSprite));
            KeyBinding(Keys.D3, new SpriteCommand(game, movingSprite));
            KeyBinding(Keys.D4, new SpriteCommand(game, movingAnimatedSprite));
            KeyBinding(Keys.D0, new QuitCommand(game));
        }

        public void KeyBinding(Keys key, ICommand command)
        {
            KeyBindingMap[key] = command;
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            foreach (var keyCommand in KeyBindingMap)
            {
                if (state.IsKeyDown(keyCommand.Key))
                {
                    keyCommand.Value.Execute();
                }
            }
        }


    }
}
