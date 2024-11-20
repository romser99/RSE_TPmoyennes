using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSE_TPmoyennes
{
    class Classe
    {
        public string nomClasse { get; private set; }
        public List<Eleve> eleves { get; private set; }
        public List<string> matieres { get; private set; }

        public Classe(string nom)
        {
            nomClasse = nom;
            eleves = new List<Eleve>();
            matieres = new List<string>();
        }

        public void ajouterEleve(string prenom, string nom)
        {
            if (eleves.Count < 30)
                eleves.Add(new Eleve(prenom, nom));
        }

        public void ajouterMatiere(string nomMatiere)
        {
            if (matieres.Count < 10)
                matieres.Add(nomMatiere);
        }

        public float moyenneMatiere(int indexMatiere)
        {
            if (indexMatiere < 0 || indexMatiere >= matieres.Count)
                return 0.0f;

            float somme = 0;
            int count = 0;
            foreach (var eleve in eleves)
            {
                float moyenne = eleve.moyenneMatiere(indexMatiere);
                if (moyenne > 0)
                {
                    somme += moyenne;
                    count++;
                }
            }
            return count > 0 ? (float)Math.Truncate(somme / count * 100) / 100 : 0.0f;
        }

        public float moyenneGeneral()
        {
            float somme = 0;
            foreach (var matiere in matieres)
            {
                int index = matieres.IndexOf(matiere);
                somme += moyenneMatiere(index);
            }
            return matieres.Count > 0 ? (float)Math.Truncate(somme / matieres.Count * 100) / 100 : 0.0f;
        }
    }
}