using System;

namespace WindowsFormsApp1.domain
{
    public class Spectacol : Entity<int>
    {
        private string nume;
        private Artist artist;
        private DateTime data;
        private string locatie;
        private int locuriDisponibile;
        private int locuriVandute;
        
        public Spectacol(){}

        public Spectacol(string nume, Artist artist, DateTime data, string locatie, int locuriDisponibile, int locuriVandute)
        {
            this.nume = nume;
            this.artist = artist;
            this.data = data;
            this.locatie = locatie;
            this.locuriDisponibile = locuriDisponibile;
            this.locuriVandute = locuriVandute;
        }

        public Spectacol(Spectacol spectacolNou)
        {
            this.nume = spectacolNou.getNume();
            this.artist = spectacolNou.getArtist();
            this.data = spectacolNou.getData();
            this.locatie = spectacolNou.getLocatie();
            this.locuriDisponibile = spectacolNou.getLocuriDisponibile();
            this.locuriVandute = spectacolNou.getLocuriVandute();
        }

        public string getNume()
        {
            return this.nume;
        }

        public Artist getArtist()
        {
            return this.artist;
        }

        public DateTime getData()
        {
            return this.data;
        }

        public string getLocatie()
        {
            return this.locatie;
        }

        public int getLocuriDisponibile()
        {
            return this.locuriDisponibile;
        }

        public int getLocuriVandute()
        {
            return this.locuriVandute;
        }

        public void setNume(string nume)
        {
            this.nume = nume;
        }

        public void setArtist(Artist artist)
        {
            this.artist = artist;
        }

        public void setData(DateTime data)
        {
            this.data = data;
        }

        public void setLocatie(string locatie)
        {
            this.locatie = locatie;
        }

        public void setLocuriDisponibile(int locuriDisponibile)
        {
            this.locuriDisponibile = locuriDisponibile;
        }

        public void setLocuriVandute(int locuriVandute)
        {
            this.locuriVandute = locuriVandute;
        }

        public override string ToString()
        {
            return "Spectacol: " + nume + " " + artist.getId().ToString() + " " + data.ToString() + " " + locatie + " " +
                   locuriDisponibile.ToString() + " " + locuriVandute; 
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Spectacol))
            {
                return false;
            }

            return (this.nume == ((Spectacol)obj).getNume()) && (this.artist.getId() == ((Spectacol)obj).getArtist().getId())
                                                          && (this.data == ((Spectacol)obj).getData()) 
                                                          && (this.locatie == ((Spectacol)obj).getLocatie())
                                                          && (this.locuriDisponibile == ((Spectacol)obj).getLocuriDisponibile()) 
                                                          && (this.locuriVandute == ((Spectacol)obj).getLocuriVandute());

        }
    }
}