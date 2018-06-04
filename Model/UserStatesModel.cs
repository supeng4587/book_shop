using System;
namespace book_shop.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class UserStatesModel
	{
		public UserStatesModel()
		{}
		#region Model
		private int _id;
		private string _name;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

