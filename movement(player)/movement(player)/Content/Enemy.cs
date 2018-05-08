using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace movement_player_.Content
{
    class Enemy
    {
        Texture2D texture;
        Rectangle rectangle;
        Vector2 moveDir;
        Vector2 postion;
        Vector2 scale;
        Vector2 offset;
        Color color;
        float Speed;
        float Rotation;

        public Enemy(Texture2D enemyTexture, Vector2 enemyStartPos, float enemySpeed, Vector2 enemyScale, float enemyRotation, Color enemyColor)
        {

        }

    }
}
