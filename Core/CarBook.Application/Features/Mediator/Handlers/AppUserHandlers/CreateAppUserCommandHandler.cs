﻿using CarBook.Application.Enums;
using CarBook.Application.Features.Mediator.Commands.RegisterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
	{
		private readonly IRepository<AppUser> _repository;

		public CreateAppUserCommandHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new AppUser
			{
				Username = request.Username,
				Password = request.Password,
				AppRoleId = (int)RolesType.Member,
				Email = request.Email,
				Name = request.Name,
				Surname = request.Surname
			});
		}
	}
}
