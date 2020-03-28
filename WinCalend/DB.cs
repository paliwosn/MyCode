using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Установил MySQL, подключил плагин через ссылку MySql.Data и создал класс для обращения к БД
namespace WinCalend
{
    class DB
    {
        //Необходимо добавить диррективу БД для использования
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=icproger");
        //Создаем ф-ию которая будет открываать соединение
        public void openConnection()
        {
            //Проверяем закрыта ли база данных, если да, то открываем соединение
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        //Закрывает соединение
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        //Возвращает соединение с базой данных
        public MySqlConnection getConnection()
        {
            return connection;
        }

    }
}
