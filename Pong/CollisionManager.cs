using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class CollisionManager
    {
        public List<Player> PlayerList = new List<Player>();
        public List<PongBall> PongBallList = new List<PongBall>();
        
        public CollisionManager()
        { 

        }

        public void Update(GameTime gameTime)
        {
            foreach (Player player in PlayerList) 
            {
                foreach (PongBall pongBall in PongBallList)
                {
                    pongBall.CheckPlayerCollision(player);
                }
            }           
        }

    }
}
