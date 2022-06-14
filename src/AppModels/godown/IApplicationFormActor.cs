using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapr.Actors;

namespace AppModels.godown
{
    public interface IApplicationFormActor : IActor
    {
        Task<string> SaveData(ApplicationOrderDto dto);
        Task<ApplicationOrderDto> GetData();
        Task<bool> IsExceeded(ApplicationOrderIsExceededDto dto);
        Task Complete();
    }
}
