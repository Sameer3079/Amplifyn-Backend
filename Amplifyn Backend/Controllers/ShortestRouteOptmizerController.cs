using Amplifyn_Backend.ServiceModels;
using Microsoft.AspNetCore.Mvc;

namespace Amplifyn_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortestRouteOptmizerController : ControllerBase
    {

        private readonly ILogger<ShortestRouteOptmizerController> _logger;

        public ShortestRouteOptmizerController(ILogger<ShortestRouteOptmizerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("GetShortestPath")]
        public GetShortestPathResponseDTO GetShortestPath([FromBody] GetShortestPathRequestDTO requestDTO)
        {
            Dictionary<string, int> distStore = new Dictionary<string, int>();
            Dictionary<string, string?> prevStore = new Dictionary<string, string?>();

            requestDTO.Graph.Nodes.ForEach(node =>
            {
                distStore.Add(node, int.MaxValue);
                prevStore.Add(node, null);
            });

            distStore.Add(requestDTO.ShortestPathFor.From, 0);

            Dictionary<string, int> nodeStore = new();
            while (nodeStore.Count != 0)
            {
                requestDTO.Graph.Edges.ForEach(edge =>
                {
                    if (distStore[edge.To] > distStore[edge.From] + edge.Distance)
                    {
                        distStore[edge.To] = distStore[edge.From] + edge.Distance;
                        prevStore[edge.To] = edge.From;
                        nodeStore.Remove()
                    }
                });
            }


            return new GetShortestPathResponseDTO { };
        }
    }
}