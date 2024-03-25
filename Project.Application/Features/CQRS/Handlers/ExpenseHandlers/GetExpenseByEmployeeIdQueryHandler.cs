using Project.Application.Features.CQRS.Queries.ExpenseQueries;
using Project.Application.Features.CQRS.Results.ExpenseResults;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.ExpenseHandlers
{
    public class GetExpenseByEmployeeIdQueryHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetExpenseByEmployeeIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ApprovalStatus GetEnum(int approvalint)
        {
            switch (approvalint)
            {
                case 1:
                    return ApprovalStatus.Waiting;
                case 2:
                    return ApprovalStatus.Approved;

                default: return ApprovalStatus.Waiting;
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

        public ExpenseType GetExpenseTypeEnum(int expenseType)
        {
            switch (expenseType)
            {
                case 1:
                    return ExpenseType.Housing;
                case 2:
                    return ExpenseType.Travel;
                case 3:
                    return ExpenseType.FoodAndDrinks;
                case 4:
                    return ExpenseType.Materials;
                case 5:
                    return ExpenseType.Education;
                case 6:
                    return ExpenseType.Health;
                case 7:
                    return ExpenseType.Fuel;
                default: return ExpenseType.Other;
            }
        }

        public async Task<List<GetExpenseByEmployeeIdQueryResult>> Handle(GetExpenseByEmployeeIdQuery query)
        {
            var values = await unitOfWork.expenseRepository.GetExpenseWithEmployeeByEmployeeId(query.Id);

            return values.Select(x=> new GetExpenseByEmployeeIdQueryResult
            {
                Id = x.Id,
                ExpenseDate = x.ExpenseDate,
                ApprovalDate = x.ApprovalDate,
                CreatedDate = x.CreatedDate,
                Currency=GetCurrencyEnum(x.Currency),
                Amount = x.Amount,
                ApprovalStatus=GetEnum(x.ApprovalStatus),
                DeletedTime=x.DeletedTime,
                Description=x.Description,
                EmployeeId=x.EmployeeId,
                EmployeeLastName=x.Employee.LastName,
                EmployeeName=x.Employee.Name,
                UpdatedDate=x.UpdatedDate,
                InvoicePath=x.InvoicePath,
                ExpenseType=GetExpenseTypeEnum(x.ExpenseType),

            }).ToList();
        }


    }
}
