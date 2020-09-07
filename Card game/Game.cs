using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Card_game
{
    // TODO: Refactor
    // Make Card just a struct with different parameters (e.g. type)
    // Add .play_card() method to the Game
    class Game
    {
        FormMain form;
        public List<Player> players;
        Deck deck;
        public int cur_player_id;
        int cards_on_hand;
        public int round;

        public Game(FormMain form, int num_of_players = 2, int cards_in_deck = 60)
        {
            this.form = form;
            deck = new Deck(cards_in_deck);
            cards_on_hand = 3;

            var labelsHP = new List<System.Windows.Forms.Label>() { form.lblHp0, form.lblHp1 };
            var panelsCards = new List<System.Windows.Forms.Panel>() { form.pnlCards0, form.pnlCards1 };

            players = new List<Player>();
            for (int i = 0; i < num_of_players; ++i)
            {
                Player player = new Player(this, labelsHP[i], panelsCards[i], i);

                // give start cards to each player
                for (int j = 0; j < cards_on_hand; ++j)
                {
                    Card card = deck.get_card();
                    player.add_card(card);
                }

                players.Add(player);
            }

            cur_player_id = 0;
            show_players();

            start();
        }

        public void AddLog(params string[] messages)
        {
            foreach (var m in messages)
            {
                form.txtLog.AppendText(m);
            }
            form.txtLog.AppendText(Environment.NewLine);
        }

        public void show_players()
        {
            for (int i = 0; i < players.Count; ++i)
            {
                players[i].show();
            }
        }

        void start()
        {
            AddLog();
            AddLog("Game start");

            round = 0;
            new_round(round);
        }

        public void new_round(int round)
        {
            if (!end_game())
            {
                AddLog();
                AddLog($"Round: {round}. Player: {cur_player_id}");

                Player cur_player = players[cur_player_id];
                int another_player_id = (cur_player_id + 1) % 2;
                Player another_player = players[another_player_id];

                // get new card
                Card card = deck.get_card();
                cur_player.add_card(card);
                AddLog($"Cards left: {deck.cards_left()}");

                show_players();
                // waiting for click
            }
            else
            {
                show_winner();
            }
        }

        public void lblCard_Click(object sender, EventArgs e)
        {
            Player cur_player = players[cur_player_id];
            int another_player_id = (cur_player_id + 1) % 2;
            Player another_player = players[another_player_id];

            var cur_card = ((sender as Label).Tag as Card);
            AddLog(cur_card.play(cur_player, another_player));
            cur_player.cards.Remove(cur_card);

            show_players();

            cur_player_id = another_player_id;
            ++round;
            new_round(round);
        }

        bool end_game()
        {
            if (deck.is_empty())
            {
                AddLog("Deck is over");
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
            AddLog();
            AddLog("End of game");
            bool winner_found = false;
            for (int i = 0; i < players.Count; ++i)
            {
                if (players[i].get_hp() <= 0)
                {
                    AddLog($"Player {(i + 1) % 2} wins");
                    winner_found = true;
                };
            }
            if (!winner_found) { AddLog("Draw"); }
        }
    }
}
