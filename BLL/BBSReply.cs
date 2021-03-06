﻿using System;
using System.Data;
using System.Collections.Generic;
using Common;
using BBS.Model;
using BBS.DALFactory;
using BBS.IDAL;
namespace BBS.BLL
{
	/// <summary>
	/// BBSReply
	/// </summary>
	public partial class BBSReply
	{
		private readonly IBBSReply dal=DataAccess.CreateBBSReply();
		public BBSReply()
		{ }
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
		public bool Exists(int RID)
		{
			return dal.Exists(RID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BBS.Model.BBSReply model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BBS.Model.BBSReply model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RID)
		{
			
			return dal.Delete(RID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RIDlist )
		{
			return dal.DeleteList(RIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BBS.Model.BBSReply GetModel(int RID)
		{
			
			return dal.GetModel(RID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BBS.Model.BBSReply GetModelByCache(int RID)
		{
			
			string CacheKey = "BBSReplyModel-" + RID;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RID);
					if (objModel != null)
					{
						int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
						Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BBS.Model.BBSReply)objModel;
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
		public List<BBS.Model.BBSReply> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BBS.Model.BBSReply> DataTableToList(DataTable dt)
		{
			List<BBS.Model.BBSReply> modelList = new List<BBS.Model.BBSReply>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BBS.Model.BBSReply model;
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

