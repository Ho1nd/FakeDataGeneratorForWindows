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
            Generate(amount, true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            // int.TryParse($"{sender}", out int result);
            amount = int.Parse($"{sender}");
            
        }

        public static void Generate(int amount, bool idBool)
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
                Person person = new Person() { Id = $"{id}", FirstName = $"{FirstNames[randIndexFirstName]}", LastName = $"{LastNames[randIndexLastName]}", Patronymic= $"{PatronymicList[randIndexPatronymicList]}" };



                StreamWriter f = new StreamWriter("FakeData.txt", true);

                f.WriteLine($"Id='{person.Id}', FirstName='{person.FirstName}', LastName='{person.LastName}', Patronymic='{person.Patronymic}'");

                f.Close();


                //WriteLine($"Id='{person.Id}', Name='{person.Name}'");

                id++;
            }
        }

        public class Person
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Patronymic { get; set; }
            
        }
    }
}
