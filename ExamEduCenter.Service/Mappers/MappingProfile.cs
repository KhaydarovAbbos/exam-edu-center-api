using AutoMapper;
using ExamEduCenter.Domain.Entities.Courses;
using ExamEduCenter.Service.DTOs.Courses;

namespace ExamEduCenter.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseForCreationDto, Course>().ReverseMap();
            CreateMap<CourseForUpdatingDto, Course>().ReverseMap();
            CreateMap<CourseTypeForUpdationDto, CourseType>().ReverseMap();
        }
    }
}
