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
        Staff _selectedStaff;

        public StaffController(IStaffView view, List<Staff> staff)
        {
            _view = view;
            _staff = staff;
            view.SetController(this);
        }
        public List<Staff> StaffList
        {
            get { return _staff??new(); }
        }

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
            foreach (Staff usr in _staff)
                _view.AddStaffToGrid(usr);
            if (_staff != null && _staff.Count>0)
                _view.SetSelectedStaffInGrid(_staff.First());

        }
        public void SelectedStaffChanged(int selectedStaffId)
        {
            foreach (Staff stf in this._staff)
            {
                if (stf.Id == selectedStaffId)
                {
                    _selectedStaff = stf;
                    updateViewDetailValues(stf);
                    _view.SetSelectedStaffInGrid(stf);
                    //this._view.CanModifyID = false;
                    break;
                }
            }
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
            if (!this._staff.Contains(_selectedStaff))
            {
                // Add new user
                this._staff.Add(_selectedStaff);
                //this._view.AddUserToGrid(_selectedStaff);
            }
            else
            {
                // Update existing
                //this._staff.UpdateGridWithChangedUser(_selectedStaff);
            }
            _view.SetSelectedStaffInGrid(_selectedStaff);
            //this._view.CanModifyID = false;

        }
    }
}
