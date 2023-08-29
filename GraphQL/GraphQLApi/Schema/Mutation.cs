using GraphQLApi.Repsoitory;

namespace GraphQLApi.Schema;

public class Mutation
{
    private readonly CvRepository _cvRepository;

    public Mutation(CvRepository cvRepository)
    {
        _cvRepository = cvRepository;
    }

    public async Task<bool> Seed()
    {
        var result = await _cvRepository.SeedDatabase();
        return result.IsCompleted;
    }
    
    
}