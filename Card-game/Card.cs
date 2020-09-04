using System;

namespace Card_game
{
    abstract class Card
    {
        protected Player owner, enemy;

        public Card(Player owner, Player enemy)
        {
            this.owner = owner;
            this.enemy = enemy;
        }

        virtual public void show()
        {
            Console.WriteLine("Card base show");
        }

        abstract public void play();
    }

    class Attack : Card
    {
        int damage;

        public Attack(Player owner, Player enemy): base(owner, enemy)
        {
            Random random = new Random();
            damage = 1 + random.Next(5);
        }

        override public void play()
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

        public Heal(Player owner, Player enemy) : base(owner, enemy)
        {
            Random random = new Random();
            healing = random.Next(5);
        }

        override public void play()
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
        public Card new_card(Player owner, Player enemy)
        {
            Random random = new Random();
            int card_type = random.Next(2);

            Card card;

            switch (card_type)
            {
                case 0:
                    card = new Attack(owner, enemy);
                    break;
                default:
                    card = new Heal(owner, enemy);
                    break;
            }

            return card;
        }

        //public CardGenerator()
        //{
            
        //}
    }
}
