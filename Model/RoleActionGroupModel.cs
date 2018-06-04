using System;
namespace book_shop.Model
{
	/// <summary>
	/// RoleActionGroupModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoleActionGroupModel
	{
		public RoleActionGroupModel()
		{}
		#region Model
		private int _role_id;
		private int _actiongroup_id;
		/// <summary>
		/// 
		/// </summary>
		public int Role_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ActionGroup_ID
		{
			set{ _actiongroup_id=value;}
			get{return _actiongroup_id;}
		}
		#endregion Model

	}
}

