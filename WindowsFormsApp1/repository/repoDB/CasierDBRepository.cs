using System;
using System.Collections.Generic;
using System.Data;
using WindowsFormsApp1.domain;
using WindowsFormsApp1.utils;

namespace WindowsFormsApp1.repository.repoDB
{
    public class CasierDBRepository : ICasierRepository
    {
        IDictionary<String, string> props;

        public CasierDBRepository(IDictionary<String, string> props)
        {
            this.props = props;
        }
        
        public Casier FindById(int id)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Casieri where id=@id";
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
                        String parola = dataR.GetString(2);
                        String email = dataR.GetString(3);
                        String oficiu = dataR.GetString(4);
                        Casier casier = new Casier(nume, parola, email, oficiu);
                        casier.setId(id2);
                        return casier;
                    }   
                }
            }
            return null;
        }

        public IEnumerable<Casier> FindAll()
        {
            IDbConnection con = DBUtils.getConnection(props);
            IList<Casier> list = new List<Casier>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Casieri";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String parola = dataR.GetString(2);
                        String email = dataR.GetString(3);
                        String oficiu = dataR.GetString(4);
                        Casier casier = new Casier(nume, parola, email, oficiu);
                        casier.setId(id2);
                        list.Add(casier);
                    }
                }
            }
            return list;
        }

        public void Save(Casier entity)
        {
            var con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Casieri (nume,parola,email,oficiu) values (@nume,@parola,@email,@oficiu)";
                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.getNume();
                comm.Parameters.Add(paramNume);

                var paramParola = comm.CreateParameter();
                paramParola.ParameterName = "@parola";
                paramParola.Value = entity.getParola();
                comm.Parameters.Add(paramParola);
            
                var paramEmail = comm.CreateParameter();
                paramEmail.ParameterName = "@email";
                paramEmail.Value = entity.getEmail();
                comm.Parameters.Add(paramEmail);
            
                var paramOficiu = comm.CreateParameter();
                paramOficiu.ParameterName = "@oficiu";
                paramOficiu.Value = entity.getOficiu();
                comm.Parameters.Add(paramOficiu);

                var result = comm.ExecuteNonQuery();
            }
        }

        public void Delete(Casier entity)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Casieri where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.getId();
                comm.Parameters.Add(paramId);
                var result = comm.ExecuteNonQuery();
            }
        }

        public void Update(int id, Casier entity)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var  comm = con.CreateCommand())
            {
                comm.CommandText = "update Casieri set nume=@nume, parola=@parola, email=@email, oficiu=@oficiu where id=@id";
                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.getNume();
                comm.Parameters.Add(paramNume);

                var paramParola = comm.CreateParameter();
                paramParola.ParameterName = "@parola";
                paramParola.Value = entity.getParola();
                comm.Parameters.Add(paramParola);
            
                var paramEmail = comm.CreateParameter();
                paramEmail.ParameterName = "@email";
                paramEmail.Value = entity.getEmail();
                comm.Parameters.Add(paramEmail);
            
                var paramOficiu = comm.CreateParameter();
                paramOficiu.ParameterName = "@oficiu";
                paramOficiu.Value = entity.getOficiu();
                comm.Parameters.Add(paramOficiu);

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
            
                var result = comm.ExecuteNonQuery();
            }
        }

        public ICollection<Casier> GetAll()
        {
            IDbConnection con = DBUtils.getConnection(props);
            IList<Casier> list = new List<Casier>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Casieri";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String parola = dataR.GetString(2);
                        String email = dataR.GetString(3);
                        String oficiu = dataR.GetString(4);
                        Casier casier = new Casier(nume, parola, email, oficiu);
                        casier.setId(id2);
                        list.Add(casier);
                    }
                }
            }
            return list;
        }

        public List<Casier> FilterByOficiu(string oficiuCautat)
        {
            IDbConnection con = DBUtils.getConnection(props);
            List<Casier> list = new List<Casier>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Casieri where oficiu=@oficiu";
                IDbDataParameter paramID = comm.CreateParameter();
                paramID.ParameterName = "@oficiu";
                paramID.Value = oficiuCautat;
                comm.Parameters.Add(paramID);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String parola = dataR.GetString(2);
                        String email = dataR.GetString(3);
                        String oficiu = dataR.GetString(4);
                        Casier casier = new Casier(nume, parola, email, oficiu);
                        casier.setId(id2);
                        list.Add(casier);
                    }   
                }
            }
            return list;
        }

        public Casier GetCasierByEmail(string emailCautat)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Casieri where email=@email";
                IDbDataParameter paramID = comm.CreateParameter();
                paramID.ParameterName = "@email";
                paramID.Value = emailCautat;
                comm.Parameters.Add(paramID);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String parola = dataR.GetString(2);
                        String email = dataR.GetString(3);
                        String oficiu = dataR.GetString(4);
                        Casier casier = new Casier(nume, parola, email, oficiu);
                        casier.setId(id2);
                        return casier;
                    }   
                }
            }
            return null;
        }
    }
}