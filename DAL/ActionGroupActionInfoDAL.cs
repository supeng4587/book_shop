﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace book_shop.DAL
{
	/// <summary>
	/// 数据访问类:ActionGroupActionInfoDAL
	/// </summary>
	public partial class ActionGroupActionInfoDAL
	{
		public ActionGroupActionInfoDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ActionGroup_ID", "ActionGroupActionInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ActionGroup_ID,int ActionInfo_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ActionGroupActionInfo");
			strSql.Append(" where ActionGroup_ID=@ActionGroup_ID and ActionInfo_ID=@ActionInfo_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ActionGroup_ID", SqlDbType.Int,4),
					new SqlParameter("@ActionInfo_ID", SqlDbType.Int,4)			};
			parameters[0].Value = ActionGroup_ID;
			parameters[1].Value = ActionInfo_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(book_shop.Model.ActionGroupActionInfoModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ActionGroupActionInfo(");
			strSql.Append("ActionGroup_ID,ActionInfo_ID)");
			strSql.Append(" values (");
			strSql.Append("@ActionGroup_ID,@ActionInfo_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@ActionGroup_ID", SqlDbType.Int,4),
					new SqlParameter("@ActionInfo_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ActionGroup_ID;
			parameters[1].Value = model.ActionInfo_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(book_shop.Model.ActionGroupActionInfoModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ActionGroupActionInfo set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("ActionGroup_ID=@ActionGroup_ID,");
			strSql.Append("ActionInfo_ID=@ActionInfo_ID");
			strSql.Append(" where ActionGroup_ID=@ActionGroup_ID and ActionInfo_ID=@ActionInfo_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ActionGroup_ID", SqlDbType.Int,4),
					new SqlParameter("@ActionInfo_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ActionGroup_ID;
			parameters[1].Value = model.ActionInfo_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ActionGroup_ID,int ActionInfo_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ActionGroupActionInfo ");
			strSql.Append(" where ActionGroup_ID=@ActionGroup_ID and ActionInfo_ID=@ActionInfo_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ActionGroup_ID", SqlDbType.Int,4),
					new SqlParameter("@ActionInfo_ID", SqlDbType.Int,4)			};
			parameters[0].Value = ActionGroup_ID;
			parameters[1].Value = ActionInfo_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public book_shop.Model.ActionGroupActionInfoModel GetModel(int ActionGroup_ID,int ActionInfo_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ActionGroup_ID,ActionInfo_ID from ActionGroupActionInfo ");
			strSql.Append(" where ActionGroup_ID=@ActionGroup_ID and ActionInfo_ID=@ActionInfo_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ActionGroup_ID", SqlDbType.Int,4),
					new SqlParameter("@ActionInfo_ID", SqlDbType.Int,4)			};
			parameters[0].Value = ActionGroup_ID;
			parameters[1].Value = ActionInfo_ID;

			book_shop.Model.ActionGroupActionInfoModel model=new book_shop.Model.ActionGroupActionInfoModel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public book_shop.Model.ActionGroupActionInfoModel DataRowToModel(DataRow row)
		{
			book_shop.Model.ActionGroupActionInfoModel model=new book_shop.Model.ActionGroupActionInfoModel();
			if (row != null)
			{
				if(row["ActionGroup_ID"]!=null && row["ActionGroup_ID"].ToString()!="")
				{
					model.ActionGroup_ID=int.Parse(row["ActionGroup_ID"].ToString());
				}
				if(row["ActionInfo_ID"]!=null && row["ActionInfo_ID"].ToString()!="")
				{
					model.ActionInfo_ID=int.Parse(row["ActionInfo_ID"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ActionGroup_ID,ActionInfo_ID ");
			strSql.Append(" FROM ActionGroupActionInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ActionGroup_ID,ActionInfo_ID ");
			strSql.Append(" FROM ActionGroupActionInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ActionGroupActionInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ActionInfo_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ActionGroupActionInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "ActionGroupActionInfo";
			parameters[1].Value = "ActionInfo_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

