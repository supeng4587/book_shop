using System;
namespace book_shop.Model
{
	/// <summary>
	/// Articel_WordsModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Articel_WordsModel
	{
		public Articel_WordsModel()
		{}
		#region Model
		private int _id;
		private string _wordpattern;
		private bool _isforbid;
		private bool _ismod;
		private string _replaceword;
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
		public string WordPattern
		{
			set{ _wordpattern=value;}
			get{return _wordpattern;}
		}
		/// <summary>
		/// 是否禁用
		/// </summary>
		public bool IsForbid
		{
			set{ _isforbid=value;}
			get{return _isforbid;}
		}
		/// <summary>
		/// 是否需要审核
		/// </summary>
		public bool IsMod
		{
			set{ _ismod=value;}
			get{return _ismod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReplaceWord
		{
			set{ _replaceword=value;}
			get{return _replaceword;}
		}
		#endregion Model

	}
}

