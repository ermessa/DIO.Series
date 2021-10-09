﻿using DIO.Series.Classes;
using DIO.Series.Enum;
using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio Repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default: break;
                }
                opcaoUsuario = obterOpcaoUsuario();
            }
            Console.WriteLine("obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = Repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            ponto1:
            
            Console.WriteLine("Tem certeza de que deseja excluir a série informada?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            int confirmação = int.Parse(Console.ReadLine());

            if (confirmação == 1)
            {
                Repositorio.Exclui(indiceSerie);
                Console.WriteLine("Exclusão finalizada.");
            }
            else if (confirmação == 2)
            {
                Console.WriteLine("Exclusão cancelada.");
            }
            else
            {
                Console.WriteLine("Escolha uma opção válida!");
                goto ponto1;
            }
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Serie atualizacaoSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        entradaTitulo,
                                        entradaDescricao,
                                        entradaAno);
            
            Repositorio.Atualiza(indiceSerie, atualizacaoSerie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série:");
            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(Genero),i));
            }
            
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: Repositorio.ProximoId(),
                                        genero: (Genero) entradaGenero,
                                        entradaTitulo,
                                        entradaDescricao,
                                        entradaAno);
            
            Repositorio.Insere(novaSerie);
        }
        
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = Repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var Serie in lista)
            {
                bool excluido = Serie.retornaExcluido();

                if (!excluido)
                {
                    Console.WriteLine("#ID {0}: {1}", Serie.retornaId(), Serie.retornaTitulo());
                }
            }
        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
