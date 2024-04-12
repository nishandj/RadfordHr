using Microsoft.VisualBasic.ApplicationServices;
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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public StaffView()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
                if (rbEmployee.Checked)
                {
                    return StaffType.Employee;
                }
                else if (rbManager.Checked)
                {
                    return StaffType.Manager;
                }
                else
                {
                    return StaffType.Employee;
                }
            }
            set
            {
                if (value == StaffType.Employee)
                {
                    rbEmployee.Checked = true;
                }
                else if (value == StaffType.Manager)
                {
                    rbManager.Checked = true;
                }
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
                if (cbManager.SelectedItem != null)
                    return ((Staff)cbManager.SelectedItem).Id;
                else
                    return null;
            }
            set
            {
                if (value.HasValue)
                {
                    cbManager.SelectedItem = _controller.ManagerList.Where(x => x.Id == value).FirstOrDefault();
                }
                else
                {
                    cbManager.SelectedItem = null;

                }
            }
        }

        public void AddStaffToGrid(RadfordHr_Model.Staff staff)
        {
            Staff? manager = _controller.ManagerList.Where(x => x.Id == staff.ManagerId).FirstOrDefault();
            string managerName = manager == null ? string.Empty : manager.FullName;
            dgvStaff.Rows.Add(staff.Id.ToString(), staff.StaffType.ToString(), staff.Title.ToString(), staff.FirstName,
                staff.LastName, staff.MiddleInitial, staff.HomePhone, staff.CellPhone,
                staff.OfficeExtension, staff.IRDNumber, staff.Status.ToString(), managerName);
        }

        public void ClearGrid()
        {
            dgvStaff.Rows.Clear();
            dgvStaff.Columns.Clear();
            dgvStaff.Columns.Add("ID", "ID");
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
            dgvStaff.Columns.Add("ManagerIdColumn", "Manager Name");
        }

        public int? GetIdOfSelectedStaffInGrid()
        {
            return this.Id;
        }

        public void RemoveStaffFromGrid(RadfordHr_Model.Staff staff)
        {

        }

        public void SetController(StaffController controller)
        {
            _controller = controller;
        }

        public void SetSelectedStaffInGrid(RadfordHr_Model.Staff staff)
        {
            //foreach (DataGridViewRow row in dgvStaff.Rows)
            //{
            //    if (row.Cells[0].Value.ToString().Equals(staff.Id?.ToString()))
            //    {
            //        row.Selected = true;
            //        break;
            //    }
            //}
        }

        public void UpdateGridWithChangedStaff(RadfordHr_Model.Staff staff)
        {
            foreach (DataGridViewRow row in dgvStaff.Rows)
            {
                // 0 is the column index
                if (row.Cells[0].Value.ToString()==staff.Id.ToString())
                {
                    row.Cells[1].Value = staff.StaffType.ToString();
                    row.Cells[2].Value = staff.Title.ToString();
                    row.Cells[3].Value = staff.FirstName;
                    row.Cells[4].Value = staff.LastName;
                    row.Cells[5].Value = staff.MiddleInitial;
                    row.Cells[6].Value = staff.HomePhone;
                    row.Cells[7].Value = staff.CellPhone;
                    row.Cells[8].Value = staff.OfficeExtension;
                    row.Cells[9].Value = staff.IRDNumber;
                    row.Cells[10].Value = staff.Status.ToString();
                    row.Cells[11].Value = _controller.ManagerList.Where(x => x.Id == staff.ManagerId).FirstOrDefault()?.FullName;
                    break;
                }
            }
        }

        private void StaffView_Load(object sender, EventArgs e)
        {
            try
            {
                btnCancel.Enabled = btnSave.Enabled = _controller.SelectedStaff != null;
                var managerList = _controller.ManagerList;
                managerList.Insert(0, new Staff() { Id = null, FirstName = "", LastName = "" });
                cbManager.DataSource = managerList;
                cbManager.DisplayMember = "FullName";
                cbManager.ValueMember = "Id";
                cbManager.Visible = false;
                cmbFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            _controller.AddNewStaff();
            btnCancel.Enabled = btnSave.Enabled = _controller.SelectedStaff != null;
            btnAddNewRecord.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _controller.Save();
            btnAddNewRecord.Enabled = true;
            btnCancel.Enabled = btnSave.Enabled = _controller.SelectedStaff != null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //_controller.AddNewStaff();
            _controller.SelectedStaff = null;
            btnAddNewRecord.Enabled = true;
            btnCancel.Enabled = btnSave.Enabled = _controller.SelectedStaff != null;
        }

        private void rbManager_CheckedChanged(object sender, EventArgs e)
        {
            if (rbManager.Checked)
            {
                cbManager.Visible = false;
            }
            else
            {
                cbManager.Visible = true;
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var id = this.dgvStaff[0, e.RowIndex].Value.ToString();
                _controller.SelectedStaffChanged(int.Parse(id));
                btnCancel.Enabled = btnSave.Enabled = _controller.SelectedStaff != null;
            }
        }

        private void rbEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (rbManager.Checked)
            {
                cbManager.Visible = false;
            }
            else
            {
                cbManager.Visible = true;
            }
        }

        private void cbManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_controller.SelectedStaff != null && cbManager.SelectedItem != null)                
                this.ManagerId = ((Staff)cbManager.SelectedItem).Id;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.FilterStaffList(cmbFilter.SelectedItem.ToString());
        }

        public void UpdateGridWithChangedStaff(List<Staff> staffList)
        {
            dgvStaff.Rows.Clear();
            foreach (var staff in staffList)
            {
                AddStaffToGrid(staff);
            }
        }
    }
}
