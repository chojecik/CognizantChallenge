using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CognizantChallenge.Core.Database.Entities
{
    public class Task
    {
        /// <summary>
        /// Records Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the task
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string TaskName { get; set; }

        /// <summary>
        /// Description of the task
        /// </summary>
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        /// <summary>
        /// Input parameter for testing the code
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string InputParameter { get; set; }

        /// <summary>
        /// Expected output of code 
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string OutputParameter { get; set; }

        public virtual ICollection<Challenge> Challenges { get; set; }
    }
}
