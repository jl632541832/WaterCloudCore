﻿using Chloe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WaterCloud.DataBase;
using WaterCloud.Domain.Entity.OperationMonitoring;
using WaterCloud.Service.Infrastructure;

namespace WaterCloud.Service.OperationMonitoring
{
    public class ODOrderStatusService : RepositoryBase, IODOrderStatusService
    {
        public ODOrderStatusService(IDbContext context) : base(context)
        {
        }
        public async Task<List<ODOrderStatusEntity>> GetTableFieldList(string GetTime)
        {
            StringBuilder strSql = new StringBuilder();
            var parameter = new List<DbParam>();
            if (string.IsNullOrEmpty(GetTime))
            {
                strSql.Append(@"SELECT Name,SUM(Number) Number FROM	Sys_ODOrderStatus WHERE IsEffective=1 GROUP BY Name ");
                parameter.Add(new DbParam("", ""));
            }
            else
            {
                var starttime = GetTime.Substring(0, 10);
                var endtime = GetTime.Remove(0, 13);

                strSql.Append(@"SELECT Name, SUM(Number) Number FROM Sys_ODOrderStatus WHERE IsEffective=1 AND AcctDate between @starttime AND @endtime GROUP BY Name");

                parameter.Add(new DbParam("@starttime", starttime.ToString()));
                parameter.Add(new DbParam("@endtime", endtime.ToString()));

            }
            var list = await FindList<ODOrderStatusEntity>(strSql.ToString(), parameter.ToArray());
            return list;
        }
    }
}
