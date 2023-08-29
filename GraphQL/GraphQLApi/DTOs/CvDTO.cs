using GraphQLApi.Types;

namespace GraphQLApi.DTOs;

public class CvDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<CompanyDTO> CompanyDTOs { get; set; }
    public IEnumerable<EducationDTO> EducationDTOs { get; set; }
    public IEnumerable<ProjectDTO> ProjectDtos { get; set; }
    public IEnumerable<SkillDTO> SkillDtos { get; set; }
}