using System;
using System.Collections.Generic;
using System.Linq;

namespace Descriptive_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {

        }



        /* Returns the double with the maximum value from the array of doubles */
        public double GetMaximum(double[] numbers)
        {
            if (numbers == null || numbers.Length == 0) throw new ArgumentException("Passed array should not be empty");
            return numbers.Max();
        }


        /* Returns the double with the minimum value from the array of doubles */
        public double GetMinimum(double[] numbers)
        {
            if (numbers == null || numbers.Length == 0) throw new ArgumentException("Passed array should not be empty");
            return numbers.Min();
        }


        /* Returns the difference between the element with the maximum value
        * and the element with the minimum value in an array.*/
        public double GetRange(double[] numbers)
        {
            if (numbers == null || numbers.Length == 0) throw new ArgumentException("Passed array should not be empty");
            return numbers.Max() - numbers.Min();
        }


        /* Returns the mean value of the range of numbers in an array */
        public double GetMean(double[] numbers)
        {
            if (numbers == null || numbers.Length == 0) throw new ArgumentException("Passed array should not be empty");
            double sum = numbers.Sum();
            return sum / numbers.Length;
        }


        /* Returns the median value of the range of numbers in an array. */
        public double GetMedian(double[] numbers)
        {
            if (numbers == null || numbers.Length == 0) throw new ArgumentException("Passed array should not be empty");

            // Make a shallow copy of the original array & Sort the array copy
            double[] sortedNumbers = (double[])numbers.Clone();
            Array.Sort(sortedNumbers);

            // Get the median value
            int size = sortedNumbers.Length;
            int middle = size / 2;

            double median = (size % 2 != 0) ? (double)sortedNumbers[middle] :
                            ((double)sortedNumbers[middle] + (double)sortedNumbers[middle - 1]) / 2;
            return median;
        }


        /* Returns the range of most frequent numbers in an array. */
        public double GetMode(double[] numbers)
        {
            if (numbers == null || numbers.Length == 0) throw new ArgumentException("Passed array should not be empty");

            // Declare dictionary to keep frequency value on each number from the source array
            Dictionary<double, int> frequencyDictionary = new Dictionary<double, int>();

            // Populate the frequency dictionary
            foreach (double value in numbers)
            {
                if (frequencyDictionary.ContainsKey(value)) { frequencyDictionary[value]++; }
                else { frequencyDictionary.Add(value, 1); }
            }

            // Find most common value
            double mostCommonValue = 0;
            int highestCount = 0;
            foreach (KeyValuePair<double, int> number_frequency_pair in frequencyDictionary)
            {
                if (number_frequency_pair.Value > highestCount)
                {
                    mostCommonValue = number_frequency_pair.Key;
                    highestCount = number_frequency_pair.Value;
                }
            }

            return mostCommonValue;
        }


        /* Returns the standard deviation of the mean of the set of numbers in an array. */
        public double GetStandardDeviation(double[] numbers)
        {
            if (numbers == null || numbers.Length == 0) throw new ArgumentException("Passed array should not be empty");

            // Caclulate the mean value
            double meanNumber = GetMean(numbers);

            // Calculate the sum of the square deviations
            double sumOfSquareDeviations = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sumOfSquareDeviations += Math.Pow((numbers[i] - meanNumber), 2);
            }

            // Calculate the value of the standard deviation
            double standardDeviation = Math.Sqrt(sumOfSquareDeviations / numbers.Length);

            return standardDeviation;
        }

    }

}

