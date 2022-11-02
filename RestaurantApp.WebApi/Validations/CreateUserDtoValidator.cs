using FluentValidation;
using RestaurantApp.Entities.Dtos.Requests;

namespace RestaurantApp.WebApi.Validations
{
    public class CreateUserDtoValidator:AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş olamaz").EmailAddress().WithMessage("Email yanlış");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş olamaz");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim alanı boş olamaz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim alanı boş olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş olamaz");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş olamaz");
        }
    }
}
