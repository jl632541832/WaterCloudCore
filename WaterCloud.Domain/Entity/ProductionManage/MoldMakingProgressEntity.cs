﻿using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace WaterCloud.Domain.Entity.ProductionManage
{
    [TableAttribute("Sys_MoldMakingProgress")]
    public class MoldMakingProgressEntity : IEntity<MoldMakingProgressEntity>
    {
        [ColumnAttribute("id", IsPrimaryKey = true)]
        public int? id { get; set; }
        public string MoldNo { get; set; }
        public string MoldTest { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string ProductName { get; set; }
        public DateTime? PlannedDeliveryDate { get; set; }
        public string EarlyWarning { get; set; }
        public string EarlyWarningColor { get; set; }
        public int? IsEffective { get; set; }
    }
}
