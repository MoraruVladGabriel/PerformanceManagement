using System;
using System.Collections.Generic;
using System.Data;
using WindowsFormsApp1.domain;
using WindowsFormsApp1.utils;

namespace WindowsFormsApp1.repository.repoDB
{
    public class TransactionDBRepository : ITransactionRepository
    {
        private ICasierRepository casierRepo;

        private ISpectacolRepository spectacolRepo;
        
        IDictionary<String, string> props;

        public TransactionDBRepository(ICasierRepository casierRepo, ISpectacolRepository spectacolRepo, IDictionary<string, string> props)
        {
            this.casierRepo = casierRepo;
            this.spectacolRepo = spectacolRepo;
            this.props = props;
        }

        public Transaction FindById(int id)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Cumparari where id=@id";
                IDbDataParameter paramID = comm.CreateParameter();
                paramID.ParameterName = "@id";
                paramID.Value = id;
                comm.Parameters.Add(paramID);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String cumparator = dataR.GetString(1);
                        int locuri = dataR.GetInt32(2);
                        int spectacol = dataR.GetInt32(3);
                        int casier = dataR.GetInt32(4);
                        Transaction cumparare = new Transaction(cumparator, locuri, spectacolRepo.FindById(spectacol),
                            casierRepo.FindById(casier));
                        cumparare.setId(id2);
                        return cumparare;
                    }   
                }
            }
            return null;
        }

        public IEnumerable<Transaction> FindAll()
        {
            IDbConnection con = DBUtils.getConnection(props);
            IList<Transaction> list = new List<Transaction>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Cumparari";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String cumparator = dataR.GetString(1);
                        int locuri = dataR.GetInt32(2);
                        int spectacol = dataR.GetInt32(3);
                        int casier = dataR.GetInt32(4);
                        Transaction cumparare = new Transaction(cumparator, locuri, spectacolRepo.FindById(spectacol),
                            casierRepo.FindById(casier));
                        cumparare.setId(id2);
                        list.Add(cumparare);
                    }
                }
            }
            return list;
        }

        public void Save(Transaction entity)
        {
            var con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Cumparari (cumparator,locuri,spectacol,casier) values (@cumparator,@locuri,@spectacol,@casier)";
            
                var paramCumparator = comm.CreateParameter();
                paramCumparator.ParameterName = "@cumparator";
                paramCumparator.Value = entity.getCumparator();
                comm.Parameters.Add(paramCumparator);

                var paramLoc = comm.CreateParameter();
                paramLoc.ParameterName = "@locuri";
                paramLoc.Value = entity.getLocuri();
                comm.Parameters.Add(paramLoc);
            
                var paramSpectacol = comm.CreateParameter();
                paramSpectacol.ParameterName = "@spectacol";
                paramSpectacol.Value = entity.getSpectacol().getId();
                comm.Parameters.Add(paramSpectacol);
            
                var paramCasier = comm.CreateParameter();
                paramCasier.ParameterName = "@casier";
                paramCasier.Value = entity.getCasier().getId();
                comm.Parameters.Add(paramCasier);

                var result = comm.ExecuteNonQuery();
            }
        }

        public void Delete(Transaction entity)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Cumparari where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.getId();
                comm.Parameters.Add(paramId);
                var result = comm.ExecuteNonQuery();
            }
        }

        public void Update(int id, Transaction entity)
        {
            IDbConnection con = DBUtils.getConnection(props);

            using (var  comm = con.CreateCommand())
            {
                comm.CommandText = "update Cumparari set cumparator=@cumparator, locuri=@locuri, spectacol=@spectacol, casier=@casier where id=@id";
            
                var paramCumparator = comm.CreateParameter();
                paramCumparator.ParameterName = "@cumparator";
                paramCumparator.Value = entity.getCumparator();
                comm.Parameters.Add(paramCumparator);

                var paramLoc = comm.CreateParameter();
                paramLoc.ParameterName = "@locuri";
                paramLoc.Value = entity.getLocuri();
                comm.Parameters.Add(paramLoc);
            
                var paramSpectacol = comm.CreateParameter();
                paramSpectacol.ParameterName = "@spectacol";
                paramSpectacol.Value = entity.getSpectacol().getId();
                comm.Parameters.Add(paramSpectacol);
            
                var paramCasier = comm.CreateParameter();
                paramCasier.ParameterName = "@casier";
                paramCasier.Value = entity.getCasier().getId();
                comm.Parameters.Add(paramCasier);

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
            
                var result = comm.ExecuteNonQuery();
            }
        }

        public ICollection<Transaction> GetAll()
        {
            IDbConnection con = DBUtils.getConnection(props);
            IList<Transaction> list = new List<Transaction>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Cumparari";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String cumparator = dataR.GetString(1);
                        int locuri = dataR.GetInt32(2);
                        int spectacol = dataR.GetInt32(3);
                        int casier = dataR.GetInt32(4);
                        Transaction cumparare = new Transaction(cumparator, locuri, spectacolRepo.FindById(spectacol),
                            casierRepo.FindById(casier));
                        cumparare.setId(id2);
                        list.Add(cumparare);
                    }
                }
            }
            return list;
        }

        public List<Transaction> FilterByCasier(Casier casierCautat)
        {
            IDbConnection con = DBUtils.getConnection(props);
            List<Transaction> list = new List<Transaction>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Cumparari where casier=@casier";
                IDbDataParameter paramID = comm.CreateParameter();
                paramID.ParameterName = "@casier";
                paramID.Value = casierCautat.getId();
                comm.Parameters.Add(paramID);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String cumparator = dataR.GetString(1);
                        int locuri = dataR.GetInt32(2);
                        int spectacol = dataR.GetInt32(3);
                        int casier = dataR.GetInt32(4);
                        Transaction cumparare = new Transaction(cumparator, locuri, spectacolRepo.FindById(spectacol),
                            casierRepo.FindById(casier));
                        cumparare.setId(id2);
                        list.Add(cumparare);
                    }   
                }
            }
            return list;
        }

        public List<Transaction> FilterBySpectacol(Spectacol spectacolCautat)
        {
            IDbConnection con = DBUtils.getConnection(props);
            List<Transaction> list = new List<Transaction>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Cumparari where spectacol=@spectacol";
                IDbDataParameter paramID = comm.CreateParameter();
                paramID.ParameterName = "@spectacol";
                paramID.Value = spectacolCautat.getId();
                comm.Parameters.Add(paramID);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id2 = dataR.GetInt32(0);
                        String cumparator = dataR.GetString(1);
                        int locuri = dataR.GetInt32(2);
                        int spectacol = dataR.GetInt32(3);
                        int casier = dataR.GetInt32(4);
                        Transaction cumparare = new Transaction(cumparator, locuri, spectacolRepo.FindById(spectacol),
                            casierRepo.FindById(casier));
                        cumparare.setId(id2);
                        list.Add(cumparare);
                    }   
                }
            }
            return list;
        }
    }
}