using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.repository;
using WindowsFormsApp1.repository.repoDB;
using WindowsFormsApp1.service;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // private readonly IArtistRepository _artistRepository;
        // private readonly ICasierRepository _casierRepository;
        // private readonly ISpectacolRepository _spectacolRepository;
        // private readonly ITransactionRepository _transactionRepository;
        
        private readonly SpectacolServices _spectacolServices;
        private readonly TransactionServices _transactionServices;
        private readonly ArtistServices _artistSer;
        private readonly CasierServices _casierServices;
        
        private readonly string connectionString =
            @"Data Source=C:\Users\morar\Desktop\proiectMPPC#\proiect\festival.db;Version=3;New=True;Compress=True;";
        // public Form1()
        // {
        //     IDictionary<string, string> props = new SortedList<string, string>();
        //     props.Add("ConnectionString",connectionString);
        //     
        //     _casierRepository = new CasierDBRepository(props);
        //     _casierServices = new CasierServices(props, _casierRepository);
        //
        //     _artistRepository = new ArtistDBRepository(props);
        //     _artistSer = new ArtistServices(props, _artistRepository);
        //
        //     _spectacolRepository = new SpectacolDBRepository(props, _artistRepository);
        //     _spectacolServices = new SpectacolServices(props, _spectacolRepository, _artistRepository);
        //
        //     _transactionRepository = new TransactionDBRepository(_casierRepository, _spectacolRepository, props);
        //     _transactionServices =
        //         new TransactionServices(props, _transactionRepository, _spectacolRepository, _casierRepository);
        //     
        //     InitializeComponent();
        // }

        public Form1(SpectacolServices spectacolServices, TransactionServices transactionServices, ArtistServices artistSer, CasierServices casierServices)
        {
            _spectacolServices = spectacolServices;
            _transactionServices = transactionServices;
            _artistSer = artistSer;
            _casierServices = casierServices;
            InitializeComponent();
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            DateTime data = DateTime.Parse(textBox1.Text);
            foreach (var s in _spectacolServices.FilterByDay(data))
            {
                var rowId = dataGridView2.Rows.Add();
                var row = dataGridView2.Rows[rowId];
                //row.Cells["Column6"].Value = s.getArtist().getNume();
                row.Cells["Column7"].Value = s.getLocatie();
                row.Cells["Column8"].Value = s.getData().ToString("HH:mm");
                row.Cells["Column9"].Value = s.getLocuriDisponibile();
            }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            _transactionServices.AddTransaction(textBoxCumparator.Text,int.Parse(textBoxNrLocuri.Text),int.Parse(textBoxIdSpectacol.Text),int.Parse(textBoxIdCasier.Text));
            _spectacolServices.cumparaBilete(int.Parse(textBoxIdSpectacol.Text),int.Parse(textBoxNrLocuri.Text));
            foreach (var s in _spectacolServices.FindAll())
            {
                var rowId = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[rowId];
                row.Cells["Column1"].Value = s.getNume();
                row.Cells["Column2"].Value = s.getData().ToString();
                row.Cells["Column3"].Value = s.getLocatie();
                row.Cells["Column4"].Value = s.getLocuriDisponibile();
                row.Cells["Column5"].Value = s.getLocuriVandute();
            }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Hide();
            var l = new LogIn();
            l.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var s in _spectacolServices.FindAll())
            {
                var rowId = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[rowId];
                row.Cells["Column1"].Value = s.getNume();
                row.Cells["Column2"].Value = s.getData().ToString();
                row.Cells["Column3"].Value = s.getLocatie();
                row.Cells["Column4"].Value = s.getLocuriDisponibile();
                row.Cells["Column5"].Value = s.getLocuriVandute();
            }
            
        }
    }
}