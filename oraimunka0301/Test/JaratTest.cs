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

            Assert.Throws<ArgumentException>(
                () => {
                }

                );

        }


    }
}
