using System;
using System.Collections;
using System.Collections.Generic;
using WindowsFormsApp1.domain;
using WindowsFormsApp1.repository;

namespace WindowsFormsApp1.service
{
    public class CasierServices
    {
        private readonly IDictionary<string, string> props = new SortedList<string, string>();
        private ICasierRepository _casierRepository;

        public CasierServices(IDictionary<string, string> props,ICasierRepository casierRepository)
        {
            this.props = props;
            _casierRepository = casierRepository;
        }

        public void AddCasier(string nume, string parola, string email, string oficiu)
        {
            try
            {
                _casierRepository.Save(new Casier(nume,parola,email,oficiu));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteCasier(int id)
        {
            try
            {
                _casierRepository.Delete(_casierRepository.FindById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void UpdateCasier(int id, string numeNou, string parolaNoua, string emailNou, string oficiuNou)
        {
            try
            {
                _casierRepository.Update(id,new Casier(numeNou,parolaNoua,emailNou,oficiuNou));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ICollection<Casier> GetAll()
        {
            return _casierRepository.GetAll();
        }

        public List<Casier> FilterByOficiu(string oficiuCautat)
        {
            return _casierRepository.FilterByOficiu(oficiuCautat);
        }

        public Casier GetCasierByEmail(string emailCautat)
        {
            return _casierRepository.GetCasierByEmail(emailCautat);
        }
    }
}