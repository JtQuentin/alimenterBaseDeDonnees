using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace alimenterBaseDeDonnees
{
    public partial class Traitement : Form
    {
        public Traitement()
        {
            InitializeComponent();
        }

        private void btParcourir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog parcourir = new FolderBrowserDialog();
            parcourir.ShowDialog();
            tbRepertoireFichiers.Text = parcourir.SelectedPath;
            string[] filepaths = Directory.GetFiles(parcourir.SelectedPath, "*.csv", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < filepaths.Length; i++)
            {
                clbFichierCsv.Items.Add(filepaths[i].Replace(parcourir.SelectedPath + "\\", " "));
            }
        }

        private void Traitement_Load(object sender, EventArgs e)
        {
            string sConnexion;
            MySqlConnection connexion;
            sConnexion = "user=admin;password=siojjr;database=rallyelecture;host=172.16.0.162";
            connexion = new MySqlConnection(sConnexion);
            connexion.Open();
            string sSelectClasse = "select niveauScolaire from niveau";
            MySqlCommand SelectClasse = new MySqlCommand(sSelectClasse, connexion);
            MySqlDataReader reader = SelectClasse.ExecuteReader();
            int i = 0;
            while(reader.Read())
            {
                cbClasse.Items.Add(reader[i]);
                i++;
            }
            connexion.Close();
        }

        private void btIntegration_Click(object sender, EventArgs e)
        {
            
        }

        static void NouvelleClasse(string nomFichierCsv, int idClasse, bool remiseABlanc)
        {

        }

        private void cbClasse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
