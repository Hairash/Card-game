using System;

namespace Card_game
{
    class Player
    {
        int id;
        int hp;
        //int damage;
        //int healing;

        public Actions actions;

        public Player(int id)
        {
            this.id = id;
            Random random = new Random();
            hp = 10 + random.Next(10);
            //damage = 1 + random.Next(5);
            //healing = random.Next(5);

            actions = new Actions(this);
        }

        public int get_hp()
        {
            return hp;
        }

        //public int get_damage()
        //{
        //    return damage;
        //}

        //public int get_healing()
        //{
        //    return healing;
        //}

        public void lose_hp(int n)
        {
            hp -= n;
        }

        public void add_hp(int n)
        {
            hp += n;
        }

        public void show()
        {
            Console.WriteLine($"Player: {id}");
            Console.WriteLine($"HP: {hp}");
            //Console.WriteLine($"damage: {damage}");
            //Console.WriteLine($"healing: {healing}");
        }
    }


    class Actions
    {
        Player self;

        public Actions(Player self)
        {
            this.self = self;
        }

        //public void attack(Player enemy)
        //{
        //    enemy.lose_hp(self.get_damage());
        //}

        //public void heal()
        //{
        //    self.add_hp(self.get_healing());
        //}
    }
}
