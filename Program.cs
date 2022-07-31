using System;
using dio.src.views.filmes;
using dio.src.views.series;


namespace dio
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            string opcaoInicial = OpcaoInicial();
            
            switch (opcaoInicial)
            {
                case "1":
                    string opcaoUsuarioSeries = SeriesView.ObterOpcaoUsuarioSeries();
                    while (opcaoUsuarioSeries.ToUpper() != "X")
                    {
                        switch (opcaoUsuarioSeries)
                        {
                            case "1":
                                SeriesView.ListarSeries();
                                break;
                            case "2":
                                SeriesView.InserirSerie();
                                break;
                            case "3":
                                SeriesView.AtualizarSerie();
                                break;
                            case "4":
                                SeriesView.ExcluirSerie();
                                break;
                            case "5":
                                SeriesView.VisualizarSerie();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        opcaoUsuarioSeries = SeriesView.ObterOpcaoUsuarioSeries();
                    }
                     break;
                case "2":
                    string opcaoUsuarioFilmes = FilmesView.ObterOpcaoUsuarioFilmes();
                    while (opcaoUsuarioFilmes.ToUpper() != "X")
                    {
                        switch (opcaoUsuarioFilmes)
                        {
                            case "1":
                                FilmesView.ListarFilmes();
                                break;
                            case "2":
                                FilmesView.InserirFilme();
                                break;
                            case "3":
                                FilmesView.AtualizarFilme();
                                break;
                            case "4":
                                FilmesView.ExcluirFilme();
                                break;
                            case "5":
                                FilmesView.VisualizarFilme();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        opcaoUsuarioFilmes = FilmesView.ObterOpcaoUsuarioFilmes();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
      
        private static string OpcaoInicial()
        {
            Console.WriteLine();
            Console.WriteLine("1- Series");
            Console.WriteLine("2- Filmes");
            Console.WriteLine();
            Console.Write("Selecione uma opção: ");
            string opcaoInicial = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoInicial;
        }
    }
}
