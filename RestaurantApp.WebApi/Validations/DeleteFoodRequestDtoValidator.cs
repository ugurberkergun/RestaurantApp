using FluentValidation;
using RestaurantApp.Entities.Dtos.Requests;

namespace RestaurantApp.WebApi.Validations
{
    public class DeleteFoodRequestDtoValidator : AbstractValidator<DeleteFoodRequestDto>
    {
        public DeleteFoodRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün ismi boş olamaz");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Ürün stok boş olamaz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş olamaz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Ürün kategorisi boş olamaz");
            RuleFor(x => x.PhotoUrl).NotEmpty().WithMessage("Ürün fotoğrafı boş olamaz");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Ürün Id boş olamaz");

        }
    }
}
