﻿using System;
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

        public void add_card(Card card)
        {
            cards.Add(card);
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

        public string show()
        {
            string message = "";
            message += $"Player: {id}\n";
            message += $"HP: {hp}\n";
            foreach (Card card in cards)
            {
                message += card.show();
            }
            return message;
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
