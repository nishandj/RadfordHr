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
        int? selectedId = null;

        public int? Id
        {
            get
            {
                return selectedId;
            }
            set { selectedId = value; }
        }

        public StaffType StaffType
        {
            get
            {
                return rbEmployee.Checked ? StaffType.Employee : StaffType.Manager;
            }
            set
            {
                if (value == StaffType.Manager)
                    rbManager.Checked = true;
                else rbEmployee.Checked = false;
            }
        }
        public StaffTitle Title
        {
            get
            {
                if (rbMr.Checked)
                {
                    return StaffTitle.Mr;
                }
                else if (rbMrs.Checked)
                {
                    return StaffTitle.Mrs;
                }
                else if (rbMiss.Checked)
                {
                    return StaffTitle.Miss;
                }
                else if (rbSir.Checked)
                {
                    return StaffTitle.Sir;
                }
                else
                {
                    return StaffTitle.Mr;
                }
            }
            set
            {
                if (value == StaffTitle.Mr)
                    rbMr.Checked = true;
                else if (value == StaffTitle.Mrs)
                    rbMrs.Checked = true;
                else if (value == StaffTitle.Miss)
                    rbMiss.Checked = true;
                else if (value == StaffTitle.Sir)
                    rbSir.Checked = true;
            }
        }
        public string FirstName
        {
            get
            {
                return txtFirstName.Text;
            }
            set { txtFirstName.Text = value; }
        }
        public string LastName
        {
            get
            {
                return txtLastName.Text;
            }
            set { txtLastName.Text = value; }
        }
        public string MiddleInitial
        {
            get
            {
                return txtMiddleInitial.Text;
            }
            set { txtMiddleInitial.Text = value; }
        }
        public string HomePhone
        {
            get
            {
                return txtHomePhone.Text;
            }
            set { txtHomePhone.Text = value; }
        }
        public string CellPhone
        {
            get
            {
                return txtCellPhone.Text;
            }
            set { txtCellPhone.Text = value; }
        }
        public string OfficeExtension
        {
            get
            {
                return txtOfficeExtension.Text;
            }
            set { txtOfficeExtension.Text = value; }
        }
        public string IRDNumber
        {
            get
            {
                return txtIRDNumber.Text;
            }
            set { txtIRDNumber.Text = value; }
        }
        public StaffStatus Status
        {
            get
            {
                if (rbActive.Checked)
                {
                    return StaffStatus.Active;
                }
                else if (rbInactive.Checked)
                {
                    return StaffStatus.Inactive;
                }
                else if (rbPending.Checked)
                {
                    return StaffStatus.Pending;
                }
                else
                {
                    return StaffStatus.Active;
                }
            }
            set
            {
                if (value == StaffStatus.Active)
                    rbActive.Checked = true;
                else if (value == StaffStatus.Inactive)
                    rbInactive.Checked = true;
                else if (value == StaffStatus.Pending)
                    rbPending.Checked = true;
            }
        }
        public int? ManagerId
        {
            get
            {
                return cbManager.SelectedIndex;
            }
            set { /*cbManager.SelectedIndex = value??0;*/  }
        }

        public void AddStaffToGrid(RadfordHr_Model.Staff user)
        {
            throw new NotImplementedException();
        }

        public void ClearGrid()
        {
            dgvStaff.Columns.Clear();
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.Columns.Add("IdColumn", "ID");
            dgvStaff.Columns.Add("StaffTypeColumn", "Type");
            dgvStaff.Columns.Add("TitleColumn", "Title");
            dgvStaff.Columns.Add("FirstNameColumn", "First Name");
            dgvStaff.Columns.Add("LastNameColumn", "Last Name");
            dgvStaff.Columns.Add("MiddleInitialColumn", "Middle Initial");
            dgvStaff.Columns.Add("HomePhoneColumn", "Home Phone");
            dgvStaff.Columns.Add("CellPhoneColumn", "Cell Phone");
            dgvStaff.Columns.Add("OfficeExtensionColumn", "Office Extension");
            dgvStaff.Columns.Add("IRDNumberColumn", "IRD Number");
            dgvStaff.Columns.Add("StatusColumn", "Status");
            dgvStaff.Columns.Add("ManagerIdColumn", "Manager");
            //_controller.AddNewStaff();
            dgvStaff.DataSource = _controller.StaffList;
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
            _controller = controller;
        }

        public void SetSelectedStaffInGrid(RadfordHr_Model.Staff user)
        {
            //throw new NotImplementedException();
        }

        public void UpdateGridWithChangedStaff(RadfordHr_Model.Staff user)
        {
            throw new NotImplementedException();
        }

        private void StaffView_Load(object sender, EventArgs e)
        {
            try
            {
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Title", "Title");
                //dgvStaff.Columns.Add("First Name", "First Name");
                //dgvStaff.Columns.Add("Last Name", "Last Name");
                //dgvStaff.Columns.Add("Middle Initial", "Middle Initial");
                //dgvStaff.Columns.Add("Home Phone", "Home Phone");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.Columns.Add("Type", "Type");
                //dgvStaff.DataSource = _controller.StaffList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            _controller.AddNewStaff();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _controller.Save();
            dgvStaff.DataSource = _controller.StaffList;
        }
    }
}
