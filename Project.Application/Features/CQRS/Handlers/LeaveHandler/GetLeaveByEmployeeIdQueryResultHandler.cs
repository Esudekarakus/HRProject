﻿using Project.Application.Features.CQRS.Queries.LeaveQueries;
using Project.Application.Features.CQRS.Results.LeaveResults;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.LeaveHandler
{
    public class GetLeaveByEmployeeIdQueryResultHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetLeaveByEmployeeIdQueryResultHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public LeaveType GetEnumLeaveType(int type)
        {
            switch (type)
            {
                case 1:
                    return LeaveType.YillikIzin;
                case 2:
                    return LeaveType.UcretsizIzin;
                case 3:
                    return LeaveType.MazeretIzni;

                case 4:
                    return LeaveType.RaporluIzin; 
                case 5:
                    return LeaveType.OzelIzin;
                case 6:
                    return LeaveType.UzunSureliIzin; 
                case 7:
                    return LeaveType.HastalikIzni;
                case 8:
                    return LeaveType.DogumIzni;
                case 9:
                    return LeaveType.EvlilikIzni;
                case 10:
                    return LeaveType.OlumIzni;
                case 11:
                    return LeaveType.AnnelikIzni;
                case 12:
                    return LeaveType.BabalıkIzni;
                default:
                    return LeaveType.MazeretIzni;
            }
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
        public async Task<List<GetLeaveByEmployeeIdQueryResult>> Handle(GetLeaveByEmployerIdQuery query)
        {
            var values = await unitOfWork.leaveRepository.GetLeaveWithEmployeeWithEmployeeId(query.Id);
            return values.Select(x=> new GetLeaveByEmployeeIdQueryResult
            { 

                EmployeeId = x.EmployeeId,
                Id = x.Id,
                Description = x.Description,
                ApprovalStatus=x.Status,
                
                DueDate = x.DueDate,
                ApprovalDate = x.ApprovalDate,
                LeaveDate = x.LeaveDate,
                NumberOfDays = x.NumberOfDays,
                EmployeeLastName=x.Employee.LastName,
                EmployeeName=x.Employee.Name,
                Type=GetEnumLeaveType(x.Type),

            }).ToList();
        }
    }
}
