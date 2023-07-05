using System.Runtime.Remoting.Messaging;

namespace WindowsFormsApp1.domain
{
    public class Entity<TId>
    {
        public TId Id;

        public TId getId()
        {
            return this.Id;
        }

        public void setId(TId id)
        {
            this.Id = id;
        }
    }
}