using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.MathLogic
{
    public class MathLogic
    {
        public int[] Poison(IEnumerable<Bottle> bottles, IEnumerable<TestStrip> testStrips)
        {
            if(bottles == null || testStrips == null)
                throw new ArgumentNullException();

            TestStrip.Clear();
            var bottlesList = bottles.ToList();
            var testStripsList = testStrips.ToList();

            var hundrends = GetHundreds(testStripsList, bottlesList);
            if(hundrends==-1)
                throw new ArgumentException("There is no poisoned bottle");

            var decades = GetDecades(hundrends, bottlesList, testStripsList);
            var ones = GetOnes(testStripsList, bottlesList, hundrends, decades);

            var result = hundrends * 100 + decades * 10 + ones;
            return new[] { result, TestStrip.CurrentDay };
        }

        private static int GetOnes(List<TestStrip> testStripsList, List<Bottle> bottlesList, int hundrends, int decades)
        {
            int half = 5;
            int currentIndex = hundrends * 100 + decades * 10;
            for (int i = 0; i < half; i++)
                testStripsList[i].DropBottle(bottlesList[currentIndex + i]);
            for (int i = 0; i < testStripsList.Count; i++)
                if (testStripsList[i].GetResults(CheckOrder.Third))
                   return  i;

            for (int i = half; i < half*2; i++)
                    testStripsList[i - half].DropBottle(bottlesList[currentIndex + i]);
                for (int i = 0; i < testStripsList.Count; i++)
                    if (testStripsList[i].GetResults(CheckOrder.Fourth))
                        return  i + half;
            return -1;
        }

        private static int GetDecades(int hundrends, List<Bottle> bottlesList, List<TestStrip> testStripsList)
        {
            int testStripIndex = -1;
            for (int i = hundrends * bottlesList.Count / testStripsList.Count;
                i < (hundrends + 1) * bottlesList.Count / testStripsList.Count;
                i++)
            {
                if (i % testStripsList.Count == 0)
                    testStripIndex++;
                testStripsList[testStripIndex].DropBottle(bottlesList[i]);
            }
            var secondResults = new List<int>();
            for (int i = 0; i < testStripsList.Count; i++)
                if (testStripsList[i].GetResults(CheckOrder.Second))
                    secondResults.Add(i);

            for (int i = 0; i < secondResults.Count; i++)
                testStripsList.RemoveAt(secondResults[i] - i);

            if (secondResults.Count == 1)
                return hundrends;
            return secondResults[0] == hundrends ? secondResults[1] : secondResults[0];
        }

        private static int GetHundreds(List<TestStrip> testStripsList, List<Bottle> bottlesList)
        {
            for (int i = 0; i < testStripsList.Count; i++)
                for (int j = i * bottlesList.Count / testStripsList.Count;
                    j < (i + 1) * bottlesList.Count / testStripsList.Count;
                    j++)
                    testStripsList[i].DropBottle(bottlesList[j]);

            for (int i = 0; i < testStripsList.Count; i++)
                if (testStripsList[i].GetResults(CheckOrder.First))
                    return i;
            return -1;
        }
    }
}
