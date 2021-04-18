using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Cure : Spell
    {
        const uint CureManaCost = 20;
        private Wizard _caster; 
        private Wizard Caster
        {
            get
            {
                return _caster;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Caster must not be null!");
                }
                _caster = value;
            }
        }
        public Cure(Wizard caster) : base(CureManaCost, false, true)
        {
            Caster = caster;
        }
        public override void SpellCast(Character target = null, uint force = 1)
        {
            if (target == null)
            {
                target = Caster;
            }
            CheckMana(Caster, ManaCost);
            CheckAction(Caster);
            if (target.State == Character.States.Sick)
            {
                Caster.MP -= (int)ManaCost;
                target.State = Character.States.Normal;
                target.NormalizeState();
            }
            else
            {
                throw new ArgumentException("The target is not sick!");
            }
        }
    }
}
