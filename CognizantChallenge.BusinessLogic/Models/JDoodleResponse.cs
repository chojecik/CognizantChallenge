namespace CognizantChallenge.BusinessLogic.Models
{
    public class JDoodleResponse
    {
        /// <summary>
        /// Output of the program
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Status Code of the result
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// Memory used by the program
        /// </summary>
        public string Memory { get; set; }

        /// <summary>
        /// CPU Time used by the program
        /// </summary>
        public string CpuTime { get; set; }

        /// <summary>
        /// Errors
        /// </summary>
        public string Error { get; set; }
    }
}
