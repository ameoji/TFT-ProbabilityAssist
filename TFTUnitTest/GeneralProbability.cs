using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TFTUnitTest
{
    [TestClass]
    public class GeneralProbability
    {
        [TestMethod]
        public void chk_GeneralProbability()
        {
            List<Double> a = TFTHelper.Probability.GeneralProbability(1);
            List<Double> b = TFTHelper.Probability.GeneralProbability(2);
            List<Double> c = TFTHelper.Probability.GeneralProbability(3);
            List<Double> d = TFTHelper.Probability.GeneralProbability(4);
            List<Double> e = TFTHelper.Probability.GeneralProbability(5);

            double f = TFTHelper.Probability.IndividualProbability(1, 1, 1);



        }
    }
}
