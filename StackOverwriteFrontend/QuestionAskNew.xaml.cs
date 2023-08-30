using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
     /// Interaction logic for QuestionAskNew.xaml
     /// </summary>
     public partial class QuestionAskNew : Window
     {
          public QuestionAskNew()
          {
               InitializeComponent();
               comboBoxTag_Loaded();
          }

          private void comboBoxTag_Loaded()
          {
               SqlConnection connection = new SqlConnection();
               connection.ConnectionString =
               ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
               connection.Open();
               SqlCommand commandCbx = new SqlCommand();
               commandCbx.CommandText = "SELECT naziv_taga FROM [tag] ORDER BY naziv_taga";
               commandCbx.Connection = connection;
               SqlDataAdapter dataAdapterCbx = new SqlDataAdapter(commandCbx);
               DataTable dataTableCbx = new DataTable("tag");
               dataAdapterCbx.Fill(dataTableCbx);
               for (int i = 0; i < dataTableCbx.Rows.Count; i++)
               {
                    comboBoxTag.Items.Add(dataTableCbx.Rows[i]["naziv_taga"]);
                    comboBoxTag2.Items.Add(dataTableCbx.Rows[i]["naziv_taga"]);
                    comboBoxTag3.Items.Add(dataTableCbx.Rows[i]["naziv_taga"]);
               }
          }

          private void ponistiUnos()
          {
               txtTitle.Text = " ";
               txtContent.Text = " ";
               comboBoxTag.SelectedItem = null;
               comboBoxTag2.SelectedItem = null;
               comboBoxTag3.SelectedItem = null;
          }

          private int TagIDGet(string Naziv)
          {
               SqlConnection connection = new SqlConnection();
               connection.ConnectionString =
               ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
               connection.Open();
               SqlCommand commandGetTagID = new SqlCommand();
               commandGetTagID.CommandText = "Select id_taga FROM [tag] WHERE naziv_taga LIKE @Tag";
               commandGetTagID.Parameters.AddWithValue("@Tag", Naziv);
               commandGetTagID.Connection = connection;
               int TagID_pom = Convert.ToInt32(commandGetTagID.ExecuteScalar());
               return TagID_pom;
          }
          private void buttonAsk_Click(object sender, RoutedEventArgs e)
          {
               if (txtTitle.Text != " " && txtContent.Text != " " && comboBoxTag.SelectedItem != null && comboBoxTag2.SelectedItem != null && comboBoxTag3.SelectedItem != null)
               {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
                    connection.Open();
                    SqlCommand commandQuestion = new SqlCommand();
                    commandQuestion.CommandText = "INSERT INTO [pitanje] (naslov, sadrzaj, datum_postavljanja) VALUES (@Title, @Content, @Date)";
                    commandQuestion.Parameters.AddWithValue("@Title", txtTitle.Text);
                    commandQuestion.Parameters.AddWithValue("@Content", txtContent.Text);
                    commandQuestion.Parameters.AddWithValue("@Date", DateTime.Now);
                    commandQuestion.Connection = connection;
                    int provera = commandQuestion.ExecuteNonQuery();
                    SqlCommand commandGetQID = new SqlCommand();
                    commandGetQID.CommandText = "SELECT MAX(id_pitanja) from [pitanje]";
                    commandGetQID.Connection = connection;
                    int QID = Convert.ToInt32(commandGetQID.ExecuteScalar());
                    string TagIme = comboBoxTag.SelectedItem.ToString();
                    int FirstTagID = TagIDGet(TagIme);
                    SqlCommand commandInsertRel = new SqlCommand();
                    commandInsertRel.CommandText = "INSERT INTO [pitanjetag] (id_pitanja,id_taga) VALUES (@QuesID, @TagID)";
                    commandInsertRel.Parameters.AddWithValue("@QuesID", QID);
                    commandInsertRel.Parameters.AddWithValue("@TagID", FirstTagID);
                    commandInsertRel.Connection = connection;
                    int provera2 = commandInsertRel.ExecuteNonQuery();
                    if (comboBoxTag2.SelectedItem != null)
                    {
                         string TagIme2 = comboBoxTag2.SelectedItem.ToString();
                         int SecondTagID = TagIDGet(TagIme2);
                         SqlCommand commandInsertRel2 = new SqlCommand();
                         commandInsertRel2.CommandText = "INSERT INTO [pitanjetag] (id_pitanja,id_taga) VALUES (@QuesID, @TagID)";
                         commandInsertRel2.Parameters.AddWithValue("@QuesID", QID);
                         commandInsertRel2.Parameters.AddWithValue("@TagID", SecondTagID);
                         commandInsertRel2.Connection = connection;
                         int provera3 = commandInsertRel2.ExecuteNonQuery();
                         if (provera3 == 0) MessageBox.Show("Greska!");
                    }
                    if (comboBoxTag3.SelectedItem != null)
                    {
                         string TagIme3 = comboBoxTag3.SelectedItem.ToString();
                         int ThirdTagID = TagIDGet(TagIme3);
                         SqlCommand commandInsertRel3 = new SqlCommand();
                         commandInsertRel3.CommandText = "INSERT INTO [pitanjetag] (id_pitanja,id_taga) VALUES (@QuesID, @TagID)";
                         commandInsertRel3.Parameters.AddWithValue("@QuesID", QID);
                         commandInsertRel3.Parameters.AddWithValue("@TagID", ThirdTagID);
                         commandInsertRel3.Connection = connection;
                         int provera4 = commandInsertRel3.ExecuteNonQuery();
                         if (provera4 == 0) MessageBox.Show("Greska!");
                    }
                    if (provera == 1 && provera2 == 1)
                    {
                         MessageBox.Show("Pitanje postavljeno!!");
                         ponistiUnos();
                    }
                    else MessageBox.Show("Greska!");
               }
               else MessageBox.Show("Podaci nisu unešeni!");
          }

          private void buttonReturnClick(object sender, RoutedEventArgs e)
          {
               QuestionsByTag newWindow = new QuestionsByTag();
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
