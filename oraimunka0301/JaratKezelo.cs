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

            public string JaratSzam { get; set; }
            public string RepterHonnan { get; set; }
            public string RepterHova { get; set; }
            public DateTime Indulas { get; set; }
            public TimeSpan Keses { get; set; }

            public Jarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
            {
                JaratSzam = jaratSzam;
                RepterHonnan = repterHonnan;
                RepterHova = repterHova;
                Indulas = indulas;
                Keses = new TimeSpan();
            }
        }
        List<Jarat> jaratok = new List<Jarat>();

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas) {
            foreach (var item in jaratok)
            {
                if (item.JaratSzam.Equals(jaratSzam))
                {
                    throw new ArgumentException("Duplikált járat: "+jaratSzam);
                }

            }

            var jar = new Jarat(jaratSzam, repterHonnan, repterHova, indulas);
            jaratok.Add(jar);

        }


        public void Keses(string jaratSzam, int keses)
        {
            foreach (var jar in jaratok)
            {
                if (jar.JaratSzam.Equals(jaratSzam))
                {
                    if (keses < 0)
                    {
                        if (jar.Keses.Minutes+keses < 0)
                        {
                            throw new NegativKesesException(jar.Keses.Minutes + keses);
                        }
                    }
                    else
                    {
                        jar.Keses += new TimeSpan(0,keses,0);
                        return;
                    }
                }
            }
            throw new ArgumentException("Nem létező járat: " + jaratSzam);


        }
        public void Keses(string jaratSzam, TimeSpan keses)
        {
            foreach (var jar in jaratok)
            {
                if (jar.JaratSzam.Equals(jaratSzam))
                {
                    if (keses.Minutes < 0)
                    {
                        if ((jar.Keses+keses).Minutes < 0)
                        {
                            throw new NegativKesesException((jar.Keses + keses).Minutes);
                        }
                    }
                    else
                    {
                        jar.Keses += keses;
                        return;
                    }
                }
            }
            throw new ArgumentException("Nem létező járat: " + jaratSzam);


        }
        public DateTime MikorIndul(string jaratSzam) {

            foreach (Jarat jar in jaratok) {
                if (jar.JaratSzam.Equals(jaratSzam))
                {
                    DateTime pontosIndulas = jar.Indulas + jar.Keses;
                    return pontosIndulas;
                }

            }
            throw new ArgumentException("Nem létező járat: "+jaratSzam);
        }
        public List<string> JaratokRepuloterrol(string repter) {

            List<string> repterrolJaratok = new List<string>();
            foreach (Jarat jar in jaratok)
            {
                if (jar.RepterHonnan.Equals(repter))
                {
                    repterrolJaratok.Add(jar.JaratSzam);
                }

            }

            if (repterrolJaratok.Count ==0)
            {
                throw new ArgumentException("Nem létező reptér: " + repter);
            }
            return repterrolJaratok;
        }
    }
}
