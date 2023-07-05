using System;
using System.Collections;
using System.Collections.Generic;
using WindowsFormsApp1.domain;
using WindowsFormsApp1.repository;

namespace WindowsFormsApp1.service
{
    public class TransactionServices
    {
        private readonly IDictionary<string, string> props = new SortedList<string, string>();
        private ITransactionRepository _transactionRepository;
        private ISpectacolRepository _spectacolRepository;
        private ICasierRepository _casierRepository;

        public TransactionServices(IDictionary<string, string> props,ITransactionRepository transactionRepository, ISpectacolRepository spectacolRepository, ICasierRepository casierRepository)
        {
            this.props = props;
            _transactionRepository = transactionRepository;
            _spectacolRepository = spectacolRepository;
            _casierRepository = casierRepository;
        }

        public void AddTransaction(string cumparator, int locuri, int idSpectacol, int idCasier)
        {
            try
            {
                _transactionRepository.Save(new Transaction(cumparator,locuri,_spectacolRepository.FindById(idSpectacol),_casierRepository.FindById(idCasier)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteTransaction(int id)
        {
            try
            {
                _transactionRepository.Delete(_transactionRepository.FindById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void UpdateTransaction(int id, string cumparatorNou, int locuriNoi, int idSpectacolNou, int idCasierNou)
        {
            try
            {
                _transactionRepository.Update(id,new Transaction(cumparatorNou,locuriNoi,_spectacolRepository.FindById(idSpectacolNou),_casierRepository.FindById(idCasierNou)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ICollection<Transaction> GetAll()
        {
            return _transactionRepository.GetAll();
        }

        public List<Transaction> FilterByCasier(int idCasier)
        {
            return _transactionRepository.FilterByCasier(_casierRepository.FindById(idCasier));
        }

        public List<Transaction> FilterBySpectacol(int idSpectacol)
        {
            return _transactionRepository.FilterBySpectacol(_spectacolRepository.FindById(idSpectacol));
        }
    }
}