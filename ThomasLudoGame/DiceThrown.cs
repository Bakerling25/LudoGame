using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasLudoGame
{
    class DiceThrown
    {
        private int diceNum;
        public int DiceNum(int diceNum)
        {
            Random random = new Random();
            diceNum = random.Next(1, 7);
            return diceNum;
        }
    }
}
