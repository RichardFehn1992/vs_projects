using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vs_test.HelpClasses.Strings
{
    class StringHandler
    {
        private int str1RefLen, str2RefLen;
        private int startIdx1 = 0, startIdx2 = 0;
        private int equalCount = 0;

        // build str by strList, example: strList has two elements {my name} --> str = myname
        public void build_str_by_strList(ref string str, List<string> strList)
        {
            str = "";

            foreach (string strElement in strList)
            {
                str += strElement;
            }
        }

        // replace str by strCatchList and setStr
        // example: str = VisualStudio, strCatchList has two elements {a o} and setStr = "?" --> str = Visu?lStudi?
        public void replaceStr_by_strCatchList_and_setStr(ref string str, List<string> strCatchList, string setStr)
        {
            foreach (string catchStr in strCatchList)
            {
                str = str.Replace(catchStr, setStr);
            }
        }

        // check if str is numeric
        public bool strIsNumber(string str)
        {
            int n;
            return int.TryParse(str, out n);
        }

        // convert str to integer value
        public int strToInt(string str)
        {
            int n;
            int.TryParse(str, out n);

            return n;
        }

        // convert integer value to string
        public string intToStr(int val) 
        {
            return val.ToString();
        }

        // check if str occurs in strList
        public bool strInList(string str, List<string> strList)
        {
            return strList.Contains(str);
        }

        // reverse str
        public void reverse_str(ref string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            s = new string(charArray);
        }

        // check str1 and str2 and calculate equality percentage [%]
        // example: str1 = "hello", str2 = "hel" --> percentage = 60
        public void str1_str2_equal_percentage(string str1, string str2, ref double percentage)
        {
            str1RefLen = str1.Count();
            str2RefLen = str2.Count();

            int str1Len = str1.Count();
            string str1Remaining = str1.Substring(startIdx1);
            int str1Remaining_lastIdx = str1Remaining.Count() - 1;
            int str1RemainingLen = str1Remaining.Count();

            int str2Len = str2.Count();
            string str2Remaining = str2.Substring(startIdx2);
            int str2Remaining_lastIdx = str2Remaining.Count() - 1;
            int str2RemainingLen = str2Remaining.Count();

            double cMax = str1RefLen > str2RefLen ? str1RefLen : str2RefLen;

            if (str1RemainingLen <= 0 || str2RemainingLen <= 0)
            {
                double val = (double)equalCount * 100;
                val /= cMax;
                percentage = val;

                startIdx1 = 0;
                startIdx2 = 0;
                equalCount = 0;

                return;
            }

            bool updated = false;

            if (str1RemainingLen >= 1 && str2RemainingLen >= 1)
            {
                for (int i = 0; i < str1RemainingLen - 1; i++)
                {
                    startIdx1 = i;
                    int addIdx1 = startIdx1 == 0 ? 1 : 0;
                    string partStr1 = str1Remaining.Substring(startIdx1, 2);

                    for (int k = 0; k < str2RemainingLen - 1; k++)
                    {
                        startIdx2 = k;
                        int addIdx2 = startIdx2 == 0 ? 1 : 0;
                        string partStr2 = str2Remaining.Substring(startIdx2, 2);

                        if (partStr1 == partStr2)
                        {
                            startIdx1--;
                            startIdx2--;

                            updated = true;

                            while (partStr1 == partStr2)
                            {
                                startIdx1++;
                                startIdx2++;

                                if (startIdx1 >= str1RemainingLen || startIdx2 >= str2RemainingLen)
                                {
                                    goto go_on;
                                }

                                partStr1 = str1Remaining.Substring(startIdx1, 1);
                                partStr2 = str2Remaining.Substring(startIdx2, 1);

                                if (partStr1 != partStr2)
                                {
                                    goto go_on;
                                }
                                else
                                {
                                    equalCount++;
                                }
                            }
                        }
                    }
                }
            }

            go_on:

            if (updated)
            {
                str1_str2_equal_percentage(str1Remaining, str2Remaining, ref percentage);
            }
            else
            {
                double val = (double)equalCount * 100;
                val /= cMax;
                percentage = val;
            }
        }

        // extract numbers from str, example: str = "hello2_333 --> numbersList = {2, 333}
        public void extract_numbers_from_str(string str, ref List<int> numberList)
        {
            string str1Remaining = str.Substring(startIdx1);
            int str1Remaining_lastIdx = str1Remaining.Count() - 1;
            int str1RemainingLen = str1Remaining.Count();

            if (str1RemainingLen <= 0)
            {
                startIdx1 = 0; 
                return;
            }

            if (str1RemainingLen == 1)
            {
                if (strIsNumber(str1Remaining))
                {
                    numberList.Add(strToInt(str1Remaining));
                    return;
                }
            }

            int startRemainingIdx = 0;
            bool startFound = false;

            for (int i = startIdx1; i < str.Count(); i++)
            {
                string cStr = str.Substring(i, 1);

                if (strIsNumber(cStr))
                {
                    startRemainingIdx = i;
                    startFound = true;
                    break; 
                }
            }

            if (!startFound)
            {
                return;
            }

            string strFinal = "";
            startIdx1 = startRemainingIdx;

            for (int i = startRemainingIdx; i < str.Count(); i++)
            {
                string cStr = str.Substring(i, 1);
                startIdx1 = i;

                if (strIsNumber(cStr))
                {
                    strFinal = strFinal + cStr;
                }
                else
                {
                    numberList.Add(strToInt(strFinal));
                    break;
                }
            }

            if (startIdx1 < str.Count() - 1)
            {
                extract_numbers_from_str(str, ref numberList);
            }
            else
            {
                startIdx1 = 0;
                numberList.Add(strToInt(strFinal));
            }
        }
    }
}
