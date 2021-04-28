using System;

namespace Role_playing_game
{
    class Program
    {
        static void Main()
        {
            Character Char = new Character("Orс", Character.Races.Orс, Character.Sexes.Male);
            Wizard wiz = new Wizard("Wiz", Character.Races.Elf, Character.Sexes.Male);
            wiz.HP -= 5;
            Console.WriteLine(wiz.ToString());
            #region Magic
            OrbOfVenom fi = new OrbOfVenom(Char);
            Add_Health heal1 = new Add_Health(wiz);//нормльный хил
            Add_Health heal2 = new Add_Health(wiz, 100);//хил с слишком большой затратой маны
            try
            {
                wiz.addart(fi);
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            try
            {
                wiz.broadcastart(fi, Char);
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            try
            {
                Char.useart(fi, wiz);
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            try
            {
                wiz.tolearn(heal1);
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            try
            {
                wiz.pronounce(heal1);
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }

            try
            {
                wiz.toforget(heal1);
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            try
            {
                heal2.Use(force: 5); //неправильный force
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            try
            {
                heal2.Use(force: 4);//недостаточно маны
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            try
            {
             //   heal1.Use(force: 2);//всё ок
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            Console.WriteLine(wiz.ToString());
            Cure cure = new Cure(wiz);
            try
            {
                cure.Use(Char);//Орк не болен,будет exception
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            //+excpetion не может говорить и/или двигаться
            //для других заклинаний exceptions аналогичны
            #endregion
            #region Artifact
            Char.HP -= 25;
            Console.WriteLine(Char.ToString());
            HealingSalve HS = new HealingSalve(Char, HealingSalve.Sizes.Big);
            Clarity clar = new Clarity(Char, Clarity.Sizes.Big);
            Dagon dagon = new Dagon(wiz);
            try
            {
                HS.Use(Char);
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            Console.WriteLine(Char.ToString());
            try
            {
                HS.Use(Char);//Бутыль была уже использована - exception, что пустая
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            try
            {
                HS.Use(Char);//У персонажа нету маны - не может использовать на себя
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            try
            {
                HS.Use(wiz);//всё ок
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            try
            {
                dagon.Use(Char, 1000);//сила превосходит мощность артефакта - exception 
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            try
            {
                dagon.Use(Char, 200);//всё ок
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            try
            {
                dagon.Use(Char, 1000);//сила артефакта иссякла - exception
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            //для корректного использования некоторых артефактов необходимо чтобы их цель была в определённом состоянии,например:
            Zhabius zhaba = new Zhabius(Char);
            try
            {
                zhaba.Use();//так как персонаж не отравлен будет выброшен exception
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            //для остальных артефактов exceptions аналогичны
            #endregion
        }
    }
}
