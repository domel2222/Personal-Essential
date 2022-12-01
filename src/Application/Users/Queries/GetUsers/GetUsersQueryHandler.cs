namespace Application.Users.Queries.GetUsers
{
    public sealed class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<UserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUserAsync(cancellationToken);

            return users.Adapt<List<UserResponse>>();
        }
    }
}