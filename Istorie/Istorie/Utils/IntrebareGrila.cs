using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istorie.Utils
{
    public class IntrebareGrila
    {
        //CONSTRUCTORI
        public IntrebareGrila(int _id,string intreb,string[] raspunsuri_1,string[] variante)
        {
            id = _id;
            intrebare = intreb;
            raspunsuri = raspunsuri_1.ToList();
            foreach(string varianta in variante)
            {
                bool isOk = bool.Parse(varianta);
                if (isOk == true )
                {
                    eCorecta.Add(true);
                }
                else
                {
                    eCorecta.Add(false);
                }
            }
            
        }
        /////////////////////////////////////////////////////////////////////////////////

        //PROPRIETATI
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string intrebare;

        public string Intrebare
        {
            get { return intrebare; }
            set { intrebare = value; }
        }
        private List<string> raspunsuri = new List<string>();
        private List<bool> eCorecta = new List<bool>();
        private int nrRaspunsuri = 0;
        /////////////////////////////////////////////////////////////////////////////////

        //METODE
        public void AddRaspuns(string raspuns,bool eCorect)
        {
            raspunsuri.Add(raspuns);
            eCorecta.Add(eCorect);
        }
        
        public int NrRaspunsuri()
        {
            return raspunsuri.Count;
        }

        public List<string> getRaspunsuri()
        {
            return raspunsuri;
        }
        public List<bool> getVariante()
        {
            return eCorecta;
        }
        public bool returnECorect(int index)
        {
            return eCorecta[index];
        }
        public string returnVarianta(int index)
        {
            return raspunsuri[index];
        }

    }
}
