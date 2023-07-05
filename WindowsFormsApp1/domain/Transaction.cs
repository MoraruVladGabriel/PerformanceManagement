namespace WindowsFormsApp1.domain
{
    public class Transaction : Entity<int>
    {
        private string cumparator;
        private int locuri;
        private Spectacol _spectacol;
        private Casier _casier;
        
        public Transaction(){}

        public Transaction(string cumparator, int locuri, Spectacol spectacol, Casier casier)
        {
            this.cumparator = cumparator;
            this.locuri = locuri;
            _spectacol = spectacol;
            _casier = casier;
        }

        public string getCumparator()
        {
            return this.cumparator;
        }

        public int getLocuri()
        {
            return this.locuri;
        }

        public Spectacol getSpectacol()
        {
            return this._spectacol;
        }

        public Casier getCasier()
        {
            return this._casier;
        }

        public void setCumparator(string cumparator)
        {
            this.cumparator = cumparator;
        }

        public void setLocuri(int locuri)
        {
            this.locuri = locuri;
        }

        public void setSpectacol(Spectacol spectacolNou)
        {
            this._spectacol = spectacolNou;
        }

        public void setCasier(Casier casierNou)
        {
            this._casier = casierNou;
        }

        public override string ToString()
        {
            return "Tranzactie: " + cumparator + " " + locuri.ToString() + " " + _spectacol.getId().ToString() + " " +
                   _casier.getId().ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Transaction))
            {
                return false;
            }

            return (this.cumparator == ((Transaction)obj).getCumparator()) && (this.locuri == ((Transaction)obj).getLocuri())
                                                             && (this._spectacol.getId() == ((Transaction)obj).getSpectacol().getId()) 
                                                             && (this._casier.getId() == ((Transaction)obj).getCasier().getId());
        }
    }
}