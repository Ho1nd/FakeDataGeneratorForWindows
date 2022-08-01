using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;

using static System.Console;

namespace FakeDataGeneratorWindows
{
    public partial class Form1 : Form
    {
        private static int amount = 100;

        private static List<string> FirstNames = File.ReadAllLines("D:/VSTraining/FakeDataGeneratorWindows/Data/nameB.txt").ToList();
        private static List<string> LastNames = File.ReadAllLines("D:/VSTraining/FakeDataGeneratorWindows/Data/middle.txt").ToList();
        private static List<string> PatronymicList = File.ReadAllLines("D:/VSTraining/FakeDataGeneratorWindows/Data/last.txt").ToList();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Output(object sender, EventArgs e)
        {
            Dictionary<string, bool> dict = new Dictionary<string, bool>();

            foreach (CheckBox item in panel1.Controls)
            {
                dict.Add(item.Text, item.Checked);
            }

            Generate(amount, dict);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var text = sender as TextBox;

            if(int.TryParse($"{text.Text}", out int result))
            {
                amount = result;
            }
        }

        public static void Generate(int amount, Dictionary<string, bool> dict)
        {            
            Random rnd = new Random();

            int id = 0;

            StringBuilder sb = new StringBuilder();

            //Путь к EXE файлу:
            string basepath = AppDomain.CurrentDomain.BaseDirectory;


            try
            {
                StreamWriter f = new StreamWriter($@"{basepath}\FakeData.txt", true);
                for (int i = 0; i < amount; i++)
                {
                    int randIndexFirstName = rnd.Next(FirstNames.Count);
                    int randIndexLastName = rnd.Next(LastNames.Count);
                    int randIndexPatronymicList = rnd.Next(PatronymicList.Count);

                    Person person = new Person() { Id = $"{id}", FirstName = $"{FirstNames[randIndexFirstName]}", LastName = $"{LastNames[randIndexLastName]}", Patronymic = $"{PatronymicList[randIndexPatronymicList]}" };


                    if (dict["Id"] == true)
                    {
                        sb.Append($"Id='{person.Id}', ");

                        id++;
                    }

                    if (dict["Имя"] == true)
                    {
                        sb.Append($"FirstName='{person.FirstName}', ");
                    }

                    if (dict["Фамилия"] == true)
                    {
                        sb.Append($"LastName='{person.LastName}', ");
                    }

                    if (dict["Отчество"] == true)
                    {
                        sb.Append($"Patronymic='{person.Patronymic}', ");
                    }

                    sb.AppendLine();
                };
                f.Write(sb.ToString());
                f.Close();
            }

            catch { }
           
        }
    }
}
