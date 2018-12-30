using MediatR;

namespace ELearning.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int Id { get; set; }
    }
}
