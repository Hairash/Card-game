using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_game
{
    abstract class Card
    {
        static public int size_x = 50;
        static public int size_y = 70;
        public Card() { }

        virtual public string get_info()
        {
            return "Card base show";
        }

        abstract public string play(Player owner, Player opponent);
    }

    class Attack : Card
    {
        int damage;

        public Attack()
        {
            damage = 1 + GameRandom.random.Next(5);
        }

        override public string play(Player owner, Player opponent)
        {
            opponent.lose_hp(damage);
            return $"Player {opponent.id} losses {damage} hp";
        }

        override public string get_info()
        {
            return $"Attacking card: {damage}";
        }
    }

    class Heal : Card
    {
        int healing;

        public Heal()
        {
            healing = 1 + GameRandom.random.Next(4);
        }

        override public string play(Player owner, Player opponent)
        {
            owner.add_hp(healing);
            return $"Player {owner.id} gains {healing} hp";
        }

        override public string get_info()
        {
            return $"Healing card: {healing}";
        }
    }

    class Draw : Card
    {
        Deck deck;
        int amount = 2;

        public Draw(Deck deck)
        {
            this.deck = deck;
        }

        override public string play(Player owner, Player opponent)
        {
            int i;
            for (i = 0; i < amount; ++i)
            {
                if (deck.is_empty()) { break; }
                var card = deck.get_card();
                owner.cards.Add(card);
            }
            return $"Player {owner.id} draws {i} cards";
        }

        override public string get_info()
        {
            return $"Draw card: {amount}";
        }
    }

    class Drop : Card
    {
        int amount;

        public Drop()
        {
            amount = 1 + GameRandom.random.Next(3);
        }

        override public string play(Player owner, Player opponent)
        {
            int i;
            for (i = 0; i < amount; ++i)
            {
                if (opponent.cards.Count == 0) { break; }
                var rand_id = GameRandom.random.Next(opponent.cards.Count);
                opponent.cards.RemoveAt(rand_id);
            }
            return $"Player {opponent.id} drops {i} cards";
        }

        override public string get_info()
        {
            return $"Drop card: {amount}";
        }
    }

    class Change : Card
    {
        Deck deck;
        int amount;

        public Change(Deck deck, int amount)
        {
            this.deck = deck;
            this.amount = amount;
        }

        override public string play(Player owner, Player opponent)
        {
            owner.cards.Clear();
            int i;
            for (i = 0; i < amount; ++i)
            {
                if (deck.is_empty()) { break; }
                var card = deck.get_card();
                owner.cards.Add(card);
            }
            return $"Player {owner.id} drops all cards and then draws {i} cards";
        }

        override public string get_info()
        {
            return $"Change card: {amount}";
        }
    }

    class CardGenerator
    {
        public Card new_card(Deck deck, int cards_on_hand)
        {
            int card_type = GameRandom.random.Next(21);

            Card card;

            switch (card_type)
            {
                case int n when n < 8:
                    card = new Attack();
                    break;
                case int n when n < 16:
                    card = new Heal();
                    break;
                case int n when n < 18:
                    card = new Draw(deck);
                    break;
                case int n when n < 20:
                    card = new Drop();
                    break;
                default:
                    card = new Change(deck, cards_on_hand);
                    break;
            }

            return card;
        }
    }
}
