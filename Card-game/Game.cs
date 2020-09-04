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
            Console.WriteLine("Game show");
            for (int i = 0; i < players.Count; ++i)
            {
                players[i].show();
            }
        }

        void start()
        {
            Console.WriteLine("Game start");
            int round = 0;
            while (round < 10)
            {
                //players[cur_player].show();
                Console.Write("Player: ");
                Console.WriteLine(cur_player);
                cur_player += 1;
                cur_player %= 2;

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

        public Player(int id)
        {
            this.id = id;
            Random random = new Random();
            hp = 10 + random.Next(10);
            damage = 1 + random.Next(5);
            healing = random.Next(5);
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
        void attack()
        {

        }
    }
}
