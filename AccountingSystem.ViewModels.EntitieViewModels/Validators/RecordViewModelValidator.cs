using FluentValidation;
using System.Text.RegularExpressions;

namespace AccountingSystem.ViewModels.EntitieViewModels.Validators
{
    public class RecordViewModelValidator:AbstractValidator<RecordsViewModel>
    {
        public RecordViewModelValidator()
        {
            RuleFor(x => x.Tittle).NotNull().NotEmpty().MaximumLength(100).WithMessage("Required field");
            RuleFor(x => x.UserId).NotNull().WithMessage("Required field");
            RuleFor(x => x.DateOfCreating).NotNull();
            RuleFor(x => x.UserId).Must(UserIdValid).WithMessage("Only digits and not 0");
        }

        private bool UserIdValid(int value)
        {
            Regex regex = new Regex(@"\d");
            Match m = regex.Match(value.ToString());
            if(value!=0 && m.Success)
            {
                return true;
            }
            return false;
        }
    }
}
