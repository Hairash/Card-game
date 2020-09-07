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

        System.Windows.Forms.Label lblHp;

        public Player(System.Windows.Forms.Label lblHp, int id)
        {
            this.id = id;
            hp = 10 + GameRandom.random.Next(10);

            this.lblHp = lblHp;

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
            //string message = "";
            //message += $"Player: {id}\n";
            //message += $"HP: {hp}\n";
            //foreach (Card card in cards)
            //{
            //    message += card.show();
            //}
            //return message;
            lblHp.Text = hp.ToString();
        }
    }


    class Actions
    {
        Player self;

        public Actions(Player self)
        {
            this.self = self;
        }

        //public void attack(Player opponent)
        //{
        //    opponent.lose_hp(self.get_damage());
        //}

        //public void heal()
        //{
        //    self.add_hp(self.get_healing());
        //}
    }
}
