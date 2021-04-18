using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Clarity : Artifact, IMagic
    {
        public enum Sizes {Small,Medium,Big}
        Sizes _size;
        Wizard _user;
        public Clarity(Wizard user, Sizes size) : base(0, true) {
            _user = user;
            _size = size; 
        }
        public void SpellCast(Character target = null, uint force = 1) {
            if (this.IsRenewable())
            {
                if (target == null) target = _user;
                if (target is Wizard)
                {

                    uint mana;
                    if (_size == Sizes.Small) mana = 10;
                    else if (_size == Sizes.Medium) mana = 25;
                    else mana = 50;
                    if ((target as Wizard).MP + mana > (target as Wizard).MaxMP) (target as Wizard).MP = (target as Wizard).MaxMP;
                    else (target as Wizard).MP += mana;
                }
                else Console.WriteLine("You are not smart enough to use it!");
            }
            else Console.WriteLine("This bottle is empty!");


        }

    }
}
