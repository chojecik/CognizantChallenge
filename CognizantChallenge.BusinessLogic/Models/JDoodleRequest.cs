namespace CognizantChallenge.BusinessLogic.Models
{
    public class JDoodleRequest
    {
        /// <summary>
        /// Client ID 
        /// </summary>
        public string clientId { get; set; }

        /// <summary>
        /// Client secret
        /// </summary>
        public string clientSecret { get; set; }

        /// <summary>
        /// Program to compile and execute
        /// </summary>
        public string script { get; set; }

        /// <summary>
        /// StdIn
        /// </summary>
        public string stdin { get; set; }

        /// <summary>
        /// Language of the script
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// Version of the language to be used
        /// </summary>
        public string versionIndex { get; set; }

    }
}
