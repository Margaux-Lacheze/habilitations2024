using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model
{
    public class Admin
    {
        public Admin(string nom, string prenom, string pwd)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Pwd = pwd;
        }

        public string Nom { get; }
        public string Prenom { get; }
        public string Pwd { get; }
    }
}
