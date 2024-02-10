using Microsoft.Data.SqlClient;
using ParsVanSale.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Services
{
	public class ServerDbConnection
	{
		private static ServerDbConnection _instance;
		public static ServerDbConnection Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ServerDbConnection();
				}
				return _instance;
			}
		}

		private string _userId;
		private string _password;
		private string _serverIp;
		private string _databaseName;

		private ServerDbConnection()
		{
		}
		public async Task InitializeAsync()
		{
			try
			{
				Expression<Func<SqlServerIPSettings, bool>> predicate = item => item.IsConnected == true;
				var dbmodel = await App.Database.GetFirstAsync<SqlServerIPSettings, bool>(predicate, null);
				_userId = dbmodel.User;
				_password = dbmodel.Password;
				_serverIp = dbmodel.IP;
				_databaseName = dbmodel.Database;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public SqlConnection GetConnection()
		{
			string connectionString = $"Data Source={_serverIp};Initial Catalog={_databaseName};Persist Security Info=True;User ID={_userId};Password={_password};Encrypt=false;TrustServerCertificate=true";
			var connection = new SqlConnection(connectionString);
			connection.Open();
			if (connection.State == ConnectionState.Open)
			{
				IsConnected();
				return connection;
			}
			else
			{
				return null;
			}
		}
		public bool IsConnected()
		{
			try
			{
				using (var ping = new Ping())
				{
					PingReply reply = ping.Send(_serverIp, 1000); 

					if (reply.Status == IPStatus.Success)
					{
						// The server is reachable, now try to open the database connection
						string connectionString = $"Data Source={_serverIp};Initial Catalog={_databaseName};Persist Security Info=True;User ID={_userId};Password={_password};Encrypt=false;TrustServerCertificate=true;Connection Timeout=4";
						var connection = new SqlConnection(connectionString);

						connection.Open(); // Attempt to open the connection

						if (connection.State == ConnectionState.Open)
						{
							connection.Close();
							return true;
						}
						else
						{
							Console.WriteLine("Connection state: " + connection.State);
							return false;
						}
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
		}
	}
}
