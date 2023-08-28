using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
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
using MySql.Data.MySqlClient;

namespace StackOverwriteFrontend
{
     /// <summary>
     /// Interaction logic for LogIn.xaml
     /// </summary>
     public partial class LogIn : Window
     {
          public LogIn()
          {
               InitializeComponent();
          }
          private void ponistiUnosTxt()
          {
               txtUsername.Text = "";
               txtPassword.Text = "";
          }

          private void buttonLogin_Click(object sender, RoutedEventArgs e)
          {
               SqlConnection sqlCon = new SqlConnection();
               sqlCon.ConnectionString = ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
               try
               {
                    if (sqlCon.State == ConnectionState.Closed)
                         sqlCon.Open();
                    String query = "SELECT COUNT(1) FROM korisnik WHERE username=@Username AND lozinka=@Password";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = System.Data.CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if(count==1)
                    {
                         QuestionsByTag newWindow = new QuestionsByTag();
                         newWindow.Show();
                         this.Close();
                    }
                    else
                    {
                         MessageBox.Show("Unešeno korisničko ime ili lozinka su netačni!");
                         ponistiUnosTxt();
                    }
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
               finally
               {
                    sqlCon.Close();
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
