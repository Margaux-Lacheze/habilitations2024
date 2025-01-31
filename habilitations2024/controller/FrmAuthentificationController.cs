using habilitations2024.dal;
using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.controller
{
    /// <summary>
    /// Contrôleur de la frame authentification
    /// </summary>
    public class FrmAuthentificationController
    {
        /// <summary>
        /// Objet d'accès aux opérations possibles sur Developpeur
        /// </summary>
        private readonly DeveloppeurAccess developpeurAccess;

        /// <summary>
        /// Récupère l'accès aux données
        /// </summary>
        public FrmAuthentificationController()
        {
            developpeurAccess = new DeveloppeurAccess();
        }

        /// <summary>
        /// Vérifie l'authentification
        /// </summary>
        /// <param name="admin">objet contenant les infos de connexion</param>
        /// <returns>true si les infos de connexion sont bonnes</returns>
        public Boolean ControleAuthentification(Admin admin)
        {
            return developpeurAccess.ControleAuthentification(admin);
        }
    }
}
