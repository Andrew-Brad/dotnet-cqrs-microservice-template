using AutoMapper;
using PROJECT_NAME.Application.Models;

namespace PROJECT_NAME.Infrastructure.ExampleService
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<ExampleEntity, Example>()
                .ReverseMap();
        }
    }
}