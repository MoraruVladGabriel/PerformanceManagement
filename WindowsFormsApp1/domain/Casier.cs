namespace WindowsFormsApp1.domain
{
    public class Casier : Entity<int>
    {
        private string nume;
        private string parola;
        private string email;
        private string oficiu;
        
        public Casier(){}

        public Casier(string nume, string parola, string email, string oficiu)
        {
            this.nume = nume;
            this.parola = parola;
            this.email = email;
            this.oficiu = oficiu;
        }

        public Casier(Casier casierNou)
        {
            this.nume = casierNou.getNume();
            this.parola = casierNou.getParola();
            this.email = casierNou.getEmail();
            this.oficiu = casierNou.getOficiu();
        }

        public string getNume()
        {
            return this.nume;
        }

        public string getParola()
        {
            return this.parola;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getOficiu()
        {
            return this.oficiu;
        }

        public void setNume(string nume)
        {
            this.nume = nume;
        }

        public void setParola(string parola)
        {
            this.parola = parola;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setOficiu(string oficiu)
        {
            this.oficiu = oficiu;
        }

        public override string ToString()
        {
            return
                $"{nameof(nume)}:{nume}, {nameof(parola)}:{parola}, {nameof(email)}:{email}, {nameof(oficiu)}:{oficiu}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Casier))
            {
                return false;
            }

            return (this.nume == ((Casier)obj).getNume()) && (this.parola == ((Casier)obj).getParola())
                && (this.email == ((Casier)obj).getEmail()) && (this.oficiu == ((Casier)obj).getOficiu());

        }
    }
}