using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class StandProud : Spell
    {
        const uint StandProudManaCost = 85;
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

        StandProud(Wizard caster) : base(StandProudManaCost, false, true)
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
            if (target.State == Character.States.Paralized)
            {
                Caster.MP -= (int)ManaCost;
                target.HP = 1;
                target.State = Character.States.Weak;
                target.CanMove = true;
            }
            else
            {
                throw new ArgumentException("The target is not Paralyzed!");
            }
        }
    }
}
