using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB.SqlQuery;
using RadfordHr.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinqToDB.DataProvider.SqlServer.SqlServerProviderAdapter;
using static RadfordHr.Data.Models.ExtensionMethods;

namespace Radford_DataService.DataService
{
    public class RadfordHrDbService
    {
        static string connectionString = string.Empty;
        public RadfordHrDbService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["RadfordHrDbContextConnectionString"].ConnectionString ?? string.Empty;
            DataConnection.DefaultSettings = new MySettings();
        }

        #region Select Records
        public List<GetStaffResult>? GetStaff()
        {
            try
            {
                using var db = new RadfordHrDbContext();
                var result = db.GetStaff();
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<GetStaffResult>> GetStaffAsync()
        {
            try
            {
                using var db = new RadfordHrDbContext();
                var result = await db.GetStaffAsync();
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region Update Records
        public int UpsertStaff(ref int? id, string staffType, string title, string firstName, string lastName, string middleInitial, string homePhone, string cellPhone, string officeExtension, string irdNumber, string status, int? managerId)
        {
            try
            {
                using var db = new RadfordHrDbContext();
                var result = db.UpsertStaff(ref id, staffType, title, firstName, lastName, middleInitial, homePhone, cellPhone, officeExtension, irdNumber, status, managerId);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
public class ConnectionStringSettings : IConnectionStringSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ProviderName { get; set; } = string.Empty;
    public bool IsGlobal => false;
}

public class MySettings : ILinqToDBSettings
{
    public IEnumerable<IDataProviderSettings> DataProviders
        => Enumerable.Empty<IDataProviderSettings>();

    public string DefaultConfiguration => "SqlServer";
    public string DefaultDataProvider => "SqlServer";

    public IEnumerable<IConnectionStringSettings> ConnectionStrings
    {
        get
        {
            yield return
                new ConnectionStringSettings
                {
                    Name = "RadfordHrDbContextConnectionString",
                    ProviderName = ProviderName.SqlServer,
                    ConnectionString =
                        ConfigurationManager.ConnectionStrings["RadfordHrDbContextConnectionString"].ConnectionString ?? string.Empty
                };
        }
    }
}