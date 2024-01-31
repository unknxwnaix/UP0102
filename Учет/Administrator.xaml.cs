using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {

        #region db varchars

        User_infoTableAdapter userAdapter = new User_infoTableAdapter();
        RolesTableAdapter rolesTableAdapter = new RolesTableAdapter();

        #endregion
        

        public Administrator()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            dg.ItemsSource = userAdapter.GetData();
            cbxRole.ItemsSource = rolesTableAdapter.GetData();
            cbxRole.DisplayMemberPath = "название";
            cbxRole.SelectedValuePath = "айди";
            tbLog.Text = "";
            tbPass.Text = "";
            cbxRole.Text = "";
        }

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
                tbLog.Text = (dg.SelectedValue as DataRowView).Row[1].ToString();
                tbPass.Text = (dg.SelectedValue as DataRowView).Row[2].ToString();
                cbxRole.Text = (dg.SelectedValue as DataRowView).Row[3].ToString();
            }
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbLog.Text != null && tbLog.Text != "" && tbPass.Text != null && tbPass.Text != "" && cbxRole.Text != null && cbxRole.Text != "")
            {
                int Role = Convert.ToInt32(cbxRole.SelectedValue.ToString());
                userAdapter.InsertQueryUser(tbLog.Text, tbPass.Text, Role);
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
                userAdapter.DeleteQueryUser((int)value);
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            UpdateDataGrid();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbLog.Text != null && tbLog.Text != "" && tbPass.Text != null && tbPass.Text != "" && cbxRole.Text != null && cbxRole.Text != "")
            {
                var value = (dg.SelectedValue as DataRowView).Row[0];
                int Role = Convert.ToInt32(cbxRole.SelectedValue.ToString());
                userAdapter.UpdateQueryUser(tbLog.Text, tbPass.Text, Role, (int)value);
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
            UpdateDataGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
        }
    }
}
