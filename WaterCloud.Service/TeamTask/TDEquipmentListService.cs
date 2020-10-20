﻿using Chloe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WaterCloud.Code;
using WaterCloud.Domain.Entity.TeamTask;

namespace WaterCloud.Service.TeamTask
{
    public class TDEquipmentListService : DataFilterService<TDEquipmentListEntity>, IDenpendency
    {
        public TDEquipmentListService(IDbContext context) : base(context)
        {
        }
        public async Task<List<TDEquipmentListEntity>> GetList(Pagination pagination, string keyword = "")
        {
            ////获取数据权限
            //var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));

            //list = list.Where(t => t.IsEffective == 1);
            //return GetFieldsFilterData(await repository.OrderList(list, pagination), className.Substring(0, className.Length - 7));

            var list = repository.IQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                list = list.Where(u => u.Number.Contains(keyword) || u.Name.Contains(keyword) || u.Brand.Contains(keyword) || u.Department.Contains(keyword) || u.State.Contains(keyword));
            }
            list = list.Where(t => t.IsEffective == 1);
            return await repository.OrderList(list, pagination);
        }
        public async Task<List<TDEquipmentListEntity>> GetList()
        {
            return repository.IQueryable().ToList();
        }
    }
}