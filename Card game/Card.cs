using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_game
{
    abstract class Card
    {
        public Card() { }

        virtual public string show()
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
            Random random = new Random();
            damage = 1 + random.Next(5);
        }

        override public string play(Player owner, Player opponent)
        {
            opponent.lose_hp(damage);
            return $"Player {opponent.id} losses {damage} hp";
        }

        override public string show()
        {
            return $"Attacking card: {damage}";
        }
    }

    class Heal : Card
    {
        int healing;

        public Heal()
        {
            Random random = new Random();
            healing = 1 + random.Next(4);
        }

        override public string play(Player owner, Player opponent)
        {
            owner.add_hp(healing);
            return $"Player {owner.id} gains {healing} hp";
        }

        override public string show()
        {
            return $"Healing card: {healing}";
        }
    }

    class Draw : Card
    {
        Deck deck;
        int amount;

        public Draw(Deck deck)
        {
            this.deck = deck;
            Random random = new Random();
            amount = 2 + random.Next(3);
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

        override public string show()
        {
            return $"Draw card: {amount}";
        }
    }

    class Drop : Card
    {
        int amount;

        public Drop()
        {
            Random random = new Random();
            amount = 1 + random.Next(3);
        }

        override public string play(Player owner, Player opponent)
        {
            int i;
            Random random = new Random();
            for (i = 0; i < amount; ++i)
            {
                if (opponent.cards.Count == 0) { break; }
                var rand_id = random.Next(opponent.cards.Count);
                opponent.cards.RemoveAt(rand_id);
            }
            return $"Player {opponent.id} drops {i} cards";
        }

        override public string show()
        {
            return $"Drop card: {amount}";
        }
    }

    class CardGenerator
    {
        public Card new_card(Deck deck)
        {
            Random random = new Random();
            int card_type = random.Next(10);

            Card card;

            switch (card_type)
            {
                case int n when n < 4:
                    card = new Attack();
                    break;
                case int n when n < 8:
                    card = new Heal();
                    break;
                case int n when n < 9:
                    card = new Draw(deck);
                    break;
                default:
                    card = new Drop();
                    break;
            }

            return card;
        }
    }
}
