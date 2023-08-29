using Bogus;
using GraphQLApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQLApi.Services;

public class CvDbContext : DbContext
{
    public CvDbContext(DbContextOptions<CvDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<CompanyDTO> Companies { get; set; }
    public DbSet<EducationDTO> Educations { get; set; }
    public DbSet<ProjectDTO> Projects { get; set; }
    public DbSet<SkillDTO> Skills { get; set; }
    public DbSet<CvDTO> Cvs { get; set; }
    
}