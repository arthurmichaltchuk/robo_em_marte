using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;


namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            string comando = "";
            char[] separador = { ' ' };
            string opcao = "1";
            string[] hist = new string[100];
            int cont = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("_______________________________________");
            Console.WriteLine("     SISTEMA DE NAVEGAÇÃO EM MARTE\n                 AEB\n\n   TAMANHO DO PLANETA VERMELHO\n\n   Primeiro valor = X \n   Segundo valor = Y \n   Exemplo = 'X Y'");
            Console.WriteLine("_______________________________________");
            Console.ResetColor();
            Console.Write("Digite as dimenções de Marte: ");
            string plano = Console.ReadLine();
            string[] planos = plano.Split(separador);
            Console.Clear();
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_______________________________________");
                Console.WriteLine("\n   LOCALIZAÇÃO INICIAL\n\nPrimeiro valor = X \nSegundo valor  = Y \nTerceiro valor = Direção\n\n    Possíveis direções: \n      N = Norte\n      S = Sul\n      L = Leste\n      O = Oeste \n\nExemplo de localização = 'X Y D'");
                Console.WriteLine("_______________________________________");
                Console.ResetColor();
                Console.Write("Digite a localização inicial do robo em Marte: ");
                string localtemp = Console.ReadLine();
                string[] local = localtemp.Split(separador);
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("_______________________________________");
                Console.WriteLine("\n           COMANDOS\n\n   M = Mover para frente\n   D = Girar para direita\n   E = Girar para Esquerda\n\n   Exemplo = MMDMMEMM");
                Console.WriteLine("_______________________________________");
                Console.ResetColor();
                Console.Write("Digite os comandos do robo: ");
                comando = Console.ReadLine();
                char[] comandos = comando.ToCharArray();
                Console.Clear();

                double limite_x = Convert.ToDouble(planos[0]);
                double limite_y = Convert.ToDouble(planos[1]);

                double plano_x = Convert.ToDouble (local[0]);
                double plano_y = Convert.ToDouble (local[1]);
                string direcao = local[2];

                foreach (char cmd in comandos)
                {
                    if (cmd == 'm' || cmd == 'M')
                    {
                        if (direcao == "N" || direcao == "n")
                        {
                            plano_y = plano_y + 1;
                        }
                        else if (direcao == "L" || direcao == "l")
                        {
                            plano_x = plano_x + 1;
                        }
                        else if (direcao == "S" || direcao == "s")
                        {
                            plano_y = plano_y - 1;
                        }
                        else if (direcao == "O" || direcao == "o")
                        {
                            plano_x = plano_x - 1;
                        }

                    }
                    else if (cmd == 'd' || cmd == 'D')
                    {
                        if (direcao == "n" | direcao == "N")
                        {
                            direcao = "L";
                        }
                        else if (direcao == "l" | direcao == "L")
                        {
                            direcao = "S";
                        }
                        else if (direcao == "s" | direcao == "S")
                        {
                            direcao = "O";
                        }
                        else if (direcao == "o" | direcao == "O")
                        {
                            direcao = "N";
                        }
                    }
                    else if (cmd == 'e' || cmd == 'E')
                    {
                
                        if (direcao == "n" || direcao == "N")
                        {
                            direcao = "O";
                        }
                        else if (direcao == "l" || direcao == "L")
                        {
                            direcao = "N";
                        }
                        else if (direcao == "s" || direcao == "S")
                        {
                            direcao = "L";
                        }
                        else if (direcao == "o" || direcao == "O")
                        {
                            direcao = "S";
                        }
                    }
                }
                if (plano_x > limite_x || plano_x < 0 || plano_y > limite_y || plano_y < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Seu robo saiu dos limites de Marte! Cuidado!");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    hist[cont] = " Direção: " + direcao + "\n Plano X: " + plano_x.ToString() + "\n Plano Y: " + plano_y.ToString();
                    cont++;

                    Console.WriteLine("_______________________________________");
                    Console.WriteLine("Localização final de todos os seus robôs: ");
                    for (int i = 0; i < cont; i++)
                    {
                        Console.Write("\nROBÔ ");
                        Console.WriteLine(i+1);
                        Console.WriteLine(hist[i]);
                    }
                    
                    Console.WriteLine("\n_______________________________________");
                    Console.WriteLine("\n\n         O QUÊ DESEJA FAZER?\n\n   Digite 1 para pilotar outro ROBÔ\n   Digite 2 para finalizar o programa");
                    Console.WriteLine("_______________________________________");
                    Console.ResetColor();
                    opcao = Console.ReadLine();
                    
                    if (opcao == "2")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("AEB (Agência Espacial Brasileira) agradece a preferência...");
                        Console.ReadLine();
                        break;
                    }
                }               
            } while (true);
        }               
    } 
}