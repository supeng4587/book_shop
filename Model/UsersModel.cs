﻿using System;
namespace book_shop.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class UsersModel
	{
		public UsersModel()
		{}
		#region Model
		private int _id;
		private string _loginid;
		private string _loginpwd;
		private string _name;
		private string _address;
		private string _phone;
		private string _mail;
		private int _userstateid;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginId
		{
			set{ _loginid=value;}
			get{return _loginid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginPwd
		{
			set{ _loginpwd=value;}
			get{return _loginpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mail
		{
			set{ _mail=value;}
			get{return _mail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UserStateId
		{
			set{ _userstateid=value;}
			get{return _userstateid;}
		}
		#endregion Model

	}
}

