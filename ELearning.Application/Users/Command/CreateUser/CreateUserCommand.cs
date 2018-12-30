using MediatR;

namespace ELearning.Application.Users.Command.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
