using dio.src.classes.filme;
using dio.src.classes.repositorioFilme;
using dio.src.classes.repositorioSerie;
using dio.src.classes.serie;
using dio.src.shared.genero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio.src.views.filmes
{
    public class FilmesView
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();
        public static string ObterOpcaoUsuarioFilmes()
        {
            Console.WriteLine();
            Console.WriteLine("Filmes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar filmes");
            Console.WriteLine("2- Inserir novo filme");
            Console.WriteLine("3- Atualizar filme");
            Console.WriteLine("4- Excluir filme");
            Console.WriteLine("5- Visualizar filme");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            Console.Write("Selecione uma opção: ");
            string opcaoUsuarioFilmes = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuarioFilmes;
        }

        public static void ListarFilmes()
        {
            Console.WriteLine("Listar filmes");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }
        public static void VisualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorio.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }
        public static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novoFilme);
        }
        public static void AtualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceFilme, atualizaFilme);
        }
        public static void ExcluirFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceFilme);
        }
    }
}