using System;
using System.Collections.Generic;

namespace Card_game
{
    class CardGame
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------------------");
            Console.WriteLine("App start");
            Game game = new Game(2);
        }
    }

    class Game
    {
        List<Player> players;
        int cur_player;

        public Game(int num_of_players)
        {
            players = new List<Player>();
            for (int i = 0; i < num_of_players; ++i)
            {
                Player player = new Player(i);
                players.Add(player);
            }
            cur_player = 0;
            show_players();

            start();
        }

        void show_players()
        {
            //Console.WriteLine();
            for (int i = 0; i < players.Count; ++i)
            {
                players[i].show();
            }
        }

        void start()
        {
            Console.WriteLine(); Console.WriteLine("Game start");
            int round = 0;
            while (round < 10)
            {
                Console.Write("Round: "); Console.WriteLine(round);
                Console.WriteLine();
                show_players();
                //players[cur_player].show();
                Console.Write("Player: "); Console.WriteLine(cur_player);

                int another_player = (cur_player + 1) % 2;
                Random random = new Random();
                int action = random.Next(2);

                switch (action) {
                    case 0:
                        Console.WriteLine("Attack");
                        players[cur_player].actions.attack(players[another_player]);
                        break;
                    case 1:
                        Console.WriteLine("Heal");
                        players[cur_player].actions.heal();
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("After action");
                show_players();

                Console.WriteLine();
                
                cur_player = another_player;
                //cur_player += 1;
                //cur_player %= 2;
                ++round;
            }
        }
    }

    class Player
    {
        int id;
        int hp;
        int damage;        
        int healing;

        public Actions actions;

        public Player(int id)
        {
            this.id = id;
            Random random = new Random();
            hp = 10 + random.Next(10);
            damage = 1 + random.Next(5);
            healing = random.Next(5);

            actions = new Actions(this);
        }

        public int get_damage()
        {
            return damage;
        }

        public int get_healing()
        {
            return healing;
        }

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
            Console.Write("Player: ");
            Console.WriteLine(id);
            Console.Write("HP: ");
            Console.WriteLine(hp);
            Console.Write("damage: ");
            Console.WriteLine(damage);
            Console.Write("healing: ");
            Console.WriteLine(healing);
        }
    }

    class Actions
    {
        Player self;

        public Actions(Player self)
        {
            this.self = self;
        }

        public void attack(Player enemy)
        {
            enemy.lose_hp(self.get_damage());
        }

        public void heal()
        {
            self.add_hp(self.get_healing());
        }
    }
}
