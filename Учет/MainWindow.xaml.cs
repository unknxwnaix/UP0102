using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Учет.UPDataSetTableAdapters;

namespace Учет
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region db varchars

        User_infoTableAdapter userAdapter = new User_infoTableAdapter();

        #endregion
        #region mvvm varchar
        private string _log;

        public string Log
        {
            get { return _log; }
            set
            {
                if (_log != value)
                {
                    _log = value;
                    OnPropertyChanged(nameof(Log));
                }
            }
        }

        private string _pass;

        public string Pass
        {
            get { return _pass; }
            set
            {
                if (_pass != value)
                {
                    _pass = value;
                    OnPropertyChanged(nameof(Pass));
                }
            }
        }

        private string _textBox;

        public string TextBox
        {
            get { return _textBox; }
            set
            {
                if (_textBox != value)
                {
                    _textBox = value;
                    OnPropertyChanged(nameof(TextBox));
                }
            }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Log = "Введите логин";
            Pass = "Введите пароль";
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [ValueConversion(typeof(bool), typeof(Visibility))]
        public class InvertedBooleanToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is bool boolValue)
                {
                    return boolValue ? Visibility.Collapsed : Visibility.Visible;
                }

                return Visibility.Visible;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        private void Authorization_Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != null && textBox.Text != "" && passBox.Password != "" && passBox.Password != null)
            {
                bool IsAuth = false;
                var allLogins = userAdapter.GetData().Rows;
                for (int i = 0; i < allLogins.Count; i++)
                {
                    var a = allLogins[i][1].ToString();
                    var b = allLogins[i][2].ToString();
                    if (allLogins[i][1].ToString() == textBox.Text && allLogins[i][2].ToString() == passBox.Password)
                    {
                        IsAuth = true;
                        string role = allLogins[i][3].ToString();
                        MessageBox.Show("Вы успешно авторизовались в системе! Ваша роль: " + role);
                        switch (role)
                        {
                            case "administrator":
                                Administrator administrator = new Administrator();
                                administrator.Show();
                                Close();
                                break;
                            case "user":
                                int id_user = Convert.ToInt32(allLogins[i][0]);
                                User user = new User(id_user);
                                user.Show();
                                Close();
                                break;
                            case "employee":
                                int id_employee = Convert.ToInt32(allLogins[i][0]);
                                Employee employee = new Employee(id_employee); 
                                employee.Show();
                                Close();
                                break;
                        }
                    }
                }
                if (!IsAuth)
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
            else
            {
                MessageBox.Show("Неверное заполнение полей!");
            }
        }
    }
}

