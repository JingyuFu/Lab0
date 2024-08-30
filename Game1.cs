using Lab0.Commands;
using Lab0.Controllers;
using Lab0.Interfaces;
using Lab0.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Lab0
{
    public class Game1 : Game
    {
        private IController keyboardController;
        private IController mouseController;
        private ISprite currentSprite;

        private ISprite staticSprite;
        private ISprite animatedSprite;
        private ISprite movingSprite;
        private ISprite movingAnimatedSprite;
        private ISprite textSprite;


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;

            Texture2D staticTexture = Content.Load<Texture2D>("Luigi_Standing");

            Texture2D[] animatedTextures = {
                Content.Load<Texture2D>("Luigi_Standing"),
                Content.Load<Texture2D>("Luigi_Jumping")
                //
            };
            Texture2D movingTexture = Content.Load<Texture2D>("Luigi_Death");

            Texture2D[] movingAnimatedTextures = {
                Content.Load<Texture2D>("Luigi_Standing"),
                Content.Load<Texture2D>("Luigi_Jumping")
                //
            };

            SpriteFont font = Content.Load<SpriteFont>("Luigi_Font");


            Vector2 centerPosition = new Vector2(
                (screenWidth - staticTexture.Width) / 2,
                (screenHeight - staticTexture.Height) / 2
            );
            Vector2 textPosition = new Vector2(
                screenWidth / 4,
                screenHeight * 3 / 4  // Text will be put on the lower half of the screen
            );

            // Initialize sprites
            staticSprite = new StaticSprite(staticTexture, centerPosition);
            animatedSprite = new AnimatedSprite(animatedTextures, centerPosition, 10); // changes frames every 10 updates
            movingSprite = new MovingSprite(movingTexture, centerPosition, new Vector2(0, 1));
            movingAnimatedSprite = new MovingAnimatedSprite(movingAnimatedTextures, centerPosition, new Vector2(1, 0), 10, screenWidth);// moves right with velocity=1 and changes frame every 10 updates 
            textSprite = new TextSprite(
                "Credits:\nProgram made by:Jingyu Fu\nSprites from: https://www.mariowiki.com/Gallery:Luigi_sprites_and_models\n", 
                font, 
                textPosition
            );


            // Set the initial sprite
            currentSprite = staticSprite;

            // Load the controllers
            keyboardController = new KeyboardController(this, staticSprite, animatedSprite, movingSprite, movingAnimatedSprite);
            mouseController = new MouseController(this, staticSprite, animatedSprite, movingSprite, movingAnimatedSprite);


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            keyboardController.Update();
            mouseController.Update();
            currentSprite.Update(gameTime);
   

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            currentSprite.Draw(_spriteBatch);
            textSprite.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SetCurrentSprite(ISprite sprite)
        {
            currentSprite = sprite;
        }
    }
}
