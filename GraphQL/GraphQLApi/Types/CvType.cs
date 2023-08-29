namespace GraphQLApi.Types;

public class CvType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    [GraphQLNonNullType]
    public IEnumerable<CompanyType> CompanyTypes { get; set; }
    [GraphQLNonNullType]
    public IEnumerable<EducationType> EducationTypes { get; set; }
    [GraphQLNonNullType]
    public IEnumerable<ProjectType> ProjectTypes { get; set; }
    [GraphQLNonNullType]
    public IEnumerable<SkillType> SkillTypes { get; set; }
}