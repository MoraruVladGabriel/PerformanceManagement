using System;
using System.Collections.Generic;
using System.Data;
using WindowsFormsApp1.domain;
using WindowsFormsApp1.utils;

namespace WindowsFormsApp1.repository.repoDB
{
    public class ArtistDBRepository : IArtistRepository
    {
        IDictionary<String, string> props;

        public ArtistDBRepository(IDictionary<String, string> props)
        {
            this.props = props;
        }

        public Artist FindById(int id)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Artisti where id=@id";
                IDbDataParameter paramID = comm.CreateParameter();
                paramID.ParameterName = "@id";
                paramID.Value = id;
                comm.Parameters.Add(paramID);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        string nume = dataR.GetString(1);
                        string tip = dataR.GetString(2);
                        Artist artist = new Artist(nume, tip);
                        artist.setId(id2);
                        return artist;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Artist> FindAll()
        {
            IDbConnection con = DBUtils.getConnection(props);
            IList<Artist> list = new List<Artist>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Artisti";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        string nume = dataR.GetString(1);
                        string tip = dataR.GetString(2);
                        Artist artist = new Artist(nume, tip);
                        artist.setId(id);
                        list.Add(artist);
                    }
                }
            }

            return list;
        }

        public void Save(Artist entity)
        {
            var con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Artisti(nume,tip) values (@nume,@tip)";
                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.getNume();
                comm.Parameters.Add(paramNume);

                var paramTip = comm.CreateParameter();
                paramTip.ParameterName = "@tip";
                paramTip.Value = entity.getTip();
                comm.Parameters.Add(paramTip);

                var result = comm.ExecuteNonQuery();
            }
        }

        public void Delete(Artist entity)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Artisti where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.getId();
                comm.Parameters.Add(paramId);
                var result = comm.ExecuteNonQuery();
            }
        }

        public void Update(int id, Artist entity)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var  comm = con.CreateCommand())
            {
                comm.CommandText = "update Artisti set nume=@nume, tip=@tip where id=@id";
                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.getNume();
                comm.Parameters.Add(paramNume);

                var paramTip = comm.CreateParameter();
                paramTip.ParameterName = "@tip";
                paramTip.Value = entity.getTip();
                comm.Parameters.Add(paramTip);

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
            
                var result = comm.ExecuteNonQuery();
            }
        }

        public ICollection<Artist> GetAll()
        {
            IDbConnection con = DBUtils.getConnection(props);
            IList<Artist> list = new List<Artist>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Artisti";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        string nume = dataR.GetString(1);
                        string tip = dataR.GetString(2);
                        Artist artist = new Artist(nume, tip);
                        artist.setId(id);
                        list.Add(artist);
                    }
                }
            }

            return list;
        }

        public List<Artist> FilterByTip(string tip)
        {
            IDbConnection con = DBUtils.getConnection(props);
            List<Artist> list = new List<Artist>();


            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Artisti where tip=@tip";
                IDbDataParameter paramID = comm.CreateParameter();
                paramID.ParameterName = "@tip";
                paramID.Value = tip;
                comm.Parameters.Add(paramID);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        string nume = dataR.GetString(1);
                        string tip2 = dataR.GetString(2);
                        Artist artist = new Artist(nume, tip2);
                        artist.setId(id2);
                        list.Add(artist);
                    }
                }
            }
            return list;
        }
    }
}