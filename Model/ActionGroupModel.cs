using System;
namespace book_shop.Model
{
	/// <summary>
	/// ActionGroupModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ActionGroupModel
	{
		public ActionGroupModel()
		{}
		#region Model
		private int _id;
		private string _groupname;
		private int _grouptype;
		private string _delflag;
		private int _sort;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GroupName
		{
			set{ _groupname=value;}
			get{return _groupname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GroupType
		{
			set{ _grouptype=value;}
			get{return _grouptype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DelFlag
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

