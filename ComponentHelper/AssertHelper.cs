using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumWebdriver.ComponentHelper
{
    public class AssertHelper
    {
        public static void AreEqual(string expected, string actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (AssertFailedException exception)
            {
                throw exception;
            }
        }

        public static void AreEqual(int expected, int actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (AssertFailedException exception)
            {
                throw exception;
            }
        }

        public static void AreNotEqual(string expected, string actual)
        {
            try
            {
                Assert.AreNotEqual(expected, actual);
            }
            catch (AssertFailedException exception)
            {
                throw exception;
            }
        }

        public static void AreNotEqual(int expected, int actual)
        {
            try
            {
                Assert.AreNotEqual(expected, actual);
            }
            catch (AssertFailedException exception)
            {
                throw exception;
            }
        }

        public static void IsTrue(bool actual)
        {
            try
            {
                Assert.IsTrue(actual);
            }
            catch (AssertFailedException exception)
            {

                throw new Exception("The value returned : " + actual);
            }
        }

        public static void IsFalse(bool actual)
        {
            try
            {
                Assert.IsFalse(actual);
            }
            catch (AssertFailedException exception)
            {
                throw exception;
            }
        }

        public static bool VerificationAssert(bool actual)
        {
            try
            {
                Assert.IsTrue(actual);
                return true;
            }
            catch (AssertFailedException)
            {
                Assert.IsFalse(actual);
                return false;
            }
        }

        public static bool VerificacionAreEqualReport(int expected, int actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
                return true;
            }
            catch (AssertFailedException exception)
            {
                Assert.AreNotEqual(expected, actual);
                return false;
            }
        }

        public static bool VerificationAreEqual(string actual, string dato)
        {
            try
            {
                Assert.AreEqual(actual, dato);
                return true;
            }
            catch (AssertFailedException)
            {
                Assert.AreNotEqual(actual, dato);
                return false;
            }
        }

        public static bool AssertIsTrue(bool actual)
        {
            try
            {
                Assert.IsTrue(actual);
                return true;
            }
            catch (AssertFailedException exception)
            {
                return false;
            }
        }

        public static bool AssertIsFalse(bool actual)
        {
            try
            {
                Assert.IsFalse(actual);
                return false;
            }
            catch (AssertFailedException exception)
            {
                return true;
            }
        }
    }
}
