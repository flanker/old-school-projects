﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3053
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DakkaData
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="dakka2")]
	public partial class DakkaLinqDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertEmployee(Employee instance);
    partial void UpdateEmployee(Employee instance);
    partial void DeleteEmployee(Employee instance);
    partial void InsertWorkRecord(WorkRecord instance);
    partial void UpdateWorkRecord(WorkRecord instance);
    partial void DeleteWorkRecord(WorkRecord instance);
    partial void InsertShiftDef(ShiftDef instance);
    partial void UpdateShiftDef(ShiftDef instance);
    partial void DeleteShiftDef(ShiftDef instance);
    partial void InsertShiftPoint(ShiftPoint instance);
    partial void UpdateShiftPoint(ShiftPoint instance);
    partial void DeleteShiftPoint(ShiftPoint instance);
    partial void InsertWorkCalendar(WorkCalendar instance);
    partial void UpdateWorkCalendar(WorkCalendar instance);
    partial void DeleteWorkCalendar(WorkCalendar instance);
    partial void InsertWorkCalendarRule(WorkCalendarRule instance);
    partial void UpdateWorkCalendarRule(WorkCalendarRule instance);
    partial void DeleteWorkCalendarRule(WorkCalendarRule instance);
    #endregion
		
		public DakkaLinqDataContext() : 
				base(global::DakkaData.Properties.Settings.Default.dakka2ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DakkaLinqDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DakkaLinqDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DakkaLinqDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DakkaLinqDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Employee> Employee
		{
			get
			{
				return this.GetTable<Employee>();
			}
		}
		
		public System.Data.Linq.Table<WorkRecord> WorkRecord
		{
			get
			{
				return this.GetTable<WorkRecord>();
			}
		}
		
		public System.Data.Linq.Table<ShiftDef> ShiftDef
		{
			get
			{
				return this.GetTable<ShiftDef>();
			}
		}
		
		public System.Data.Linq.Table<ShiftPoint> ShiftPoint
		{
			get
			{
				return this.GetTable<ShiftPoint>();
			}
		}
		
		public System.Data.Linq.Table<WorkCalendar> WorkCalendar
		{
			get
			{
				return this.GetTable<WorkCalendar>();
			}
		}
		
		public System.Data.Linq.Table<WorkCalendarRule> WorkCalendarRule
		{
			get
			{
				return this.GetTable<WorkCalendarRule>();
			}
		}
	}
	
	[Table(Name="dbo.Employee")]
	public partial class Employee : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Code;
		
		private string _Name;
		
		private string _Email;
		
		private string _Dept;
		
		private EntitySet<WorkRecord> _WorkRecord;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnCodeChanging(string value);
    partial void OnCodeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnDeptChanging(string value);
    partial void OnDeptChanged();
    #endregion
		
		public Employee()
		{
			this._WorkRecord = new EntitySet<WorkRecord>(new Action<WorkRecord>(this.attach_WorkRecord), new Action<WorkRecord>(this.detach_WorkRecord));
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Code", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Email", DbType="VarChar(50)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[Column(Storage="_Dept", DbType="VarChar(50)")]
		public string Dept
		{
			get
			{
				return this._Dept;
			}
			set
			{
				if ((this._Dept != value))
				{
					this.OnDeptChanging(value);
					this.SendPropertyChanging();
					this._Dept = value;
					this.SendPropertyChanged("Dept");
					this.OnDeptChanged();
				}
			}
		}
		
		[Association(Name="Employee_WorkRecord", Storage="_WorkRecord", ThisKey="ID", OtherKey="Employee")]
		public EntitySet<WorkRecord> WorkRecord
		{
			get
			{
				return this._WorkRecord;
			}
			set
			{
				this._WorkRecord.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_WorkRecord(WorkRecord entity)
		{
			this.SendPropertyChanging();
			entity.Employee1 = this;
		}
		
		private void detach_WorkRecord(WorkRecord entity)
		{
			this.SendPropertyChanging();
			entity.Employee1 = null;
		}
	}
	
	[Table(Name="dbo.WorkRecord")]
	public partial class WorkRecord : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private long _Employee;
		
		private System.DateTime _WorkPoint;
		
		private int _PointType;
		
		private bool _Status;
		
		private EntityRef<Employee> _Employee1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnEmployeeChanging(long value);
    partial void OnEmployeeChanged();
    partial void OnWorkPointChanging(System.DateTime value);
    partial void OnWorkPointChanged();
    partial void OnPointTypeChanging(int value);
    partial void OnPointTypeChanged();
    partial void OnStatusChanging(bool value);
    partial void OnStatusChanged();
    #endregion
		
		public WorkRecord()
		{
			this._Employee1 = default(EntityRef<Employee>);
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Employee", DbType="BigInt NOT NULL")]
		public long Employee
		{
			get
			{
				return this._Employee;
			}
			set
			{
				if ((this._Employee != value))
				{
					if (this._Employee1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEmployeeChanging(value);
					this.SendPropertyChanging();
					this._Employee = value;
					this.SendPropertyChanged("Employee");
					this.OnEmployeeChanged();
				}
			}
		}
		
		[Column(Storage="_WorkPoint", DbType="DateTime NOT NULL")]
		public System.DateTime WorkPoint
		{
			get
			{
				return this._WorkPoint;
			}
			set
			{
				if ((this._WorkPoint != value))
				{
					this.OnWorkPointChanging(value);
					this.SendPropertyChanging();
					this._WorkPoint = value;
					this.SendPropertyChanged("WorkPoint");
					this.OnWorkPointChanged();
				}
			}
		}
		
		[Column(Storage="_PointType", DbType="Int NOT NULL")]
		public int PointType
		{
			get
			{
				return this._PointType;
			}
			set
			{
				if ((this._PointType != value))
				{
					this.OnPointTypeChanging(value);
					this.SendPropertyChanging();
					this._PointType = value;
					this.SendPropertyChanged("PointType");
					this.OnPointTypeChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="Bit NOT NULL")]
		public bool Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[Association(Name="Employee_WorkRecord", Storage="_Employee1", ThisKey="Employee", OtherKey="ID", IsForeignKey=true)]
		public Employee Employee1
		{
			get
			{
				return this._Employee1.Entity;
			}
			set
			{
				Employee previousValue = this._Employee1.Entity;
				if (((previousValue != value) 
							|| (this._Employee1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Employee1.Entity = null;
						previousValue.WorkRecord.Remove(this);
					}
					this._Employee1.Entity = value;
					if ((value != null))
					{
						value.WorkRecord.Add(this);
						this._Employee = value.ID;
					}
					else
					{
						this._Employee = default(long);
					}
					this.SendPropertyChanged("Employee1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.ShiftDef")]
	public partial class ShiftDef : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Code;
		
		private string _Name;
		
		private string _Description;
		
		private System.Nullable<int> _ShiftType;
		
		private System.Nullable<System.DateTime> _FromTime;
		
		private System.Nullable<System.DateTime> _ToTime;
		
		private System.Nullable<decimal> _WorkingHours;
		
		private EntitySet<ShiftPoint> _ShiftPoint;
		
		private EntitySet<WorkCalendarRule> _WorkCalendarRule;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnCodeChanging(string value);
    partial void OnCodeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnShiftTypeChanging(System.Nullable<int> value);
    partial void OnShiftTypeChanged();
    partial void OnFromTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnFromTimeChanged();
    partial void OnToTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnToTimeChanged();
    partial void OnWorkingHoursChanging(System.Nullable<decimal> value);
    partial void OnWorkingHoursChanged();
    #endregion
		
		public ShiftDef()
		{
			this._ShiftPoint = new EntitySet<ShiftPoint>(new Action<ShiftPoint>(this.attach_ShiftPoint), new Action<ShiftPoint>(this.detach_ShiftPoint));
			this._WorkCalendarRule = new EntitySet<WorkCalendarRule>(new Action<WorkCalendarRule>(this.attach_WorkCalendarRule), new Action<WorkCalendarRule>(this.detach_WorkCalendarRule));
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Code", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="VarChar(500)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_ShiftType", DbType="Int")]
		public System.Nullable<int> ShiftType
		{
			get
			{
				return this._ShiftType;
			}
			set
			{
				if ((this._ShiftType != value))
				{
					this.OnShiftTypeChanging(value);
					this.SendPropertyChanging();
					this._ShiftType = value;
					this.SendPropertyChanged("ShiftType");
					this.OnShiftTypeChanged();
				}
			}
		}
		
		[Column(Storage="_FromTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> FromTime
		{
			get
			{
				return this._FromTime;
			}
			set
			{
				if ((this._FromTime != value))
				{
					this.OnFromTimeChanging(value);
					this.SendPropertyChanging();
					this._FromTime = value;
					this.SendPropertyChanged("FromTime");
					this.OnFromTimeChanged();
				}
			}
		}
		
		[Column(Storage="_ToTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> ToTime
		{
			get
			{
				return this._ToTime;
			}
			set
			{
				if ((this._ToTime != value))
				{
					this.OnToTimeChanging(value);
					this.SendPropertyChanging();
					this._ToTime = value;
					this.SendPropertyChanged("ToTime");
					this.OnToTimeChanged();
				}
			}
		}
		
		[Column(Storage="_WorkingHours", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> WorkingHours
		{
			get
			{
				return this._WorkingHours;
			}
			set
			{
				if ((this._WorkingHours != value))
				{
					this.OnWorkingHoursChanging(value);
					this.SendPropertyChanging();
					this._WorkingHours = value;
					this.SendPropertyChanged("WorkingHours");
					this.OnWorkingHoursChanged();
				}
			}
		}
		
		[Association(Name="ShiftDef_ShiftPoint", Storage="_ShiftPoint", ThisKey="ID", OtherKey="ShiftDef")]
		public EntitySet<ShiftPoint> ShiftPoint
		{
			get
			{
				return this._ShiftPoint;
			}
			set
			{
				this._ShiftPoint.Assign(value);
			}
		}
		
		[Association(Name="ShiftDef_WorkCalendarRule", Storage="_WorkCalendarRule", ThisKey="ID", OtherKey="ShiftDef")]
		public EntitySet<WorkCalendarRule> WorkCalendarRule
		{
			get
			{
				return this._WorkCalendarRule;
			}
			set
			{
				this._WorkCalendarRule.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ShiftPoint(ShiftPoint entity)
		{
			this.SendPropertyChanging();
			entity.ShiftDef1 = this;
		}
		
		private void detach_ShiftPoint(ShiftPoint entity)
		{
			this.SendPropertyChanging();
			entity.ShiftDef1 = null;
		}
		
		private void attach_WorkCalendarRule(WorkCalendarRule entity)
		{
			this.SendPropertyChanging();
			entity.ShiftDef1 = this;
		}
		
		private void detach_WorkCalendarRule(WorkCalendarRule entity)
		{
			this.SendPropertyChanging();
			entity.ShiftDef1 = null;
		}
	}
	
	[Table(Name="dbo.ShiftPoint")]
	public partial class ShiftPoint : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private int _IndexNumber;
		
		private string _Name;
		
		private System.DateTime _PointTime;
		
		private int _PointType;
		
		private string _Description;
		
		private long _ShiftDef;
		
		private EntityRef<ShiftDef> _ShiftDef1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnIndexNumberChanging(int value);
    partial void OnIndexNumberChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPointTimeChanging(System.DateTime value);
    partial void OnPointTimeChanged();
    partial void OnPointTypeChanging(int value);
    partial void OnPointTypeChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnShiftDefChanging(long value);
    partial void OnShiftDefChanged();
    #endregion
		
		public ShiftPoint()
		{
			this._ShiftDef1 = default(EntityRef<ShiftDef>);
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_IndexNumber", DbType="Int NOT NULL")]
		public int IndexNumber
		{
			get
			{
				return this._IndexNumber;
			}
			set
			{
				if ((this._IndexNumber != value))
				{
					this.OnIndexNumberChanging(value);
					this.SendPropertyChanging();
					this._IndexNumber = value;
					this.SendPropertyChanged("IndexNumber");
					this.OnIndexNumberChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_PointTime", DbType="DateTime NOT NULL")]
		public System.DateTime PointTime
		{
			get
			{
				return this._PointTime;
			}
			set
			{
				if ((this._PointTime != value))
				{
					this.OnPointTimeChanging(value);
					this.SendPropertyChanging();
					this._PointTime = value;
					this.SendPropertyChanged("PointTime");
					this.OnPointTimeChanged();
				}
			}
		}
		
		[Column(Storage="_PointType", DbType="Int NOT NULL")]
		public int PointType
		{
			get
			{
				return this._PointType;
			}
			set
			{
				if ((this._PointType != value))
				{
					this.OnPointTypeChanging(value);
					this.SendPropertyChanging();
					this._PointType = value;
					this.SendPropertyChanged("PointType");
					this.OnPointTypeChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="VarChar(500)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_ShiftDef", DbType="BigInt NOT NULL")]
		public long ShiftDef
		{
			get
			{
				return this._ShiftDef;
			}
			set
			{
				if ((this._ShiftDef != value))
				{
					if (this._ShiftDef1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnShiftDefChanging(value);
					this.SendPropertyChanging();
					this._ShiftDef = value;
					this.SendPropertyChanged("ShiftDef");
					this.OnShiftDefChanged();
				}
			}
		}
		
		[Association(Name="ShiftDef_ShiftPoint", Storage="_ShiftDef1", ThisKey="ShiftDef", OtherKey="ID", IsForeignKey=true)]
		public ShiftDef ShiftDef1
		{
			get
			{
				return this._ShiftDef1.Entity;
			}
			set
			{
				ShiftDef previousValue = this._ShiftDef1.Entity;
				if (((previousValue != value) 
							|| (this._ShiftDef1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ShiftDef1.Entity = null;
						previousValue.ShiftPoint.Remove(this);
					}
					this._ShiftDef1.Entity = value;
					if ((value != null))
					{
						value.ShiftPoint.Add(this);
						this._ShiftDef = value.ID;
					}
					else
					{
						this._ShiftDef = default(long);
					}
					this.SendPropertyChanged("ShiftDef1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.WorkCalendar")]
	public partial class WorkCalendar : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Code;
		
		private string _Name;
		
		private string _Description;
		
		private System.Nullable<System.DateTime> _FromDate;
		
		private System.Nullable<System.DateTime> _ToDate;
		
		private EntitySet<WorkCalendarRule> _WorkCalendarRule;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnCodeChanging(string value);
    partial void OnCodeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnFromDateChanging(System.Nullable<System.DateTime> value);
    partial void OnFromDateChanged();
    partial void OnToDateChanging(System.Nullable<System.DateTime> value);
    partial void OnToDateChanged();
    #endregion
		
		public WorkCalendar()
		{
			this._WorkCalendarRule = new EntitySet<WorkCalendarRule>(new Action<WorkCalendarRule>(this.attach_WorkCalendarRule), new Action<WorkCalendarRule>(this.detach_WorkCalendarRule));
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Code", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="VarChar(500)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_FromDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> FromDate
		{
			get
			{
				return this._FromDate;
			}
			set
			{
				if ((this._FromDate != value))
				{
					this.OnFromDateChanging(value);
					this.SendPropertyChanging();
					this._FromDate = value;
					this.SendPropertyChanged("FromDate");
					this.OnFromDateChanged();
				}
			}
		}
		
		[Column(Storage="_ToDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ToDate
		{
			get
			{
				return this._ToDate;
			}
			set
			{
				if ((this._ToDate != value))
				{
					this.OnToDateChanging(value);
					this.SendPropertyChanging();
					this._ToDate = value;
					this.SendPropertyChanged("ToDate");
					this.OnToDateChanged();
				}
			}
		}
		
		[Association(Name="WorkCalendar_WorkCalendarRule", Storage="_WorkCalendarRule", ThisKey="ID", OtherKey="WrokCalendar")]
		public EntitySet<WorkCalendarRule> WorkCalendarRule
		{
			get
			{
				return this._WorkCalendarRule;
			}
			set
			{
				this._WorkCalendarRule.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_WorkCalendarRule(WorkCalendarRule entity)
		{
			this.SendPropertyChanging();
			entity.WorkCalendar = this;
		}
		
		private void detach_WorkCalendarRule(WorkCalendarRule entity)
		{
			this.SendPropertyChanging();
			entity.WorkCalendar = null;
		}
	}
	
	[Table(Name="dbo.WorkCalendarRule")]
	public partial class WorkCalendarRule : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private int _RuleType;
		
		private string _RuleValue;
		
		private bool _IsWorkDay;
		
		private System.Nullable<int> _Number;
		
		private long _WrokCalendar;
		
		private System.Nullable<long> _ShiftDef;
		
		private EntityRef<ShiftDef> _ShiftDef1;
		
		private EntityRef<WorkCalendar> _WorkCalendar;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnRuleTypeChanging(int value);
    partial void OnRuleTypeChanged();
    partial void OnRuleValueChanging(string value);
    partial void OnRuleValueChanged();
    partial void OnIsWorkDayChanging(bool value);
    partial void OnIsWorkDayChanged();
    partial void OnNumberChanging(System.Nullable<int> value);
    partial void OnNumberChanged();
    partial void OnWrokCalendarChanging(long value);
    partial void OnWrokCalendarChanged();
    partial void OnShiftDefChanging(System.Nullable<long> value);
    partial void OnShiftDefChanged();
    #endregion
		
		public WorkCalendarRule()
		{
			this._ShiftDef1 = default(EntityRef<ShiftDef>);
			this._WorkCalendar = default(EntityRef<WorkCalendar>);
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_RuleType", DbType="Int NOT NULL")]
		public int RuleType
		{
			get
			{
				return this._RuleType;
			}
			set
			{
				if ((this._RuleType != value))
				{
					this.OnRuleTypeChanging(value);
					this.SendPropertyChanging();
					this._RuleType = value;
					this.SendPropertyChanged("RuleType");
					this.OnRuleTypeChanged();
				}
			}
		}
		
		[Column(Storage="_RuleValue", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string RuleValue
		{
			get
			{
				return this._RuleValue;
			}
			set
			{
				if ((this._RuleValue != value))
				{
					this.OnRuleValueChanging(value);
					this.SendPropertyChanging();
					this._RuleValue = value;
					this.SendPropertyChanged("RuleValue");
					this.OnRuleValueChanged();
				}
			}
		}
		
		[Column(Storage="_IsWorkDay", DbType="Bit NOT NULL")]
		public bool IsWorkDay
		{
			get
			{
				return this._IsWorkDay;
			}
			set
			{
				if ((this._IsWorkDay != value))
				{
					this.OnIsWorkDayChanging(value);
					this.SendPropertyChanging();
					this._IsWorkDay = value;
					this.SendPropertyChanged("IsWorkDay");
					this.OnIsWorkDayChanged();
				}
			}
		}
		
		[Column(Storage="_Number", DbType="Int")]
		public System.Nullable<int> Number
		{
			get
			{
				return this._Number;
			}
			set
			{
				if ((this._Number != value))
				{
					this.OnNumberChanging(value);
					this.SendPropertyChanging();
					this._Number = value;
					this.SendPropertyChanged("Number");
					this.OnNumberChanged();
				}
			}
		}
		
		[Column(Storage="_WrokCalendar", DbType="BigInt NOT NULL")]
		public long WrokCalendar
		{
			get
			{
				return this._WrokCalendar;
			}
			set
			{
				if ((this._WrokCalendar != value))
				{
					if (this._WorkCalendar.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnWrokCalendarChanging(value);
					this.SendPropertyChanging();
					this._WrokCalendar = value;
					this.SendPropertyChanged("WrokCalendar");
					this.OnWrokCalendarChanged();
				}
			}
		}
		
		[Column(Storage="_ShiftDef", DbType="BigInt")]
		public System.Nullable<long> ShiftDef
		{
			get
			{
				return this._ShiftDef;
			}
			set
			{
				if ((this._ShiftDef != value))
				{
					if (this._ShiftDef1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnShiftDefChanging(value);
					this.SendPropertyChanging();
					this._ShiftDef = value;
					this.SendPropertyChanged("ShiftDef");
					this.OnShiftDefChanged();
				}
			}
		}
		
		[Association(Name="ShiftDef_WorkCalendarRule", Storage="_ShiftDef1", ThisKey="ShiftDef", OtherKey="ID", IsForeignKey=true)]
		public ShiftDef ShiftDef1
		{
			get
			{
				return this._ShiftDef1.Entity;
			}
			set
			{
				ShiftDef previousValue = this._ShiftDef1.Entity;
				if (((previousValue != value) 
							|| (this._ShiftDef1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ShiftDef1.Entity = null;
						previousValue.WorkCalendarRule.Remove(this);
					}
					this._ShiftDef1.Entity = value;
					if ((value != null))
					{
						value.WorkCalendarRule.Add(this);
						this._ShiftDef = value.ID;
					}
					else
					{
						this._ShiftDef = default(Nullable<long>);
					}
					this.SendPropertyChanged("ShiftDef1");
				}
			}
		}
		
		[Association(Name="WorkCalendar_WorkCalendarRule", Storage="_WorkCalendar", ThisKey="WrokCalendar", OtherKey="ID", IsForeignKey=true)]
		public WorkCalendar WorkCalendar
		{
			get
			{
				return this._WorkCalendar.Entity;
			}
			set
			{
				WorkCalendar previousValue = this._WorkCalendar.Entity;
				if (((previousValue != value) 
							|| (this._WorkCalendar.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._WorkCalendar.Entity = null;
						previousValue.WorkCalendarRule.Remove(this);
					}
					this._WorkCalendar.Entity = value;
					if ((value != null))
					{
						value.WorkCalendarRule.Add(this);
						this._WrokCalendar = value.ID;
					}
					else
					{
						this._WrokCalendar = default(long);
					}
					this.SendPropertyChanged("WorkCalendar");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
