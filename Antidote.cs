using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Antidote : Spell
    {
        const uint AntidoteManaCost = 30;
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
        public Antidote(Wizard caster) : base(AntidoteManaCost, true, true)
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
            CheckVerbal(Caster);
            if (target.State == Character.States.Poisoned)
            {
                Caster.MP -= (int)ManaCost;
                target.State = Character.States.Normal;
                target.NormalizeState();
            }
            else
            {
                Console.WriteLine("The target is not poisoned!");
            }
        }
    }
}
