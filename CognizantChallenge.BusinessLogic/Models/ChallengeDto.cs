using CognizantChallenge.BusinessLogic.Enums;
using System.ComponentModel.DataAnnotations;

namespace CognizantChallenge.BusinessLogic.Models
{
    public class ChallengeDto
    {
        /// <summary>
        /// Name of the user taking a challenge
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Task ID
        /// </summary>
        [Required]
        public int TaskId { get; set; }

        /// <summary>
        /// Solution 
        /// </summary>
        [Required]
        public string Solution { get; set; }

        /// <summary>
        /// Selected programming language
        /// </summary>
        [Required]
        public Language Language { get; set; }
    }
}
