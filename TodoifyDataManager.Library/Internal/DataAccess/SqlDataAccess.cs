﻿using Dapper;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoifyDataManager.Library.Internal.DataAccess
{
    public class SqlDataAccess
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connString = GetConnectionString(connectionStringName);
            using (IDbConnection conn = new SqlConnection(connString))
            {
                List<T> rows = conn.Query<T>(storedProcedure, parameters, commandType: CommandType.Text).ToList();
                return rows;
            }
        }

        //public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        //{
        //    string connString = GetConnectionString(connectionStringName);
        //    using (IDbConnection conn = new SqlConnection(connString))
        //    {
        //        conn.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        //    }
        //}
    }
}
