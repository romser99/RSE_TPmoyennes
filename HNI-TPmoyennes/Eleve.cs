using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSE_TPmoyennes
{
    class Eleve
    {
        public string prenom { get; private set; }
        public string nom { get; private set; }
        private List<Note> notes;

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            notes = new List<Note>();
        }

        public void ajouterNote(Note note)
        {
            if (notes.Count < 200)
                notes.Add(note);
        }

        public float moyenneMatiere(int indexMatiere)
        {
            float somme = 0;
            int count = 0;
            foreach (var note in notes)
            {
                if (note.matiere == indexMatiere)
                {
                    somme += note.note;
                    count++;
                }
            }
            return count > 0 ? (float)Math.Truncate(somme / count * 100) / 100 : 0.0f; //si notes présentes renvoie valeur sinon renvoie un indidateur d'erreur
        }

        public float moyenneGeneral()
        {
            Dictionary<int, float> moyennesMatieres = new Dictionary<int, float>();
            foreach (var note in notes)
            {
                if (!moyennesMatieres.ContainsKey(note.matiere))
                    moyennesMatieres[note.matiere] = moyenneMatiere(note.matiere);
            }
            float somme = 0;
            foreach (var moyenne in moyennesMatieres.Values)
            {
                somme += moyenne;
            }
            return moyennesMatieres.Count > 0 ? (float)Math.Truncate(somme / moyennesMatieres.Count * 100) / 100 : 0.0f; // comme dans moyenneMatiere
        }
    }
}
