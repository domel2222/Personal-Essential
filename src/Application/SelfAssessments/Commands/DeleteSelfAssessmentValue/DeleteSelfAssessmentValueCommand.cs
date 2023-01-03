using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SelfAssessments.Commands.DeleteSelfAssessmentValue
{
    public sealed record DeleteSelfAssessmentValueCommand(Guid SelfAssessmentValueId) : ICommand<Unit>
    {
    }
}
