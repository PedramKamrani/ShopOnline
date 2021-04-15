using CorService.ViewModels.Varint;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Services.IService
{
   public interface IVarintService
    {
        List<VarintViewModel> GetVarintByProudctId(int id);
    }
}
