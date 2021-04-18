using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    abstract class Spell : IMagic
    {
        private uint _manaCost;
        private bool _isVoiceRequired;
        private bool _isActionRequired;
        public uint ManaCost
        {
            get
            {
                return this._manaCost;
            }
            protected set
            {
                this._manaCost = (uint)value;
            }
        }
        public Spell(uint manaCost, bool isVoiceRequired, bool isActionRequired)
        {
            ManaCost = manaCost;
            _isVoiceRequired = isVoiceRequired;
            _isActionRequired = isActionRequired;
        }
        public void CheckVerbal(Wizard wizard)
        {
            if (_isVoiceRequired == true & wizard.CanSpeak == false)
            {
                throw new ArgumentException("You can't speak to cast this spell!");
            }
        }
        public void CheckAction(Wizard wizard)
        {
            if (_isActionRequired == true & wizard.CanMove == false)
            {
                throw new ArgumentException("You can't move to cast this spell!");
            }
        }
        public void CheckMana(Wizard wizard, uint mana)
        {
            if (wizard.MP < mana)
            {
                throw new ArgumentException("Not Enough Mana!");
            }
        }
        public abstract void SpellCast(Character character = null, uint force = 1);
    }
}
