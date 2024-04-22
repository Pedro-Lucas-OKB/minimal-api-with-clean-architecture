using CleanArchitecture.Application.Shared.UserCQRS;
using MediatR;

namespace CleanArchitecture.API.Endpoints.Users;

public static class UsersModule
{
    // Configuração dos endpoints relacionados aos usuários
    public static void RegisterEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users", GetAll)
        .WithSummary("Lists all users in database")
        .WithDescription("Retrieves a list of all users stored in the database.");

        app.MapGet("/api/users/{email}", GetByEmail)
        .WithSummary("Get an user by its email")
        .WithDescription("Retrieves user information based on the provided email address.");

        app.MapPost("/api/users", Create)
        .WithSummary("Add an user to database")
        .WithDescription("Add an user to the database based on the provided email address and name");

        app.MapPut("/api/users/{id}", Update)
        .WithSummary("Update an existing user in database")
        .WithDescription("Update an existing user in the database based on the provided id. The fields 'email' and 'name' can be changed.");

        app.MapDelete("/api/users/{id}", Delete)
        .WithSummary("Remove an existing user from database")
        .WithDescription("Gets an user from the provided id and deletes it from the database.");
    }

    public static async Task<IResult> GetAll(IMediator mediator, CancellationToken cancellationToken)
    {
        try
        {
            var response = await mediator.Send(new UserRequest.GetAllUsersRequest(), cancellationToken);
            return Results.Ok(response);
        }
        catch (FluentValidation.ValidationException e)
        {
            return Results.Problem(e.Message);
        }
    }

    public static async Task<IResult> GetByEmail(string? email, IMediator mediator, CancellationToken cancellationToken)
    {
        try
        {
            var response = await mediator.Send(new UserRequest.GetByEmailUser(email), cancellationToken);
            return Results.Ok(response);
        }
        catch (FluentValidation.ValidationException e)
        {
            return Results.Problem(e.Message);
        }
    }

    public static async Task<IResult> Create(UserRequest.CreateUserRequest request, IMediator mediator, CancellationToken cancellationToken)
    {
        try
        {
            var response = await mediator.Send(request, cancellationToken);
            return Results.Ok(response);
        }
        catch (FluentValidation.ValidationException e)
        {
            return Results.Problem(e.Message);
        }
    }

    public static async Task<IResult> Update(Guid id, UserRequest.UpdateUserRequest request, IMediator mediator,CancellationToken cancellationToken)
    {
        try
        {
            if (id != request.Id) return Results.BadRequest();
    
            var response = await mediator.Send(request, cancellationToken);
            return Results.Ok(response);
        }
        catch (FluentValidation.ValidationException e)
        {
            return Results.Problem(e.Message);
        }
    }

    public static async Task<IResult> Delete(Guid? id, IMediator mediator, CancellationToken cancellationToken)
    {
        try
        {
            if (id == null) return Results.BadRequest();
            
            var deleteUser = new UserRequest.DeleteUserRequest(id.Value);
    
            var response = await mediator.Send(deleteUser, cancellationToken);
            return Results.Ok(response);
        }
        catch (FluentValidation.ValidationException e)
        {
            return Results.Problem(e.Message);
        }
    }
}

