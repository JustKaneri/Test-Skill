namespace Test_Skill_UI.Models
{
    public class RequestAnswer<T>
    {
        public string ErrorContent { get; set; }
        public T Result { get; set; }

    }
}
