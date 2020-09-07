using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Card_game
{
    public partial class FormMain : Form
    {
        Game game;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            game = new Game(this);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Player cur_player = game.players[game.cur_player_id];
            int another_player_id = (game.cur_player_id + 1) % 2;
            Player another_player = game.players[another_player_id];

            int selected_card_id = Int32.Parse(txtInput.Text);
            game.AddLog(cur_player.cards[selected_card_id].play(cur_player, another_player));
            cur_player.cards.RemoveAt(selected_card_id);

            game.AddLog();
            game.AddLog("After playing card");
            game.show_players();

            game.AddLog();

            game.cur_player_id = another_player_id;
            ++game.round;
            game.new_round(game.round);
        }
    }
}
