﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_game
{
    class Deck
    {
        List<Card> cards = new List<Card>();

        public Deck(int num_of_cards, int cards_on_hand)
        {
            CardGenerator card_gen = new CardGenerator();

            for (int i = 0; i < num_of_cards; ++i)
            {
                Card card = card_gen.new_card(this, cards_on_hand);
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
