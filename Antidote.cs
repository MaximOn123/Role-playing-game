using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Antidote : Spell, IMagic
    {
        Wizard Caster;
        Antidote(Wizard caster) : base(30, true, true)
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
            if (target.State == Character.States.Poisoned)
            {
                if (target.CanMove == false)
                {
                    Caster.MP -= minM;
                    target.State = Character.States.Weak;
                    target.CanMove = true;
                }
                else { 
                    Caster.MP -= minM;
                    target.State = Character.States.Normal;
                }
            }
            else
                Console.WriteLine("The target is not Poisoned!");


        }

    }
}
