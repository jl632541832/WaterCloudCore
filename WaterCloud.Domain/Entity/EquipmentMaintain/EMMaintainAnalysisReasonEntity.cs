﻿using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace WaterCloud.Domain.Entity.EquipmentMaintain
{
    [TableAttribute("Sys_EMMaintainAnalysisReason")]
    public class EMMaintainAnalysisReasonEntity : IEntity<EMMaintainAnalysisReasonEntity>
    {
        [ColumnAttribute("id", IsPrimaryKey = true)]
        public int? id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? IsEffective { get; set; }
    }
}
