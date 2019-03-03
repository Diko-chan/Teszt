using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oraimunka0301
{
    public class JaratKezelo
    {
        class Jarat {

            public string jaratSzam;
            private string repterHonnan;
            private string repterHova;
            public DateTime indulas;
            public int Keses;

            public Jarat(string jaratSzam2, string repterHonnan2, string repterHova2, DateTime indulas2, int Keses2) {

                jaratSzam = jaratSzam2;
                repterHonnan = repterHonnan2;
                repterHova = repterHova2;
                indulas = indulas2;
                Keses = Keses2;

            }

        }
        List<Jarat> jarat = new List<Jarat>();

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas, int Keses) {

            var jar = new Jarat(jaratSzam, repterHonnan, repterHova, indulas, Keses);
            jarat.Add(jar);

        }

        internal double UjJarat(string v)
        {
            throw new NotImplementedException();
        }

        internal double Keses(string v)
        {
            throw new NotImplementedException();
        }

        public void Keses(string jaratSzam, int keses) {
            foreach (var jar in jarat)
            {
                if (jar.jaratSzam.Equals(jaratSzam))
                {
                    if (keses < 0)
                    {
                        if (jar.Keses + keses < 0)
                        {
                            throw new NegativKesesException(jar.Keses+keses);
                        }
                    }
                    else
                    {
                        jar.Keses += keses;
                    }
                }
            }
            

        }
        public DateTime MikorIndul(string jaratSzam) {

            foreach (Jarat jar in jarat) {
                if (jar.jaratSzam.Equals(jaratSzam))
                {
                    DateTime pontosIndulas = jar.indulas.AddMinutes(jar.Keses);
                    return pontosIndulas;
                }

            }
            throw new NotImplementedException();
        }
        public List<string> JaratokRepuloterrol(string repter) {


            throw new NotImplementedException();
        }
    }
}
