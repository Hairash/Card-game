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

    // TODO: Refactor
    // Make Card just a struct with different parameters (e.g. type)
    // Add .play_card() method to the Game
    class Game
    {
        List<Player> players;
        Deck deck = new Deck();
        int cur_player_id;
        int cards_per_round;
        
        public Game(int num_of_players)
        {
            players = new List<Player>();
            for (int i = 0; i < num_of_players; ++i)
            {
                Player player = new Player(i);
                players.Add(player);
            }
            cur_player_id = 0;
            cards_per_round = 3;
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
            // Game cycle
            Console.WriteLine("\nGame start");

            //CardGenerator card_gen = new CardGenerator();

            int round = 0;
            while (!end_game())
            {
                Console.WriteLine($"Round: {round}. Player: {cur_player_id}");

                int another_player_id = (cur_player_id + 1) % 2;

                // generate some cards for choice
                Console.WriteLine("Choose card: ");
                List<Card> current_cards = new List<Card>();
                for (int i = 0; i < cards_per_round; ++i)
                {
                    Card card = deck.get_card();
                    Console.Write($"{i}) ");
                    card.show();
                    current_cards.Add(card);
                    //card.play();
                }

                int selected_card_id = Int32.Parse(Console.ReadLine());
                current_cards[selected_card_id].play(players[cur_player_id], players[another_player_id]);

                //Console.WriteLine("Choose action: ");
                //Console.WriteLine("0) Attack");
                //Console.WriteLine("1) Heal");
                //int action = Int32.Parse(Console.ReadLine());

                //switch (action)
                //{
                //    case 0:
                //        Console.WriteLine("Attack");
                //        players[cur_player].actions.attack(players[another_player]);
                //        break;
                //    case 1:
                //        Console.WriteLine("Heal");
                //        players[cur_player].actions.heal();
                //        break;
                //}
                Console.WriteLine();
                Console.WriteLine("After playing card");
                show_players();

                Console.WriteLine();
                
                cur_player_id = another_player_id;
                ++round;
            }

            Console.WriteLine($"End of game. Player {(cur_player_id + 1) % 2} wins");
        }

        bool end_game()
        {
            for (int i = 0; i < players.Count; ++i)
            {
                if (players[i].get_hp() <= 0) { return true; };
            }
            return false;
        }
    }
}
