using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace movement_player_
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Bannanatextur;
        Rectangle Bannanarectangle;
        Vector2 MoveDir;
        Vector2 position;
        Vector2 scale;
        Vector2 offset;
        Color BannanaColor;
        float rotation;
        float speed;
        Texture2D walltextur;
        Rectangle wallRectange;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            IsMouseVisible = true;
            speed = 300;
            Bannanarectangle = Bannanatextur.Bounds;
            position = new Vector2(100, 100);
            MoveDir = Vector2.Zero;
            rotation = 0;
            scale = new Vector2(1, 1);
            BannanaColor = Color.White;
            offset = (Bannanatextur.Bounds.Size.ToVector2() / 2.0f) * scale;
            Bannanarectangle = new Rectangle((position - offset).ToPoint(), (Bannanatextur.Bounds.Size.ToVector2() * scale).ToPoint());
            wallRectange = walltextur.Bounds;
        }
        protected override void LoadContent()
        {
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Bannanatextur = Content.Load<Texture2D>("Bannana");
            walltextur = Content.Load<Texture2D>("wall123");
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            MouseState mousestate = Mouse.GetState();
            Vector2 mousePos = mousestate.Position.ToVector2();
            MoveDir = mousePos - position;
            float pixelstoMove = speed * deltaTime;
            if( MoveDir != Vector2.Zero)
            {
                MoveDir.Normalize();

                rotation = (float)Math.Atan2(MoveDir.Y, MoveDir.X);
                if(Vector2.Distance(position, mousePos) < pixelstoMove)
                {
                    position = mousePos;
                }
                else
                {
                    position += MoveDir * pixelstoMove;
                }
                Bannanarectangle.Location = (position - offset).ToPoint();
            }
            BannanaColor = Color.White;
            if(Bannanarectangle.Intersects(wallRectange))
            {
                BannanaColor = Color.Blue;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(walltextur, wallRectange, Color.White);
            spriteBatch.Draw(Bannanatextur, position, null, BannanaColor, rotation, offset, scale, SpriteEffects.None, 0);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
