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
    public class GetExpensesWithEmployeesQueryHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetExpensesWithEmployeesQueryHandler(IUnitOfWork unitOfWork)
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
                case 3:
                    return ApprovalStatus.Denied;

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
            switch(expenseType)
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

        public async Task<List<GetExpenseWithEmployeesQueryResult>> Handle()
        {
            var expense = unitOfWork.expenseRepository.GetAllWithEmployee();

            var results=new List<GetExpenseWithEmployeesQueryResult>();

            foreach (var ex in expense)
            {
                var approvalStatus = GetEnum(ex.ApprovalStatus);
                var currency= GetCurrencyEnum(ex.Currency);
                var expenseType=GetExpenseTypeEnum(ex.ExpenseType);
                results.Add(new GetExpenseWithEmployeesQueryResult
                {
                    Id = ex.Id,
                    InvoicePath = ex.InvoicePath,
                    ApprovalStatus = approvalStatus,
                    Currency = currency,
                    Amount = ex.Amount,
                    ApprovalDate = ex.ApprovalDate,
                    CreatedDate = ex.CreatedDate,
                    DeletedTime = ex.DeletedTime,
                    Description = ex.Description,
                    UpdatedDate = ex.UpdatedDate,
                    EmployeeId = ex.EmployeeId,
                    EmployeeLastName = ex.Employee.LastName,
                    EmployeeName = ex.Employee.Name,
                    ExpenseDate = ex.Employee.CreatedDate,
                    ExpenseType=expenseType

                });

            }
            return results;
        }
    }
}
