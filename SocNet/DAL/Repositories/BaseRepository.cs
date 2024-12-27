using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Dapper;

namespace SocNet.DAL.Repositories;

/// <summary>
/// Класс для подключения к файлу БД
/// </summary>
internal class BaseRepository
{
    /// <summary>
    /// Метод для исполнения запроса, подразумевающего возврат одной записи
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();
            return connection.QueryFirstOrDefault<T>(sql, parameters);
        }
    }

    /// <summary>
    /// Метод для исполнения запроса, подразумевающего возврат нескольких записей
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <returns>Коллекция</returns>
    protected List<T> Query<T>(string sql, object parameters = null)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();
            return connection.Query<T>(sql, parameters).ToList();
        }
    }

    /// <summary>
    /// Метод для исполнения запроса, не подразумевающиего возврат данных
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <returns>Выполнение запроса</returns>
    protected int Execute(string sql, object parameters = null)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();
            return connection.Execute(sql, parameters);
        }
    }

    /// <summary>
    /// Создание подключения по адресу файла БД
    /// </summary>
    /// <returns>Подключение</returns>
    private IDbConnection CreateConnection()
    {
        return new SQLiteConnection("Data Source = DAL/DB/soc_net_DB.db; Version = 3");
    }
}
