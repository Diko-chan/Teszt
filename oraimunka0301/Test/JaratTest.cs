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
        public void NegativKesik() {
            j.UjJarat("22","Budapest","Helsinki",new DateTime(1995,01,21,17,15,45),5);
            j.Keses("22", 5);

            Assert.Throws<NegativKesesException>(
                () => {
                    j.Keses("22", -13);
                }
                
                );

        }
        [Test]
        public void UjKeses() {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45), 0);
            Assert.AreEqual(5, j.UjJarat("22"));

        }
        [Test]
        public void MikorIndult() {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45),0);
            Assert.AreEqual(new DateTime(1995, 01, 21, 17, 15, 45), j.MikorIndul("22"));
        }
        [Test]
        public void KesesOsszeadodik() {
            j.UjJarat("22", "Budapest", "Helsinki", new DateTime(1995, 01, 21, 17, 15, 45), 0);
            j.Keses("22", 15);
            j.Keses("22", 12);
            Assert.AreEqual(27, j.Keses("22"));


        }

    }
}
