using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalend
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 64);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void cleseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cleseButton_MouseEnter(object sender, EventArgs e)
        {
            cleseButton.ForeColor = Color.Red;
        }

        private void cleseButton_MouseLeave(object sender, EventArgs e)
        {
            cleseButton.ForeColor = Color.White;
        }
        //Создаем новую функцию для оперирования передвижения всего окна
        Point LastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //Создаем проверку на нажатие левой кнопки мыши MouseButtons.Left через 
            //Объект "е" так как в нем хранятся все свойства нашего объекта
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //Проверка логина и пароля
            String loginUser = loginField.Text;
            String passUser = passField.Text;
            //Создаем несколько объектов
            DB db = new DB();

            DataTable tables = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            
            //Выбираю все пользователей из таблички Users в БД, где логин и пароль равны loginUser и passUser (и к какой базе подключаемся)
            
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @UsL AND `pass` = @UsP", db.getConnection());
            
            //В сомандах по обращению к БД указали заглушку и теперь заглушкам указываем реальные переменные
            //Это для безопасности. При этом указывает тип данных БД
            
            command.Parameters.Add("@UsL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@UsP", MySqlDbType.VarChar).Value = passUser;
            
            //Через адаптер обращаемся к команде, и формируем массив данных(к табличке)
            //Все объекты будем помещать в table
            
            adapter.SelectCommand = command;
            adapter.Fill(tables);
           
            //Проверка сколько у нас есть записей, если больше чем 0, то пользователь авторизован
            
            if (tables.Rows.Count > 0)
                MessageBox.Show("Yes");
            else
                MessageBox.Show("No");

        }

        private void loginField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
