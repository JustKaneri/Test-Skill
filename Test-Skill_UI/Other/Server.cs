using Test_Skill_UI.Models;

namespace Test_Skill_UI.Other
{
    public class Server
    {
        public static async Task<RequestAnswer<T>> SendRequest<T>(object obj, string path)
        {
            JsonContent content = JsonContent.Create(obj);

            HttpClient client = new HttpClient();

            var responce = await client.PostAsync(path, content);

            var result = await responce.Content.ReadFromJsonAsync<RequestAnswer<T>>();

            return result;
        }
    }
}
