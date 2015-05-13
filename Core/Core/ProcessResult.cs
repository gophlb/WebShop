
namespace Core
{
    public class ProcessResult
    {
        public enum RESULT_STATES 
        { 
            KO = -10,
            OK = 10
        };
        
        public int Result { get; set; }

        public string Message { get; set; }

        public string RedirectTo { get; set; }
    }
}
