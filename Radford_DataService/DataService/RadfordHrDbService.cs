using LinqToDB;
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
        public RadfordHrDbService() => connectionString = ConfigurationManager.AppSettings["RadfordHrDbContextConnectionString"] ?? string.Empty;

        #region Select Records
        public List<GetStaffResult>? GetStaff()
        {
            using var db = new RadfordHrDbContext(connectionString);
            var result = db.GetStaff();
            return result.ToList(); 
        }
        public async Task<List<GetStaffResult>> GetStaffAsync()
        {
            using var db = new RadfordHrDbContext(connectionString);
            var result = await db.GetStaffAsync();
            return result.ToList();
        }
        #endregion
        #region Update Records
        public int UpsertStaff(int? id, string staffType, string title, string firstName, string lastName, string middleInitial, string homePhone, string cellPhone, string officeExtension, string irdNumber, string status, int? managerId)
        {            
            using var db = new RadfordHrDbContext(connectionString);
            var result = db.UpsertStaff(id, staffType, title, firstName, lastName, middleInitial, homePhone, cellPhone, officeExtension, irdNumber, status, managerId);
            return result;
        }

        #endregion
    }
}
