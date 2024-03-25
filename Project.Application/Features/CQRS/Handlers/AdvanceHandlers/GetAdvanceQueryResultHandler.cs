using Project.Application.Features.CQRS.Results.AdvanceResults;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.AdvanceHandlers
{
    public class GetAdvanceQueryResultHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAdvanceQueryResultHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ApprovalStatus GetEnum (int approvalint)
        {
            switch (approvalint)
            {
                case 1:
                    return ApprovalStatus.Waiting;
                case 2:
                    return ApprovalStatus.Approved;
                case 3:
                    return ApprovalStatus.Denied;

                default: return ApprovalStatus.Waiting;
            }
                

        }
        public AdvanceType GetEnumAdvance(int advanceInt)
        {
            switch (advanceInt)
            {
                case 1:
                    return AdvanceType.Individual;
                case 2:
                    return AdvanceType.Medical;
                case 3:
                    return AdvanceType.Travel;

                default: return AdvanceType.Individual;
            }


        }

        public Currency GetCurrencyEnum(int curr)
        {
            switch (curr)
            {
                case 1:
                    return Currency.TL;
                case 2:
                    return Currency.USD;
                case 3:
                    return Currency.EUR;

                default: return Currency.TL;
            }


        }
        public async Task<List<GetAdvanceWithEmployeeQueryResult>> Handle()
        {
            var advances = unitOfWork.advanceRepository.GetAllWithEmployee();

            // Sonuçları işlemek için bir liste oluştur.
            var results = new List<GetAdvanceWithEmployeeQueryResult>();

            // Her bir 'advance' için dönüşüm yap.
            foreach (var advance in advances)
            {
                
                var approvalStatus = GetEnum(advance.ApprovalStatusInt); // Bu, int'ten enum'a çeviren bir fonksiyon varsayımıdır.
                var currencyE = GetCurrencyEnum(advance.CurrencyInt);
                var type=GetEnumAdvance(advance.CurrencyInt);
                // Sonuç listesine yeni bir nesne ekleyin.
                results.Add(new GetAdvanceWithEmployeeQueryResult
                {
                    Id = advance.Id,
                    ApprovalStatus = approvalStatus, // Dönüştürülen enum değerini kullanın
                    Amount = advance.Amount,
                    Currency = currencyE,
                    AdvanceType=type,
                    ApprovalDate = advance.ApprovalDate,
                    CreatedDate = advance.CreatedDate,
                    DeletedTime = advance.DeletedTime,
                    Description = advance.Description,
                    EmployeeName = advance.Employee.Name,
                    EmployeeLastName = advance.Employee.LastName,
                    UpdatedDate = advance.UpdatedDate,
                    // Diğer alanlarınız...
                });
            }

            // İşlenmiş sonuç listesini döndür.
            return results;
        }
    }
}
