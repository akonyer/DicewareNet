#region Includes

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace DicewareNet.Dice
{
   public class ClrRandom : IRandom
   {
      #region Fields

      private readonly CryptoRandom _rng;

      #endregion
      #region Constructor(s), Destructor, and Dispose

      public ClrRandom()
      {
         _rng = new CryptoRandom();
      }

      #endregion
      #region IRandom Members

      public long DiceRoll(int numberOfDice)
      {
         var diceRolls = new List<int>(numberOfDice);
         diceRolls.AddRange(Enumerable.Range(0, numberOfDice).Select(_ => _rng.Next(1, 7)));

         long finalNumber = 0;
         for(var power = 0; power < numberOfDice; power++)
         {
            finalNumber += (long)(diceRolls[(numberOfDice - 1) - power] * Math.Pow(10.0, power));
         }

         return finalNumber;
      }

      #endregion
   }
}