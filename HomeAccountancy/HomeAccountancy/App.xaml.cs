using HomeAccountancy.Model;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace HomeAccountancy
{
    public partial class App : Application
    {
        public App()
        {
            string connectionString = string.Format("Data Source={0}", Path.Combine(Directory.GetCurrentDirectory(), "Data", "HomeAccountancy.db"));

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    PreloadAccounts(connection, "Accounts");
                    PreloadTransaction(connection, "Transactions");
                    PreloadCategory(connection, "Categories");
                    PreloadCurrency(connection, "Currencies");
                    PreloadRate(connection, "Rates");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception: " + e.Message);
                }
            }
        }

        private void PreloadAccounts(SQLiteConnection connection, string tableName)
        {
            SQLiteDataAdapter adapter = GetAdapter(connection, tableName);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            foreach (DataRow row in dataSet.Tables[0].Rows)
                Account.Entities.Add(new Account(Convert.ToInt64(row["Id"]), Convert.ToString(row["Name"]), Convert.ToInt32(row["CurrencyId"])));

            Account.PreloadData(adapter, dataSet);
        }
        private void PreloadTransaction(SQLiteConnection connection, string tableName)
        {
            SQLiteDataAdapter adapter = GetAdapter(connection, tableName);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                long id = Convert.ToInt64(row["Id"]);
                long categoryId = Convert.ToInt64(row["CategoryId"]);
                long accountId = Convert.ToInt64(row["AccountId"]);
                double sum = Convert.ToDouble(row["Sum"]);
                DateTime date = DateTime.ParseExact(Convert.ToString(row["Date"]), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                string description = Convert.ToString(row["Description"]);

                if (Convert.ToDouble(row["Sum"]) > 0)
                    IncomeTransaction.Entities.Add(new IncomeTransaction(id, categoryId, accountId, sum, date, description));
                else
                    OutgoTransaction.Entities.Add(new IncomeTransaction(id, categoryId, accountId, sum, date, description));
            }

            Account.PreloadData(adapter, dataSet);
        }
        private void PreloadCategory(SQLiteConnection connection, string tableName)
        {
            SQLiteDataAdapter adapter = GetAdapter(connection, tableName);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                long id = Convert.ToInt64(row["Id"]);
                string name = Convert.ToString(row["Name"]);

                if (Convert.ToInt32(row["IsOutgo"]) == 0)
                    Category.Entities.Add(new IncomeCategory(id, name));
                else
                    Category.Entities.Add(new OutgoCategory(id, name));
            }

            Account.PreloadData(adapter, dataSet);
        }
        private void PreloadCurrency(SQLiteConnection connection, string tableName)
        {
            SQLiteDataAdapter adapter = GetAdapter(connection, tableName);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            foreach (DataRow row in dataSet.Tables[0].Rows)
                Currency.Entities.Add(new Currency(Convert.ToInt64(row["Id"]), Convert.ToString(row["FullName"]), Convert.ToString(row["ShortageName"])));

            Account.PreloadData(adapter, dataSet);
        }
        private void PreloadRate(SQLiteConnection connection, string tableName)
        {
            SQLiteDataAdapter adapter = GetAdapter(connection, tableName);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);



            Account.PreloadData(adapter, dataSet);
        }

        private SQLiteDataAdapter GetAdapter(SQLiteConnection connection, string tableName)
        {
            return new SQLiteDataAdapter(string.Format("SELECT * FROM {0}", tableName), connection);
        }
    }
}