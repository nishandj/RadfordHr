using ClosedXML.Excel;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.VisualBasic.ApplicationServices;
using RadfordHr_Controller;
using RadfordHr_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WkHtmlToPdfDotNet;

namespace RadfordHr
{
    public partial class StaffView : Form, IStaffView
    {
        private PDFHelper pdfHelper;
        string css = @"
                table {
    width: 100%;
    border-collapse: collapse; /* This ensures borders are collapsed */
  }
  td {
    vertical-align: top;
    border: 1px solid black; /* Add border to table cells */
    padding: 5px; /* Add padding for better appearance */
  }
    .square {        
        margin-left: 20px;
        display: inline-block;
    }
.table_component {
    overflow: auto;
    width: 100%;
}

.table_component table {
    border: 1px solid #dededf;
    height: 100%;
    width: 100%;
    table-layout: fixed;
    border-collapse: collapse;
    border-spacing: 1px;
    text-align: left;
}

.table_component caption {
    caption-side: top;
    text-align: left;
}

.table_component th {
    border: 1px solid #dededf;
    background-color: #eceff1;
    color: #000000;
    padding: 5px;
}

.table_component td {
    border: 1px solid #dededf;
    background-color: #ffffff;
    color: #000000;
    padding: 5px;
}
                ";

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public StaffView()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            pdfHelper = new PDFHelper(new SynchronizedConverter(new PdfTools()));
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
            try
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
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
            }            
        }
        public void SetController(StaffController controller)
        {
            _controller = controller;
        }
        public void SetSelectedStaffInGrid(RadfordHr_Model.Staff staff)
        {
            //set selected staff in grid - highlight the row - not specified on the spec - to be implemented
        }
        public void UpdateGridWithChangedStaff(RadfordHr_Model.Staff staff)
        {
            try
            {
                foreach (DataGridViewRow row in dgvStaff.Rows)
                {
                    // 0 is the column index
                    if (row.Cells[0].Value.ToString() == staff.Id.ToString())
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
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
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
                cmbFilter.SelectedItem = "Active";
                rbMr.Checked = rbActive.Checked = true;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
            }
        }
        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.AddNewStaff();
                btnCancel.Enabled = btnSave.Enabled = _controller.SelectedStaff != null;
                btnAddNewRecord.Enabled = false;
                cmbFilter.SelectedItem = "All";
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
            }            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.Save();
                btnAddNewRecord.Enabled = true;
                btnCancel.Enabled = btnSave.Enabled = _controller.SelectedStaff != null;
                MessageHelper.SuccessMessage("Staff saved successfully");
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
            }            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.SelectedStaff = null;
                Id = null;
                btnAddNewRecord.Enabled = true;
                btnCancel.Enabled = btnSave.Enabled = _controller.SelectedStaff != null;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
            }            
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
            try
            {
                if (e.RowIndex > -1)
                {
                    string? id = this.dgvStaff[0, e.RowIndex].Value.ToString();
                    if (id == null)
                        throw new Exception("Id is null");
                    _controller.SelectedStaffChanged(int.Parse(id));
                    btnCancel.Enabled = btnSave.Enabled = _controller.SelectedStaff != null;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
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
            try
            {
                if (_controller.SelectedStaff != null && cbManager.SelectedItem != null)
                    this.ManagerId = ((Staff)cbManager.SelectedItem).Id;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
            }            
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cmbFilter.SelectedItem==null)
                    throw new Exception("Filter is null");
                _controller.FilterStaffList(cmbFilter.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
            }            
        }
        public void UpdateGridWithChangedStaff(List<Staff> staffList)
        {
            try
            {
                dgvStaff.Rows.Clear();
                foreach (var staff in staffList)
                {
                    AddStaffToGrid(staff);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
            }            
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog1.Title = "To Excel";
                saveFileDialog1.FileName = "RadfordHr - StaffList";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    List<StaffToPrint> staffToPrintList = new();
                    foreach (var item in _controller.StaffList)
                    {
                        staffToPrintList.Add(new StaffToPrint
                        {
                            Id = item.Id,
                            StaffType = item.StaffType.ToString(),
                            Title = item.Title.ToString(),
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            MiddleInitial = item.MiddleInitial,
                            HomePhone = item.HomePhone,
                            CellPhone = item.CellPhone,
                            OfficeExtension = item.OfficeExtension,
                            IRDNumber = item.IRDNumber,
                            Status = item.Status.ToString(),
                            Manager = _controller.ManagerList.Where(x => x.Id == item.ManagerId).FirstOrDefault()?.FullName
                        });
                    }
                    staffToPrintList = staffToPrintList.OrderBy(x => x.StaffType).ThenBy(x => x.FirstName).ToList();
                    fileName = saveFileDialog1.FileName;
                    XLWorkbook xLWorkbook = ExcelHelper.GenerateExcel<StaffToPrint>(staffToPrintList, "RadfordHr - StaffList");
                    xLWorkbook.SaveAs(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
            }            
        }        
        private void btnExportToPdf_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();                
                saveFileDialog1.Title = "Pdf";
                saveFileDialog1.FileName = "RadfordHr - StaffList.pdf";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    List<StaffToPrint> staffToPrintList = new();
                    foreach (var item in _controller.StaffList)
                    {
                        staffToPrintList.Add(new StaffToPrint
                        {
                            Id = item.Id,
                            StaffType = item.StaffType.ToString(),
                            Title = item.Title.ToString(),
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            MiddleInitial = item.MiddleInitial,
                            HomePhone = item.HomePhone,
                            CellPhone = item.CellPhone,
                            OfficeExtension = item.OfficeExtension,
                            IRDNumber = item.IRDNumber,
                            Status = item.Status.ToString(),
                            Manager = _controller.ManagerList.Where(x => x.Id == item.ManagerId).FirstOrDefault()?.FullName
                        });
                    }
                    staffToPrintList = staffToPrintList.OrderBy(x => x.StaffType).ThenBy(x => x.FirstName).ToList();
                    StringBuilder documentBuilder = new StringBuilder();
                    documentBuilder.Append("<html>");
                    documentBuilder.Append("<head><style>" + css + "</style></head>");
                    documentBuilder.Append("<body>");
                    documentBuilder.Append("<div style='text-align:center;'><h1>RadfordHr - StaffList</h1></div>");
                    documentBuilder.Append("<table class='table_component'>");
                    documentBuilder.Append("<thead><tr>");
                    documentBuilder.Append("<th>ID</th>");
                    documentBuilder.Append("<th>Staff Type</th>");
                    documentBuilder.Append("<th>Title</th>");
                    documentBuilder.Append("<th>First Name</th>");
                    documentBuilder.Append("<th>Last Name</th>");
                    documentBuilder.Append("<th>Middle Initial</th>");
                    documentBuilder.Append("<th>Home Phone</th>");
                    documentBuilder.Append("<th>Cell Phone</th>");
                    documentBuilder.Append("<th>Office Extension</th>");
                    documentBuilder.Append("<th>IRD Number</th>");
                    documentBuilder.Append("<th>Status</th>");
                    documentBuilder.Append("<th>Manager</th>");
                    documentBuilder.Append("</tr></thead><tbody>");
                    foreach (var stf in staffToPrintList)
                    {
                        documentBuilder.Append("<tr>");
                        documentBuilder.Append("<td>" + stf.Id + "</td>");
                        documentBuilder.Append("<td>" + stf.StaffType + "</td>");
                        documentBuilder.Append("<td>" + stf.Title + "</td>");
                        documentBuilder.Append("<td>" + stf.FirstName + "</td>");
                        documentBuilder.Append("<td>" + stf.LastName + "</td>");
                        documentBuilder.Append("<td>" + stf.MiddleInitial + "</td>");
                        documentBuilder.Append("<td>" + stf.HomePhone + "</td>");
                        documentBuilder.Append("<td>" + stf.CellPhone + "</td>");
                        documentBuilder.Append("<td>" + stf.OfficeExtension + "</td>");
                        documentBuilder.Append("<td>" + stf.IRDNumber + "</td>");
                        documentBuilder.Append("<td>" + stf.Status + "</td>");
                        documentBuilder.Append("<td>" + stf.Manager + "</td>");
                        documentBuilder.Append("</tr>");
                    }
                    documentBuilder.Append("</tbody></table>");//<div style='page-break-before:always'>&nbsp;</div>
                    documentBuilder.Append("</body></html>");
                    byte[] pdf = pdfHelper.PdfSharpConvert(documentBuilder.ToString());
                    fileName = saveFileDialog1.FileName;
                    File.WriteAllBytes(fileName, pdf);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
            }
        }
        private class StaffToPrint
        {
            public int? Id { get; set; }
            public string? StaffType { get; set; }
            public string? Title { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? MiddleInitial { get; set; }
            public string? HomePhone { get; set; }
            public string? CellPhone { get; set; }
            public string? OfficeExtension { get; set; }
            public string? IRDNumber { get; set; }
            public string? Status { get; set; }
            public string? Manager { get; set; }
        }
    }
}
