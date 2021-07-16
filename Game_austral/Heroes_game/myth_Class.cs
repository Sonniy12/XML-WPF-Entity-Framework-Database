using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Game_austral.Heroes_game
{
    class myth_Class : Heroes
    {
      
        List<Hero> heroes;

        TextBox tx1; TextBox tx2; TextBox tx3; TextBox tx4; ListBox list;

        public string Result_comboBox { get; set; }

        public myth_Class(TextBox tx1_, TextBox tx2_, TextBox tx3_, TextBox tx4_, ListBox list_, List<Hero> heroes_, string res1_)
        {




            this.tx1 = tx1_;
            this.tx2 = tx2_;
            this.tx3 = tx3_;
            this.tx4 = tx4_;
            this.list = list_;
            this.heroes = heroes_;
            Result_comboBox = res1_;
            skills = new Interface_games.implementation.Skills_();
            Special_Skills = new Interface_games.implementation.noISpecial_skills_();
        }

        public override void Add_race_combo(ComboBox comboBox1)
        {
            comboBox1.Items.Add("Эльфы");
            comboBox1.Items.Add("Люди");
            comboBox1.Items.Add("Гномы");
            comboBox1.Items.Add("Боги");



        }

        public override void Add_type_combo(ComboBox comboBox1)
        {
            comboBox1.Items.Add("Защитник");
            comboBox1.Items.Add("Танк");
            comboBox1.Items.Add("Агрессор");
            comboBox1.Items.Add("Хилер");

        }

        public override void Add_type_Hero(string resylt_combo)
        {
            string res1 = resylt_combo;
            if (res1 == "") return;

            using (Game_australEntities connect = new Game_australEntities())
            {
                var obj = (from x in connect.Hero
                           where x.name == res1
                           select x).FirstOrDefault();

                if (obj != null) { MessageBox.Show("Тип героя существует!"); return; }

                Hero hero = new Hero();
                hero.name = res1;
                connect.Hero.Add(hero);
                connect.SaveChanges();
            }
        }

        public override bool Change_character(TextBox name, TextBox update_specialized)
        {

            if (name.Text == "" || update_specialized.Text == "") { MessageBox.Show("пустое поле"); return false; }

            using (Game_australEntities db = new Game_australEntities())
            {
                Characteristics_hero updateCharacter = db.Characteristics_hero.First(c => c.name_hero.StartsWith(name.Text));

                updateCharacter.specialized = update_specialized.Text;
                int affected = db.SaveChanges();

                return (affected == 1);
            }



        }



        public override void Delet_character_(TextBox Id_hero)
        {
            if (Id_hero.Text != "")
            {
                int ID = int.Parse(Id_hero.Text);
                using (Game_australEntities db = new Game_australEntities())
                {
                    var hero = db.Characteristics_hero.Where(i => i.id == ID);
                    if (hero.FirstOrDefault() != null)
                    {
                        db.Characteristics_hero.Remove(hero.FirstOrDefault());
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Введите ID героя!");
            }

        }


        public override void Display(TextBox txt, TextBox txt2, ListBox list, MediaElement media, MediaTimeline timeline)
        {

            string result = "";
            using (Game_australEntities connect = new Game_australEntities())
            {
                if (txt.Text == "" || txt2.Text == "") { return; }
                var array = from x in connect.Hero

                            select x;
                foreach (var item2 in array)
                {


                    foreach (var item in item2.Characteristics_hero)// видео проигрывается,если папку с файлами поместить в папки bin/debug
                    {

                        // result += item2.name;
                        if (item.name_hero == txt.Text && item2.name == txt2.Text)
                        {
                            if (item2.name == "Защитник")
                            {
                                // media.Source = new Uri(@"legends/Легенды_защитник.mp4", UriKind.Relative);
                                timeline.Source = new Uri(@"myth/Мифы_защитник_.mp4", UriKind.Relative);
                                media.LayoutTransform = new RotateTransform(90);
                                result += "---ID = " + item.id + " -- Возраст = " + item.age + "---полное имя = " + item.name_hero + "---раса = " + item.race + "---пол = " + item.gender + "---умения = " + item.specialized;
                                list.Items.Add(result);
                                result = " ";
                            }
                            else if (item2.name == "Танк")
                            {
                                // media.Source = new Uri(@"legends/Легенды_танк (3).mp4", UriKind.Relative);
                                timeline.Source = new Uri(@"myth/Мифы_танк_.mp4", UriKind.Relative);
                                //  timeline.RepeatBehavior = new RepeatBehavior(600);
                                media.LayoutTransform = new RotateTransform(90);

                                result += "---ID = " + item.id + " -- Возраст = " + item.age + "  полное имя = " + item.name_hero + "  раса = " + item.race + "  пол = " + item.gender + "  умения = " + item.specialized;
                                list.Items.Add(result);
                                result = " ";
                            }
                            else if (item2.name == "Агрессор")
                            {
                                // media.Source = new Uri(@"legends/Легенда_агрессор.mp4", UriKind.Relative);
                                timeline.Source = new Uri(@"myth/Мифы_агрессор.mp4", UriKind.Relative);
                                media.LayoutTransform = new RotateTransform(90);
                                result += "---ID = " + item.id + " -- Возраст = " + item.age + " полное имя = " + item.name_hero + "  раса = " + item.race + "  пол = " + item.gender + "  умения = " + item.specialized;
                                list.Items.Add(result);
                                result = " ";
                            }
                            else if (item2.name == "Хилер")
                            {
                                // media.Source = new Uri(@"legends/Легенды_защитник.mp4", UriKind.Relative);
                                timeline.Source = new Uri(@"myth/Защитник_мифы_1.mp4", UriKind.Relative);
                                media.LayoutTransform = new RotateTransform(90);
                                result += "---ID = " + item.id + " -- Возраст = " + item.age + "  полное имя = " + item.name_hero + "  раса = " + item.race + "  пол = " + item.gender + "  умения = " + item.specialized;
                                list.Items.Add(result);
                                result = " ";
                            }
                            else
                            {
                                MessageBox.Show("Неверно введены значения");
                            }

                        }



                    }
                }


            }
        }

        public override List<Hero> Show_hero_type(ListBox list)
        {
            List<Hero> heroes;
            using (Game_australEntities connect = new Game_australEntities())
            {
                heroes = (from x in connect.Hero select x).ToList();

                foreach (var x in heroes)
                {
                    list.Items.Add(x.name);
                }
                return heroes;

            }
        }//не вызывается в форме

        public override void Add_Skills(TextBox tx1, TextBox tx2, TextBox tx3, TextBox tx4, ListBox list, string res1)
        {

            if (tx1.Text == "" || tx2.Text == "" || tx3.Text == "" || tx4.Text == "") return;
            if (list.SelectedIndex == -1) { MessageBox.Show("Выбери тип героя."); return; }
            using (Game_australEntities connect = new Game_australEntities())
            {
                Characteristics_hero character = new Characteristics_hero();
                character.name_hero = tx1.Text;
                character.gender = tx2.Text;
                character.age = int.Parse(tx3.Text);
                character.specialized = tx4.Text;
                character.race = res1;
                character.fk_hero = this.heroes[list.SelectedIndex].id;
                connect.Characteristics_hero.Add(character);
                connect.SaveChanges();
            }
        }

    }
}
