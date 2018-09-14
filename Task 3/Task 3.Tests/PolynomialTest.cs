using System.Collections.Generic;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace Task_3.Tests
{
    [TestFixture]
    public class PolynomialTest
    {
        [Test]
        public void Add_LeftAddendIsEmpty_RightPolynomialReturned()
        {
            var p1 = new Polynomial(new List<double>());
            var p2 = new Polynomial(new List<double> { 1, 20 });
            var expectedResult = new Polynomial(new List<double> { 1, 20 });
            Assert.AreEqual(expectedResult, p1.Add(p2));
        }

        [Test]
        public void Add_BothPolynomialsAreEmpty_EmptyPolynomialReturned()
        {
            var p1 = new Polynomial(new List<double>());
            var p2 = new Polynomial(new List<double>());
            var expectedResult = new Polynomial(new List<double>());
            Assert.AreEqual(expectedResult, p1.Add(p2));
        }

        [Test]
        public void Add_PolynomialsHaveDifferentCoefficientsCount_CorrectSumReturned()
        {
            var p1 = new Polynomial(new List<double> { 1, 20, 4, -5, 13 });
            var p2 = new Polynomial(new List<double> { 1, 12, 8, 3 });
            var expectedResult = new Polynomial(new List<double> { 2, 32, 12, -2, 13 });
            Assert.AreEqual(expectedResult, p1.Add(p2));
        }

        [Test]
        public void Subtract_LeftAddendIsEmpty_MinusRightPolynomialReturned()
        {
            var p1 = new Polynomial(new List<double>());
            var p2 = new Polynomial(new List<double> { 1, 20 });
            var expectedResult = new Polynomial(new List<double> { -1, -20 });
            Assert.AreEqual(expectedResult, p1.Subtract(p2));
        }

        [Test]
        public void Subtract_RightPolynomialIsEmpty_LeftPolynomialReturned()
        {
            var p1 = new Polynomial(new List<double> { 1, 20 });
            var p2 = new Polynomial(new List<double>());
            var expectedResult = new Polynomial(new List<double> { 1, 20 });
            Assert.AreEqual(expectedResult, p1.Subtract(p2));
        }

        [Test]
        public void Subtract_BothPolynomialsAreEmpty_EmptyPolynomialReturned()
        {
            var p1 = new Polynomial(new List<double>());
            var p2 = new Polynomial(new List<double>());
            var expectedResult = new Polynomial(new List<double>());
            Assert.AreEqual(expectedResult, p1.Subtract(p2));
        }

        [Test]
        public void Subtract_PolynomialsHaveDifferentCoefficientsCount_CorrectSumReturned()
        {
            var p1 = new Polynomial(new List<double> { 1, 20, 4, -5, 13 });
            var p2 = new Polynomial(new List<double> { 1, 12, 8, 3 });
            var expectedResult = new Polynomial(new List<double> { 0, 8, -4, -8, 13 });
            Assert.AreEqual(expectedResult, p1.Subtract(p2));
        }

        [Test]
        public void Multiply_MultiplyByZero_AllCoefficientsZeroReturned()
        {
            var p1 = new Polynomial(new List<double> { 4, 5, 7, -20, 0, 3 });
            var expectedResult = new Polynomial(new List<double>());
            Assert.AreEqual(expectedResult, p1.Multiply(0));
        }

        [Test]
        public void Multiply_MultiplyBy5_CorrectResultReturned()
        {
            var p1 = new Polynomial(new List<double> { 4, 5, 7, -20, 0, 3 });
            var expectedResult = new Polynomial(new List<double> { 20, 25, 35, -100, 0, 15 });
            Assert.AreEqual(expectedResult, p1.Multiply(5));
        }

        [Test]
        public void Multiply_LeftMultipliedIsEmpty_EmptyPolynomialReturned()
        {

            var p1 = new Polynomial(new List<double>());
            var p2 = new Polynomial(new List<double> { 4, 1, 6, 9, 5 });
            var expectedResult = new Polynomial(new List<double>());
            Assert.AreEqual(expectedResult, p1.Multiply(p2));
        }

        [Test]
        public void Multiply_PolynomialsHaveDifferentCoefficientsCount_CorrectResultReturned()
        {
            var p1 = new Polynomial(new List<double> { 2, 0, 9, 6 });
            var p2 = new Polynomial(new List<double> { 4, 1, 6, 9, 5 });
            var expectedResult = new Polynomial(new List<double> { 8, 2, 48, 51, 70, 117, 99, 30 });
            Assert.AreEqual(expectedResult, p1.Multiply(p2));
        }

        [Test]
        public void ValueAtThePoint_ValueZero_FirstCoefficientReturned()
        {
            var p1 = new Polynomial(new List<double> { 2, 5, 7, 5, -10, 4 });
            Assert.AreEqual(2, p1.ValueAtThePoint(0));
        }

        [Test]
        public void ValueAtThePoint_Value3_CorrectResultReturned()
        {
            var p1 = new Polynomial(new List<double> { 2, 5, 4 });
            Assert.AreEqual(53, p1.ValueAtThePoint(3));
        }

        [Test]
        public void RootFinding_StartIntervalIsGreaterThanTheEndOfTheInterval_CorrectResultReturned()
        {
            var p1 = new Polynomial(new List<double> { 8, 12, 3, 1 });
            Assert.AreEqual(8, p1.RootFinding(11, 5, 0.001));
        }

        [Test]
        public void RootFinding_StartIntervalIsLessThanTheEndOfTheInterval_CorrectResultReturned()
        {
            var p1 = new Polynomial(new List<double> { 8, 12, 3, 1 });
            Assert.AreEqual(-0.77911376953125, p1.RootFinding(-5, 5, 0.001));
        }

        [Test]
        public void ToString_IndexLessThanZero_CorrectResultReturned()
        {
            var p1 = new Polynomial(new List<double> { -4, -2, 0, 13, 0, -4 });
            const string ExpectedResult = "-4x^5+13x^3-2x-4";
            Assert.AreEqual(ExpectedResult, p1.ToString());
        }

        [Test]
        public void OperatorPlus_AdditionOfTwoPolynomials_CorrectResultReturned()
        {
            var p1 = new Polynomial(new List<double> { 1, 20, 4, -5, 13 });
            var p2 = new Polynomial(new List<double> { 1, 12, 8, 3 });
            var expectedResult = new Polynomial(new List<double> { 2, 32, 12, -2, 13 });
            Assert.AreEqual(expectedResult, p1 + p2);
        }

        [Test]
        public void OperatorMinus_SubtractionOfTwoPolynomials_CorrectResultReturned()
        {
            var p1 = new Polynomial(new List<double> { 1, 20, 4, -5, 13 });
            var p2 = new Polynomial(new List<double> { 1, 12, 8, 3 });
            var expectedResult = new Polynomial(new List<double> { 0, 8, -4, -8, 13 });
            Assert.AreEqual(expectedResult, p1 - p2);
        }

        [Test]
        public void OperatorEquality_ComparesOnePolynomial_TrueReturned()
        {
            var p1 = new Polynomial(new List<double> { 1, 20, 4, -5, 13 });
            Assert.IsTrue(p1 == p1);
        }

        [Test]
        public void OperatorEquality_DifferentListSizeButCoeefficientsEquals_TrueReturned()
        {
            var p1 = new Polynomial(new List<double> { 1, 20, 4, -5, 13 });
            var p2 = new Polynomial(new List<double> { 1, 20, 4, -5, 13, 0, 0 });
            Assert.IsTrue(p1 == p2);
        }

        [Test]
        public void OperatorNotEqual_ComparesOnePolynomial_FalseReturned()
        {
            var p1 = new Polynomial(new List<double> { 1, 20, 4, -5, 13 });
            Assert.IsFalse(p1 != p1);
        }
    }
}
