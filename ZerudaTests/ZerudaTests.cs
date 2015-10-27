using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeruda;



namespace ZerudaTests
{
    [TestClass]
    public class ZerudaTests
    {
        [TestMethod]
        public void VLOOKUP_True_Count()
        {
            string formula = "VLOOKUP(I8,[1]Sheet3!A$3:B$84,2,TRUE)";
            int numParams = LinkAnalysis.NumberOfParameters(formula);
            Assert.AreEqual(4, numParams);
        }

        [TestMethod]
        public void Nested_VLOOKUP_Count()
        {
            string formula = "IF(VLOOKUP(I8,A5:B100,2,TRUE))";
            int numParams = LinkAnalysis.NumberOfParameters(formula);
            Assert.AreEqual(4, numParams);
        }

        [TestMethod]
        public void Double_Nested_VLOOKUP_Count()
        {
            string formula = "IF(VLOOKUP(I8,A5:B100,2,TRUE),1,VLOOKUP(I8,A5:B100,3,FALSE))";
            var allLookups = LinkAnalysis.ReturnLookups(formula);
            Assert.AreEqual(2, allLookups.Count);
        }


        [TestMethod]
        public void No_VLOOKUP_Count()
        {
            string formula = "SUM(A1:A17)";
            var allLookups = LinkAnalysis.ReturnLookups(formula);
            Assert.AreEqual(0, allLookups.Count);
        }

        [TestMethod]
        public void One_VLOOKUP_Count()
        {
            string formula = "IF(VLOOKUP(I8,A5:B100,2,TRUE))";
            int numParams = LinkAnalysis.NumberOfParameters(formula);
            Assert.AreEqual(4, numParams);
        }


        [TestMethod]
        public void VLOOKUP_Default()
        {
            string formula = "VLOOKUP(I8,[1]Sheet3!A$3:B$84,2)";
            int numParams = LinkAnalysis.NumberOfParameters(formula);
            Assert.AreEqual(3, numParams);
        }

        [TestMethod]
        public void VLOOKUP_True_Type()
        {
            string formula = "VLOOKUP(I8,[1]Sheet3!A$3:B$84,2,TRUE)";
            bool finalParam = LinkAnalysis.TypeofFinalParameter(formula);
            Assert.AreEqual(true, finalParam);
        }

        [TestMethod]
        public void VLOOKUP_False_Type()
        {
            string formula = "VLOOKUP(I8,[1]Sheet3!A$3:B$84,2,FALSE)";
            bool finalParam = LinkAnalysis.TypeofFinalParameter(formula);
            Assert.AreEqual(false, finalParam);
        }

        [TestMethod]
        public void HLOOKUP_Three()
        {
            string formula = "HLOOKUP(Assumptions!$H$12,IDC!$I$40:$M$56,2+F42)";
            int numParams = LinkAnalysis.NumberOfParameters(formula);
            Assert.AreEqual(3, numParams);
        }

  
    }
}
