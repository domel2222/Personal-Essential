using Application.Users.Commands.UpdateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SelfAssessments.Commands
{
    public class CreateSelfAssessmentCommandValueValidator : AbstractValidator<CreateSelfAssessmentCommand>
    {
        public CreateSelfAssessmentCommandValueValidator()
        {
            RuleFor(x => x.UserId)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(CreateSelfAssessmentCommand.UserId)} {HelperValidator.NotNullOrEmpty}");

            RuleFor(x => x.JournalId)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(CreateSelfAssessmentCommand.JournalId)} {HelperValidator.NotNullOrEmpty}");

        }
    }
}
