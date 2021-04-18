using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Armor : Spell,IMagic
    {
        Wizard Caster;

        Armor(Wizard caster) : base(50, true, false)
        {
            Caster = caster;

        }
        public override void SpellCast(Character target = null, uint force = 1)
        {

            if (target == null)
            {
                target = Caster;
            }
            try
            {
                CheckMana(Caster, minM*force);
                CheckVerbal(Caster);
            }
            catch (Exception) { }
                Caster.MP -= minM*force;
               
           


        }
    }
}
