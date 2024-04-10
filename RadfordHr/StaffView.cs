using RadfordHr_Controller;
using RadfordHr_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadfordHr
{
    public partial class StaffView : Form, IStaffView
    {
        public StaffView()
        {
            InitializeComponent();
        }

        StaffController _controller;
        Staff Staff = new();
        RadfordHr_Model.Staff IStaffView.Staff
        {
            get
            {
                return new RadfordHr_Model.Staff();

            }
            set
            {
                Staff = value;
            }
        }

        //public int? Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public StaffType StaffType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string MiddleInitial { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string HomePhone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string CellPhone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string OfficeExtension { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string IRDNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public int? ManagerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddStaffToGrid(RadfordHr_Model.Staff user)
        {
            throw new NotImplementedException();
        }

        public void ClearGrid()
        {
            throw new NotImplementedException();
        }

        public int? GetIdOfSelectedStaffInGrid()
        {
            throw new NotImplementedException();
        }

        public void RemoveStaffFromGrid(RadfordHr_Model.Staff user)
        {
            throw new NotImplementedException();
        }

        public void SetController(StaffController controller)
        {
            throw new NotImplementedException();
        }

        public void SetSelectedStaffInGrid(RadfordHr_Model.Staff user)
        {
            throw new NotImplementedException();
        }

        public void UpdateGridWithChangedStaff(RadfordHr_Model.Staff user)
        {
            throw new NotImplementedException();
        }
    }
}
