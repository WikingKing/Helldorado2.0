using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace movement_player_
{
    class Player
    {

        Texture2D texture;
        Rectangle rectangle;
        Vector2 MoveDir;
        Vector2 postition;
        Vector2 scale;
        Vector2 offset;
        Color color;
        float speed;
        float rotation;

        public  Player(Texture2D playeterxture, Vector2 playerStartPos, float playerspeed, Vector2 playerScale, float playerRotation, Color playerColor)
        {
            texture = playeterxture;
            postition = playerStartPos;
            speed = playerspeed;
            rotation = playerRotation;
            color = playerColor;
            scale = playerScale;
            MoveDir = Vector2.Zero;
            offset = (playeterxture.Bounds.Size.ToVector2() / 2.0f) * scale;
            rectangle = new Rectangle((playerStartPos - offset).ToPoint(), (playeterxture.Bounds.Size.ToVector2() * playerScale).ToPoint());

        }
    }
}
