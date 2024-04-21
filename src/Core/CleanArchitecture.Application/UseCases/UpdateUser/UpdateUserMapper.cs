﻿using AutoMapper;
using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application;

public sealed class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UserRequest.UpdateUserRequest, User>();
        CreateMap<User, UserResponse>();
    }
}
