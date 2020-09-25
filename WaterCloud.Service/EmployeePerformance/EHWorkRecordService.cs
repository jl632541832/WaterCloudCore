﻿using Chloe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCloud.Code;
using WaterCloud.Domain.Entity.EmployeePerformance;

namespace WaterCloud.Service.EmployeePerformance
{
    public class EHWorkRecordService : DataFilterService<EHWorkRecordEntity>, IDenpendency
    {
        public EHWorkRecordService(IDbContext context) : base(context)
        {
        }
        public async Task<List<EHWorkRecordEntity>> GetList(Pagination pagination, string keyvalue)
        {
            ////获取数据权限
            //var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));

            //list = list.Where(t => t.IsEffective == 1);
            //return GetFieldsFilterData(await repository.OrderList(list, pagination), className.Substring(0, className.Length - 7));

            var list = repository.IQueryable();
            if (!string.IsNullOrEmpty(keyvalue))
            {
                DateTime startTime = keyvalue.Substring(0, 10).ToDate();
                DateTime endTime = keyvalue.Remove(0, 13).ToDate().AddDays(1);

                list = list.Where(t => t.StartTime >= startTime && t.EndTime <= endTime);
            }
            list = list.Where(t => t.IsEffective == 1);
            return await repository.OrderList(list, pagination);
        }
        public async Task<List<EHWorkRecordEntity>> GetList(string keyvalue)
        {
            var list= repository.IQueryable();
            if (!string.IsNullOrEmpty(keyvalue))
            {
                DateTime startTime = keyvalue.Substring(0, 10).ToDate();
                DateTime endTime = keyvalue.Remove(0, 13).ToDate();

                list = list.Where(t => t.StartTime >= startTime && t.EndTime <= endTime);
            }
            return list.ToList();
        }
    }
}
