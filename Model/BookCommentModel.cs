using System;
namespace book_shop.Model
{
	/// <summary>
	/// BookCommentModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BookCommentModel
	{
		public BookCommentModel()
		{}
		#region Model
		private int _id;
		private string _msg;
		private DateTime _createdatetime;
		private int _bookid;
        private bool _isPass;
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
		public string Msg
		{
			set{ _msg=value;}
			get{return _msg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDateTime
		{
			set{ _createdatetime=value;}
			get{return _createdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int BookId
		{
			set{ _bookid=value;}
			get{return _bookid;}
		}

        public bool IsPass
        {
            set { _isPass = value; }
            get { return _isPass; }
        }
		#endregion Model

	}
}

