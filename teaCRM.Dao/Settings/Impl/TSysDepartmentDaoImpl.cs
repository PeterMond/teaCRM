using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data;
using NLite.Reflection;
using teaCRM.Common;
using teaCRM.DBContext;
using teaCRM.Entity;
using System.Linq.Dynamic;

namespace teaCRM.Dao.Impl
{
    /// <summary>
    /// 自动生成的实现ITSysDepartmentDao接口的Dao类。 2014-08-28 05:06:48 By 唐有炜
    /// </summary>
    public class TSysDepartmentDaoImpl : ITSysDepartmentDao
    {
        #region T4自动生成的函数 2014-09-05 14:58:50 By 唐有炜

        /// <summary>
        /// 获取所有的数据
        /// </summary>
        /// <returns>返回所有数据列表</returns>
        public List<TSysDepartment> GetList()
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                var models = db.TSysDepartments;
                var sqlText = models.GetProperty("SqlText");
                LogHelper.Debug(sqlText.ToString());
                return models.ToList();
            }
        }


        /// <summary>
        /// 获取所有的数据
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>返回所有数据列表</returns>
        public List<TSysDepartment> GetList(Expression<Func<TSysDepartment, bool>> predicate)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                var models = db.TSysDepartments.Where<TSysDepartment>(predicate);
                var sqlText = models.GetProperty("SqlText");
                LogHelper.Debug(sqlText.ToString());
                return models.ToList();
            }
        }

        /// <summary>
        /// 获取指定的单个实体
        /// 如果不存在则返回null
        /// 如果存在多个则抛异常
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>Entity</returns>
        public TSysDepartment GetEntity(Expression<Func<TSysDepartment, bool>> predicate)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                var model = db.TSysDepartments.Where<TSysDepartment>(predicate);
                var sqlText = model.GetProperty("SqlText");
                LogHelper.Debug(sqlText.ToString());
                return model.SingleOrDefault();
            }
        }



        /// <summary>
        /// 根据条件查询某些字段(LINQ 动态查询)
        /// </summary>
        /// <param name="selector">要查询的字段（格式：new(ID,Name)）</param>
        /// <param name="predicate">筛选条件（id=0）</param>
        /// <returns></returns>
        public IQueryable<Object> GetFields(string selector, string predicate)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                var model = db.TSysDepartments.Where(predicate).Select(selector);
                var sqlText = model.GetProperty("SqlText");
                LogHelper.Debug(sqlText.ToString());
                return (IQueryable<object>)model;
            }
        }


        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        public bool InsertEntity(TSysDepartment entity)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                int rows = db.TSysDepartments.Insert(entity);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        public bool DeleteEntity(Expression<Func<TSysDepartment, bool>> predicate)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                TSysDepartment entity = db.TSysDepartments.Where(predicate).First();
                int rows = db.TSysDepartments.Delete(entity);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list">实体集合</param>
        public bool DeletesEntity(List<TSysDepartment> list)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                if (db.Connection.State != ConnectionState.Open)
                {
                    db.Connection.Open();
                }
                var tran = db.Connection.BeginTransaction();
                try
                {
                    //数据库操作
                    LogHelper.Info("删除事务开始...");

                    foreach (var item in list)
                    {
                        db.TSysDepartments.Delete(item);
                    }
                    tran.Commit();
                    //数据库操作
                    LogHelper.Info("删除事务结束...");
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    LogHelper.Error("删除事务执行失败，", ex);
                    return false;
                }
                finally
                {
                    if (db.Connection.State != ConnectionState.Closed)
                    {
                        db.Connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        public bool UpadateEntity(TSysDepartment entity)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                int rows = db.TSysDepartments.Update(entity);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <returns></returns>
        public bool ExistsEntity(Expression<Func<TSysDepartment, bool>> predicate)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                bool status = db.TSysDepartments.Any(predicate);
                return status;
            }
        }


        //查询分页
        public IPagination<TSysDepartment> GetListByPage(int pageIndex, int pageSize, int rowCount,
            Expression<Func<TSysDepartment, bool>> predicate)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                var models = db.TSysDepartments.Where(predicate).ToPagination(pageIndex, pageSize, rowCount);
                return models;
            }
        }



        //以下是原生Sql方法==============================================================
        //===========================================================================
        /// <summary>
        /// 用SQL语句查询
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="namedParameters">sql参数</param>
        /// <returns>集合</returns>
        public IEnumerable<TSysDepartment> GetListBySql(string sql, dynamic namedParameters)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                return db.DbHelper.ExecuteDataTable(sql, namedParameters).ToList<TSysDepartment>();
            }

        }

        /// <summary>
        /// 执行Sql
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="namedParameters">查询字符串</param>
        /// <returns></returns>
        public bool ExecuteSql(string sql, dynamic namedParameters = null)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                var rows = db.DbHelper.ExecuteNonQuery(sql, namedParameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion


        #region 手写的扩展函数 2014-08-21 14:58:50 By 唐有炜



        #endregion
    }
}