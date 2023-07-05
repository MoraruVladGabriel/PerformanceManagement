using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WindowsFormsApp1.domain;
using WindowsFormsApp1.repository;
using WindowsFormsApp1.repository.repoDB;

namespace WindowsFormsApp1.service
{
    public class SpectacolServices
    {
        private readonly IDictionary<string, string> props = new SortedList<string, string>();
        private ISpectacolRepository _spectacolRepository;
        private IArtistRepository _artistRepository;

        public SpectacolServices(IDictionary<string, string> props,ISpectacolRepository spectacolRepository, IArtistRepository artistRepository)
        {
            this.props = props;
            _spectacolRepository = spectacolRepository;
            _artistRepository = artistRepository;
        }

        public void AddSpectacol(string nume, int idArtist, DateTime data, string locatie, int locuriDisponibile,
            int locuriVandute)
        {
            try
            {
                _spectacolRepository.Save(new Spectacol(nume, _artistRepository.FindById(idArtist), data, locatie, locuriDisponibile, locuriVandute));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteSpectacol(int id)
        {
            try
            {
                _spectacolRepository.Delete(_spectacolRepository.FindById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void UpdateSpectacol(int id, string numeNou, int idArtistNou, DateTime dataNoua, string locatieNoua, int locuriDisponibileNoi, int locuriVanduteNoi)
        {
            try
            {
                _spectacolRepository.Update(id,new Spectacol(numeNou,_artistRepository.FindById(idArtistNou),dataNoua,locatieNoua,locuriDisponibileNoi,locuriVanduteNoi));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ICollection<Spectacol> GetAll()
        {
            return _spectacolRepository.GetAll();
        }

        public IEnumerable<Spectacol> FindAll()
        {
            return _spectacolRepository.FindAll();
        }

        public List<Spectacol> FilterByDay(DateTime data)
        {
            List<Spectacol> list = new List<Spectacol>();
            foreach (var spectacol in _spectacolRepository.FindAll())
            {
                if (spectacol.getData().Date.Equals(data.Date))
                {
                    list.Add(spectacol);
                }
            }

            return list;
        }

        public void cumparaBilete(int id, int numarLocuri)
        {
            try
            {
                Spectacol spectacolNou = new Spectacol();
                spectacolNou.setId(id);
                spectacolNou.setNume(_spectacolRepository.FindById(id).getNume());
                spectacolNou.setArtist(_spectacolRepository.FindById(id).getArtist());
                spectacolNou.setData(_spectacolRepository.FindById(id).getData());
                spectacolNou.setLocatie(_spectacolRepository.FindById(id).getLocatie());
                spectacolNou.setLocuriDisponibile(_spectacolRepository.FindById(id).getLocuriDisponibile()-numarLocuri);
                spectacolNou.setLocuriVandute(_spectacolRepository.FindById(id).getLocuriVandute()+numarLocuri);
                //_spectacolRepository.Update(id,spectacolNou);
                UpdateSpectacol(id,_spectacolRepository.FindById(id).getNume(),_spectacolRepository.FindById(id).getArtist().getId(),_spectacolRepository.FindById(id).getData(),_spectacolRepository.FindById(id).getLocatie(),spectacolNou.getLocuriDisponibile(),spectacolNou.getLocuriVandute());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Spectacol FindById(int id)
        {
            try
            {
                return this._spectacolRepository.FindById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}