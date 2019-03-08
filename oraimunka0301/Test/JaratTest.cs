using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace oraimunka0301.Test
{
    [TestFixture]
    class JaratTest
    {
        JaratKezelo j;

        [SetUp]
        public void Setup() {
            j = new JaratKezelo();
        }

        [Test]
        public void DuplikaltJarat()
        {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45));
            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.UjJarat("22", "Róma", "London", new DateTime(1995, 02, 21, 17, 15, 45));
                }
            );
        }

        [Test]
        public void NegativKesik()
        {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45));
            j.Keses("22", 5);

            Assert.Throws<NegativKesesException>(
                () =>
                {
                    j.Keses("22", -13);
                }

                );

        }

        [Test]
        public void KesesNemLetezoJarat()
        {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45));
            
            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.Keses("23", 5);
                }

              );
        }

        [Test]
        public void KesesRendesenHozzaad()
        {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45));
            j.Keses("22", 15);
            DateTime indulas = new DateTime(1995, 01, 21, 17, 30, 45);
            Assert.AreEqual(indulas,j.MikorIndul("22"));
        }

        [Test]
        public void UjJaratAkkorIndul()
        {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45));
            Assert.AreEqual(new DateTime(1995, 01, 21, 17, 15, 45), j.MikorIndul("22"));
        }

        [Test]
        public void MikorIndulNemLetezoJarat()
        {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45));

            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.MikorIndul("23");
                }

              );
        }

        [Test]
        public void KesesOsszeadodik()
        {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45));
            j.Keses("22", 15);
            j.Keses("22", 12);
            DateTime indulas = new DateTime(1995, 01, 21, 17, 42, 45);
            Assert.AreEqual(indulas, j.MikorIndul("22"));
        }

        [Test]
        public void RepterNemLetezik()
        {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45));

            Assert.Throws<ArgumentException>(
                () =>
                {
                    j.JaratokRepuloterrol("London");
                }

              );
        }

        [Test]
        public void JaratokRepterrol()
        {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45));

            Assert.AreEqual(j.JaratokRepuloterrol("Budapest").Count, 1);
        }

        [Test]
        public void TobbRepuloter()
        {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45));
            j.UjJarat("23", "Budapest", "London", new DateTime(1995, 01, 21, 17, 15, 45));
            j.UjJarat("24", "Budapest", "Párizs", new DateTime(1995, 01, 21, 17, 15, 45));
            j.UjJarat("25", "London", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45));
            j.UjJarat("26", "Párizs", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45));
            j.UjJarat("27", "Helsinki", "New Castle", new DateTime(1995, 01, 21, 17, 15, 45));

            Assert.AreEqual(j.JaratokRepuloterrol("Budapest").Count, 3);
        }
    }
}
