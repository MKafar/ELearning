using MediatR;

namespace ELearning.Application.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQuery : IRequest<RoleViewModel>
    {
        public int Id { get; set; }
    }
}
