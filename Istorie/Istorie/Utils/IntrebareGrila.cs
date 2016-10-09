using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istorie.Utils
{
    class IntrebareGrila
    {
        //CONSTRUCTORI
        public IntrebareGrila(string intreb,string[] raspunsuri_1,string[] variante)
        {
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
        public bool returnVarianta(int index)
        {
            return eCorecta[index];
        }

    }
}
