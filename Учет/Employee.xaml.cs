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
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        private int id_user;
        public Employee(int id)
        {
            InitializeComponent();
            id_user = id;
            UpdateDataGrid();
        }

        #region db varchars

        StatusTableAdapter statusTableAdapter = new StatusTableAdapter();
        User_infoTableAdapter userAdapter = new User_infoTableAdapter();
        RolesTableAdapter rolesTableAdapter = new RolesTableAdapter();
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
            if (dg.SelectedValue != null && dg.SelectedIndex < (dg.Items.Count - 1))
            {
                tblText.Text = "Текст обращения: " + (dg.SelectedValue as DataRowView).Row[0].ToString();
                cbxStatus.Text = (dg.SelectedValue as DataRowView).Row[1].ToString();
            }
        }

        private void dg2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg2.SelectedValue != null && dg2.SelectedIndex < (dg.Items.Count - 1))
            {
                tbResponse.Text = (dg2.SelectedValue as DataRowView).Row[1].ToString();
                cbxRequest.Text = (dg2.SelectedValue as DataRowView).Row[3].ToString();
            }
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbResponse.Text != null && tbResponse.Text != "" && cbxRequest.Text != null && cbxRequest.Text != "")
            {
                int Request = Convert.ToInt32(cbxRequest.SelectedValue.ToString());
                responsesTableAdapter.InsertQueryResponse(tbResponse.Text, Request, id_user);
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            UpdateDataGrid();
            tbResponse.Text = "";
            cbxRequest.Text = "";
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (dg2.SelectedValue != null)
            {
                var value = (dg2.SelectedValue as DataRowView).Row[0];
                responsesTableAdapter.DeleteQueryResponse((int)value);
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            UpdateDataGrid();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbResponse.Text != null && tbResponse.Text != "" && cbxRequest.Text != null && cbxRequest.Text != "")
            {
                var value = (dg2.SelectedValue as DataRowView).Row[0];
                int Request = Convert.ToInt32(cbxRequest.SelectedValue.ToString());
                responsesTableAdapter.UpdateQueryResponse(tbResponse.Text, Request, id_user, (int)value);
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            UpdateDataGrid();
            tbResponse.Text = "";
            cbxRequest.Text = "";
        }

        private void UpdateDataGrid()
        {
            dg.ItemsSource = requestsTableAdapter.GetDataBy4();
            dg2.ItemsSource = responsesTableAdapter.GetData();
            cbxStatus.ItemsSource = statusTableAdapter.GetData();
            cbxStatus.DisplayMemberPath = "статус";
            cbxStatus.SelectedValuePath = "айди_статуса";
            cbxRequest.ItemsSource = requestsTableAdapter.GetDataBy4();
            cbxRequest.DisplayMemberPath = "текст";
            cbxRequest.SelectedValuePath = "Обращение";

        }

        private void cbxPriority_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg.SelectedValue != null && dg.SelectedIndex < (dg.Items.Count - 1))
            {
                var value = Convert.ToInt32((dg.SelectedValue as DataRowView).Row[3]);
                int priority = Convert.ToInt32(cbxStatus.SelectedValue.ToString());
                requestsTableAdapter.UpdateQueryRequest2(priority, value);
            }
            dg.ItemsSource = requestsTableAdapter.GetDataBy4();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            tblText.Text = "Текст обращения: ";
            cbxStatus.Text = "";
        }
    }
}
