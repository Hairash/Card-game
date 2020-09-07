using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_game
{
    class Deck
    {
        //int num_of_cards;
        List<Card> cards = new List<Card>();

        public Deck(int num_of_cards = 60)
        {
            //this.num_of_cards = num_of_cards;
            CardGenerator card_gen = new CardGenerator();

            for (int i = 0; i < num_of_cards; ++i)
            {
                Card card = card_gen.new_card(this);
                cards.Add(card);
            }
        }

        public Card get_card()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public bool is_empty()
        {
            if (cards.Count == 0) { return true; }
            else { return false; }
        }

        public int cards_left()
        {
            return cards.Count;
        }
    }
}
