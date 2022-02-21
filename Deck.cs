using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace HFCS_Ch8_TwoDecksWPF
{
     class Deck : ObservableCollection<Card>
     {
		private readonly List<Card> cards = new();
          private static readonly Random random = new();

          public Deck()
          {
			Reset();
          }

		public void Shuffle()
		{
			List<Card> copy = new(this);
			Clear();
			for (int i = 0; i < copy.Count; i++)
			{
				int index = random.Next(0, copy.Count);
				Card card = copy[index];
				copy.RemoveAt(index);
				Add(card);
			}
		}

		public void Sort()
		{
			List<Card> sortedCards = new(this);
			sortedCards.Sort(new CardComparerByValue());

			Clear();
			foreach(Card card in sortedCards)
			{
				Add(card);
			}
		}

		public void Reset()
		{
			Clear();
			for (int suit = 0; suit < 4; suit++)
			{
				for (int value = 1; value <= 13; value++)
					cards.Add(new Card((Values)value, (Suits)suit));
			}

		}

		public Card Deal(int index)
		{
			Card cardToDeal = base[index];
			RemoveAt(index);
			return cardToDeal;
		}
	}
}
