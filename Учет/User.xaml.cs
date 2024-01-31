using System;
using System.Collections.Generic;
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
using Учет.UPDataSetTableAdapters;

namespace Учет
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        private int id_user;
        public User(int id)
        {
            InitializeComponent();
            id_user = id;
            UpdateDataGrid();
        }

        #region db varchars

        RequestsTableAdapter requestsTableAdapter = new RequestsTableAdapter();
        PriorityTableAdapter priorityTableAdapter = new PriorityTableAdapter();
        ResponsesTableAdapter responsesTableAdapter = new ResponsesTableAdapter();

        #endregion

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg.SelectedValue != null && dg.SelectedIndex < (dg.Items.Count-1))
            {
                tbText.Text = (dg.SelectedValue as DataRowView).Row[0].ToString();
                cbxPriority.Text = (dg.SelectedValue as DataRowView).Row[2].ToString();
            }
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbText.Text != null && tbText.Text != "" && cbxPriority.Text != null && cbxPriority.Text != "")
            {
                int priority = Convert.ToInt32(cbxPriority.SelectedValue.ToString());
                requestsTableAdapter.InsertQueryRequest(2, tbText.Text, priority, id_user);
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            UpdateDataGrid();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedValue != null)
            {
                var value = (dg.SelectedValue as DataRowView).Row[0];
                requestsTableAdapter.DeleteQueryRequest((int)value);
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            UpdateDataGrid();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbText.Text != null && tbText.Text != "" && cbxPriority.Text != null && cbxPriority.Text != "")
            {
                var value = (dg.SelectedValue as DataRowView).Row[0];
                int priority = Convert.ToInt32(cbxPriority.SelectedValue.ToString());
                requestsTableAdapter.UpdateQueryRequest(2, tbText.Text, priority, id_user, (int)value);
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            dg.ItemsSource = requestsTableAdapter.GetDataBy4();
            cbxPriority.ItemsSource = priorityTableAdapter.GetData();
            cbxPriority.DisplayMemberPath = "приоритет";
            cbxPriority.SelectedValuePath = "айди_приоритета";
            tbText.Text = "";
            cbxPriority.Text = "";
        }

        private void Check_Button_Click(object sender, RoutedEventArgs e)
        {
            string status = "Status: ", response = "Response: ";
            if (Convert.ToString((dg.SelectedValue as DataRowView).Row[1]) != "Unsolved")
            {
                status += "solved";
                var allResponses = responsesTableAdapter.GetDataBy3();
                foreach (DataRow row in allResponses)
                {
                    if (Convert.ToInt32(row[4]) == Convert.ToInt32((dg.SelectedValue as DataRowView).Row[3]))
                    {
                        response += Convert.ToString(row[1]);
                    }
                }
            }
            else
            {
                status += "unsolved";
                response += "Your request will be verified shortly";
            }
            MessageBox.Show(status + "\n" + response);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
        }
    }
}
