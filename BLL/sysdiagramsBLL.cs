﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using book_shop.Model;
namespace book_shop.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class sysdiagramsBLL
	{
		private readonly book_shop.DAL.sysdiagramsDAL dal=new book_shop.DAL.sysdiagramsDAL();
		public sysdiagramsBLL()
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
		public bool Exists(string name,int principal_id,int diagram_id)
		{
			return dal.Exists(name,principal_id,diagram_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(book_shop.Model.sysdiagramsModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(book_shop.Model.sysdiagramsModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int diagram_id)
		{
			
			return dal.Delete(diagram_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string name,int principal_id,int diagram_id)
		{
			
			return dal.Delete(name,principal_id,diagram_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string diagram_idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(diagram_idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public book_shop.Model.sysdiagramsModel GetModel(int diagram_id)
		{
			
			return dal.GetModel(diagram_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public book_shop.Model.sysdiagramsModel GetModelByCache(int diagram_id)
		{
			
			string CacheKey = "sysdiagramsModelModel-" + diagram_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(diagram_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (book_shop.Model.sysdiagramsModel)objModel;
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
		public List<book_shop.Model.sysdiagramsModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<book_shop.Model.sysdiagramsModel> DataTableToList(DataTable dt)
		{
			List<book_shop.Model.sysdiagramsModel> modelList = new List<book_shop.Model.sysdiagramsModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				book_shop.Model.sysdiagramsModel model;
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

