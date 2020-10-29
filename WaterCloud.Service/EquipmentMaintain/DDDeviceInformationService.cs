﻿using Chloe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WaterCloud.Code;
using WaterCloud.Domain.Entity.EquipmentMaintain;

namespace WaterCloud.Service.EquipmentMaintain
{
    public class DDDeviceInformationService : DataFilterService<DDDeviceInformationEntity>, IDenpendency
    {
        public DDDeviceInformationService(IDbContext context) : base(context)
        {
        }
        public async Task<List<DDDeviceInformationEntity>> GetList(Pagination pagination)
        {
            ////获取数据权限
            //var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));

            //list = list.Where(t => t.IsEffective == 1);
            //return GetFieldsFilterData(await repository.OrderList(list, pagination), className.Substring(0, className.Length - 7));

            var list = repository.IQueryable();
            list = list.Where(t => t.IsEffective == 1);
            return await repository.OrderList(list, pagination);
        }
    }
}
