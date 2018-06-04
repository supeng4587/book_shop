using System;
namespace book_shop.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class UserInfoRoleModel
	{
		public UserInfoRoleModel()
		{}
		#region Model
		private int _userinfo_id;
		private int _role_id;
		/// <summary>
		/// 
		/// </summary>
		public int UserInfo_ID
		{
			set{ _userinfo_id=value;}
			get{return _userinfo_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Role_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		#endregion Model

	}
}

