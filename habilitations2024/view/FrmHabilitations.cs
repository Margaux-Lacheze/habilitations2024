using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using habilitations2024.controller;
using habilitations2024.model;
using MySql.Data.MySqlClient;

namespace habilitations2024.view
{
    public partial class FrmHabilitations : Form
    {
        /// <summary>
        /// Booléen pour savoir si une modification est demandée
        /// </summary>
        private Boolean enModifDev = false;

        /// <summary>
        /// Objet pour gérer la liste des développeurs
        /// </summary>
        private BindingSource bdgDeveloppeurs = new BindingSource();

        /// <summary>
        /// Objet pour gérer la liste des profils
        /// </summary>
        private BindingSource bdgProfils = new BindingSource();

        /// <summary>
        /// Contrôleur de la fenêtre
        /// </summary>
        private FrmHabilitationsController controller;

        /// <summary>
        /// Construction des composants graphiques et appel des autres initialisations
        /// </summary>
        public FrmHabilitations() 
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Création du contrôleur et remplissage des listes
        /// </summary>
        private void Init()
        {
            controller = new FrmHabilitationsController();
            RemplirListeDeveloppeurs();
            RemplirListeProfils();
            modifDev(false);
            modifPwd(false);
        }

        /// <summary>
        /// Affichage des développeurs
        /// </summary>
        private void RemplirListeDeveloppeurs()
        {
            List<Developpeur> lesDeveloppeurs = controller.GetLesDeveloppeurs();
            bdgDeveloppeurs.DataSource = lesDeveloppeurs;
            dgvDeveloppeurs.DataSource = bdgDeveloppeurs;
            dgvDeveloppeurs.Columns["iddeveloppeur"].Visible = false;
            dgvDeveloppeurs.Columns["pwd"].Visible = false;
            dgvDeveloppeurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Affichage des profils
        /// </summary>
        private void RemplirListeProfils()
        {
            List<Profil> lesProfils = controller.GetLesProfils();
            bdgProfils.DataSource = lesProfils;
            cbbProfil.DataSource = bdgProfils;
        }

        private void InitializeComponent()
        {
            this.gpbDev = new System.Windows.Forms.GroupBox();
            this.btnChgMdp = new System.Windows.Forms.Button();
            this.btnSuppr = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.dgvDeveloppeurs = new System.Windows.Forms.DataGridView();
            this.gpbAjoutDev = new System.Windows.Forms.GroupBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbProfil = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbChangeMdp = new System.Windows.Forms.GroupBox();
            this.btnAnnulerMdp = new System.Windows.Forms.Button();
            this.btnEnregistrerMdp = new System.Windows.Forms.Button();
            this.txtEncore = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMdp = new System.Windows.Forms.TextBox();
            this.gpbDev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeveloppeurs)).BeginInit();
            this.gpbAjoutDev.SuspendLayout();
            this.gpbChangeMdp.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbDev
            // 
            this.gpbDev.Controls.Add(this.btnChgMdp);
            this.gpbDev.Controls.Add(this.btnSuppr);
            this.gpbDev.Controls.Add(this.btnModifier);
            this.gpbDev.Controls.Add(this.dgvDeveloppeurs);
            this.gpbDev.Location = new System.Drawing.Point(12, 12);
            this.gpbDev.Name = "gpbDev";
            this.gpbDev.Size = new System.Drawing.Size(516, 279);
            this.gpbDev.TabIndex = 0;
            this.gpbDev.TabStop = false;
            this.gpbDev.Text = "les développeurs";
            // 
            // btnChgMdp
            // 
            this.btnChgMdp.Location = new System.Drawing.Point(169, 247);
            this.btnChgMdp.Name = "btnChgMdp";
            this.btnChgMdp.Size = new System.Drawing.Size(88, 23);
            this.btnChgMdp.TabIndex = 3;
            this.btnChgMdp.Text = "changer mdp";
            this.btnChgMdp.UseVisualStyleBackColor = true;
            this.btnChgMdp.Click += new System.EventHandler(this.btnChgMdp_Click);
            // 
            // btnSuppr
            // 
            this.btnSuppr.Location = new System.Drawing.Point(88, 247);
            this.btnSuppr.Name = "btnSuppr";
            this.btnSuppr.Size = new System.Drawing.Size(75, 23);
            this.btnSuppr.TabIndex = 2;
            this.btnSuppr.Text = "supprimer";
            this.btnSuppr.UseVisualStyleBackColor = true;
            this.btnSuppr.Click += new System.EventHandler(this.btnSuppr_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(7, 247);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(75, 23);
            this.btnModifier.TabIndex = 1;
            this.btnModifier.Text = "modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // dgvDeveloppeurs
            // 
            this.dgvDeveloppeurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeveloppeurs.Location = new System.Drawing.Point(6, 19);
            this.dgvDeveloppeurs.MultiSelect = false;
            this.dgvDeveloppeurs.Name = "dgvDeveloppeurs";
            this.dgvDeveloppeurs.ReadOnly = true;
            this.dgvDeveloppeurs.RowHeadersVisible = false;
            this.dgvDeveloppeurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeveloppeurs.Size = new System.Drawing.Size(504, 221);
            this.dgvDeveloppeurs.TabIndex = 0;
            // 
            // gpbAjoutDev
            // 
            this.gpbAjoutDev.Controls.Add(this.btnAnnuler);
            this.gpbAjoutDev.Controls.Add(this.btnEnregistrer);
            this.gpbAjoutDev.Controls.Add(this.label5);
            this.gpbAjoutDev.Controls.Add(this.cbbProfil);
            this.gpbAjoutDev.Controls.Add(this.label4);
            this.gpbAjoutDev.Controls.Add(this.txtTel);
            this.gpbAjoutDev.Controls.Add(this.txtMail);
            this.gpbAjoutDev.Controls.Add(this.label3);
            this.gpbAjoutDev.Controls.Add(this.txtPrenom);
            this.gpbAjoutDev.Controls.Add(this.label2);
            this.gpbAjoutDev.Controls.Add(this.txtNom);
            this.gpbAjoutDev.Controls.Add(this.label1);
            this.gpbAjoutDev.Location = new System.Drawing.Point(12, 311);
            this.gpbAjoutDev.Name = "gpbAjoutDev";
            this.gpbAjoutDev.Size = new System.Drawing.Size(516, 152);
            this.gpbAjoutDev.TabIndex = 1;
            this.gpbAjoutDev.TabStop = false;
            this.gpbAjoutDev.Text = "ajouter un développeur";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(88, 117);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 11;
            this.btnAnnuler.Text = "annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(6, 117);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(75, 23);
            this.btnEnregistrer.TabIndex = 10;
            this.btnEnregistrer.Text = "enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "profil";
            // 
            // cbbProfil
            // 
            this.cbbProfil.FormattingEnabled = true;
            this.cbbProfil.Location = new System.Drawing.Point(281, 81);
            this.cbbProfil.Name = "cbbProfil";
            this.cbbProfil.Size = new System.Drawing.Size(176, 21);
            this.cbbProfil.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "tel";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(281, 55);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(176, 20);
            this.txtTel.TabIndex = 6;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(281, 29);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(229, 20);
            this.txtMail.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "email";
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(55, 55);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(169, 20);
            this.txtPrenom.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "prénom";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(55, 29);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(169, 20);
            this.txtNom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "nom";
            // 
            // gpbChangeMdp
            // 
            this.gpbChangeMdp.Controls.Add(this.btnAnnulerMdp);
            this.gpbChangeMdp.Controls.Add(this.btnEnregistrerMdp);
            this.gpbChangeMdp.Controls.Add(this.txtEncore);
            this.gpbChangeMdp.Controls.Add(this.label7);
            this.gpbChangeMdp.Controls.Add(this.label6);
            this.gpbChangeMdp.Controls.Add(this.txtMdp);
            this.gpbChangeMdp.Location = new System.Drawing.Point(12, 469);
            this.gpbChangeMdp.Name = "gpbChangeMdp";
            this.gpbChangeMdp.Size = new System.Drawing.Size(516, 92);
            this.gpbChangeMdp.TabIndex = 2;
            this.gpbChangeMdp.TabStop = false;
            this.gpbChangeMdp.Text = "changer le mot de passe";
            // 
            // btnAnnulerMdp
            // 
            this.btnAnnulerMdp.Location = new System.Drawing.Point(88, 59);
            this.btnAnnulerMdp.Name = "btnAnnulerMdp";
            this.btnAnnulerMdp.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulerMdp.TabIndex = 5;
            this.btnAnnulerMdp.Text = "annuler";
            this.btnAnnulerMdp.UseVisualStyleBackColor = true;
            this.btnAnnulerMdp.Click += new System.EventHandler(this.btnAnnulerMdp_Click);
            // 
            // btnEnregistrerMdp
            // 
            this.btnEnregistrerMdp.Location = new System.Drawing.Point(6, 59);
            this.btnEnregistrerMdp.Name = "btnEnregistrerMdp";
            this.btnEnregistrerMdp.Size = new System.Drawing.Size(75, 23);
            this.btnEnregistrerMdp.TabIndex = 4;
            this.btnEnregistrerMdp.Text = "enregistrer";
            this.btnEnregistrerMdp.UseVisualStyleBackColor = true;
            this.btnEnregistrerMdp.Click += new System.EventHandler(this.btnEnregistrerMdp_Click);
            // 
            // txtEncore
            // 
            this.txtEncore.Location = new System.Drawing.Point(299, 32);
            this.txtEncore.Name = "txtEncore";
            this.txtEncore.PasswordChar = '*';
            this.txtEncore.Size = new System.Drawing.Size(196, 20);
            this.txtEncore.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "repeter mdp";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "mdp";
            // 
            // txtMdp
            // 
            this.txtMdp.Location = new System.Drawing.Point(40, 33);
            this.txtMdp.Name = "txtMdp";
            this.txtMdp.PasswordChar = '*';
            this.txtMdp.Size = new System.Drawing.Size(169, 20);
            this.txtMdp.TabIndex = 0;
            // 
            // FrmHabilitations
            // 
            this.ClientSize = new System.Drawing.Size(540, 572);
            this.Controls.Add(this.gpbChangeMdp);
            this.Controls.Add(this.gpbAjoutDev);
            this.Controls.Add(this.gpbDev);
            this.Name = "FrmHabilitations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Habilitations";
            this.gpbDev.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeveloppeurs)).EndInit();
            this.gpbAjoutDev.ResumeLayout(false);
            this.gpbAjoutDev.PerformLayout();
            this.gpbChangeMdp.ResumeLayout(false);
            this.gpbChangeMdp.PerformLayout();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Modification d'un développeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvDeveloppeurs.SelectedRows.Count > 0)
            {
                modifDev(true);
                Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
                txtNom.Text = developpeur.Nom;
                txtPrenom.Text = developpeur.Prenom;
                txtTel.Text = developpeur.Tel;
                txtMail.Text = developpeur.Mail;
                cbbProfil.SelectedIndex = cbbProfil.FindStringExact(developpeur.Profil.Nom);
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
            }
        }

        /// <summary>
        /// Suppression d'un développeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuppr_Click(object sender, EventArgs e)
        {
            if(dgvDeveloppeurs.SelectedRows.Count > 0)
            {
                Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
                if (MessageBox.Show("Voulez-vous vraiment supprimer " + developpeur.Nom + " " + developpeur.Prenom + " ?", "Confirmation de suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    controller.DelDeveloppeur(developpeur);
                    RemplirListeDeveloppeurs();
                }
            }
        }


        /// <summary>
        /// Modification ou ajout d'un développeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if(!txtNom.Text.Equals("") && !txtPrenom.Text.Equals("") && !txtTel.Text.Equals("") && !txtMail.Text.Equals("") && cbbProfil.SelectedIndex != -1)
            {
                Profil profil = (Profil)bdgProfils.List[bdgProfils.Position];
                if (enModifDev)
                {
                    Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
                    developpeur.Nom = txtNom.Text;
                    developpeur.Prenom = txtPrenom.Text;
                    developpeur.Tel = txtTel.Text;
                    developpeur.Mail = txtMail.Text;
                    developpeur.Profil = profil;
                    controller.UpdateDeveloppeur(developpeur);
                }
                else
                {
                    Developpeur developpeur = new Developpeur(0, txtNom.Text, txtPrenom.Text, txtTel.Text, txtMail.Text, profil);
                    controller.AddDeveloppeur(developpeur);
                }
                RemplirListeDeveloppeurs();
                modifDev(false);
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis", "Information");
            }
        }

        /// <summary>
        /// Gestion de l'affichage selon si on modifie ou ajoute un développeur
        /// </summary>
        /// <param name="modif"></param>
        private void modifDev(Boolean modif)
        {
            enModifDev = modif;
            gpbDev.Enabled = !modif;
            if (modif)
            {
                gpbAjoutDev.Text = "modifier un développeur";
            }
            else
            {
                gpbAjoutDev.Text = "ajouter un développeur";
                txtNom.Text = "";
                txtPrenom.Text = "";
                txtTel.Text = "";
                txtMail.Text = "";
                cbbProfil.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Modification du mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChgMdp_Click(object sender, EventArgs e)
        {
            if (dgvDeveloppeurs.SelectedRows.Count > 0)
            {
                modifPwd(true);
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
            }
        }

        /// <summary>
        /// Enregistrement d'un nouveau mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnregistrerMdp_Click(object sender, EventArgs e)
        {
            if(!txtMdp.Text.Equals("") && !txtEncore.Text.Equals("") && txtMdp.Text.Equals(txtEncore.Text))
            {
                Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
                developpeur.Pwd = txtMdp.Text;
                controller.UpdatePwd(developpeur);
                modifPwd(false);
            }
            else
            {
                MessageBox.Show("Les deux zones doivent être remplies et avoir un contenu identique", "Information");
            }
        }

        /// <summary>
        /// Gestion de l'affichage si on modifie le mot de passe
        /// </summary>
        /// <param name="modif"></param>
        private void modifPwd(Boolean modif)
        {
            gpbChangeMdp.Enabled = modif;
            gpbDev.Enabled = !modif;
            gpbAjoutDev.Enabled = !modif;
            txtMdp.Text = "";
            txtEncore.Text = "";
        }

        /// <summary>
        /// Annulation du changement de mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnulerMdp_Click(object sender, EventArgs e)
        {
            modifPwd(false);
        }

        /// <summary>
        /// Annulation de l'ajout ou de la modification d'un développeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment annuler ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modifDev(false);
            }
        }
    }
}
