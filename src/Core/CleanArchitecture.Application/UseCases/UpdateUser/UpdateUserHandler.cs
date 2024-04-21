﻿using AutoMapper;
using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application;

public class UpdateUserHandler : IRequestHandler<UserRequest.UpdateUserRequest, UserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserResponse> Handle(UserRequest.UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id, cancellationToken);

        if (user == null) return default!;

        user.Name = request.Name;
        user.Email = request.Email;

        _userRepository.Update(user);

        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<UserResponse>(user);
    }
}
