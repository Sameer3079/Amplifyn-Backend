namespace Amplifyn_Backend.ServiceModels
{
    public class GetShortestPathRequestDTO
    {
        public GraphDTO Graph { get; set; }
        public ShortestPathForDTO ShortestPathFor { get; set; }
    }
}
