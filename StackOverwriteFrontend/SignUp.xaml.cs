using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace StackOverwriteFrontend
{
     /// <summary>
     /// Interaction logic for SignUp.xaml
     /// </summary>
     public partial class SignUp : Window
     {
          public SignUp()
          {
               InitializeComponent();
          }
          private void ponistiUnosTxt()
          {
               txtUsername.Text = "";
               txtPassword.Text = "";
               txtEmail.Text = "";
          }

          private void buttonRegister_Click(object sender, RoutedEventArgs e)
          {
               SqlConnection sqlCon = new SqlConnection();
               sqlCon.ConnectionString =
               ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
               sqlCon.Open();
               SqlCommand command = new SqlCommand();
               command.CommandText = "INSERT INTO [korisnik] (email,username,lozinka) VALUES( @Email, @Username,  @Lozinka)";
               command.Parameters.AddWithValue("@Email", txtEmail.Text);
               command.Parameters.AddWithValue("@Username", txtUsername.Text);
               command.Parameters.AddWithValue("@Lozinka", txtPassword.Text);
               command.Connection = sqlCon;
               int provera = command.ExecuteNonQuery();
               if (provera == 1)
               {
                    MessageBox.Show("Korisnik registrovan!!");
                    MainWindow newWindow = new MainWindow();
                    newWindow.Show();
                    this.Close();
               }
               else
               {
                    MessageBox.Show("Nisu uneseni dobri podaci!");
                    ponistiUnosTxt();
               }
          }

          private void buttonHome_Click(object sender, RoutedEventArgs e)
          {
               MainWindow newWindow = new MainWindow();
               newWindow.Show();
               this.Close();
          }
     }
}
