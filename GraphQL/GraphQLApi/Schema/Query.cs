using Bogus;
using GraphQLApi.Types;

namespace GraphQLApi.Schema;

public class Query
{
    private readonly Faker<CvType> _cvFaker;
    private readonly Faker<CompanyType> _companyFaker;
    private readonly Faker<EducationType> _educationFaker;
    private readonly Faker<ProjectType> _projectFaker;
    private readonly Faker<SkillType> _skillFaker;

    public Query()
    {
        _companyFaker = new Faker<CompanyType>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Company.CompanyName())
            .RuleFor(c => c.Description, f => f.Name.JobDescriptor());

        _educationFaker = new Faker<EducationType>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Degree, f => f.Name.JobTitle())
            .RuleFor(c => c.InstitutionName, f => f.Music.Locale);

        _projectFaker = new Faker<ProjectType>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Music.Locale)
            .RuleFor(c => c.Description, f => f.Lorem.Locale);

        _skillFaker = new Faker<SkillType>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Lorem.Word());
        
        _cvFaker = new Faker<CvType>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .RuleFor(c => c.CompanyTypes, _companyFaker?.Generate(4))
            .RuleFor(c => c.EducationTypes, _educationFaker?.Generate(2))
            .RuleFor(c => c.ProjectTypes, _projectFaker?.Generate(8))
            .RuleFor(c => c.SkillTypes, _skillFaker?.Generate(16));
    }
    
    public IEnumerable<CvType> GetCvs()
    {
        var cvs = _cvFaker.Generate(8);
        return cvs;
    }

    public CvType GetCvsById(Guid id)
    {
        var cv = _cvFaker.Generate();
        cv.Id = id;
        return cv;
    }
    
    [GraphQLDeprecated("For test only!")]
    public string Test => "Test of GraphQL";
}