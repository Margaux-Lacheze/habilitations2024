using habilitations2024.controller;
using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace habilitations2024.view
{
    public partial class FrmAuthentification : Form
    {
        /// <summary>
        /// Contrôleur de la frame Authentification
        /// </summary>
        private FrmAuthentificationController controller;

        /// <summary>
        /// Construction des composants graphiques et appel des autres initialisations
        /// </summary>
        public FrmAuthentification()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Initialisation : création du contrôleur
        /// </summary>
        private void Init()
        {
            controller = new FrmAuthentificationController();
        }


        private void btnConnexion_Click(object sender, EventArgs e)
        {
            String nom = txtNom.Text;
            String prenom = txtPrenom.Text;
            String pwd = txtPwd.Text;
            if (String.IsNullOrEmpty(nom) || String.IsNullOrEmpty(prenom) || String.IsNullOrEmpty(pwd) )
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Information");
            }
            else
            {
                Admin admin = new Admin(nom, prenom, pwd);
                if (controller.ControleAuthentification(admin))
                {
                    FrmHabilitations frm = new FrmHabilitations();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Authentification incorrecte ou vous n'êtes pas admin", "Alerte");
                }
            }
        }
    }
}
