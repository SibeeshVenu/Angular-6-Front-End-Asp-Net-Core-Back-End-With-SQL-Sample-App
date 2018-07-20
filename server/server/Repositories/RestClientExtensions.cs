using RestSharp;
using System.Threading.Tasks;

namespace server.Repositories
{
    public static class RestClientExtensions
    {
        public static async Task<string> ExecuteAsync(this RestClient client, RestRequest request)
        {
            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
            RestRequestAsyncHandle handle = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
            return (await taskCompletion.Task).Content;
        }
    }
}
