﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadfordHr_Model
{
    public class Staff 
    {
        public Staff()
        {
        }
        public Staff(int? Id, StaffType StaffType, string Title, string FirstName, string LastName, string MiddleInitial, string HomePhone, string CellPhone,
            string OfficeExtension, string IRDNumber, string Status, int? ManagerId)
        {
            this.Id = Id;
            this.StaffType = StaffType;
            this.Title = Title;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleInitial = MiddleInitial;
            this.HomePhone = HomePhone;
            this.CellPhone = CellPhone;
            this.OfficeExtension = OfficeExtension;
            this.IRDNumber = IRDNumber;
            this.Status = Status;
            this.ManagerId = ManagerId;
        }
        public int? Id { get; set; }
        public StaffType StaffType { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleInitial { get; set; } = string.Empty;
        public string HomePhone { get; set; } = string.Empty;
        public string CellPhone { get; set; } = string.Empty;
        public string OfficeExtension { get; set; } = string.Empty;
        public string IRDNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
    }
    public enum StaffType
    {
        Employee, 
        Manager
    }
    public enum StaffStatus
    {
        Active, 
        Inactive, 
        Pending
    }
}
