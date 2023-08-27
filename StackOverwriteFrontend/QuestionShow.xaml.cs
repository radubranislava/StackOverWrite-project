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
     /// Interaction logic for QuestionShow.xaml
     /// </summary>
     public partial class QuestionShow : Window
     {
          private String Title01 = " ";
          public QuestionShow()
          {
               InitializeComponent();
          }

          public QuestionShow(string QTitle)
          {
               InitializeComponent();
               binDataGrid(QTitle);
               Title01 = QTitle;
          }

         private void  binDataGrid(string QTitle)
          {
               SqlConnection connection = new SqlConnection();
               connection.ConnectionString =
               ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
               connection.Open();
               txtTitle.Text = QTitle;
               SqlCommand commandGetID = new SqlCommand();
               commandGetID.CommandText = "Select id_pitanja FROM [pitanje] WHERE naslov LIKE @Naslov";
               commandGetID.Parameters.AddWithValue("@Naslov", QTitle);
               commandGetID.Connection = connection;
               int QID = Convert.ToInt32(commandGetID.ExecuteScalar());
               SqlCommand commandCount = new SqlCommand();
               commandCount.CommandText = "Select COUNT(id_pitanja_odgovora) from [pitanje] INNER JOIN [pitanjeodgovor] ON pitanje.id_pitanja = pitanjeodgovor.id_pitanja INNER JOIN [odgovor] ON odgovor.id_odgovora = pitanjeodgovor.id_odgovora WHERE pitanje.id_pitanja LIKE @ID";
               commandCount.Parameters.AddWithValue("@ID", QID);
               commandCount.Connection = connection;
               int count = Convert.ToInt32(commandCount.ExecuteScalar());
               SqlCommand commandDate = new SqlCommand();
               commandDate.CommandText = "Select datum_postavljanja from [pitanje] WHERE pitanje.id_pitanja LIKE @ID";
               commandDate.Parameters.AddWithValue("@ID", QID);
               commandDate.Connection = connection;
               SqlDataReader reader2 = commandDate.ExecuteReader();
               reader2.Read();
               txtDate.Text = reader2.GetValue(0).ToString();
               reader2.Close();
               SqlCommand commandContent = new SqlCommand();
               commandContent.CommandText = "Select sadrzaj from [pitanje] WHERE pitanje.id_pitanja LIKE @ID";
               commandContent.Parameters.AddWithValue("@ID", QID);
               commandContent.Connection = connection;
               SqlDataReader reader3 = commandContent.ExecuteReader();
               reader3.Read();
               txtContent.Text = reader3.GetValue(0).ToString();
               reader3.Close();
               SqlCommand commandAnswers = new SqlCommand();
               commandAnswers.CommandText = "Select tekst_odgovora from [pitanje] INNER JOIN [pitanjeodgovor] ON pitanje.id_pitanja = pitanjeodgovor.id_pitanja INNER JOIN [odgovor] ON odgovor.id_odgovora = pitanjeodgovor.id_odgovora WHERE pitanje.id_pitanja LIKE @ID";
               commandAnswers.Parameters.AddWithValue("@ID", QID);
               commandAnswers.Connection = connection;
               if (count == 2)
               {
                    SqlDataReader reader = commandAnswers.ExecuteReader();
                    reader.Read();
                    txtAns1.Text = reader.GetValue(0).ToString();
                    reader.Read();
                    txtAns2.Text = reader.GetValue(0).ToString();
               }
               else if (count == 1)
               {
                    SqlDataReader reader = commandAnswers.ExecuteReader();
                    reader.Read();
                    txtAns1.Text = reader.GetValue(0).ToString();
               }

          }

          private void buttonAnswer_Click(object sender, RoutedEventArgs e)
          {
               AnswerNew newWindow = new AnswerNew(Title01);
               newWindow.Show();
               this.Close();
          }

          private void buttonHome_Click(object sender, RoutedEventArgs e)
          {
               MainWindow newWindow = new MainWindow();
               newWindow.Show();
               this.Close();
          }

          private void buttonReturnClick(object sender, RoutedEventArgs e)
          {
               QuestionsByTag newWindow = new QuestionsByTag();
               newWindow.Show();
               this.Close();
          }
     }
}
