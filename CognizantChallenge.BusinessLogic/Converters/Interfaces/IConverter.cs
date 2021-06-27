namespace CognizantChallenge.BusinessLogic.Converters.Interfaces
{
    /// <summary>
    /// Interface for converting dto objects to database objects
    /// </summary>
    /// <typeparam name="Tfrom">Source object</typeparam>
    /// <typeparam name="Tto">Destination object</typeparam>
    public interface IConverter<Tfrom, Tto> 
        where Tfrom : class
        where Tto : class
    {
        /// <summary>
        /// Converts object of Tfrom type to object Tto type
        /// </summary>
        /// <param name="source">Object of type Tfrom to convert from</param>
        /// <returns>Converted object of Tto type</returns>
        Tto Convert(Tfrom source);
    }
}
