using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;

namespace AceApp.ViewModel.Helpers
{
    public static class DataBaseHelper
    {
        //create database file path that will be stored in app
        private static string dataBaseFile = Path.Combine(Environment.CurrentDirectory, @"src/data/", "ACEDataBase.db3");

        //TODO: also create backup database file if user would like to be sure that if someone will delete the file, still file can be recovered

        //create generic insert method that retun bool type if operation was successful
        public static bool Insert<T>(T item)
        {
            bool result = false;
            //open connection for database path and create a table if is not created yet
            using (SQLiteConnection connection = new SQLiteConnection(dataBaseFile))
            {
                connection.CreateTable<T>();
                //insert item to table and get table rows integer
                int tableRows = connection.Insert(item);
                if (tableRows > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        //create generic update method that return bool type if operation was successful
        public static bool Update<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection connection = new SQLiteConnection(dataBaseFile))
            {
                connection.CreateTable<T>();
                int tableRows = connection.Update(item);
                if (tableRows > 0)
                {
                    result = true;
                }

                return result;
            }
        }

        //create remove or delete method that will remove item from table and return bool type if success or not
        public static bool Remove<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection connection = new SQLiteConnection(dataBaseFile))
            {
                connection.CreateTable<T>();
                int tableRows = connection.Delete<T>(item);
                if (tableRows > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        //create read method that return List of Database items stored in table databaseFile
        public static List<T> Read<T>() where T : new()
        {
            //create List of items for storage
            List<T> dataBaseListItems;
            //open connection and ....
            using (SQLiteConnection connection = new SQLiteConnection(dataBaseFile))
            {
                connection.CreateTable<T>();
                //get collection from table and store it to List type dataBaseListItems
                dataBaseListItems = connection.Table<T>().ToList();
            }

            return dataBaseListItems;
        }
    }
}