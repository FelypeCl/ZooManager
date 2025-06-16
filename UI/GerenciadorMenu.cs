using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoologicoManager.Services;
using ZoologicoManager.Models.Animais;

namespace ZoologicoManager.UI
{
    public class GerenciadorMenu
    {
        public static bool VoltarPagina { get; set; }
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
                Console.WriteLine("1. Cadastrar Novo Animal");
                Console.WriteLine("2. Registrar Visita");
                Console.WriteLine("3. Consultar Animais por Recinto");
                Console.WriteLine("4. Agendar Atividades Especiais");
                Console.WriteLine("5. Relatórios Gerenciais");
                Console.WriteLine("6. Informações para Visitantes");
                Console.WriteLine("0. Sair do Sistema");
                Console.WriteLine("═══════════════════════════════");
                Console.Write("Digite sua opção: ");

                VoltarPagina = false;

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MenuCadastroAnimal(zoo);
                        break;

                    case "2":
                        //MenuRegistroVisita();
                        break;

                    case "3":
                        MenuConsultaRecintos(zoo);
                        break;

                    case "4":
                        //MenuAtividadesEspeciais();
                        break;

                    case "5":
                        //MenuRelatorios();
                        break;

                    case "6":
                        //MenuInformacoesVisitantes();
                        break;

                    case "0":
                        EncerrarMenu();
                        Console.WriteLine("Encerrando o sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        //EncerrarMenu();
                        break;
                }
            }

        }

        private static void MenuCadastroAnimal(Zoologico zoo)
        {
            while (!VoltarPagina)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════");
                Console.WriteLine("    CADASTRO DE ANIMAIS");
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
                        Animal animal = CadastrarAnimal();
                        zoo.AdicionarAnimalRecinto("SAVANA", animal);

                        Console.ReadKey();
                        break;

                    case "4":
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
                        break;

                    case "0":
                        VoltarPagina = true;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void MenuConsultaRecintos(Zoologico zoo)
        {
            zoo.ListarAnimaisPorTipo();
            Console.ReadKey();
        }

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

        private static void EncerrarMenu()
        {
            Programa.IsRunning = false;
        }


    }
}
