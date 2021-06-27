using System.ComponentModel.DataAnnotations;

namespace CognizantChallenge.Core.Database.Entities
{
    public class Challenge
    {
        /// <summary>
        /// Records Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Flag determining if challenge was a success
        /// </summary>
        [Required]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Name of user taking a challenge
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// The task of challenge
        /// </summary>
        [Required]
        public virtual Task Task { get; set; }
        public int TaskId { get; set; }
    }
}
