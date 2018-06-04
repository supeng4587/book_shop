using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using book_shop.Model;
namespace book_shop.BLL
{
	/// <summary>
	/// keyWordsRankBLL
	/// </summary>
	public partial class keyWordsRankBLL
	{
		private readonly book_shop.DAL.keyWordsRankDAL dal=new book_shop.DAL.keyWordsRankDAL();
		public keyWordsRankBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id,string KeyWords)
		{
			return dal.Exists(Id,KeyWords);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(book_shop.Model.keyWordsRankModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(book_shop.Model.keyWordsRankModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid Id,string KeyWords)
		{
			
			return dal.Delete(Id,KeyWords);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public book_shop.Model.keyWordsRankModel GetModel(Guid Id,string KeyWords)
		{
			
			return dal.GetModel(Id,KeyWords);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public book_shop.Model.keyWordsRankModel GetModelByCache(Guid Id,string KeyWords)
		{
			
			string CacheKey = "keyWordsRankModelModel-" + Id+KeyWords;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id,KeyWords);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (book_shop.Model.keyWordsRankModel)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<book_shop.Model.keyWordsRankModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<book_shop.Model.keyWordsRankModel> DataTableToList(DataTable dt)
		{
			List<book_shop.Model.keyWordsRankModel> modelList = new List<book_shop.Model.keyWordsRankModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				book_shop.Model.keyWordsRankModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

