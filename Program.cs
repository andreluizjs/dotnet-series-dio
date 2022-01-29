using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
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
                        DeletarSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default: 
                        throw new ArgumentOutOfRangeException();

                }
                
                opcaoUsuario = obterOpcaoUsuario();
            }
        }

         private static void ListarSeries()
        {
            Console.WriteLine ("Listar series");

            var lista = repositorio.Lista(); 

            if (lista.Count == 0)
            {
                Console.WriteLine("Sem séries Cadastradas");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }

        }

        private static void InserirSerie()
        {
            Console.WriteLine ("Inserir uma nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {

                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));

            }

            Console.Write ("Inserir o Genero: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write ("Inserir o titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write ("Inserir o ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write ("Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie (id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            
            repositorio.Insere(novaSerie);
        }

         private static void AtualizarSerie()
        {
            Console.Write ("Qual série deseja Atualizar? (id) ");
            int atualizaEntradaSerieId = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {

                Console.WriteLine ("{0} - {1}", i, Enum.GetName(typeof(Genero), i));

            }

            Console.Write ("Inserir o Genero: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write ("Inserir o titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write ("Inserir o ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write ("Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie (id: atualizaEntradaSerieId,
                                           genero: (Genero) entradaGenero,
                                           titulo: entradaTitulo,
                                           ano: entradaAno,
                                           descricao: entradaDescricao );

            
            repositorio.Atualiza(atualizaEntradaSerieId, atualizaSerie);

        }

        private static void DeletarSerie()
        {
            Console.WriteLine ("Delete uma Série");
            Console.Write ("Serie id: ");
            int deletaEntradaSerie = int.Parse(Console.ReadLine());

            Console.Write ("Deseja deletar a série numero {0} ? (S/N) ",deletaEntradaSerie );
            string answer = Console.ReadLine().ToUpper();

            while (answer != "S")
            {
                if (answer != "N")
                {
                    Console.WriteLine ("Escolha errada! Por favor Pressione S ou N.");
                    return;
                }
                else
                {
                    return;
                }

            }

            repositorio.Exclui(deletaEntradaSerie);
            
        }

         private static void VisualizarSerie()
        {
            Console.Write ("Inserir o Id da Série: ");
            int seeSerieIdEntry = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(seeSerieIdEntry);

            Console.WriteLine(serie);

        }



        private static string obterOpcaoUsuario()
        {
            Console.WriteLine ();
            Console.WriteLine ("Escolha Uma opção: ");

            Console.WriteLine ("1- Listar series");
            Console.WriteLine ("2- Inserir nova serie");
            Console.WriteLine ("3- Atualizar serie");
            Console.WriteLine ("4- Deletar serie");
            Console.WriteLine ("5- Visualizar serie");
            Console.WriteLine ("C- Limpar tela");
            Console.WriteLine ("X- sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
            
        }
    }
}