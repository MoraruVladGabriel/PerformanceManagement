using System;
using System.Collections.Generic;
using System.Data;
using WindowsFormsApp1.domain;
using WindowsFormsApp1.utils;

namespace WindowsFormsApp1.repository.repoDB
{
    public class SpectacolDBRepository : ISpectacolRepository
    {
        private IArtistRepository artistRepo;
        IDictionary<String, string> props;
        
        public SpectacolDBRepository(IDictionary<String, string> props, IArtistRepository artistRepo)
        {
            this.props = props;
            this.artistRepo = artistRepo;
        }
        
        public Spectacol FindById(int id)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Spectacole where id=@id";
                IDbDataParameter paramID = comm.CreateParameter();
                paramID.ParameterName = "@id";
                paramID.Value = id;
                comm.Parameters.Add(paramID);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        Artist artist = artistRepo.FindById(dataR.GetInt32(2));
                        DateTime dateTime = DateTime.Parse(dataR.GetString(3));
                        String locatie = dataR.GetString(4);
                        int locuriDisponibile = dataR.GetInt32(5);
                        int locuriVandute = dataR.GetInt32(6);
                    
                        Spectacol spectacol =
                            new Spectacol(nume, artist, dateTime, locatie, locuriDisponibile, locuriVandute);
                    
                        spectacol.setId(id2);
                        return spectacol;
                    }   
                }
            }
            return null;
        }

        public IEnumerable<Spectacol> FindAll()
        {
            IDbConnection con = DBUtils.getConnection(props);
            IList<Spectacol> list = new List<Spectacol>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Spectacole";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        Artist artist = artistRepo.FindById(dataR.GetInt32(2));
                        DateTime dateTime = DateTime.Parse(dataR.GetString(3));
                        String locatie = dataR.GetString(4);
                        int locuriDisponibile = dataR.GetInt32(5);
                        int locuriVandute = dataR.GetInt32(6);
                    
                        Spectacol spectacol =
                            new Spectacol(nume, artist, dateTime, locatie, locuriDisponibile, locuriVandute);
                    
                        spectacol.setId(id2);
                        list.Add(spectacol);
                    }
                }
            }
            return list;
        }

        public void Save(Spectacol entity)
        {
            var con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Spectacole (nume,artist,data,locatie,locuriDisponibile,locuriVandute) values (@nume,@artist,@data,@locatie,@locuriDisponibile,@locuriVandute)";
            
                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.getNume();
                comm.Parameters.Add(paramNume);

                var paramArtist = comm.CreateParameter();
                paramArtist.ParameterName = "@artist";
                paramArtist.Value = entity.getArtist().getId();
                comm.Parameters.Add(paramArtist);
            
                var paramData = comm.CreateParameter();
                paramData.ParameterName = "@data";
                paramData.Value = entity.getData().ToString();
                comm.Parameters.Add(paramData);
            
                var paramLocatie = comm.CreateParameter();
                paramLocatie.ParameterName = "@locatie";
                paramLocatie.Value = entity.getLocatie();
                comm.Parameters.Add(paramLocatie);
            
                var paramLocuriDisponibile = comm.CreateParameter();
                paramLocuriDisponibile.ParameterName = "@locuriDisponibile";
                paramLocuriDisponibile.Value = entity.getLocuriDisponibile();
                comm.Parameters.Add(paramLocuriDisponibile);
            
                var paramLocuriVandute = comm.CreateParameter();
                paramLocuriVandute.ParameterName = "@locuriVandute";
                paramLocuriVandute.Value = entity.getLocuriVandute();
                comm.Parameters.Add(paramLocuriVandute);

                var result = comm.ExecuteNonQuery();
            }
        }

        public void Delete(Spectacol entity)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Spectacole where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.getId();
                comm.Parameters.Add(paramId);
                var result = comm.ExecuteNonQuery();
            }
        }

        public void Update(int id, Spectacol entity)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var  comm = con.CreateCommand())
            {
                comm.CommandText = "update Spectacole set nume=@nume, artist=@artist, data=@data, locatie=@locatie, locuriDisponibile=@locuriDisponibile, locuriVandute=@locuriVandute where id=@id";
            
                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.getNume();
                comm.Parameters.Add(paramNume);

                var paramArtist = comm.CreateParameter();
                paramArtist.ParameterName = "@artist";
                paramArtist.Value = entity.getArtist().getId();
                comm.Parameters.Add(paramArtist);
            
                var paramData = comm.CreateParameter();
                paramData.ParameterName = "@data";
                paramData.Value = entity.getData().ToString();
                comm.Parameters.Add(paramData);
            
                var paramLocatie = comm.CreateParameter();
                paramLocatie.ParameterName = "@locatie";
                paramLocatie.Value = entity.getLocatie();
                comm.Parameters.Add(paramLocatie);
            
                var paramLocuriDisponibile = comm.CreateParameter();
                paramLocuriDisponibile.ParameterName = "@locuriDisponibile";
                paramLocuriDisponibile.Value = entity.getLocuriDisponibile();
                comm.Parameters.Add(paramLocuriDisponibile);
            
                var paramLocuriVandute = comm.CreateParameter();
                paramLocuriVandute.ParameterName = "@locuriVandute";
                paramLocuriVandute.Value = entity.getLocuriVandute();
                comm.Parameters.Add(paramLocuriVandute);

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
            
                var result = comm.ExecuteNonQuery();
            }
        }

        public ICollection<Spectacol> GetAll()
        {
            IDbConnection con = DBUtils.getConnection(props);
            IList<Spectacol> list = new List<Spectacol>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Spectacole";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        Artist artist = artistRepo.FindById(dataR.GetInt32(2));
                        DateTime dateTime = DateTime.Parse(dataR.GetString(3));
                        String locatie = dataR.GetString(4);
                        int locuriDisponibile = dataR.GetInt32(5);
                        int locuriVandute = dataR.GetInt32(6);
                    
                        Spectacol spectacol =
                            new Spectacol(nume, artist, dateTime, locatie, locuriDisponibile, locuriVandute);
                    
                        spectacol.setId(id2);
                        list.Add(spectacol);
                    }
                }
            }
            return list;
        }

        public List<Spectacol> FilterByDay(DateTime data)
        {
            IDbConnection con = DBUtils.getConnection(props);
            List<Spectacol> list = new List<Spectacol>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Spectacole where data=@data";
                IDbDataParameter paramID = comm.CreateParameter();
                paramID.ParameterName = "@data";
                paramID.Value = data.ToString();
                comm.Parameters.Add(paramID);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        Artist artist = artistRepo.FindById(dataR.GetInt32(2));
                        DateTime dateTime = DateTime.Parse(dataR.GetString(3));
                        String locatie = dataR.GetString(4);
                        int locuriDisponibile = dataR.GetInt32(5);
                        int locuriVandute = dataR.GetInt32(6);
                    
                        Spectacol spectacol =
                            new Spectacol(nume, artist, dateTime, locatie, locuriDisponibile, locuriVandute);
                    
                        spectacol.setId(id2);
                        list.Add(spectacol);
                    }   
                }
            }
            return list;
        }
    }
}