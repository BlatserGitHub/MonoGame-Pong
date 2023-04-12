using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class InputManager
    {
        private Player Player1;
        private Player Player2;
        private Input Player1_Inputs = new Input() { Up = Keys.W, Down = Keys.S };
        private Input Player2_Inputs = new Input() { Up = Keys.I, Down = Keys.K };
        public InputManager(Player player1, Player player2) 
        {
            Player1 = player1; { Player1.PlayerInputs = Player1_Inputs; }
            Player2 = player2; { Player2.PlayerInputs = Player2_Inputs; }
        }

        public void ProcessControls(GameTime gameTime)
        {
            KeyboardState KeyState = Keyboard.GetState();

            Player1.MovePlayer(Player1_Inputs, KeyState, gameTime);
            Player2.MovePlayer(Player2_Inputs, KeyState, gameTime);
            
        }

    }
}
