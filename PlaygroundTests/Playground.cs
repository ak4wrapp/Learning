
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playground
{
    [TestClass]
    public class PlaygroundTests
    {
        #region ContainsAA
        private bool ContainsAA(string inputStr)
        {
            if (inputStr.IndexOf("a") == -1) return false;

            return inputStr.IndexOf("aa") == inputStr.IndexOf("a");
        }

        [TestMethod]
        public void ContainsAA_Test()
        {
            Console.WriteLine(ContainsAA("caabb"));
            Console.WriteLine(ContainsAA("amanaa"));
            Console.WriteLine(ContainsAA("ryaan"));
            Console.WriteLine(ContainsAA("renu"));
        }

        #endregion

        #region Staircase
        private void StairCase(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine(string.Concat(Enumerable.Repeat("#", i))
                                        .PadLeft(num));
            }
        }

        [TestMethod]
        public void StairCaseTest() {
            StairCase(4);
            StairCase(3);
            StairCase(5);
        }
        #endregion

        #region checkMagazine
        private void CheckMagazine(string[] magazine, string[] note)
        {
            int wordMatchCount = 0;
            Array.Sort(magazine);
            Array.Sort(note);
            for (int i = 0; i < magazine.Length && wordMatchCount < note.Length; i++)
            {
                if (magazine[i] == note[wordMatchCount])
                {
                    wordMatchCount++;
                }
            }
            string result = wordMatchCount == note.Length ? "Yes" : "No";
            Console.Write(result);
        }

        [TestMethod]
        public void CheckMagazineTest()
        {
            CheckMagazine(new string[] { "I", "am", "saying", "Good", "Morning" },
                new string[] { "Good", "Good", "Morning" });
        }
        #endregion

        
    }
}