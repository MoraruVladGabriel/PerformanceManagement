using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using WindowsFormsApp1.domain;
using WindowsFormsApp1.repository;

namespace WindowsFormsApp1.service
{
    public class ArtistServices
    {
        private readonly IDictionary<string, string> props = new SortedList<string, string>();
        private IArtistRepository _artistRepository;

        public ArtistServices(IDictionary<string,string> props, IArtistRepository artistRepository)
        {
            this.props = props;
            _artistRepository = artistRepository;
        }

        public void AddArtist(string nume, string tip)
        {
            try{
                _artistRepository.Save(new Artist(nume, tip));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteArtist(int id)
        {
            try
            {
                _artistRepository.Delete(_artistRepository.FindById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void UpdateArtist(int id, string numeNou, string tipNou)
        {
            try
            {
                _artistRepository.Update(id, new Artist(numeNou,tipNou));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Artist> FilterByTip(string tipCautat)
        {
            return _artistRepository.FilterByTip(tipCautat);
        }

        public ICollection<Artist> GetAll()
        {
            return _artistRepository.GetAll();
        }
    }
}