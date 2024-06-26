﻿using Project.Application.Features.CQRS.Commands.LeaveCommands;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.LeaveHandler
{
    public class UpdateLeaveCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateLeaveCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateLeaveCommand command)
        {
            var values= await unitOfWork.leaveRepository.GetByIdAsync(command.Id);

            if (values != null)
            {
                values.ApprovalDate = DateTime.Now;
              
                values.Status = command.Status;
                await unitOfWork.leaveRepository.UpdateAsync(values);
                await unitOfWork.CommitAsync();
            }
           
        }
    }
}
