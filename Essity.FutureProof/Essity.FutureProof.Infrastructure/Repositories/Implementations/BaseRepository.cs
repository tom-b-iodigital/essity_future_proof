namespace Essity.FutureProof.Infrastructure.Repositories.Implementations
{
    public abstract class BaseRepository
    {
        /// <summary>
        /// Gets a value indicating whether user data may be stored (partially encrypted) for a certain configuration, or not (ie Russian market).
        /// </summary>
        public bool SkipSaveData
        {
            get
            {
                if (Thread.CurrentThread.CurrentCulture.Name.Equals("ru-ru", StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }

                return false;
            }
        }
    }
}