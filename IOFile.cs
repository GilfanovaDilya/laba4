using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public static class IOFile
    {
        public static string content = string.Empty;

        public static string path = string.Empty;

        public static Form1 form1 = new Form1();

        public static string[] inputString;

        public static List<string> arrayList = new List<string>();

        public static void OpenSaveDialogForm()
        {
            if (form1.saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            path = form1.saveFileDialog1.FileName;
        }

        public static void OpenLoadDialogForm()
        {
            if (form1.openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            path = form1.openFileDialog1.FileName;
        }

        public static string InputInfoAboutComparison(int first, int second)
        {
            content += "Сравниваем " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
            return "Сравниваем " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
        }

        public static string InputInfoAboutTransposition(int first, int second)
        {
            content += "Перестановка " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
            return "Перестановка " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
        }

        public static void FillContent()
        {
            foreach (var i in Context.array)
            {
                content += Convert.ToString(i) + ' ';
            }

            content += '\n';
        }

        private static void Separator(StreamReader streamReader)
        {
            try
            {
                inputString = streamReader.ReadToEnd().Split(' ');
                Context.array = new int[inputString.Length];
                if (inputString.Where((t, k) => !int.TryParse(t, out Context.array[k])).Any())
                {
                    throw new Exception("Wrong input");
                }

                foreach (var j in Context.array)
                {
                    content += Convert.ToString(j) + " ";
                }

                form1.listBox1.Items.Add(content);
                form1.listBox1.Items.Add(string.Empty);
            }
            catch
            {
                MessageBox.Show("Некорректный формат загружаемого файла.");
            }
        }

        public static void LoadData()
        {
            try
            {
                OpenLoadDialogForm();
                using (var sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    Separator(sr);
                    sr.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Вы не выбрали путь");
            }
        }

        public static void SaveData(string text = "", bool flag = false)
        {
            content += text;

            if (flag == false)
            {
                OpenSaveDialogForm();
            }

            try
            {
                System.IO.File.WriteAllText(path, IOFile.content);
            }
            catch (System.ArgumentException)
            {
            }
        }
    }
}