using RadfordHr_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadfordHr_Controller
{
    public interface IStaffView
    {
        void SetController(StaffController controller);
        void ClearGrid();
        void AddStaffToGrid(Staff user);
        void UpdateGridWithChangedStaff(Staff user);
        void RemoveStaffFromGrid(Staff user);
        int? GetIdOfSelectedStaffInGrid();
        void SetSelectedStaffInGrid(Staff user);

        Staff Staff { get; set; }
         //int? Id { get; set; }
         //StaffType StaffType { get; set; }
         //string Title { get; set; } 
         //string FirstName { get; set; } 
         //string LastName { get; set; } 
         //string MiddleInitial { get; set; } 
         //string HomePhone { get; set; } 
         //string CellPhone { get; set; } 
         //string OfficeExtension { get; set; } 
         //string IRDNumber { get; set; } 
         //string Status { get; set; } 
         //int? ManagerId { get; set; }
    }
}
