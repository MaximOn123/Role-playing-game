using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Ressurect : Spell,IMagic
    {
        Wizard Caster;
        Ressurect(Wizard caster) : base(150, true, true)
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
                CheckMana(Caster, minM);
                CheckAction(Caster);
                CheckVerbal(Caster);
            }
            catch (Exception) { }
            if (target.State == Character.States.Dead)
            {
                Caster.MP -= minM;
                target.State = Character.States.Weak;
                target.HP = 1;
            }
            else
                Console.WriteLine("The target is not Dead!");


        }

    }
}
