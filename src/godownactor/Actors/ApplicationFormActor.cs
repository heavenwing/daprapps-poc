using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using AppModels.godown;
using AutoMapper;
using Dapr.Actors.Runtime;
using godown.DomainModels;
using Google.Type;
using Microsoft.AspNetCore.Identity;

namespace godown.Actors
{
    public class ApplicationFormActor : Actor, IApplicationFormActor
    {
        private const string StateName = "godownstore";

        private readonly IMapper mapper;

        public ApplicationFormActor(ActorHost host, IMapper mapper) : base(host)
        {
            this.mapper = mapper;
        }

        public async Task<string> SaveData(ApplicationFormDto dto)
        {
            var entity = mapper.Map<ApplicationForm>(dto);
            entity.Id = new Guid(Id.GetId());
            await StateManager.SetStateAsync(StateName, entity);
            return Id.GetId();
        }

        public async Task<ApplicationFormDto> GetData()
        {
            var entity = await StateManager.GetStateAsync<ApplicationForm>(StateName);
            var dto = mapper.Map<ApplicationFormDto>(entity);
            return dto;
        }

        public async Task<bool> IsExceeded(ApplicationFormIsExceededDto dto)
        {
            var entity = await StateManager.GetStateAsync<ApplicationForm>(StateName);
            bool exceeded = false;
            foreach (var d in entity.Details)
            {
                var limitAmount = dto.LimitAmounts[d.ProductId];
                if (limitAmount == -1) continue;
                if (d.ProductAmount + dto.InventoryQuantities[d.ProductId] > limitAmount)
                {
                    exceeded = true;
                    break;
                }
            }
            return exceeded;
        }

        public async Task Complete()
        {
            var entity = await StateManager.GetStateAsync<ApplicationForm>(StateName);
            entity.Complete();
            await StateManager.SetStateAsync(StateName, entity);
        }
    }
}
