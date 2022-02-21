using System;
using System.Collections.Generic;
using System.Text;

namespace HFCS_Ch8_TwoDecksWPF
{
     class Card
     {
          public Suits Suit { get; private set; }
          public Values Value { get; private set; }

          public string Name
          {
               get => $"{ Value} of { Suit }"; 
          }


		public Card(Values value, Suits suit)
          {
               Suit = suit;
               Value = value;
          }
		public override string ToString()
		{
               return Name;
		}
	}
}
