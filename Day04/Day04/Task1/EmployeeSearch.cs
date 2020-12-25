﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class EmployeeSearch
    {
        public Employee[] empSearch;
        public EmployeeSearch(Employee [] empMain)
        {
            empSearch = empMain;
        }

        //Bubble Sort
       public void sortByID()
        {
            int len;
            len = empSearch.Length;
            Employee temp;

            for(int i = 0; i < len-1; i++)
            {
                for(int j = 0; j < len - 2; j++)
                {
                    if(empSearch[i].Id > empSearch[j + 1].Id)
                    {
                        temp = empSearch[i];
                        empSearch[i]=empSearch[j+1];
                        empSearch[j + 1] = temp;
                    }
                }
            }
        }
        //Binary Search
        public Employee searchById(int idSearch)
        {
            sortByID();
            int len,left, right, mid=0;
            len = empSearch.Length;
            left = 0;right = len - 1;

            while (left <= right)
            {
                mid = (left + right) / 2;
                if (idSearch == empSearch[mid].Id) { mid++;break; }
                else if (idSearch > empSearch[mid].Id){ left = mid + 1; }
                else{right = mid - 1;}
            }
            mid--;
                return empSearch[mid];
            }

    }
}