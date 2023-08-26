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

namespace StackOverwriteFrontend
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

          private void buttonQuestions_Click(object sender, RoutedEventArgs e)
          {
               QuestionsByTag newWindow = new QuestionsByTag();
               newWindow.Show();
               this.Close();
          }

          private void buttonLogin_Click(object sender, RoutedEventArgs e)
          {
               LogIn newWindow = new LogIn();
               newWindow.Show();
               this.Close();
          }

          private void buttonSignup_Click(object sender, RoutedEventArgs e)
          {
               SignUp newWindow = new SignUp();
               newWindow.Show();
               this.Close();
          }
     }
}
