namespace WindowsFormsApp1.domain
{
    public class Artist : Entity<int>
    {
        private string nume;
        private string tip;

        public Artist(){}
        
        public Artist(string nume, string tip)
        {
            this.nume = nume;
            this.tip = tip;
        }

        public string getNume()
        {
            return this.nume;
        }

        public string getTip()
        {
            return this.tip;
        }

        public void setNume(string nume)
        {
            this.nume = nume;
        }

        public void setTip(string tip)
        {
            this.tip = tip;
        }

        public override string ToString()
        {
            return $"{nameof(nume)}: {nume}, {nameof(tip)}: {tip}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Artist))
            {
                return false;
            }

            return (this.nume == ((Artist)obj).getNume()) && (this.tip == ((Artist)obj).getTip());
        }
    }
}