using Application.Abstractions.Messaging;
using Application.Contracts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserResponse>
    //public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        public CreateUserCommandHandler()
        {

        }

        //public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        //{
        //    return Unit.Value;
        //}

        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        //{

        //    var user = new User
        //    {
        //        FirstName = request.FirstName,
        //        LastName = request.LastName,
        //        Email = request.Email,
        //    };
        //    UserResponse userResponse = new UserResponse(user.FirstName, user.LastName, user.Email);//to test
        //    //_userRepository.Insert(user);

        //    //await _unitOfwork
        //    return userResponse;
        //}
    }
}
