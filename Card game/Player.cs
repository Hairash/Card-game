using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_game
{
    class Player
    {
        public int id;
        int hp;
        public List<Card> cards = new List<Card>();
        public Actions actions;
        Game game;

        // hp display
        System.Windows.Forms.Label lblHp;

        // cards display
        System.Windows.Forms.Panel pnlCards;
        int card_x_start = 0;
        int card_x_shift = Card.size_x + 10;
        int card_y = 0;

        public Player(Game game, System.Windows.Forms.Label lblHp, System.Windows.Forms.Panel pnlCards, int id)
        {
            this.game = game;
            this.id = id;
            hp = 10 + GameRandom.random.Next(10);

            this.lblHp = lblHp;
            this.pnlCards = pnlCards;

            actions = new Actions(this);
        }

        public void add_card(Card card)
        {
            cards.Add(card);
        }

        public int get_hp()
        {
            return hp;
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
            // show hp
            lblHp.Text = hp.ToString();

            // show cards
            pnlCards.Controls.Clear();
            int x = card_x_start;
            int y = card_y;
            foreach (var card in cards)
            {
                create_card_label(card, x, y);
                x += card_x_shift;
            }
        }

        void create_card_label(Card card, int x, int y)
        {
            var lblCard = new System.Windows.Forms.Label();
            lblCard.Text = card.get_info();
            lblCard.Location = new System.Drawing.Point(x, y);
            lblCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblCard.Size = new System.Drawing.Size(Card.size_x, Card.size_y);
            lblCard.Tag = card;
            lblCard.Click += new System.EventHandler(game.lblCard_Click);
            pnlCards.Controls.Add(lblCard);
        }

        public void EnableCards()
        {
            pnlCards.Enabled = true;
        }

        public void DisableCards()
        {
            pnlCards.Enabled = false;
        }
    }


    class Actions
    {
        Player self;

        public Actions(Player self)
        {
            this.self = self;
        }
    }
}
