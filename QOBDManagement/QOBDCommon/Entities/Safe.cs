namespace QOBDCommon.Entities
{
    public class Safe
    {
        public Agent AuthenticatedUser { get; set; }
        public bool IsAuthenticated { get; set; }

        public Safe()
        {
            AuthenticatedUser = new Agent();
        }    
    }
}
