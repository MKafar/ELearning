using MediatR;

namespace ELearning.Application.Sections.Queries.GetSectionEvaluationsListById
{
    public class GetSectionEvaluationsListByIdQuery : IRequest<SectionEvaluationsListViewModel>
    {
        public int Id { get; set; }
    }
}
