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
     /// Interaction logic for AnswerNew.xaml
     /// </summary>
     public partial class AnswerNew : Window
     {
          private String Title01 = " ";
          public AnswerNew()
          {
               InitializeComponent();
          }
          public AnswerNew(String QTitle)
          {
               InitializeComponent();
               binDataGrid(QTitle);
               Title01 = QTitle;
          }

          private void disableInput()
          {
               txtAnswer.IsEnabled = false;
          }

          private void binDataGrid(string QTitle)
          {
               SqlConnection connection = new SqlConnection();
               connection.ConnectionString =
               ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
               connection.Open();
               txtTitle.Text = QTitle;
               SqlCommand commandGetContent = new SqlCommand();
               commandGetContent.CommandText = "Select sadrzaj FROM [pitanje] WHERE naslov LIKE @Naslov";
               commandGetContent.Parameters.AddWithValue("@Naslov", QTitle);
               commandGetContent.Connection = connection;
               SqlDataReader readerContent = commandGetContent.ExecuteReader();
               readerContent.Read();
               txtContent.Text = readerContent.GetValue(0).ToString();
               readerContent.Close();
          }

          private void buttonAnswer_Click(object sender, RoutedEventArgs e)
          {
               if (string.IsNullOrEmpty(txtAnswer.Text))
               {
                    MessageBox.Show("Niste uneli odgovor!");
               }
               else
               {
               SqlConnection connection = new SqlConnection();
               connection.ConnectionString =
               ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
               connection.Open();
               SqlCommand commandGetQID = new SqlCommand();
               commandGetQID.CommandText = "Select id_pitanja FROM [pitanje] WHERE naslov LIKE @Naslov";
               commandGetQID.Parameters.AddWithValue("@Naslov", Title01);
               commandGetQID.Connection = connection;
               int QID = Convert.ToInt32(commandGetQID.ExecuteScalar());
               SqlCommand commandInsertAns = new SqlCommand();
               commandInsertAns.CommandText = "INSERT INTO [odgovor](tekst_odgovora, datum_postavljanja) VALUES (@AnsText, @AnsDate)";
               commandInsertAns.Parameters.AddWithValue("@AnsText", txtAnswer.Text);
               commandInsertAns.Parameters.AddWithValue("@AnsDate", DateTime.Now);
               commandInsertAns.Connection = connection;
               int provera = commandInsertAns.ExecuteNonQuery();
               SqlCommand commandGetAID = new SqlCommand();
               commandGetAID.CommandText = "SELECT MAX(id_odgovora) from [odgovor]";
               commandGetAID.Connection = connection;
               int AID = Convert.ToInt32(commandGetAID.ExecuteScalar());
               SqlCommand commandInsertRel = new SqlCommand();
               commandInsertRel.CommandText = "INSERT INTO [pitanjeodgovor] (id_odgovora,id_pitanja) VALUES (@AnsID, @QuesID)";
               commandInsertRel.Parameters.AddWithValue("@AnsID", AID);
               commandInsertRel.Parameters.AddWithValue("@QuesID", QID);
               commandInsertRel.Connection = connection;
               int provera2 = commandInsertRel.ExecuteNonQuery();
                    if (provera == 1&&provera2==1)
                    {
                         MessageBox.Show("Odgovor upisan!!");
                         disableInput();
                    }
               }
          }

          private void buttonReturnClick(object sender, RoutedEventArgs e)
          {
               QuestionShow newWindow = new QuestionShow(Title01);
               newWindow.Show();
               this.Close();
          }

          private void buttonHome_Click(object sender, RoutedEventArgs e)
          {
               MainWindow newWindow = new MainWindow();
               newWindow.Show();
               this.Close();
          }
     }
}
