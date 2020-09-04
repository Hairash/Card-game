using System;
using System.Collections.Generic;

namespace Card_game
{
    public class CardGame
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
    public class Game
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
            show();

            start();
        }

        void show()
        {
            Console.WriteLine("Game show");
            for (int i = 0; i < players.Count; ++i)
            {
                players[i].show();
            }
        }

        void start()
        {
            Console.WriteLine("Game");
            int round = 0;
            while (round < 10)
            {
                players[cur_player].show();
                cur_player += 1;
                cur_player %= 2;

                ++round;
            }
        }
    }

    public class Player
    {
        int id;

        public Player(int id)
        {
            this.id = id;
        }

        public void show()
        {
            Console.Write("Player: ");
            Console.WriteLine(id);
        }
    }
}
