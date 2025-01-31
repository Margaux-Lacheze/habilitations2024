﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using habilitations2024.model;

namespace habilitations2024.dal
{
    /// <summary>
    /// Classe permettant de gérer les demandes concernant les développeurs
    /// </summary>
    public class DeveloppeurAccess
    {
        // Instance unique de l'accès aux données
        private readonly Access access = null;

        /// <summary>
        /// Constructeur pour créer l'accès aux données;
        /// </summary>
        public DeveloppeurAccess() 
        {
            access = Access.GetInstance();
        }

        public List<Developpeur> GetlesDeveloppeurs()
        {
            // Création en local d'une liste de développeurs
            List<Developpeur> lesDeveloppeurs = new List<Developpeur>();

            // Récupération des développeurs via l'objet Manager de la classe Access
            if (access.Manager != null)
            {
                string req = "select d.iddeveloppeur as iddeveloppeur, d.nom as nom, d.prenom as prenom, d.tel as tel, d.mail as mail, p.idprofil as idprofil, p.nom as profil ";
                req += "from developpeur d join profil p on (d.idprofil = p.idprofil) ";
                req += "order by nom, prenom";
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        foreach (Object[] record in records)
                        {
                            Profil profil = new Profil((int)record[5], (string)record[6]);
                            Developpeur developpeur = new Developpeur((int)record[0], (string)record[1], (string)record[2], (string)record[3], (string)record[4], profil);
                            lesDeveloppeurs.Add(developpeur);
                        }
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return lesDeveloppeurs;
        }
        
        /// <summary>
        /// Demande de suppression d'un développeur
        /// </summary>
        /// <param name="developpeur">objet développeur à supprimer</param>
        public void DelDeveloppeur(Developpeur developpeur) 
        { 
            if (access.Manager != null)
            {
                string req = "delete from developpeur where iddeveloppeur = @iddeveloppeur;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@iddeveloppeur", developpeur.Iddeveloppeur);
                try 
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Demande d'ajout d'un développeur
        /// </summary>
        /// <param name="developpeur">objet développeur à ajouter</param>
        public void AddDeveloppeur(Developpeur developpeur)
        {
            if (access.Manager != null)
            {
                string req = "insert into developpeur(nom, prenom, tel, mail, pwd, idprofil)";
                req += "values (@nom, @prenom, @tel, @mail, SHA2(@pwd, 256), @idprofil);";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@nom", developpeur.Nom);
                parameters.Add("@prenom", developpeur.Prenom);
                parameters.Add("@tel", developpeur.Tel);
                parameters.Add("@mail", developpeur.Mail);
                parameters.Add("@pwd", developpeur.Nom);
                parameters.Add("@idprofil", developpeur.Profil.IdProfil);

                try 
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Demande de modification d'un développeur
        /// </summary>
        /// <param name="developpeur">objet développeur à modifier</param>
        public void UpdateDeveloppeur(Developpeur developpeur)
        {
            if (access.Manager != null)
            {
                string req = "update developpeur set nom = @nom, prenom = @prenom, tel = @tel, mail = @mail, idprofil = @idprofil where iddeveloppeur = @iddeveloppeur;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idDeveloppeur", developpeur.Iddeveloppeur);
                parameters.Add("@nom", developpeur.Nom);
                parameters.Add("@prenom", developpeur.Prenom);
                parameters.Add("@tel", developpeur.Tel);
                parameters.Add("@mail", developpeur.Mail);
                parameters.Add("@idprofil", developpeur.Profil.IdProfil);
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Demande de modification du mot de passe
        /// </summary>
        /// <param name="developpeur">objet développeur avec nouveau mot de passe</param>
        public void UpdatePwd(Developpeur developpeur)
        {
            if (access.Manager != null)
            {
                string req = "update developpeur set pwd = SHA2(@pwd, 256) where iddeveloppeur = @iddeveloppeur;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idDeveloppeur", developpeur.Iddeveloppeur);
                parameters.Add("@pwd", developpeur.Pwd);
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }

    }
}
