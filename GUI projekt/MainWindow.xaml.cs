using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstName1 = firstName.Text;
            string lastName1 = lastName.Text;
            string age = age1.Text;
            string cpr1 = cpr.Text;

            string gender = "na";
            if (male.IsChecked == true)
            {
                gender = "m";
            }
            if (female.IsChecked == true)
            {
                gender = "f";
            }

            Person person = new Person(firstName1, lastName1, age, cpr1, gender);
            outputText(person);
        }

        public void outputText(object Object)
        {
            var fieldValues = Object.GetType()
                     .GetFields()
                     .Select(field => field.GetValue(Object))
                     .ToList();
            for (int i = 0; i < fieldValues.Count; i++)
            {
                output1.Content = fieldValues[i];
            }

        }   

    }

    class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private long cpr;
        private string gender;

        public Person(string firstName, string lastName, string age1, string cpr, string gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = Int32.Parse(age1);
            this.cpr = Int64.Parse(cpr);
            this.gender = gender;
        }

        public string FirstName   // property
        {
            get { return firstName; }   // get method
            set { firstName = value; }  // set method
        }
        public string LastName   // property
        {
            get { return lastName; }   // get method
            set { lastName = value; }  // set method
        }
        public int Age  // property
        {
            get { return age; }   // get method
            set { age = value; }  // set method
        }
        public long Cpr  // property
        {
            get { return cpr; }   // get method
            set { cpr = value; }  // set method
        }
        public string Gender   // property
        {
            get { return gender; }   // get method
            set { gender = value; }  // set method
        }

    }
}
