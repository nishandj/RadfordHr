using Radford_DataService.DataService;
using RadfordHr_Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadfordHr_Controller
{
    public class StaffController
    {        
        IStaffView _view;
        List<Staff> _staff;
        List<Staff> _staffBackup;
        Staff _selectedStaff;
        RadfordHrDbService radfordHrDbService;

        public StaffController(IStaffView view, List<Staff> staff)
        {
            _view = view;
            _staff = staff;
            view.SetController(this);
            radfordHrDbService = new RadfordHrDbService();
            _staffBackup = new();
        }
        public List<Staff> StaffList
        {
            get { return _staff??new(); }
        }
        public List<Staff> ManagerList
        {
            get { return _staff.Where(x => x.StaffType.ToString().ToLower().Equals(StaffType.Manager.ToString().ToLower())).ToList(); }
        }
        public Staff? SelectedStaff { get { return _selectedStaff; }set { _selectedStaff = value; } } 

        private void updateViewDetailValues(Staff staff)
        {
            //_view.Staff = staff;
            _view.Id = staff.Id;
            _view.StaffType = staff.StaffType;
            _view.Title = staff.Title;
            _view.FirstName = staff.FirstName;
            _view.LastName = staff.LastName;
            _view.MiddleInitial = staff.MiddleInitial;
            _view.HomePhone = staff.HomePhone;
            _view.CellPhone = staff.CellPhone;
            _view.OfficeExtension = staff.OfficeExtension;
            _view.IRDNumber = staff.IRDNumber;
            _view.Status = staff.Status;
            _view.ManagerId = staff.ManagerId;
        }
        private void updateStaffWithViewValues(Staff staff)
        {
            //staff = _view.Staff;
            staff.Id = _view.Id;
            staff.StaffType = _view.StaffType;
            staff.Title = _view.Title;
            staff.FirstName = _view.FirstName;
            staff.LastName = _view.LastName;
            staff.MiddleInitial = _view.MiddleInitial;
            staff.HomePhone = _view.HomePhone;
            staff.CellPhone = _view.CellPhone;
            staff.OfficeExtension = _view.OfficeExtension;
            staff.IRDNumber = _view.IRDNumber;
            staff.Status = _view.Status;
            staff.ManagerId = _view.ManagerId;
        }
        public void LoadView()
        {
            _view.ClearGrid();
            _staffBackup = new();
            var staff = radfordHrDbService.GetStaff();
            Staff staffToAdd;
            foreach (var stf in staff)
            {
                staffToAdd= new Staff(stf.Id, (StaffType)Enum.Parse(typeof(StaffType), stf.StaffType), 
                    (StaffTitle)Enum.Parse(typeof(StaffTitle), stf.Title), stf.FirstName, stf.LastName, 
                    stf.MiddleInitial, stf.HomePhone, stf.CellPhone, stf.OfficeExtension, stf.IrdNumber, 
                    (StaffStatus)Enum.Parse(typeof(StaffStatus), stf.Status), stf.ManagerId);
                this._staff.Add(staffToAdd);
            }
            foreach (Staff stf in _staff)
                _view.AddStaffToGrid(stf);
            if (_staff != null && _staff.Count>0)
                _view.SetSelectedStaffInGrid(_staff.First());
            if (_staff != null)
                _staffBackup.AddRange(_staff);
        }
        public void SelectedStaffChanged(int selectedStaffId)
        {
            Staff? stf = _staff.Where(x => x.Id == selectedStaffId).FirstOrDefault();
            if (stf == null)
                return;
            _selectedStaff = stf;
            updateViewDetailValues(stf);
            _view.SetSelectedStaffInGrid(stf);
            //this._view.CanModifyID = false;
        }
        public void FilterStaffList(string status)
        {
            _staff = _staffBackup;
            if (status.ToLower().Equals(StaffStatus.Active.ToString().ToLower()))
            {
                _staff = _staff.Where(x => x.Status.ToString().ToLower().Equals(StaffStatus.Active.ToString().ToLower())).ToList();
            }  
            else if (status.ToLower().Equals(StaffStatus.Inactive.ToString().ToLower()))
            {
                _staff = _staff.Where(x => x.Status.ToString().ToLower().Equals(StaffStatus.Inactive.ToString().ToLower())).ToList();
            }
            else if (status.ToLower().Equals(StaffStatus.Pending.ToString().ToLower()))
            {
                _staff = _staff.Where(x => x.Status.ToString().ToLower().Equals(StaffStatus.Pending.ToString().ToLower())).ToList();
            }
            _view.UpdateGridWithChangedStaff(_staff);
            //this._view.CanModifyID = false;
        }
        public void AddNewStaff()
        {
            _selectedStaff = new Staff(null,StaffType.Employee, StaffTitle.Mr, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, StaffStatus.Active, null);

            this.updateViewDetailValues(_selectedStaff);
            //this._view.CanModifyID = true;
        }

        public void RemoveUser()
        {
            int? id = this._view.GetIdOfSelectedStaffInGrid();
            Staff? userToRemove = null;

            if (id.HasValue)
            {
                foreach (Staff stf in this._staff)
                {
                    if (stf.Id == id)
                    {
                        userToRemove = stf;
                        break;
                    }
                }

                if (userToRemove != null)
                {
                    int newSelectedIndex = this._staff.IndexOf(userToRemove);
                    this._staff.Remove(userToRemove);
                    //this._view.RemoveUserFromGrid(userToRemove);

                    if (newSelectedIndex > -1 && newSelectedIndex < _staff.Count)
                    {
                        //this._view.SetSelectedUserInGrid((User)_users[newSelectedIndex]);
                    }
                }
            }
        }

        public void Save()
        {
            updateStaffWithViewValues(_selectedStaff);
            int? id = _selectedStaff.Id;           
            radfordHrDbService.UpsertStaff(ref id, _selectedStaff.StaffType.ToString(), 
                _selectedStaff.Title.ToString(), _selectedStaff.FirstName, _selectedStaff.LastName, _selectedStaff.MiddleInitial, 
                _selectedStaff.HomePhone, _selectedStaff.CellPhone, _selectedStaff.OfficeExtension, _selectedStaff.IRDNumber, 
                _selectedStaff.Status.ToString(), _selectedStaff.ManagerId);
            _selectedStaff.Id = id;
            if (!this._staff.Contains(_selectedStaff))
            {
                // Add new user                
                this._staff.Add(_selectedStaff);
                this._view.AddStaffToGrid(_selectedStaff);
            }
            else
            {
                // Update existing
                this._view.UpdateGridWithChangedStaff(_selectedStaff);
            }
            _view.SetSelectedStaffInGrid(_selectedStaff);
            //this._view.CanModifyID = false;

        }
    }
}
