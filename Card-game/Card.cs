using System;

namespace Card_game
{
    abstract class Card
    {
        public Card() { }

        virtual public void show()
        {
            Console.WriteLine("Card base show");
        }

        abstract public void play(Player owner, Player enemy);
    }

    class Attack : Card
    {
        int damage;

        public Attack()
        {
            Random random = new Random();
            damage = 1 + random.Next(5);
        }

        override public void play(Player owner, Player enemy)
        {
            enemy.lose_hp(damage);
        }

        override public void show()
        {
            Console.WriteLine($"Attacking card: {damage}");
        }
    }

    class Heal : Card
    {
        int healing;

        public Heal()
        {
            Random random = new Random();
            healing = random.Next(5);
        }

        override public void play(Player owner, Player enemy)
        {
            owner.add_hp(healing);
        }
        
        override public void show()
        {
            Console.WriteLine($"Healing card: {healing}");
        }
    }

    class CardGenerator
    {
        public Card new_card()
        {
            Random random = new Random();
            int card_type = random.Next(2);

            Card card;

            switch (card_type)
            {
                case 0:
                    card = new Attack();
                    break;
                default:
                    card = new Heal();
                    break;
            }

            return card;
        }
    }
}
