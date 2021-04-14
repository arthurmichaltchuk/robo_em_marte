using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sudoku.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string condicao;
            char[] separador = { ' ' };
            Console.WriteLine("Deseja ver o sistema funcionando?");
            condicao = Console.ReadLine();

            string sudoku_temp =
            "1 3 2 5 7 9 4 6 8 " +
            "4 9 8 2 6 1 3 7 5 " +
            "7 5 6 3 8 4 2 1 9 " +
            "6 4 3 1 5 8 7 9 2 " +
            "5 2 1 7 9 3 8 4 6 " +
            "9 8 7 4 2 6 5 3 1 " +
            "2 1 4 9 3 5 6 8 7 " +
            "3 6 5 8 1 7 9 2 4 " +
            "8 7 9 6 4 2 1 5 3";

            int cont = 0;
            int cont2 = 0;
            int cont3 = 0;
            string[] sudoku = sudoku_temp.Split(separador);


            string[] linha = new string[100];
            string[] coluna = new string[100];
            string[] bloco = new string[100];
            if (condicao == "1")
            {
                Console.WriteLine("\nCOLUNAS");
            }

            for (int i = 0; i < 9; i++)
            {
                coluna[i] = sudoku[0 + cont] + " " + sudoku[9 + cont] + " " + sudoku[18 + cont] + " " + sudoku[27 + cont] + " " + sudoku[36 + cont] + " " + sudoku[45 + cont] + " " + sudoku[54 + cont] + " " + sudoku[63 + cont] + " " + sudoku[72 + cont];

                cont++;


                if (condicao == "1")
                {
                    Console.WriteLine(coluna[i]);
                }
            }
            if (condicao == "1")
            {
                Console.WriteLine("\nLINHAS");
            }

            for (int i = 0; i < 9; i++)
            {
                linha[i] = sudoku[0 + cont2] + " " + sudoku[1 + cont2] + " " + sudoku[2 + cont2] + " " + sudoku[3 + cont2] + " " + sudoku[4 + cont2] + " " + sudoku[5 + cont2] + " " + sudoku[6 + cont2] + " " + sudoku[7 + cont2] + " " + sudoku[8 + cont2];

                cont2 += 9;
                if (condicao == "1")
                {
                    Console.WriteLine(linha[i]);
                }

            }
            if (condicao == "1")
            {
                Console.WriteLine("\nBLOCOS");
            }

            for (int i = 0; i < 3; i++)
            {
                bloco[i] = sudoku[0 + cont3] + " " + sudoku[1 + cont3] + " " + sudoku[2 + cont3] + " " + sudoku[9 + cont3] + " " + sudoku[10 + cont3] + " " + sudoku[11 + cont3] + " " + sudoku[18 + cont3] + " " + sudoku[19 + cont3] + " " + sudoku[20 + cont3];
                bloco[i + 3] = sudoku[27 + cont3] + " " + sudoku[28 + cont3] + " " + sudoku[29 + cont3] + " " + sudoku[36 + cont3] + " " + sudoku[37 + cont3] + " " + sudoku[38 + cont3] + " " + sudoku[45 + cont3] + " " + sudoku[46 + cont3] + " " + sudoku[47 + cont3];
                bloco[i + 6] = sudoku[54 + cont3] + " " + sudoku[55 + cont3] + " " + sudoku[56 + cont3] + " " + sudoku[63 + cont3] + " " + sudoku[64 + cont3] + " " + sudoku[65 + cont3] + " " + sudoku[72 + cont3] + " " + sudoku[73 + cont3] + " " + sudoku[74 + cont3];

                cont3 += 3;

            }
            for (int i = 0; i < 9; i++)
            {
                if (condicao == "1")
                {
                    Console.WriteLine(bloco[i]);
                }

            }
            for (int i = 0; i < sudoku.Length; i++)
            {
                if (condicao == "1")
                {
                    Console.Write("\nCaractere ");
                    Console.WriteLine(i);
                    Console.WriteLine(sudoku[i]);
                }
            }

            int saida = 0;
            int soma = 45;
            int cont4 = 0;

            if (condicao == "1")
            {
                Console.WriteLine("VERIFICAÇÃO");
            }

            verificacao(condicao, linha, ref saida, ref soma, ref cont4);

            verificacao(condicao, coluna, ref saida, ref soma, ref cont4);

            verificacao(condicao, bloco, ref saida, ref soma, ref cont4);
            
            Console.WriteLine("SAÍDA");
            if (saida == 0)
            {
                Console.WriteLine("SIM");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("NÃO");
                Console.ReadLine();
            }

        }

        private static void verificacao(string condicao, string[] linha, ref int saida, ref int soma, ref int cont4)
        {
            for (int i = 0; i < 9; i++)
            {
                string[] linhas = linha[i].Split(' ');
                if (soma != 45)
                {
                    if (condicao == "1")
                    {
                        Console.WriteLine("NÃO");
                    }
                    saida++;
                }
                if (soma == 45)
                {
                    if (condicao == "1")
                    {
                        Console.WriteLine("SIM");
                    }

                }
                soma = 0;
                cont4 = 0;


                for (int c = 0; c < 9; c++)
                {
                    soma += Convert.ToInt32(linhas[c]);
                    if (linhas[i] == linhas[c])
                    {
                        cont4++;
                    }
                    if (cont4 > 1)
                    {
                        if (condicao == "1")
                        {
                            Console.WriteLine("NÃO");
                        }
                        saida++;
                    }
                }


            }
        }
    }
}
