using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoologicoManager.Services;
using ZoologicoManager.Models.Animais;
using ZoologicoManager.Models.Pessoas;

namespace ZoologicoManager.UI
{
    public class GerenciadorMenu
    {
        public static int Pagina { get; set; }
        public static bool isRemovendoAnimal { get; set; }
        public static void MostrarMenu(Zoologico zoo)
        {
            while (Programa.IsRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("═══════════════════════════════");
                Console.WriteLine("    ZOOLÓGICO - MENU PRINCIPAL");
                Console.WriteLine("═══════════════════════════════");
                Console.WriteLine("1. Gerenciar Animais");
                Console.WriteLine("2. Gerenciar Visitantes");
                Console.WriteLine("3. Gerenciar Funcionários");
                Console.WriteLine("4. Gerenciar Relatórios");
                Console.WriteLine("5. Consultar Animais por Recinto");
                Console.WriteLine("0. Sair do Sistema");
                Console.WriteLine("═══════════════════════════════");
                Console.Write("Digite sua opção: ");

                Pagina = 1;

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Pagina = 2;
                        MenuGerenciarAnimal(zoo);
                        break;

                    case "2":
                        Pagina = 2;
                        MenuGerenciarVisitantes(zoo);
                        break;

                    case "3":
                        Pagina = 2;
                        //Funcionarios
                        break;

                    case "4":
                        Pagina = 2;
                        //Relatorios
                        break;

                    case "5":
                        zoo.ListarAnimaisPorTipo();
                        break;

                    case "0":
                        EncerrarMenu();
                        Console.WriteLine("Encerrando o sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }

        }

        private static void MenuGerenciarAnimal(Zoologico zoo)
        {
            while (Pagina != 1)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════");
                Console.WriteLine("    GERENCIADOR DE ANIMAIS");
                Console.WriteLine("═══════════════════════════════");
                Console.WriteLine("1. Cadastrar Mamífero");
                Console.WriteLine("2. Cadastrar Ave");
                Console.WriteLine("3. Cadastrar Réptil");
                Console.WriteLine("4. Remover Animal");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.WriteLine("═══════════════════════════════");
                Console.Write("Escolha: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                    case "2":
                    case "3":    
                        Animal animal = CadastrarAnimal();
                        zoo.AdicionarAnimalRecinto("SAVANA", animal);

                        Console.ReadKey();
                        break;

                    case "4":
                        RemoverAnimal(zoo);

                        Console.ReadKey();
                        break;

                    case "0":
                        Pagina = 1;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void MenuGerenciarVisitantes(Zoologico zoo)
        {
            while (Pagina != 1)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════");
                Console.WriteLine("    GERENCIADOR DE VISITANTES");
                Console.WriteLine("═══════════════════════════════");
                Console.WriteLine("1. Cadastrar Visitante");
                Console.WriteLine("2. Remover Visitante");
                Console.WriteLine("3. Listar Visitantes");
                Console.WriteLine("4. Gerenciar Visita");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.WriteLine("═══════════════════════════════");
                Console.Write("Escolha: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Visitante visitante = CadastrarVisitante();
                        zoo.AdicionarVisitanteZoologico(visitante);

                        Console.ReadKey();
                        break;

                    case "2":
                        RemoverVisitante(zoo);

                        Console.ReadKey();
                        break;

                    case "3":
                        zoo.ListarVisitantes();

                        Console.ReadKey();
                        break;

                    case "4":
                        Pagina = 3;
                        MenuGerenciarVisitas(zoo);
                        break;

                    case "0":
                        Pagina = 1;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void MenuGerenciarVisitas(Zoologico zoo)
        {
            while (Pagina != 2)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════");
                Console.WriteLine("    GERENCIADOR DE VISITAS");
                Console.WriteLine("═══════════════════════════════");
                Console.WriteLine("1. Registrar Visita");
                Console.WriteLine("2. Remover Visita");
                Console.WriteLine("3. Listar Visitas");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.WriteLine("═══════════════════════════════");
                Console.Write("Escolha: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        zoo.RegistrarVisitaZoologico();

                        Console.ReadKey();
                        break;

                    case "2":
                        zoo.RemoverVisitaZoologico();

                        Console.ReadKey();
                        break;

                    case "3":
                        zoo.ListarVisitantes();

                        Console.ReadKey();
                        break;

                    case "0":
                        Pagina = 2;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /*
         * @Animal Methods
         */

        private static Animal CadastrarAnimal()
        {
            Console.Clear();
            Console.WriteLine("═════════════════════════════");
            Console.WriteLine("    CADASTRO DE NOVO ANIMAL");
            Console.WriteLine("═════════════════════════════");

            // Dados básicos do animal
            Random random = new Random();
            int id = random.Next(1, 10);

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Idade: ");
            int idade = int.Parse(Console.ReadLine());

            // Dados de alimentação
            Console.WriteLine("\nINFORMAÇÕES DE ALIMENTAÇÃO");
            Console.Write("Tipo de alimento: ");
            string tipoAlimento = Console.ReadLine();

            Console.Write("Frequência diária: (Ex: 1x 2x 5x 10x) ");
            int frequencia = int.Parse(Console.ReadLine());

            Console.Write("Quantidade por refeição (kg): ");
            double quantidade = double.Parse(Console.ReadLine());

            Alimentacao alimentacao = new Alimentacao(tipoAlimento, frequencia, quantidade);

            // Tipo do animal
            Console.WriteLine("\nTIPOS DISPONÍVEIS: Leao, Aguia e Cobra");
            Console.Write("Tipo do animal: ");
            string tipoAnimal = Console.ReadLine().ToLower();

            // Caracteristicas dos Animais
            Console.WriteLine("\nINFORMAÇÕES ESPECÍFICAS");

            var caracteristicas = new Dictionary<string, object>();

            if(tipoAnimal == "leao")
            {
                Console.Write("Tempo de gestação (dias): ");
                caracteristicas["gestacao"] = int.Parse(Console.ReadLine());

                Console.Write("Possui melena? (S/N): ");
                caracteristicas["melena"] = Console.ReadLine().ToUpper() == "S";
            } else if (tipoAnimal == "aguia")
            {
                Console.Write("Tamanho da envergadura da asa (cm): ");
                caracteristicas["envergaduraAsa"] = double.Parse(Console.ReadLine());

                Console.Write("Tem visão aguçada? (S/N): ");
                caracteristicas["visaoAgucada"] = Console.ReadLine().ToUpper() == "S";
            } else if (tipoAnimal == "cobra")
            {
                Console.Write("Faz troca de pele? (S/N): ");
                caracteristicas["trocaDePele"] = Console.ReadLine().ToUpper() == "S";

                Console.Write("Tem peçonha? (S/N): ");
                caracteristicas["venenosa"] = Console.ReadLine().ToUpper() == "S";
            }

            Animal novoAnimal = AnimalFactory.CriarAnimal(id, nome, idade, alimentacao, tipoAnimal, caracteristicas);

            Console.WriteLine("\nAnimal cadastrado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();

            return novoAnimal;
        }

        public static void RemoverAnimal(Zoologico zoo)
        {
            Console.Clear();
            Console.WriteLine("═════════════════════════════");
            Console.WriteLine("       REMOÇÃO DE ANIMAL");
            Console.WriteLine("═════════════════════════════");

            isRemovendoAnimal = true;

            zoo.ListarAnimaisPorTipo();

            Console.WriteLine("ID do animal para remoção: ");
            int id = int.Parse(Console.ReadLine());

            zoo.RemoverAnimalRecinto("SAVANA", id);

            Console.ReadKey();
        }

       /*
        * @Visitante Methods
        */

        private static Visitante CadastrarVisitante()
        {
            Console.Clear();
            Console.WriteLine("═════════════════════════════");
            Console.WriteLine("   CADASTRO DE NOVO VISITANTE");
            Console.WriteLine("═════════════════════════════");

            // Dados básicos do animal
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Idade: ");
            int idade = int.Parse(Console.ReadLine());

            Visitante novoVisitante = new Visitante(nome, idade);

            Console.WriteLine("\nVisitante cadastrado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();

            return novoVisitante;
        }

        public static void RemoverVisitante(Zoologico zoo)
        {
            Console.Clear();
            Console.WriteLine("═════════════════════════════");
            Console.WriteLine("       REMOÇÃO DE VISITANTE");
            Console.WriteLine("═════════════════════════════");

            zoo.ListarVisitantes();

            Console.WriteLine("Nome do visitante para remoção: ");
            string nome = Console.ReadLine();

            zoo.RemoverVisitanteZoologico(nome);

            Console.ReadKey();
        }

       /*
        * @Extra Methods
        */

        private static void EncerrarMenu()
        {
            Programa.IsRunning = false;
        }


    }
}
