using System.Collections.Generic;

namespace CognizantChallenge.ComBusinessLogicmon.Models
{
    public class Result
    {
        /// <summary>
        /// Name of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Number of successful submissions
        /// </summary>
        public int SuccessfulSubmissions { get; set; }

        /// <summary>
        /// Names of successfully solved tasks
        /// </summary>
        public List<string> SolvedTasks { get; set; }
    }
}
