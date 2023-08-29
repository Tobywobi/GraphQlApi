namespace GraphQLApi.Types;

public class CvType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<CompanyType> CompanyTypes { get; set; }
    public IEnumerable<EducationType> EducationTypes { get; set; }
    public IEnumerable<ProjectType> ProjectTypes { get; set; }
    public IEnumerable<SkillType> SkillTypes { get; set; }
}