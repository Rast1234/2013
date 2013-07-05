using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace ����������_�������������
{

    class Program
    {
        

        static int CountWords(char[,] s, char s0, int j)
        {
            int count = 0;
            for (int i = 0; i < 6; i++)
                if (s[j, i] == s0) count++;
            return count;
        }

        static int poisk(char[,] C, char sym, int j)
        {

            for (int i = 0; i < 6; i++)
                if (C[j, i] == sym) return i;
            return -1;
        }

        static int status_eq(int n, int old)
        {

            if ( old==0 || n<old ) return n;
            return old;
        }

        static double dl(double X, double Y, double xw, double yd, double zh)
        {
            int[] temp = new int[3];
                if (X == xw)
                {
                    temp[0] = 1;
                }
                else if (X == yd)
                {
                    temp[1] = 1;
                }
                else temp[2] = 1;

                if (Y == xw && temp[0] != 1)
                {
                    temp[0] = 1;
                }
                else if (Y == yd && temp[1] != 1)
                {
                    temp[1] = 1;
                }
                else temp[2] = 1;

                if (temp[0] == 0) return xw;
                else if (temp[1] == 0) return yd;
                else return zh;
        }

        static string Rotat(char col1, int poz1, char col2,int poz2, char[,] M,int j)
        {
            char men;
            int kl;
            char[,] MM=new char[M.GetLength(0),6];
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];

            //1
           int x = poisk(MM, col1, j);
           int y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "FD";

            //2

           men = MM[j, 4]; MM[j, 4]= MM[j, 5]; MM[j, 5] = men;
           men = MM[j, 2]; MM[j, 2] = MM[j, 3]; MM[j, 3] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "FU";

            //3
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "FL";

            //4
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 2]; MM[j, 2] = MM[j, 5]; MM[j, 5] = MM[j, 3]; MM[j, 3] = MM[j, 4]; MM[j, 4] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "FR";

            //5
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 1]; MM[j, 1] = MM[j, 3]; MM[j, 3] = MM[j, 0]; MM[j, 0] = MM[j, 2]; MM[j, 2] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "DB";

            //6
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 1]; MM[j, 1] = MM[j, 3]; MM[j, 3] = MM[j, 0]; MM[j, 0] = MM[j, 2]; MM[j, 2] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "DF";

            //7
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 1]; MM[j, 1] = MM[j, 3]; MM[j, 3] = MM[j, 0]; MM[j, 0] = MM[j, 2]; MM[j, 2] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "DL";

            //8
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 1]; MM[j, 1] = MM[j, 3]; MM[j, 3] = MM[j, 0]; MM[j, 0] = MM[j, 2]; MM[j, 2] = men;
           men = MM[j, 2]; MM[j, 2] = MM[j, 5]; MM[j, 5] = MM[j, 3]; MM[j, 3] = MM[j, 4]; MM[j, 4] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "DR";

           //9
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "UL";

           //10
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
           men = MM[j, 2]; MM[j, 2] = MM[j, 5]; MM[j, 5] = MM[j, 3]; MM[j, 3] = MM[j, 4]; MM[j, 4] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "UR";

            //11
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "UF";

           //12
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "UB";

            //13
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
           men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "BL";

           //14
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
           men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
           men = MM[j, 2]; MM[j, 2] = MM[j, 5]; MM[j, 5] = MM[j, 3]; MM[j, 3] = MM[j, 4]; MM[j, 4] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "BR";

           //15
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
           men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "BU";

           //16
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
           men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "BD";

           //17
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 0]; MM[j, 0] = MM[j, 4]; MM[j, 4] = MM[j, 1]; MM[j, 1] = MM[j, 5]; MM[j, 5] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "LU";

            //18
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 0]; MM[j, 0] = MM[j, 4]; MM[j, 4] = MM[j, 1]; MM[j, 1] = MM[j, 5]; MM[j, 5] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "LD";

            //19
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 0]; MM[j, 0] = MM[j, 4]; MM[j, 4] = MM[j, 1]; MM[j, 1] = MM[j, 5]; MM[j, 5] = men;
           men = MM[j, 2]; MM[j, 2] = MM[j, 5]; MM[j, 5] = MM[j, 3]; MM[j, 3] = MM[j, 4]; MM[j, 4] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "LF";

           //20
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 0]; MM[j, 0] = MM[j, 4]; MM[j, 4] = MM[j, 1]; MM[j, 1] = MM[j, 5]; MM[j, 5] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "LB";

           //21
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 5]; MM[j, 5] = MM[j, 1]; MM[j, 1] = MM[j, 4]; MM[j, 4] = MM[j, 0]; MM[j, 0] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "RU";

            //22
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 5]; MM[j, 5] = MM[j, 1]; MM[j, 1] = MM[j, 4]; MM[j, 4] = MM[j, 0]; MM[j, 0] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "RD";

           //23
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 5]; MM[j, 5] = MM[j, 1]; MM[j, 1] = MM[j, 4]; MM[j, 4] = MM[j, 0]; MM[j, 0] = men;
           men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "RF";

           //24
           for (kl = 0; kl < 6; kl++)
               MM[j, kl] = M[j, kl];
           men = MM[j, 5]; MM[j, 5] = MM[j, 1]; MM[j, 1] = MM[j, 4]; MM[j, 4] = MM[j, 0]; MM[j, 0] = men;
           men = MM[j, 2]; MM[j, 2] = MM[j, 5]; MM[j, 5] = MM[j, 3]; MM[j, 3] = MM[j, 4]; MM[j, 4] = men;
           x = poisk(MM, col1, j);
           y = poisk(MM, col2, j);
           if (x == poz1 && y == poz2) return "RB";





           



            return "";
        }

        static string Rotat2(char col1, int poz1, char[,] M, int j)
        {
            char men;
            int kl;
            char[,] MM = new char[M.GetLength(0), 6];
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];

            //1
            int x = poisk(MM, col1, j);
            if (x == poz1 ) return "FD";

            //2

            men = MM[j, 4]; MM[j, 4] = MM[j, 5]; MM[j, 5] = men;
            men = MM[j, 2]; MM[j, 2] = MM[j, 3]; MM[j, 3] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "FU";

            //3
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "FL";

            //4
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 2]; MM[j, 2] = MM[j, 5]; MM[j, 5] = MM[j, 3]; MM[j, 3] = MM[j, 4]; MM[j, 4] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "FR";

            //5
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 1]; MM[j, 1] = MM[j, 3]; MM[j, 3] = MM[j, 0]; MM[j, 0] = MM[j, 2]; MM[j, 2] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "DB";

            //6
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 1]; MM[j, 1] = MM[j, 3]; MM[j, 3] = MM[j, 0]; MM[j, 0] = MM[j, 2]; MM[j, 2] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            x = poisk(MM, col1, j);
            if (x == poz1) return "DF";

            //7
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 1]; MM[j, 1] = MM[j, 3]; MM[j, 3] = MM[j, 0]; MM[j, 0] = MM[j, 2]; MM[j, 2] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "DL";

            //8
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 1]; MM[j, 1] = MM[j, 3]; MM[j, 3] = MM[j, 0]; MM[j, 0] = MM[j, 2]; MM[j, 2] = men;
            men = MM[j, 2]; MM[j, 2] = MM[j, 5]; MM[j, 5] = MM[j, 3]; MM[j, 3] = MM[j, 4]; MM[j, 4] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "DR";

            //9
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "UL";

            //10
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
            men = MM[j, 2]; MM[j, 2] = MM[j, 5]; MM[j, 5] = MM[j, 3]; MM[j, 3] = MM[j, 4]; MM[j, 4] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "UR";

            //11
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "UF";

            //12
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "UB";

            //13
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
            men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "BL";

            //14
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
            men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
            men = MM[j, 2]; MM[j, 2] = MM[j, 5]; MM[j, 5] = MM[j, 3]; MM[j, 3] = MM[j, 4]; MM[j, 4] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "BR";

            //15
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
            men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "BU";

            //16
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
            men = MM[j, 2]; MM[j, 2] = MM[j, 0]; MM[j, 0] = MM[j, 3]; MM[j, 3] = MM[j, 1]; MM[j, 1] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "BD";

            //17
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 0]; MM[j, 0] = MM[j, 4]; MM[j, 4] = MM[j, 1]; MM[j, 1] = MM[j, 5]; MM[j, 5] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "LU";

            //18
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 0]; MM[j, 0] = MM[j, 4]; MM[j, 4] = MM[j, 1]; MM[j, 1] = MM[j, 5]; MM[j, 5] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "LD";

            //19
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 0]; MM[j, 0] = MM[j, 4]; MM[j, 4] = MM[j, 1]; MM[j, 1] = MM[j, 5]; MM[j, 5] = men;
            men = MM[j, 2]; MM[j, 2] = MM[j, 5]; MM[j, 5] = MM[j, 3]; MM[j, 3] = MM[j, 4]; MM[j, 4] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "LF";

            //20
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 0]; MM[j, 0] = MM[j, 4]; MM[j, 4] = MM[j, 1]; MM[j, 1] = MM[j, 5]; MM[j, 5] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "LB";

            //21
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 5]; MM[j, 5] = MM[j, 1]; MM[j, 1] = MM[j, 4]; MM[j, 4] = MM[j, 0]; MM[j, 0] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "RU";

            //22
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 5]; MM[j, 5] = MM[j, 1]; MM[j, 1] = MM[j, 4]; MM[j, 4] = MM[j, 0]; MM[j, 0] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "RD";

            //23
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 5]; MM[j, 5] = MM[j, 1]; MM[j, 1] = MM[j, 4]; MM[j, 4] = MM[j, 0]; MM[j, 0] = men;
            men = MM[j, 4]; MM[j, 4] = MM[j, 3]; MM[j, 3] = MM[j, 5]; MM[j, 5] = MM[j, 2]; MM[j, 2] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "RF";

            //24
            for (kl = 0; kl < 6; kl++)
                MM[j, kl] = M[j, kl];
            men = MM[j, 5]; MM[j, 5] = MM[j, 1]; MM[j, 1] = MM[j, 4]; MM[j, 4] = MM[j, 0]; MM[j, 0] = men;
            men = MM[j, 2]; MM[j, 2] = MM[j, 5]; MM[j, 5] = MM[j, 3]; MM[j, 3] = MM[j, 4]; MM[j, 4] = men;
            x = poisk(MM, col1, j);
            if (x == poz1 ) return "RB";









            return "";
        }


        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double w, d, h;          //������� ��������� ����
            string Colour_I = null;    //����� ��������� ����
            int n, i, j;                   //���������� ������, �� ������� ��������� �������� ���

            string line;
            string[] SP = new string[4];

            line = Console.ReadLine();
            SP = line.Split(' ');
            w = Convert.ToDouble(SP[0]); //����� - ���
            d = Convert.ToDouble(SP[1]); //������
            h = Convert.ToDouble(SP[2]); //������
            Colour_I = SP[3];

            line = Console.ReadLine();
            n = Convert.ToInt32( line); //���������� ������
            double[] t_w = new double[n];
            double[] t_d = new double[n];
            double[] t_h = new double[n];

            int[] status = new int[n]; // ������ ����� ��������� ������� ����������� ���
            int[,] inv = new int[27,n+1]; //�������� ������ ��� status. index

            char[,] t_Colour = new char[n, 6];
            char[,] PN = new char[n, 2];      // ���� ��������. ���� ������
            double[,] CorN = new double[n, 3]; //��� ���������� ������ ����� �������� �������
            int ver_0_0_0=0; //������� 000
            int ver_w_d_h=0;//

            int dl1 = 0; //���������� ���������� ������� � ����� 9
            int dl2 = 0; //���������� ���������� ������� � ����� 10
            int dl3 = 0; //���������� ���������� ������� � ����� 11
            bool[,] Bool; //������/�������� �����

            double men;
            i = 0;
            while (i < n)
            {
                //������ �� ������
                //��������� ������ � ������� �����...
                //line = file.ReadLine();
                line = Console.ReadLine();
                SP = line.Split(' ');
                t_w[i] = Convert.ToDouble(SP[0]); //����� - ���
                t_d[i] = Convert.ToDouble(SP[1]); //������
                t_h[i] = Convert.ToDouble(SP[2]); //������
                for (j = 0; j < 6; j++)
                    t_Colour[i, j] = SP[3][j];


                if (poisk(t_Colour, Colour_I[0], i) > -1) //���� �������� ����?
                {
                    //status[i] = 21;
                    status[i]=status_eq(21,status[i]);
                    if (poisk(t_Colour, Colour_I[2], i) > -1) //������
                    {
                        //status[i] = 9;
                        status[i] = status_eq(9, status[i]);
                        if (poisk(t_Colour, Colour_I[4], i) > -1)// ����� ����
                        {
                            //status[i] = 1;
                            status[i] = status_eq(1, status[i]);
                        }
                         if (poisk(t_Colour, Colour_I[5], i) > -1)//������ ����
                        {
                            //status[i] = 3;
                            status[i] = status_eq(3, status[i]);
                        }
                    }

                     if (poisk(t_Colour, Colour_I[3], i) > -1) //�������
                    {
                        //status[i] = 17;
                        status[i] = status_eq(17, status[i]);
                        if (poisk(t_Colour, Colour_I[4], i) > -1)// ����� ����
                        {
                            //status[i] = 4;
                            status[i] = status_eq(4, status[i]);
                        }
                         if (poisk(t_Colour, Colour_I[5], i) > -1)//������ ����
                        {
                            //status[i] = 5;
                            status[i] = status_eq(5, status[i]);
                        }
                    }
                     if (poisk(t_Colour, Colour_I[4], i) > -1) //����� ����
                    {
                        //status[i] = 10;
                        status[i] = status_eq(10, status[i]);
                    }
                     if (poisk(t_Colour, Colour_I[5], i) > -1) //������ ����
                    {
                        //status[i] = 19;
                        status[i] = status_eq(19, status[i]);
                    }
                }

                 if (poisk(t_Colour, Colour_I[1], i) > -1) //��� ���������. � ������ ����
                {
                    //status[i] = 26;
                    status[i] = status_eq(26, status[i]);
                    if (poisk(t_Colour, Colour_I[3], i) > -1) //�������
                    {
                       // status[i] = 15;
                        status[i] = status_eq(15, status[i]);
                        if (poisk(t_Colour, Colour_I[5], i) > -1)//������ ����
                        {
                            //status[i] = 2;
                            status[i] = status_eq(2, status[i]);
                        }

                         if (poisk(t_Colour, Colour_I[4], i) > -1)// ����� ����
                        {
                            //status[i] = 6;
                            status[i] = status_eq(6, status[i]);
                        }
                    }

                     if (poisk(t_Colour, Colour_I[2], i) > -1) //������
                    {
                        status[i] = status_eq(13, status[i]);
                        //status[i] = 13;
                        if (poisk(t_Colour, Colour_I[4], i) > -1)// ����� ����
                        {
                           // status[i] = 7;
                            status[i] = status_eq(7, status[i]);
                        }
                         if (poisk(t_Colour, Colour_I[5], i) > -1)//������ ����
                        {
                            //status[i] = 8;
                            status[i] = status_eq(8, status[i]);
                        }
                    }
                     if (poisk(t_Colour, Colour_I[4], i) > -1) //����� ����
                    {
                        //status[i] = 20;
                        status[i] = status_eq(20, status[i]);
                    }
                     if (poisk(t_Colour, Colour_I[5], i) > -1) //������ ����
                    {
                        //status[i] = 18;
                        status[i] = status_eq(18, status[i]);
                    }
                }

                 if (poisk(t_Colour, Colour_I[4], i) > -1)//��� �� ��������� �� �������. � �����?
                {
                    status[i] = status_eq(23, status[i]);
                    //status[i] = 23;
                    if (poisk(t_Colour, Colour_I[2], i) > -1)//������
                    {
                        //status[i] = 11;
                        status[i] = status_eq(11, status[i]);
                    }
                     if (poisk(t_Colour, Colour_I[3], i) > -1)//�������
                    {
                        //status[i] = 14;
                        status[i] = status_eq(14, status[i]);
                    }
                }

                 if (poisk(t_Colour, Colour_I[5], i) > -1) //��� ���������, �������, ������. � ������?
                {
                    //status[i]=25;
                    status[i] = status_eq(25, status[i]);
                    if (poisk(t_Colour, Colour_I[2], i) > -1)//������
                    {
                        //status[i] = 12;
                        status[i] = status_eq(12, status[i]);
                    }
                     if (poisk(t_Colour, Colour_I[3], i) > -1)//�������
                    {
                        //status[i] = 16;
                        status[i] = status_eq(16, status[i]);
                    }

                }

                 if (poisk(t_Colour, Colour_I[3], i) > -1)//������� ������?
                {
                   // status[i] = 24;
                    status[i] = status_eq(24, status[i]);
                }
                 if (poisk(t_Colour, Colour_I[2], i) > -1)//������ ������?
                {
                   // status[i] = 22;
                    status[i] = status_eq(22, status[i]);
                }

                //������� ��� ������ �� ����� ��������
                //.....
                i++;
            }



            //������ �������������� ������� status
            for (i = 0; i < 27; i++)
            {
                int k=0;
                for (j = 0; j < n; j++)
                {
                    if (status[j] == i)
                    {
                        inv[i, k] = j;
                        k++;
                    }
                }
                inv[i, k] = -1;// ������� ������������� ����� ������� ���� � ������ �������
            }


            //������������ ������� ���� 1
            i = inv[1, 0];
            string g = Rotat(Colour_I[0], 0, Colour_I[2], 2, t_Colour, i);//////<---------------------
            PN[i, 0] = g[0];
            PN[i, 1] = g[1];
            if (g[0] == 'F' || g[0] == 'B')
            {
                if (g[1] == 'L' || g[1] == 'R')
                {
                    men = t_h[i]; t_h[i] = t_d[i]; t_d[i] = men;
                }
            }

            if (g[0] == 'U' || g[0] == 'D')
            {
                men = t_w[i]; t_w[i] = t_d[i]; t_d[i] = men;
                if (g[1] == 'L' || g[1] == 'R')
                {
                    men = t_h[i]; t_h[i] = t_d[i]; t_d[i] = men;
                }
                else if (g[1] == 'F' || g[1] == 'B')
                {
                    //������� �� �����������
                }
            }

            if (g[0] == 'L' || g[0] == 'R')
            {
                men = t_w[i]; t_w[i] = t_h[i]; t_h[i] = men;
                if (g[1] == 'U' || g[1] == 'D')
                {
                    //������� �� �����������
                }
                else if (g[1] == 'F' || g[1] == 'B')
                {

                    men = t_h[i]; t_h[i] = t_d[i]; t_d[i] = men;
                }
            }
            ver_0_0_0 = i;
            CorN[i, 0] = 0; CorN[i, 1] = 0; CorN[i, 2] = 0;

            //������������ ������� ���� 6
            // ��� ����� ����, ���� n>1
            if (n > 1)
            {
                i = inv[2, 0];
                g = Rotat(Colour_I[1], 1, Colour_I[3], 3, t_Colour, i);//////<---------------------
                PN[i, 0] = g[0];
                PN[i, 1] = g[1];
                if (g[0] == 'F' || g[0] == 'B')
                {
                    if (g[1] == 'L' || g[1] == 'R')
                    {
                        men = t_h[i]; t_h[i] = t_d[i]; t_d[i] = men;
                    }
                }

                if (g[0] == 'U'||g[0]=='D')
                {
                    men = t_w[i]; t_w[i] = t_d[i]; t_d[i] = men;
                    if (g[1] == 'L' || g[1] == 'R')
                    {
                        men = t_h[i]; t_h[i] = t_d[i]; t_d[i] = men;
                    }
                    else if (g[1] == 'F' || g[1] == 'B')
                    {
                      //������� �� �����������
                    }
                }

                if (g[0] == 'L' || g[0] == 'R')
                {
                    men = t_w[i]; t_w[i] = t_h[i]; t_h[i] = men;
                    if (g[1] == 'U' || g[1] == 'D')
                    {
                        //������� �� �����������
                    }
                    else if (g[1] == 'F' || g[1] == 'B')
                    {
                        
                        men = t_h[i]; t_h[i] = t_d[i]; t_d[i] = men;
                    }
                }

                ver_w_d_h = i;
                CorN[i, 0] = w - t_w[i]; CorN[i, 1] = d - t_d[i]; CorN[i, 2] = h - t_h[i];

              
            }

            if (inv[4, 0] != -1)
            {
                i = inv[4, 0];
               // x = poisk(t_Colour, Colour_I[0], i); //�����
               // y = poisk(t_Colour, Colour_I[3], i); //����
                g = Rotat(Colour_I[0], 0, Colour_I[3], 3, t_Colour, i);
                PN[i, 0] = g[0];
                PN[i, 1] = g[1];
                CorN[i, 0] = 0; CorN[i, 1] = d - t_d[ver_w_d_h]; CorN[i, 2] = 0;
            }

            if (inv[5, 0] != -1)
            {
                i = inv[5, 0];
                //x = poisk(t_Colour, Colour_I[0], i); //�����
               // y = poisk(t_Colour, Colour_I[3], i); //����
                g = Rotat(Colour_I[0], 0, Colour_I[3], 3, t_Colour, i);
                PN[i, 0] = g[0];
                PN[i, 1] = g[1];
                CorN[i, 0] = 0; CorN[i, 1] = d - t_d[ver_w_d_h]; CorN[i, 2] = h - t_h[ver_w_d_h];
            }

            if (inv[3, 0] != -1)
            {
                i = inv[3, 0];
                //x = poisk(t_Colour, Colour_I[0], i); //�����
                //y = poisk(t_Colour, Colour_I[2], i); //���
                g = Rotat(Colour_I[0], 0, Colour_I[2], 2, t_Colour, i);
                PN[i, 0] = g[0];
                PN[i, 1] = g[1];
                CorN[i, 0] = 0; CorN[i, 1] = 0; CorN[i, 2] = h - t_h[ver_w_d_h];
            }

            //������ �������
            if (inv[6, 0] != -1)
            {
                i = inv[6, 0];
                //x = poisk(t_Colour, Colour_I[1], i); //���
               // y = poisk(t_Colour, Colour_I[3], i); //����
                g = Rotat(Colour_I[1], 1, Colour_I[3], 3, t_Colour, i);
                PN[i, 0] = g[0];
                PN[i, 1] = g[1];
                CorN[i, 0] = w - t_w[ver_w_d_h]; CorN[i, 1] = d - t_d[ver_w_d_h]; CorN[i, 2] = 0;
            }

            if (inv[7, 0] != -1)
            {
                i = inv[7, 0];
                //x = poisk(t_Colour, Colour_I[1], i); //���
               // y = poisk(t_Colour, Colour_I[2], i); //���
                g = Rotat(Colour_I[1], 1, Colour_I[2], 2, t_Colour, i);
                PN[i, 0] = g[0];
                PN[i, 1] = g[1];
                CorN[i, 0] = w - t_w[ver_w_d_h]; CorN[i, 1] = 0; CorN[i, 2] = 0;
            }

            if (inv[8, 0] != -1)
            {
                i = inv[8, 0];
                //x = poisk(t_Colour, Colour_I[1], i); //���
                //y = poisk(t_Colour, Colour_I[2], i); //���
                g = Rotat(Colour_I[1], 1, Colour_I[2], 2, t_Colour, i);
                PN[i, 0] = g[0];
                PN[i, 1] = g[1];
                CorN[i, 0] = w - t_w[ver_w_d_h]; CorN[i, 1] = 0; CorN[i, 2] = h - t_h[ver_w_d_h];
            }

         

            //������� ����� ����� 12,10 , 14, 16 (9,17,15,13)
            // � ������ �� � ������ t_w, ��� ��� ��������� ������ ��� ��� �� �����
            i=0;
            while (inv[9, i] != -1)
            {
                j=inv[9, i];
                t_w[j] = dl(t_w[ver_0_0_0], t_d[ver_0_0_0], t_w[j], t_d[j], t_h[j]);
                i++;
            }
            dl1 = i;
            i = 0;
            while (inv[17, i] != -1)
            {
                j = inv[17, i];
                t_w[j] = dl(t_w[ver_0_0_0], t_d[ver_w_d_h], t_w[j], t_d[j], t_h[j]);
                i++;
            }
            i = 0;
            while (inv[15, i] != -1)
            {
                j = inv[15, i];
                t_w[j] = dl(t_w[ver_w_d_h], t_d[ver_w_d_h], t_w[j], t_d[j], t_h[j]);
                i++;
            }
            i = 0;
            while (inv[13, i] != -1)
            {
                j = inv[13, i];
                t_w[j] = dl(t_w[ver_w_d_h], t_d[ver_0_0_0], t_w[j], t_d[j], t_h[j]);

                i++;
            }


            //������ ���� �� ����������� �� ����������� ����..

            int[] rebro = new int[] { 9, 17, 15, 13 };
            for (int kl = 0; kl < 4; kl++)
            {
                int  ind, per;
                i = 0;
                double min = 0;
                while (inv[rebro[kl], i] != -1)
                {

                    min = t_w[inv[rebro[kl], i]];
                    ind = i;
                    j=i+1;
                    while (inv[rebro[kl], j] != -1)
                    {
                        if (min > t_w[inv[rebro[kl], j]]) { min = t_w[inv[rebro[kl], j]]; ind = j; }
                        j++;
                    }
                    //������ �������
                    per = inv[rebro[kl], i];
                    inv[rebro[kl], i] = inv[rebro[kl], ind];
                    inv[rebro[kl], ind] = per;
                    i++;
                }

            }


 

            //�������� ��� �� 9 �����     
            double rt;// ����� �����������

            i = 0;
            rt = t_h[ver_0_0_0];
            while (inv[9, i] != -1)
            {
                j = inv[9, i];
                CorN[j, 0] = 0; CorN[j, 1] = 0; CorN[j, 2] = rt; rt += t_w[j];

               g= Rotat(Colour_I[0], 0, Colour_I[2], 2, t_Colour,j);//////<---------------------
               PN[j, 0] = g[0];
               PN[j, 1] = g[1];

                i++;
            }


            //�������� ��� �� 17 �����
            i = 0;
            rt = t_h[ver_0_0_0];         
            while (inv[17, i] != -1)
            {
                j = inv[17, i];
                CorN[j, 0] = 0; CorN[j, 1] = d-t_d[ver_w_d_h]; CorN[j, 2] = rt; rt += t_w[j];
                //x = poisk(t_Colour, Colour_I[0], j);
                //y = poisk(t_Colour, Colour_I[3], j);
                g = Rotat(Colour_I[0], 0, Colour_I[3], 3, t_Colour, j);//////<---------------------
                PN[j, 0] = g[0];
                PN[j, 1] = g[1];
                
                i++;
            }

            //�������� ��� �� 15 �����
            i = 0;
            rt = t_h[ver_0_0_0];          
            while (inv[15, i] != -1)
            {
                j = inv[15, i];
                CorN[j, 0] = w-t_w[ver_w_d_h]; CorN[j, 1] = d - t_d[ver_w_d_h]; CorN[j, 2] = rt; rt += t_w[j];
                //x = poisk(t_Colour, Colour_I[1], j);
                //y = poisk(t_Colour, Colour_I[3], j);
                g = Rotat(Colour_I[1], 1, Colour_I[3], 3, t_Colour, j);//////<---------------------
                PN[j, 0] = g[0];
                PN[j, 1] = g[1];
                i++;
            }

            //�������� ��� �� 13 �����
            i = 0;
            rt = t_h[ver_0_0_0];
            while (inv[13, i] != -1)
            {
                j = inv[13, i];
                CorN[j, 0] = w - t_w[ver_w_d_h]; CorN[j, 1] = 0; CorN[j, 2] = rt; rt += t_w[j];
                //x = poisk(t_Colour, Colour_I[1], j);
               // y = poisk(t_Colour, Colour_I[2], j);
                g = Rotat(Colour_I[1], 1, Colour_I[2], 2, t_Colour, j);//////<---------------------
                PN[j, 0] = g[0];
                PN[j, 1] = g[1];
                i++;
            }



            //������� ����� ����� 9,13 , 15, 11 (10,20,18,19)
            // � ������ �� � ������ t_w, ��� ��� ��������� ������ ��� ��� �� �����
            i = 0;
            while (inv[10, i] != -1)
            {
                j = inv[10, i];
                t_w[j] = dl(t_w[ver_0_0_0], t_h[ver_0_0_0], t_w[j], t_d[j], t_h[j]);
                i++;
            }
            dl2 = i;
            i = 0;
            while (inv[19, i] != -1)
            {
                j = inv[19, i];
                t_w[j] = dl(t_w[ver_0_0_0], t_h[ver_w_d_h], t_w[j], t_d[j], t_h[j]);
                i++;
            }
            i = 0;
            while (inv[18, i] != -1)
            {

                j = inv[18, i];
                t_w[j] = dl(t_w[ver_w_d_h], t_h[ver_w_d_h], t_w[j], t_d[j], t_h[j]);
                i++;
            }
            i = 0;
            while (inv[20, i] != -1)
            {

                j = inv[20, i];
                t_w[j] = dl(t_w[ver_w_d_h], t_h[ver_0_0_0], t_w[j], t_d[j], t_h[j]);

                i++;
            }


            //������ ���� �� ����������� �� ����������� ����..

            rebro = new int[] { 10, 20, 18, 19 };
            for (int kl = 0; kl < 4; kl++)
            {
                int ind, per;
                i = 0;
                double min = 0;
                while (inv[rebro[kl], i] != -1)
                {

                    min = t_w[inv[rebro[kl], i]];
                    ind = i;
                    j = i + 1;
                    while (inv[rebro[kl], j] != -1)
                    {
                        if (min > t_w[inv[rebro[kl], j]]) { min = t_w[inv[rebro[kl], j]]; ind = j; }
                        j++;
                    }
                    //������ �������
                    per = inv[rebro[kl], i];
                    inv[rebro[kl], i] = inv[rebro[kl], ind];
                    inv[rebro[kl], ind] = per;
                    i++;
                }

            }
           

            //�������� ��� �� 10 �����
            i = 0;
            rt = t_d[ver_0_0_0];
            while (inv[10, i] != -1)
            {
                j = inv[10, i];
                CorN[j, 0] = 0; CorN[j, 1] = rt; CorN[j, 2] = 0; rt += t_w[j];
                //x = poisk(t_Colour, Colour_I[0], j);
                //y = poisk(t_Colour, Colour_I[4], j);
                g = Rotat(Colour_I[0], 0, Colour_I[4], 4, t_Colour, j);//////<---------------------
                PN[j, 0] = g[0];
                PN[j, 1] = g[1];          
                i++;
            }

            //�������� ��� �� 19 �����
            i = 0;
            rt = t_d[ver_0_0_0];
            while (inv[19, i] != -1)
            {
                j = inv[19, i];
                CorN[j, 0] = 0; CorN[j, 1] = rt; CorN[j, 2] = h - t_h[ver_w_d_h]; rt += t_w[j];
                //x = poisk(t_Colour, Colour_I[0], j);
                //y = poisk(t_Colour, Colour_I[5], j);
                g = Rotat(Colour_I[0], 0, Colour_I[5], 5, t_Colour, j);//////<---------------------
                PN[j, 0] = g[0];
                PN[j, 1] = g[1]; 
               
                i++;
            }


            //�������� ��� �� 20 �����
            i = 0;
            rt = t_d[ver_0_0_0];
            while (inv[20, i] != -1)
            {
                j = inv[20, i];
                CorN[j, 0] = w - t_w[ver_w_d_h]; CorN[j, 1] = rt; CorN[j, 2] = 0; rt += t_w[j];
                //x = poisk(t_Colour, Colour_I[1], j);
                //y = poisk(t_Colour, Colour_I[4], j);
                g = Rotat(Colour_I[1], 1, Colour_I[4], 4, t_Colour, j);//////<---------------------
                PN[j, 0] = g[0];
                PN[j, 1] = g[1]; 
                i++;
            }

            //�������� ��� �� 18 �����
            i = 0;
            rt = t_d[ver_0_0_0];
            while (inv[18, i] != -1)
            {
                j = inv[18, i];
                CorN[j, 0] = w - t_w[ver_w_d_h]; CorN[j, 1] = rt; CorN[j, 2] = h - t_h[ver_w_d_h]; rt += t_w[j];
                //x = poisk(t_Colour, Colour_I[1], j);
                //y = poisk(t_Colour, Colour_I[5], j);
                g = Rotat(Colour_I[1], 1, Colour_I[5], 5, t_Colour, j);//////<---------------------
                PN[j, 0] = g[0];
                PN[j, 1] = g[1]; 
                i++;
            }

          
            //������� ����� ����� 17,18 , 19, 20 (11,14,16,12)
            // � ������ �� � ������ t_w, ��� ��� ��������� ������ ��� ��� �� �����
            i = 0;
            while (inv[11, i] != -1)
            {
                j = inv[11, i];
                t_w[j] = dl(t_d[ver_0_0_0], t_h[ver_0_0_0], t_w[j], t_d[j], t_h[j]);
                i++;
            }
            dl3 = i;
            i = 0;
            while (inv[12, i] != -1)
            {
                j = inv[12, i];
                t_w[j] = dl(t_d[ver_0_0_0], t_h[ver_w_d_h], t_w[j], t_d[j], t_h[j]);
                i++;
            }
            i = 0;
            while (inv[16, i] != -1)
            {
                j = inv[16, i];
                t_w[j] = dl(t_d[ver_w_d_h], t_h[ver_w_d_h], t_w[j], t_d[j], t_h[j]);
                i++;
            }
            i = 0;
            while (inv[14, i] != -1)
            {

                j = inv[14, i];
                t_w[j] = dl(t_d[ver_w_d_h], t_h[ver_0_0_0], t_w[j], t_d[j], t_h[j]);
                i++;
            }

            //�����������
            rebro = new int[] { 11, 14, 16, 12 };
            for (int kl = 0; kl < 4; kl++)
            {
                int ind, per;
                i = 0;
                double min = 0;
                while (inv[rebro[kl], i] != -1)
                {

                    min = t_w[inv[rebro[kl], i]];
                    ind = i;
                    j = i + 1;
                    while (inv[rebro[kl], j]!= -1)
                    {
                        if (min > t_w[inv[rebro[kl], j]]) { min = t_w[inv[rebro[kl], j]]; ind = j; }
                        j++;
                    }
                    //������ �������
                    per = inv[rebro[kl], i];
                    inv[rebro[kl], i] = inv[rebro[kl], ind];
                    inv[rebro[kl], ind] = per;
                    i++;
                }

            }



            //������������ ����� 11..
            //�������� ��� �� 11 �����
            i = 0;
            rt = t_w[ver_0_0_0];
            while (inv[11, i] != -1)
            {
                j = inv[11, i];
                CorN[j, 0] = rt; CorN[j, 1] = 0; CorN[j, 2] = 0; rt += t_w[j];
                //x = poisk(t_Colour, Colour_I[4], j);//�����
                //y = poisk(t_Colour, Colour_I[2], j);//���
                g = Rotat(Colour_I[4], 4, Colour_I[2], 2, t_Colour, j);//////<---------------------
                PN[j, 0] = g[0];
                PN[j, 1] = g[1];
               
                i++;
            }



            //�������� ��� �� 14 �����
            i = 0;
            rt = t_w[ver_0_0_0];
            while (inv[14, i] != -1)
            {
                j = inv[14, i];
                CorN[j, 0] = rt; CorN[j, 1] = d-t_d[ver_w_d_h]; CorN[j, 2] = 0; rt += t_w[j];
                g = Rotat(Colour_I[4], 4, Colour_I[3], 3, t_Colour, j);//////<---------------------
                PN[j, 0] = g[0];
                PN[j, 1] = g[1];
                i++;
            }

            //�������� ��� �� 16 �����
            i = 0;
            rt = t_w[ver_0_0_0];        
            while (inv[16, i] != -1)
            {
                j = inv[16, i];
                CorN[j, 0] = rt; CorN[j, 1] = d - t_d[ver_w_d_h]; CorN[j, 2] = h - t_h[ver_w_d_h]; rt += t_w[j];
                g = Rotat(Colour_I[3], 3, Colour_I[5], 5, t_Colour, j);//////<---------------------
                PN[j, 0] = g[0];
                PN[j, 1] = g[1];
                i++;
            }

            //�������� ��� �� 12 �����
            i = 0;
            rt = t_w[ver_0_0_0];
            while (inv[12, i] != -1)
            {
                j = inv[12, i];
                CorN[j, 0] = rt; CorN[j, 1] = 0; CorN[j, 2] = h - t_h[ver_w_d_h]; rt += t_w[j];
                g = Rotat(Colour_I[2], 2, Colour_I[5], 5, t_Colour, j);//////<---------------------
                PN[j, 0] = g[0];
                PN[j, 1] = g[1];
                i++;
            }




            // ��������� ������� � ����������� � ��������� 21
            Bool = null;
            if(dl1>1 && dl2>1) Bool = new bool[dl1, dl2];
            else if (dl1 > 0)
            {
                Bool = new bool[dl1,1];
            }
            else if(dl2>0)
            {
                Bool = new bool[1,dl2];
            }
            i = 0;
            while (inv[21, i] != -1)
            {
                j = inv[21, i];
                g = Rotat2(Colour_I[0], 0, t_Colour, j);//////<---------------------

                if (g[0] == 'F' || g[0] == 'B'){if (g[1] == 'L' || g[1] == 'R'){men = t_h[j]; t_h[j] = t_d[j]; t_d[j] = men;}}
                if (g[0] == 'U' || g[0] == 'D'){men = t_w[j]; t_w[j] = t_d[j]; t_d[j] = men;if (g[1] == 'L' || g[1] == 'R'){men = t_h[j]; t_h[j] = t_d[j]; t_d[j] = men;}}
                if (g[0] == 'L' || g[0] == 'R'){men = t_w[j]; t_w[j] = t_h[j]; t_h[j] = men;if (g[1] == 'F' || g[1] == 'B'){men = t_h[j]; t_h[j] = t_d[j]; t_d[j] = men;}}

                bool post = false;
                for (int k = 0; k < dl1; k++)
                {
                    for (int l = 0; l < dl2; l++)
                    {
                        if (!Bool[k, l] && t_h[j] == t_w[inv[9, k]] && t_d[j] == t_w[inv[10, l]])
                        {
                            Bool[k, l] = true;//������ �����
                            PN[j, 0] = g[0];//�������� ��� ���������
                            PN[j, 1] = g[1];
                            CorN[j, 0] = 0; CorN[j, 1] = CorN[inv[10, l], 1]; CorN[j, 2] = CorN[inv[9, k], 2];
                            post = true;
                        }
                    }
                }
                if (!post)
                {
                    for (int k = 0; k < dl1; k++)
                    {
                        for (int l = 0; l < dl2; l++)
                        {
                            if (!Bool[k, l] && t_d[j] == t_w[inv[9, k]] && t_h[j] == t_w[inv[10, l]])
                            {
                                Bool[k, l] = true;//������ �����
                                PN[j, 0] = g[0];//�������� ��� �� ���������
                                if (g[0] == 'F' || g[0] == 'B'){if (g[1] == 'L' || g[1] == 'R') PN[j, 1] = 'D';else PN[j, 1] = 'R';}
                                else if (g[0] == 'L' || g[0] == 'R'){if (g[1] == 'F' || g[1] == 'B') PN[j, 1] = 'D';else PN[j, 1] = 'B';}
                                else{if (g[1] == 'F' || g[1] == 'B') PN[j, 1] = 'R';else PN[j, 1] = 'B';}
                                CorN[j, 0] = 0; CorN[j, 1] = CorN[inv[10, l], 1]; CorN[j, 2] = CorN[inv[9, k], 2];
                            }
                        }
                    }
                }

                i++;
            }




            // ��������� ������� � ����������� � ��������� 22
            Bool = null;
            if (dl1 > 1 && dl3 > 1) Bool = new bool[dl1, dl3];
            else if (dl1 > 0)
            {
                Bool = new bool[dl1, 1];
            }
            else if (dl3 > 0)
            {
                Bool = new bool[1, dl3];
            }
            i = 0;
            while (inv[22, i] != -1)
            {
                j = inv[22, i];
                g = Rotat2(Colour_I[2], 2, t_Colour, j);//////<---------------------

                if (g[0] == 'F' || g[0] == 'B') { if (g[1] == 'L' || g[1] == 'R') { men = t_h[j]; t_h[j] = t_d[j]; t_d[j] = men; } }
                if (g[0] == 'U' || g[0] == 'D') { men = t_w[j]; t_w[j] = t_d[j]; t_d[j] = men; if (g[1] == 'L' || g[1] == 'R') { men = t_h[j]; t_h[j] = t_d[j]; t_d[j] = men; } }
                if (g[0] == 'L' || g[0] == 'R') { men = t_w[j]; t_w[j] = t_h[j]; t_h[j] = men; if (g[1] == 'F' || g[1] == 'B') { men = t_h[j]; t_h[j] = t_d[j]; t_d[j] = men; } }

                bool post = false;
                for (int k = 0; k < dl1; k++)
                {
                    for (int l = 0; l < dl3; l++)
                    {
                        if (!Bool[k, l] && t_h[j] == t_w[inv[9, k]] && t_w[j] == t_w[inv[11, l]])
                        {
                            Bool[k, l] = true;//������ �����
                            PN[j, 0] = g[0];//�������� ��� ���������
                            PN[j, 1] = g[1];
                            CorN[j, 0] = CorN[inv[11, l], 0]; CorN[j, 1] = 0; CorN[j, 2] = CorN[inv[9, k], 2];
                            post = true;
                        }
                    }
                }
                if (!post)
                {
                    for (int k = 0; k < dl1; k++)
                    {
                        for (int l = 0; l < dl3; l++)
                        {
                            if (!Bool[k, l] && t_w[j] == t_w[inv[9, k]] && t_h[j] == t_w[inv[11, l]])
                            {
                                Bool[k, l] = true;//������ �����
                                PN[j, 1] = g[1];//�������� ��� �� ���������
                                if (g[1] == 'F' || g[1] == 'B') { if (g[0] == 'L' || g[0] == 'R') PN[j, 0] = 'D'; else PN[j, 0] = 'R'; }
                                else if (g[1] == 'L' || g[1] == 'R') { if (g[0] == 'F' || g[0] == 'B') PN[j, 0] = 'D'; else PN[j, 0] = 'B'; }
                                else { if (g[0] == 'F' || g[0] == 'B') PN[j, 0] = 'R'; else PN[j, 0] = 'B'; }
                                CorN[j, 0] = CorN[inv[11, l], 0]; CorN[j, 1] = 0; CorN[j, 2] = CorN[inv[9, k], 2];
                            }
                        }
                    }
                }

                i++;
            }


            // ��������� ������� � ����������� � ��������� 23
            Bool = null;
            if (dl2 > 1 && dl3 > 1) Bool = new bool[dl2, dl3];
            else if (dl2 > 0)
            {
                Bool = new bool[dl2, 1];
            }
            else if (dl3 > 0)
            {
                Bool = new bool[1, dl3];
            }
            i = 0;
            while (inv[23, i] != -1)
            {
                j = inv[23, i];
                g = Rotat2(Colour_I[4], 4, t_Colour, j);//////<---------------------

                if (g[0] == 'F' || g[0] == 'B') { if (g[1] == 'L' || g[1] == 'R') { men = t_h[j]; t_h[j] = t_d[j]; t_d[j] = men; } }
                if (g[0] == 'U' || g[0] == 'D') { men = t_w[j]; t_w[j] = t_d[j]; t_d[j] = men; if (g[1] == 'L' || g[1] == 'R') { men = t_h[j]; t_h[j] = t_d[j]; t_d[j] = men; } }
                if (g[0] == 'L' || g[0] == 'R') { men = t_w[j]; t_w[j] = t_h[j]; t_h[j] = men; if (g[1] == 'F' || g[1] == 'B') { men = t_h[j]; t_h[j] = t_d[j]; t_d[j] = men; } }

                bool post = false;
                for (int k = 0; k < dl2; k++)
                {
                    for (int l = 0; l < dl3; l++)
                    {
                        if (!Bool[k, l] && t_d[j] == t_w[inv[10, k]] && t_w[j] == t_w[inv[11, l]])
                        {
                            Bool[k, l] = true;//������ �����
                            PN[j, 0] = g[0];//�������� ��� ���������
                            PN[j, 1] = g[1];
                            CorN[j, 0] = CorN[inv[11, l], 0]; CorN[j, 1] = CorN[inv[10, k], 1]; CorN[j, 2] = 0;
                            post = true;
                        }
                    }
                }
                if (!post)
                {
                    for (int k = 0; k < dl2; k++)
                    {
                        for (int l = 0; l < dl3; l++)
                        {
                            if (!Bool[k, l] && t_w[j] == t_w[inv[10, k]] && t_d[j] == t_w[inv[11, l]])
                            {
                                Bool[k, l] = true;//������ �����
                                PN[j, 0] = g[1];//�������� ��� �� ���������
                                if (g[0] == 'F') PN[j, 1] = 'B';
                                if (g[0] == 'B') PN[j, 1] = 'F';
                                if (g[0] == 'L') PN[j, 1] = 'R';
                                if (g[0] == 'R') PN[j, 1] = 'L';
                                if (g[0] == 'U') PN[j, 1] = 'D';
                                if (g[0] == 'D') PN[j, 1] = 'U';
                                
                                CorN[j, 0] = CorN[inv[11, l], 0]; CorN[j, 1] = CorN[inv[10, k], 1]; CorN[j, 2] = 0;
                            }
                        }
                    }
                }

                i++;
            }
            





           

            for (i = 0; i < n; i++)
                Console.WriteLine(PN[i, 0].ToString() + " " + PN[i, 1].ToString() + " " + CorN[i, 0].ToString()+" "+CorN[i, 1].ToString()+" "+CorN[i, 2].ToString());

            Console.ReadLine();
        }
    }

}