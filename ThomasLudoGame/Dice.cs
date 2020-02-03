using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class Dice
    {
        private static int diceNum;
        public int ThrowDice()
        {
            Random random = new Random();
            diceNum = random.Next(1, 7);
            return diceNum;
        }
    }
}
