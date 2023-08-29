using AutoMapper;
using Bogus;
using GraphQLApi.Repsoitory;
using GraphQLApi.Types;

namespace GraphQLApi.Schema;

public class Query
{
    private readonly CvRepository _cvRepository;
    private readonly IMapper _mapper;
    public Query(CvRepository cvRepository, IMapper mapper)
    {
        _cvRepository = cvRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CvType>> GetCvs()
    {
        var cvs = await _cvRepository.GetAll();
        return cvs.Select(c => _mapper.Map<CvType>(cvs));
    }

    public async Task<CvType> GetCvsById(Guid id)
    {
        var cv = await _cvRepository.GetById(id);
        return _mapper.Map<CvType>(cv);
    }
    
    [GraphQLDeprecated("For test only!")]
    public string Test => "Test of GraphQL";
}