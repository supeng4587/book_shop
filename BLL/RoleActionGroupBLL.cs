using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using book_shop.Model;
namespace book_shop.BLL
{
	/// <summary>
	/// RoleActionGroupBLL
	/// </summary>
	public partial class RoleActionGroupBLL
	{
		private readonly book_shop.DAL.RoleActionGroupDAL dal=new book_shop.DAL.RoleActionGroupDAL();
		public RoleActionGroupBLL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Role_ID,int ActionGroup_ID)
		{
			return dal.Exists(Role_ID,ActionGroup_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(book_shop.Model.RoleActionGroupModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(book_shop.Model.RoleActionGroupModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Role_ID,int ActionGroup_ID)
		{
			
			return dal.Delete(Role_ID,ActionGroup_ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public book_shop.Model.RoleActionGroupModel GetModel(int Role_ID,int ActionGroup_ID)
		{
			
			return dal.GetModel(Role_ID,ActionGroup_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public book_shop.Model.RoleActionGroupModel GetModelByCache(int Role_ID,int ActionGroup_ID)
		{
			
			string CacheKey = "RoleActionGroupModelModel-" + Role_ID+ActionGroup_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Role_ID,ActionGroup_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (book_shop.Model.RoleActionGroupModel)objModel;
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
		public List<book_shop.Model.RoleActionGroupModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<book_shop.Model.RoleActionGroupModel> DataTableToList(DataTable dt)
		{
			List<book_shop.Model.RoleActionGroupModel> modelList = new List<book_shop.Model.RoleActionGroupModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				book_shop.Model.RoleActionGroupModel model;
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

