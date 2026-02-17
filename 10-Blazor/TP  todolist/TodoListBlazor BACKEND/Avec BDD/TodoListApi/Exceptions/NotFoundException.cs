namespace TodoListApi.Exceptions
{
    /// <summary>
    /// Exception lancee quand une ressource demandee n'existe pas.
    /// Le middleware la transformera en reponse HTTP 404.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
