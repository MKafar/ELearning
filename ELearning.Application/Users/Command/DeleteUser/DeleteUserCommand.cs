using MediatR;

namespace ELearning.Application.Users.Command.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
