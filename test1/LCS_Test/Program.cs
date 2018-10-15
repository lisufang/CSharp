using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS_Test
{
    class LCS_Compute
    {
        #region 字符串数组公共子序列
        public static void getLCS(string[] str1, string[] str2)
        {
            string[] x = str1;// 将字符串对象中的字符转换为对象数组
            string[] y = str2;
            int[,] c = new int[x.Length + 1, y.Length + 1];// 定义c为输入的两个字符串转换的两个对象数组组成的二维数组，长度定义为两个字符串数组的长度+1
            /*
             这里利用两个循环嵌套，用第一个字符串数组依次去和第二个字符串数组比对
             */
            for (int i = 1; i <= x.Length; ++i)
            {
                for (int j = 1; j <= y.Length; ++j)
                {
                    // 当x[i - 1] == y[j - 1]时，说明x[i - 1]与y[j - 1] 一定在最长公共子序列中，
                    // 所以lcs (i , j) 是由lcs(i-1,j -1)之前的值决定的；即 lcs(i,j) = lcs(i-1, j-1) + 1
                    if (x[i - 1] == y[j - 1])
                        c[i, j] = c[i - 1, j - 1] + 1;
                    // 设在最长公共子序列中的最后一个值为zk，zk == xi, 那么最长公共子序列取决于去掉yj的y字符串数组与x字符串数组的最长公共子序列
                    else if (c[i - 1, j] < c[i, j - 1])
                        c[i, j] = c[i, j - 1];
                    // 若yj在最长公共子序列中，那么lcs(i, j) = lcs(i - 1, j)
                    else
                        c[i, j] = c[i - 1, j];
                }
            }
            printLCS(c, x, y, x.Length, y.Length);
        }
        public static void printLCS(int[,] c, string[] x, string[] y, int i, int j)
        {
            if (i == 0 || j == 0)
                return;
            if (x[i - 1] == y[j - 1])
            {
                printLCS(c, x, y, i - 1, j - 1);
                Console.WriteLine("{" + x[i - 1] + "}");
            }
            else if (c[i - 1, j] >= c[i, j - 1])
                printLCS(c, x, y, i - 1, j);
            else
                printLCS(c, x, y, i, j - 1);
        }
        #endregion
        #region 整形数组公共子序列
        public static void getLCS(int[] str1, int[] str2)
        {
            int[] x = str1;// 将字符串对象中的字符转换为对象数组
            int[] y = str2;
            int[,] c = new int[x.Length + 1, y.Length + 1];// 定义c为输入的两个字符串转换的两个对象数组组成的二维数组，长度定义为两个字符串数组的长度+1
            /*
             这里利用两个循环嵌套，用第一个字符串数组依次去和第二个字符串数组比对
             */
            for (int i = 1; i <= x.Length; ++i)
            {
                for (int j = 1; j <= y.Length; ++j)
                {
                    // 当x[i - 1] == y[j - 1]时，说明x[i - 1]与y[j - 1] 一定在最长公共子序列中，
                    // 所以lcs (i , j) 是由lcs(i-1,j -1)之前的值决定的；即 lcs(i,j) = lcs(i-1, j-1) + 1
                    if (x[i - 1] == y[j - 1])
                        c[i, j] = c[i - 1, j - 1] + 1;
                    // 设在最长公共子序列中的最后一个值为zk，zk == xi, 那么最长公共子序列取决于去掉yj的y字符串数组与x字符串数组的最长公共子序列
                    else if (c[i - 1, j] < c[i, j - 1])
                        c[i, j] = c[i, j - 1];
                    // 若yj在最长公共子序列中，那么lcs(i, j) = lcs(i - 1, j)
                    else
                        c[i, j] = c[i - 1, j];
                }
            }
            printLCS(c, x, y, x.Length, y.Length);
        }

        public static void printLCS(int[,] c, int[] x, int[] y, int i, int j)
        {
            if (i == 0 || j == 0)
                return;
            if (x[i - 1] == y[j - 1])
            {
                printLCS(c, x, y, i - 1, j - 1);
                Console.WriteLine("{" + x[i - 1] + "}");
            }
            else if (c[i - 1, j] >= c[i, j - 1])
                printLCS(c, x, y, i - 1, j);
            else
                printLCS(c, x, y, i, j - 1);
        }
        #endregion
        public static void Main(string[] args)
        {
            int[] list1 = { 34, 72, 13, 44, 25, 30, 10 };
            int[] list2 = { 34, 13, 44, 7, 25 };

            string[] str1 = { "abc", "def", "gh", "zwd" };
            string[] str2 = { "abc", "2", "def", "gh", "zwd" };
            string[] str3 = { "abc", "33" };

            //LCS.LCS<int> lcs_int = new LCS.LCS<int>(list1, list2);
            //LCS.LCS<string> lcs_string = new LCS.LCS<string>(str1, str2);
            //LCS.LCS<string> lcs_string3 = new LCS.LCS<string>(str1, str3);
            Console.WriteLine("lcs_int 的最长公共子序列：");
            getLCS(list1, list2);
            Console.WriteLine("lcs_string 的最长公共子序列：");
            getLCS(str1, str2);
            Console.WriteLine("lcs_string3 的最长公共子序列：");
            getLCS(str1, str3);
            Console.ReadKey();

        }
    }
}
