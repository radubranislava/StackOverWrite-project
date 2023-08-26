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
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StackOverwriteFrontend
{
     /// <summary>
     /// Interaction logic for QuestionsByTag.xaml
     /// </summary>
     public partial class QuestionsByTag : Window
     {
          private String QuestionTitle = " ";
          public QuestionsByTag()
          {
               InitializeComponent();
               binDataGrid();
          }

          private void binDataGrid()
          {
               SqlConnection connection = new SqlConnection();
               connection.ConnectionString =
               ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
               connection.Open();
               SqlCommand command = new SqlCommand();
               command.CommandText = "Select naslov,datum_postavljanja, naziv_taga from [pitanje] INNER JOIN [pitanjetag] ON pitanje.id_pitanja = pitanjetag.id_pitanja INNER JOIN [tag] ON pitanjetag.id_taga = tag.id_taga ORDER BY datum_postavljanja desc";
               command.Connection = connection;
               SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
               DataTable dataTable = new DataTable("pitanje");
               dataAdapter.Fill(dataTable);
               DataGrid.ItemsSource = dataTable.DefaultView;
          }


          private void comboBoxTag_Loaded(object sender, RoutedEventArgs e)
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
               }
          }

          private void buttonSearch_Click(object sender, RoutedEventArgs e)
          {

               if (comboBoxTag.SelectedItem == null)
               {
                    System.Windows.MessageBox.Show("Niste selektovali tag!");
               }
               else
               {
               String tagSearch = comboBoxTag.SelectedItem.ToString();
               SqlConnection connection = new SqlConnection();
               connection.ConnectionString =
               ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
               connection.Open();
               SqlCommand command = new SqlCommand();
               command.CommandText = "Select naslov,datum_postavljanja, naziv_taga from [pitanje] INNER JOIN[pitanjetag] ON pitanje.id_pitanja = pitanjetag.id_pitanja INNER JOIN[tag] ON pitanjetag.id_taga = tag.id_taga WHERE tag.naziv_taga = @ImeTaga ORDER BY datum_postavljanja desc";
               command.Parameters.AddWithValue("ImeTaga", tagSearch);
               command.Connection = connection;
               SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
               DataTable dataTable = new DataTable("pitanje");
               dataAdapter.Fill(dataTable);
               DataGrid.ItemsSource = dataTable.DefaultView;
               }
          }

          private void buttonGo_Click(object sender, RoutedEventArgs e)
          {
               if(QuestionTitle== " ")
               {
                    System.Windows.MessageBox.Show("Nije selektovano pitanje!");
               }
               else
               {
                    QuestionShow newWindow = new QuestionShow(QuestionTitle);
                    newWindow.Show();
                    this.Close();
               }
          }

          private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
               SqlConnection connection = new SqlConnection();
               connection.ConnectionString =
               ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
               connection.Open();
               System.Windows.Controls.DataGrid dg = sender as System.Windows.Controls.DataGrid;
               DataRowView dr = dg.SelectedItem as DataRowView;
               if (dr != null)
               {
                    QuestionTitle = dr["naslov"].ToString();
               }
          }

          private void buttonNewQ_Click(object sender, RoutedEventArgs e)
          {
               QuestionAskNew newWindow = new QuestionAskNew();
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
