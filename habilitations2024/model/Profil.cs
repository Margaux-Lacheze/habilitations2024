using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model
{
    /// <summary>
    /// Classe métier liée à la table profil
    /// </summary>
    public class Profil
    {
        /// <summary>
        /// Constructeur valorisant les propriétés
        /// </summary>
        /// <param name="idProfil"></param>
        /// <param name="nom"></param>
        public Profil(int idProfil, string nom)
        {
            this.IdProfil = idProfil;
            this.Nom = nom;
        }

        public int IdProfil { get; }
        public string Nom { get; }

        /// <summary>
        /// Redéfinition de la fonction ToString pour retourner juste le nom du profil
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Nom;
        }
    }
}
