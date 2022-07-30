using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace FakeDataGeneratorWindows
{
    public partial class Form1 : Form
    {
        private static int amount = 100;
        private static bool idBool = false;
        private static bool nameBool = false;
        private static bool lastNameBool = false;
        private static bool PatronymicBool = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Output(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter("FakeData.txt");
            f.Close();
            Generate(amount, idBool, nameBool, lastNameBool, PatronymicBool);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var text = sender as TextBox;
            if(int.TryParse($"{text.Text}", out int result))
            {
                amount = result;
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var checkBoxId = sender as CheckBox;
            if (checkBoxId.Checked)
            {
                idBool = true;
            }
            else
            {
                idBool = false;
            }
        }

        public static void Generate(int amount, bool idBool, bool nameBool, bool lastNameBool, bool PatronymicBool)
        {
            List<string> FirstNames = new List<string>() { "Алексей", "Владимир", "Дмитрий", "Константин", "Елена", "Борис", "Егор", "Александр", "Андрей", "Антон", "Адам" };
            List<string> LastNames = new List<string>() { "Кузнецов", "Загаров", "Богомолов", "Азарнов", "Иванов", "Смирнов", "Васильев", "Соколов", "Михайлов", "Петров", "Попов" };
            List<string> PatronymicList = new List<string>() { "Петрович", "Валерьевич", "Александрович", "Борисович", "Сергеевич", "Геннадьевич", "Дмитриевич", "Никитич", "Ильич", "Кириллович", "Иваныч" };
            Random rnd = new Random();

            int id = 0;

            for (int i = 0; i < amount; i++)
            {
                int randIndexFirstName = rnd.Next(FirstNames.Count);
                int randIndexLastName = rnd.Next(LastNames.Count);
                int randIndexPatronymicList = rnd.Next(PatronymicList.Count);
                if (idBool == true)
                {
                    Person person = new Person() { Id = $"{id}" };
                    StreamWriter f = new StreamWriter("FakeData.txt", true);

                    f.Write($"Id='{person.Id}', ");

                    f.Close();
                    id++;
                }

                if (nameBool == true)
                {
                    Person person = new Person() {FirstName = $"{FirstNames[randIndexFirstName]}", LastName = $"{LastNames[randIndexLastName]}", Patronymic = $"{PatronymicList[randIndexPatronymicList]}" };
                    StreamWriter f = new StreamWriter("FakeData.txt", true);

                    f.Write($"FirstName='{person.FirstName}', ");

                    f.Close();
                }


                StreamWriter s = new StreamWriter("FakeData.txt", true);
                s.WriteLine();

                // Person person = new Person() {FirstName = $"{FirstNames[randIndexFirstName]}", LastName = $"{LastNames[randIndexLastName]}", Patronymic = $"{PatronymicList[randIndexPatronymicList]}" };
            }
        }

        public class Person
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Patronymic { get; set; }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            var checkBoxName = sender as CheckBox;
            if (checkBoxName.Checked)
            {
                nameBool = true;
            }
            else
            {
                nameBool = false;
            }
        }
    }
}
