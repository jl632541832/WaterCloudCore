﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WaterCloud.Domain.Entity.MouldDesign;

namespace WaterCloud.Service.Infrastructure
{
    public interface IDHWorkloadAnalysisService
    {
        Task<List<DHWorkloadAnalysisEntity>> GetTableFieldList(string GetTime);
    }
}