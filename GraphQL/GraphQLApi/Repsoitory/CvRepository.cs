using Bogus;
using GraphQLApi.DTOs;
using GraphQLApi.Services;
using Microsoft.EntityFrameworkCore;

namespace GraphQLApi.Repsoitory;

public class CvRepository
{
    private readonly IDbContextFactory<CvDbContext> _contextFactory;
    private readonly Faker<CvDTO> _cvFaker;
    private readonly Faker<CompanyDTO> _companyFaker;
    private readonly Faker<EducationDTO> _educationFaker;
    private readonly Faker<ProjectDTO> _projectFaker;
    private readonly Faker<SkillDTO> _skillFaker;
    
    public CvRepository(IDbContextFactory<CvDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
        _companyFaker = new Faker<CompanyDTO>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Company.CompanyName())
            .RuleFor(c => c.Description, f => f.Name.JobDescriptor());

        _educationFaker = new Faker<EducationDTO>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Degree, f => f.Name.JobTitle())
            .RuleFor(c => c.InstitutionName, f => f.Music.Locale);

        _projectFaker = new Faker<ProjectDTO>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Music.Locale)
            .RuleFor(c => c.Description, f => f.Lorem.Locale);

        _skillFaker = new Faker<SkillDTO>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Lorem.Word());
        
        _cvFaker = new Faker<CvDTO>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .RuleFor(c => c.CompanyDTOs, _companyFaker?.Generate(4))
            .RuleFor(c => c.EducationDTOs, _educationFaker?.Generate(2))
            .RuleFor(c => c.ProjectDtos, _projectFaker?.Generate(8))
            .RuleFor(c => c.SkillDtos, _skillFaker?.Generate(16));
    }

    public async Task<Task> SeedDatabase()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        context.Cvs.AddRange(_cvFaker.Generate(5));
        await context.SaveChangesAsync();

        return Task.CompletedTask;
    }
    
    public async Task<CvDTO> Create(CvDTO dto)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        context.Cvs.Add(dto);
        await context.SaveChangesAsync();

        return dto;
    }

    public async Task<IEnumerable<CvDTO>> GetAll()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var result = await context.Cvs.ToListAsync();
        return result;
    }
    
    public async Task<CvDTO?> GetById(Guid id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var result = await context.Cvs.FirstOrDefaultAsync(x=> x.Id == id) ;
        return result;
    }
}