using System;
using System.Collections.Generic;
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

namespace LoginWPF
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\local; Initial Catalog=LoginDB; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                    String query = "SELECT COUNT(1) FROM tblUser WHERE UserName=@UserName AND Password=@Password";
                    SqlCommand sqlCommand = new SqlCommand(query,sqlCon);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@UserName", txtUsername.Text);
                    sqlCommand.Parameters.AddWithValue("@Password", txtPassword.Password);
                    int Count = Convert.ToInt32(sqlCommand.ExecuteScalar()); 

                    if (Count == 1)
                    {
                        MainWindow dashboard = new MainWindow();
                        dashboard.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password is incorrect");
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

        private void BtnNewUser_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
