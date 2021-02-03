﻿using System;
using static Task2.ListGenerators;
using System.Linq;
using System.IO;

namespace Task2
{
    class Program
    {
        static string ReverseString(string s)
        {
            // Convert to char array, then call Array.Reverse.
            // ... Finally use string constructor on array.
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
        static void Main(string[] args)
        {



            #region LINQ - Set Operators
            /*
            //Q1:Find the unique Category names from Product List
            var Result11 = ProductList.Select(p => p.Category).Distinct();
            foreach(var item in Result11)
            {
                Console.WriteLine(item);
            }
            //Q2 :Produce a Sequence containing the unique first letter from both product and customer names.
            var PName = ProductList.Select(p => p.ProductName.ElementAt(0)).Distinct();
            var CName = CustomerList.Select(c => c.CompanyName.ElementAt(0)).Distinct();
            var Result12 = PName.Concat(CName).Distinct();
            foreach(var item in Result12)
            {
                Console.WriteLine(item);
            }
            //Q3 :Create one sequence that contains the common first letter 
            //from both product and customer names
            var PName3 = ProductList.Select(p => p.ProductName.ElementAt(0));
            var CName3 = CustomerList.Select(c => c.CompanyName.ElementAt(0));
            var Result13 = PName3.Intersect(CName3);
            foreach (var item in Result13)
            {
                Console.WriteLine(item);
            }
            //Q4 :Create one sequence that contains the first letters of product names
            //that are not also first letters of customer names
            var PName4 = ProductList.Select(p => p.ProductName.ElementAt(0));
            var CName4 = CustomerList.Select(c => c.CompanyName.ElementAt(0));
            var Result14 = PName4.Except(CName4);
            foreach (var item in Result14)
            {
                Console.WriteLine(item);
            }

            //Q5 : Create one sequence that contains the last Three Characters in each names 
            //of all customers and products, including any duplicates
            var PName5 = ProductList.Select(p => ReverseString(p.ProductName).Substring(0,3));
            var CName5 = CustomerList.Select(c => ReverseString(c.CompanyName).Substring(0, 3) );
            var Result15 = PName5.Concat(CName5);
            foreach (var item in Result15)
            {
                Console.WriteLine(item);
            }*/

            #endregion

            #region LINQ - Aggregate Operators
            /*
            //Q1 : Uses Count to get the number of odd numbers in the array
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var Result21 = Arr.Where(a => a % 2 != 0).Count();
            Console.WriteLine(Result21);
            //Q2 : Return a list of customers and how many orders each has
            var Result22 = (
                from c in CustomerList
                select new { CustomerID = c.CustomerID,orderCount = c.Orders.Count() });
            foreach (var item in Result22)
                Console.WriteLine(item);
            //Q3 Return a list of categories and how many products each has
            var Result23 = (
                     from p in ProductList
                     select new {Pcategory = p.Category , Pamount = p.UnitsInStock}
                     );
            foreach (var item in Result23)
                Console.WriteLine(item);
            //Q4 Get the total of the numbers in an array.
            int[] Arr4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var Result24 = Arr4.Count();
            Console.WriteLine(Result24);
            //Q5 Get the total number of characters of all words in dictionary_english.txt 
            //(Read dictionary_english.txt into Array of String First).
            string filePath = 
                "D:\\CSharp\\Day11\\Task2\\bin\\Debug\\net5.0\\dictionary_english.txt";
            var lines = File.ReadAllLines(filePath);
            
            var count = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                 count += lines[i].Count();

            }
            Console.WriteLine("Number of Words into file : " + lines.Length);

            Console.WriteLine("The total number characters of all words in dictionary_english.txt : " + count);
            //Q6 Get the total units in stock for each product category
            var Result26 = ProductList.GroupBy(p => p.Category);
            foreach(var item in Result26)
            {
                Console.WriteLine("("+item.Key+" )total = " + item.Sum(P => P.UnitsInStock)+"items");
            }
            //Q7 Get the length of the shortest word in dictionary_english.txt 
            //(Read dictionary_english.txt into Array of String First).

            string _filePath =
               "D:\\CSharp\\Day11\\Task2\\bin\\Debug\\net5.0\\dictionary_english.txt";
            var _lines = File.ReadAllLines(_filePath);

            var minCount = _lines.Min();
            
            Console.WriteLine("Number of Words into file : " + _lines.Length);

            Console.WriteLine("The length of the shortest word in dictionary_english.txt  : " + minCount + " -> Length is : " + minCount.Length);
            
            //Q8 Get the cheapest price among each category's products --xxxx
            var Result28 = ProductList.Min(p => p.UnitPrice);
            Console.WriteLine($"{Result28:C}");

            //Q9  Get the products with the cheapest price in each category (Use Let)
            var Result29 = ProductList.GroupBy(p => p.Category);
            foreach (var item in Result29)
            {
                Console.WriteLine("Product category : " + item.Key + " --> " + item.Min(i => i.UnitPrice));
            }
            
            //Q10 Get the length of the longest word in dictionary_english.txt 
            //(Read dictionary_english.txt into Array of String First).
            string _filePath_ =
              "D:\\CSharp\\Day11\\Task2\\bin\\Debug\\net5.0\\dictionary_english.txt";
            var _lines_ = File.ReadAllLines(_filePath_);

            var maxCount = _lines_.Max();

            Console.WriteLine("Number of Words into file : " + _lines_.Length);

            Console.WriteLine("The length of the Longest word in dictionary_english.txt  : " + maxCount + " -> Length is : " + maxCount.Length);

            //Q11 --xxxxx Get the most expensive price among each category's products
            var Result211 = ProductList.Max(p => p.UnitPrice);
            Console.WriteLine($"{Result211:C}");
            //Q12 Get the products with the most expensive price in each category -xxx
            var Result212 = ProductList.GroupBy(p => p.Category); 
            foreach (var item in Result212)
            {
                Console.WriteLine("(" + item.Key + " )MaxAmount = " + item.Max(P => P.UnitPrice) );
            }
            //Q13 Get the average length of the words in dictionary_english.txt 
            //(Read dictionary_english.txt into Array of String First).
            string _filePath__ =
               "D:\\CSharp\\Day11\\Task2\\bin\\Debug\\net5.0\\dictionary_english.txt";
            var _lines__ = File.ReadAllLines(_filePath__);

            var AvgValue = _lines__.Average(line => line.Length);

            Console.WriteLine("Number of Words into file : " + _lines__.Length);

            Console.WriteLine("The average length of the words in dictionary_english.txt  : " + AvgValue );
            //Q14 Get the average price of each category's products. --xx
            var Result214 = ProductList.GroupBy(p => p.Category);
            foreach (var item in Result214)
            {
                Console.WriteLine("(" + item.Key + " )avgPrice = " + item.Average(P => P.UnitPrice));
            }
            */
            #endregion

            #region LINQ - Ordering Operators
            /*
            //Q1 Sort a list of products by name  
            var Result31 = ProductList.OrderBy(p => p.ProductName);
            foreach(var item in Result31)
            {
                Console.WriteLine(item);
            }

            //Q2 Uses a custom comparer to do a case-insensitive sort of the words in an array.
            string[] ArrString = 
                { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var Result32 = ArrString.OrderBy(s => s.ToUpper());
            foreach (var item in Result32)
            {
                Console.WriteLine(item);
            }

            //Q3 Sort a list of products by units in stock from highest to lowest.
            var Result33 =ProductList.OrderByDescending(p => p.UnitsInStock) ;
            foreach (var item in Result33)
            {
                Console.WriteLine(item);
            }

            //Q4 Sort a list of digits, first by length of their name, 
            //and then alphabetically by the name itself.
            string[] ArrNumber = 
                { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var Result34 = ArrNumber.OrderBy(num => num.Length).ThenBy(num => num.ToLower());
            foreach (var item in Result34)
            {
                Console.WriteLine(item);
            }

            //Q5 . Sort first by word length and then by a case-insensitive sort of the words in an array.
            string[] words = 
                { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var Result35 = words.OrderBy(num => num.Length).ThenBy(num => num.ToLower());
            foreach (var item in Result35)
            {
                Console.WriteLine(item);
            }

            //Q6 Sort a list of products, first by category, and then by unit price, from highest to lowest.
            var Result36 = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var item in Result36)
            {
                Console.WriteLine(item);
            }

            //Q7 Sort first by word length and 
            //then by a case-insensitive descending sort of the words in an array.
            string[] ArrWords= 
                { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var Result37 = ArrWords.OrderBy(w => w.Length).ThenByDescending(w => w.ToLower());
            foreach (var item in Result37)
            {
                Console.WriteLine(item);
            }
            //Q8 Create a list of all digits in the array whose second letter is 'i' 
            //that is reversed from the order in the original array

            string[] Arrnum = 
                { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var Result38 = Arrnum.Where(num => num.ElementAt(1) == 'i');
               
            foreach (var item in Result38)
            {
                Console.WriteLine(ReverseString(item));
            }
           */
            #endregion

            #region Correct Answers
            //Q8 : Get the cheapest price among each category's products
            /*var Result28 = ProductList.GroupBy(p => p.Category);
            foreach(var item in Result28)
            {
                Console.WriteLine("Product category : " + item.Key + " --> " + item.Min(i => i.UnitPrice));
            }

            //Q8 Get the cheapest price among each category's products
            var Result28 = ProductList.GroupBy(p => p.ProductName).Min();
            Console.WriteLine(Result28);
            //Q9 Get the products with the cheapest price in each category (Use Let)
            /*var Result29 = ProductList.GroupBy(p => p.Category);
            foreach (var item in Result29)
            {
                Console.WriteLine("Product category : " + item.Key + " --> " + item.Min(i => i.UnitPrice));
            }*/
            #endregion

        }
    }
}