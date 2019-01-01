using MediatR;

namespace ELearning.Application.Sections.Queries.GetSectionById
{
    public class GetSectionByIdQuery : IRequest<SectionViewModel>
    {
        public int Id { get; set; }
    }
}
