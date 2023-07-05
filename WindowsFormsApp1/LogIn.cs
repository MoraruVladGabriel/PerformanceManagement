using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.domain;
using WindowsFormsApp1.repository;
using WindowsFormsApp1.repository.repoDB;
using WindowsFormsApp1.service;

namespace WindowsFormsApp1
{
    public partial class LogIn : Form
    {
        
        private readonly ICasierRepository _casierRepository;
        private readonly ISpectacolRepository _spectacolRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IArtistRepository _artistRepository;
        
        private readonly SpectacolServices _spectacolServices;
        private readonly TransactionServices _transactionServices;
        private readonly ArtistServices _artistSer;
        private readonly CasierServices _casierServices;

        private readonly string connectionString =
            @"Data Source=C:\Users\morar\Desktop\proiectMPPC#\proiect\festival.db;Version=3;New=True;Compress=True;";
        public LogIn()
        {
            IDictionary<string, string> props = new SortedList<string, string>();
            props.Add("ConnectionString",connectionString);
            
            _artistRepository = new ArtistDBRepository(props);
            _artistSer = new ArtistServices(props, _artistRepository);
            
            //Console.WriteLine(_artistRepository.FindById(1).ToString());
            
            _casierRepository = new CasierDBRepository(props);
            _casierServices = new CasierServices(props, _casierRepository);
            
            _spectacolRepository = new SpectacolDBRepository(props, _artistRepository);
            _spectacolServices = new SpectacolServices(props, _spectacolRepository, _artistRepository);

            _transactionRepository = new TransactionDBRepository(_casierRepository, _spectacolRepository, props);
            _transactionServices =
                new TransactionServices(props, _transactionRepository, _spectacolRepository, _casierRepository);
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //_spectacolServices.UpdateSpectacol(1,"mmm",2,DateTime.Now, "mmm",120,100);
            //_spectacolRepository.Update(1,new Spectacol("mmm",_artistRepository.FindById(2),DateTime.Now, "mmm",120,100));
            //Console.WriteLine(_artistRepository.FindById(1).ToString());
            //Console.WriteLine(_casierRepository.FindById(1).getNume());
            Console.WriteLine(textBox1.Text);
            if (_casierServices.GetCasierByEmail(textBox1.Text) != null)
            {
                Hide();
                var l = new Form1(_spectacolServices,_transactionServices,_artistSer,_casierServices);
                l.ShowDialog();
            }
            else
            {
                MessageBox.Show("Date Invalide!");
            }
        }
    }
}