using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Ressurect : Spell
    {
        const uint RessurectManaCost = 30;
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
        public Ressurect(Wizard caster) : base(RessurectManaCost, true, true)
        {
            Caster = caster;

        }
        public override void Use(Character target = null, uint force = 1)
        {
            if (target == null)
            {
                target = Caster;
            }
            CheckMana(Caster, ManaCost);
            CheckAction(Caster);
            CheckVerbal(Caster);
            if (target.State == Character.States.Dead)
            {
                Caster.MP -= (int)ManaCost;
                target.State = Character.States.Weak;
                target.HP = 1;
            }
            else
            {
                throw new ArgumentException("The target is not dead!");
            }
        }
    }
}
