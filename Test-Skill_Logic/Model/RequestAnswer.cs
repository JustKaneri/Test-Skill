namespace Test_Skill_Logic.Model
{
    public class RequestAnswer<T>
    {
        public string ErrorContent { get; set; }
        public T Result { get; set; }

        public RequestAnswer(T result):this(result,null)
        {
                
        }

        public RequestAnswer(T result,string error) 
        {
            if (!string.IsNullOrWhiteSpace(error))
            {
                ErrorContent = error;
            }

            Result = result;
        }


    }
}
