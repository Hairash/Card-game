using System;
using System.Collections.Generic;

namespace Card_game
{
    class CardGame
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\n\n\n\n\n------------------------");
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
        Deck deck = new Deck(60);
        int cur_player_id;
        int cards_on_hand;
        
        public Game(int num_of_players)
        {
            cards_on_hand = 3;

            players = new List<Player>();
            for (int i = 0; i < num_of_players; ++i)
            {
                Player player = new Player(i);

                // give start cards to each player
                for (int j = 0; j < cards_on_hand; ++j)
                {
                    Card card = deck.get_card();
                    player.add_card(card);
                    //Console.WriteLine($"Num of cards: {player.cards.Count}");
                }

                players.Add(player);
            }

            cur_player_id = 0;
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
                
                Player cur_player = players[cur_player_id];
                int another_player_id = (cur_player_id + 1) % 2;
                Player another_player = players[another_player_id];

                //if (deck.is_empty()) { break; }

                Console.Write("New card: ");
                Card card = deck.get_card();
                card.show();
                cur_player.add_card(card);
                Console.WriteLine($"Cards left: {deck.cards_left()}");

                // play card from the hand
                Console.WriteLine("Choose card from: ");
                List<Card> current_cards = cur_player.cards;
                for (int i = 0; i < current_cards.Count; ++i)
                {
                    Console.Write($"{i}) ");
                    current_cards[i].show();
                }

                int selected_card_id = Int32.Parse(Console.ReadLine());
                current_cards[selected_card_id].play(cur_player, another_player);
                cur_player.cards.RemoveAt(selected_card_id);

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

            show_winner();            
        }

        bool end_game()
        {
            if (deck.is_empty())
            {
                Console.WriteLine("Deck is over");
                return true;
            }
            for (int i = 0; i < players.Count; ++i)
            {
                if (players[i].get_hp() <= 0) { return true; };
            }
            return false;
        }

        void show_winner()
        {
            Console.WriteLine("End of game");
            bool winner_found = false;
            for (int i = 0; i < players.Count; ++i)
            {
                if (players[i].get_hp() <= 0) {
                    Console.WriteLine($"Player {(i + 1) % 2} wins");
                    winner_found = true;
                };
            }
            if (!winner_found) { Console.WriteLine("Draw"); }
        }
    }
}
