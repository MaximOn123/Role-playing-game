using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
     abstract class Spell : IMagic
    {
        private uint _mana;
        private bool _voice;
        private bool _action;
        public uint minM
        {
            get
            {
                return this._mana;
            }
            protected set
            {
                this._mana = (uint)value;
            }
        }
        public Spell(uint mana,bool v,bool a) {
            minM = mana;
            _voice = v;
            _action = a;
        
        }

       public void CheckVerbal(Wizard wizard) {
            if (_voice == true & wizard.CanSpeak == false)
            {
                throw new ArgumentException("You can't speak to cast this spell!");
            }
        }
       public void CheckAction(Wizard wizard) {
            if (_action == true & wizard.CanMove == false)
            {
                throw new ArgumentException("You can't move to cast this spell!");
            }
        }
         public void CheckMana(Wizard wizard,uint mana) {
            if (wizard.MP < mana)
            {
                throw new ArgumentException("Not Enough Mana!");
            }
            else if (mana < 0) {
                throw new ArgumentException("Negative mana?");
            }
        }
        public abstract void SpellCast(Character character = null, uint force = 1);
        
        
        
     
            
            
            
            
        

        


    }
}
