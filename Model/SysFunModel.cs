﻿using System;
namespace book_shop.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class SysFunModel
	{
		public SysFunModel()
		{}
		#region Model
		private int _nodeid;
		private string _displayname;
		private string _nodeurl;
		private int _displayorder;
		private int _parentnodeid;
		/// <summary>
		/// 
		/// </summary>
		public int NodeId
		{
			set{ _nodeid=value;}
			get{return _nodeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DisplayName
		{
			set{ _displayname=value;}
			get{return _displayname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NodeURL
		{
			set{ _nodeurl=value;}
			get{return _nodeurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DisplayOrder
		{
			set{ _displayorder=value;}
			get{return _displayorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ParentNodeId
		{
			set{ _parentnodeid=value;}
			get{return _parentnodeid;}
		}
		#endregion Model

	}
}

