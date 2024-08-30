using Lab0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0.Commands
{
    public class SpriteCommand : ICommand
    {
        private readonly ISprite sprite;
        private readonly Game1 game;

        public SpriteCommand(Game1 game, ISprite sprite)
        {
            this.game = game;
            this.sprite = sprite;
        }

        public void Execute()
        {
            game.SetCurrentSprite(sprite);
        }
    }
}
