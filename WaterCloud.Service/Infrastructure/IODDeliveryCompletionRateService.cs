﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WaterCloud.Domain.Entity.OperationMonitoring;

namespace WaterCloud.Service.Infrastructure
{
    public interface IODDeliveryCompletionRateService
    {
        Task<List<ODDeliveryCompletionRateEntity>> GetTableFieldList(string GetTime);
    }
}
