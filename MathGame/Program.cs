using System.Diagnostics;

public class Game
{
    public static void Main(string[] args)
    {

        // Instância de classes e variáveis
        Operadores operador = new Operadores();
        Stopwatch stopwatch = new Stopwatch();
        int valor;
        int i = 0;
        bool valido = false;
        Jogar();

        void Jogar()
        {
            //Método principal, executando a estrutura de escolhas, passando por uma validação de escolha dentro de um ParseInt
            //Posteriormente entrando em um "Switch-Case", o qual define as operações a serem escolhidas, baseada no input do usuário
            Random random = new Random();

            Console.Write("Escolha entre:\n" +
                        "1 - Adição \n2 - Subtração\n" +
                        "3 - Divisão \n4 - Multiplicação\n" +
                        "5 - Aleatório\n");
            string? escolha = Console.ReadLine();
            valido = int.TryParse(escolha, out int opcao);

            do
            {
                valido = int.TryParse(escolha, out opcao);
                if (!valido)
                {
                    Console.WriteLine("Insira uma opção válida");
                    escolha = Console.ReadLine();
                }
                else if (opcao < 1 && opcao > 4)
                {

                    Console.WriteLine(" Escolha entre uma das opções (1 a 4)");
                    escolha = Console.ReadLine();
                }
                stopwatch.Start();
            } while (!valido);
            do
            {
                switch (opcao)
                {
                    case 1:
                        operador.Somar();
                        i++;
                        break;
                    case 2:
                        operador.Subtrair();
                        i++;
                        break;
                    case 3:
                        operador.Dividir();
                        i++;
                        break;
                    case 4:
                        operador.Multiplicar();
                        i++;
                        break;
                    case 5: //Randomização das operações, feita com um segundo switch, usando o parâmetro com um random
                        switch (random.Next(1, 4))
                        {
                            case 1:
                                operador.Somar();
                                i++;
                                break;
                            case 2:
                                operador.Subtrair();
                                i++;
                                break;
                            case 3:
                                operador.Dividir();
                                i++;
                                break;
                            case 4:
                                operador.Multiplicar();
                                i++;
                                break;
                        }
                        break;
                }
            } while (i < 10);
            stopwatch.Stop();
            string tempofinal = String.Format("{0:00}:{1:00}:{2:000}", stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);

            Console.WriteLine($"O jogo acabou! Tempo total {tempofinal}. O que deseja fazer?");
            Thread.Sleep(1200);
        }

        do
        {
            Console.WriteLine("\n1 - Jogar novamente\n2 - Ver Histórico\n3 - Encerrar");
            string? decisao = Console.ReadLine();
            bool decisaoBol = int.TryParse(decisao, out valor);

            switch (valor)
            {
                case 1:
                    i = 0;
                    Jogar();
                    break;
                case 2:
                    operador.historico.ImprimirLista();
                    break;
                case 3:
                    Console.WriteLine("Obrigado por jogar!! Encerrando...");
                    Thread.Sleep(1500);
                    System.Environment.Exit(0);
                    break;
            }
        } while (valor != 3);
    }
}

public class Operadores
{
    //Criando os métodos das operações e adicionando cada resultado na lista de histórico
    public Historico historico = new Historico();

    public List<Action> operacoes = new List<Action>();

    //Gera dois números aleatórios, questionando a soma e validando, posteriormente informando se acertou ou não
    public void Somar()
    {

        Jogo jogo = new Jogo();
        int resposta = 0;
        Random rand = new Random();
        int numero1 = rand.Next(0, 100);
        int numero2 = rand.Next(0, 100);
        string expressao = $"{numero1} + {numero2}";


        Console.Write($"Qual o resultado de {numero1} + {numero2}: ");
        string? escolha = Console.ReadLine();

        string msg = ((int.TryParse(escolha, out resposta) && resposta == (numero1 + numero2)))
                ? "Parabéns! Você acertou!"
                : "Que pena! Você errou :( A resposta era " + (numero1 + numero2);
        Console.WriteLine(msg);
        Thread.Sleep(1200);

        jogo.Pergunta = expressao;
        jogo.Resposta = resposta;
        historico.historicoDeJogos.Add(jogo);

    }


    //Gera dois números aleatórios, questinando da subtração e validando posteriormente com o input do usuário, adicionando a lista do histórico
    public void Subtrair()
    {
        Jogo jogo = new Jogo();
        Random rand = new Random();
        int numero1 = rand.Next(0, 100);
        int numero2 = rand.Next(0, 100);
        string expressao = $"{numero1} - {numero2}";

        Console.Write($"Qual o resultado de {numero1} - {numero2}: ");
        string? escolha = Console.ReadLine();

        string msg = ((int.TryParse(escolha, out int resposta) && resposta == (numero1 - numero2)))
                  ? "Parabéns! Você acertou!"
                  : "Que pena! Você errou :( A resposta era " + (numero1 - numero2);
        Console.WriteLine(msg);
        Thread.Sleep(1200);

        jogo.Pergunta = expressao;
        jogo.Resposta = resposta;
        historico.historicoDeJogos.Add(jogo);
    }


    //Gera dois números aleatórios, questinando da divisão e validando posteriormente com o input do usuário, adicionando a lista do histórico
    public void Dividir()
    {
        Jogo jogo = new Jogo();
        Random rand = new Random();
        int numero1 = 0;
        int numero2 = 0;

        //Utilização do Try-Catch pela possibilidade do número gerado ser zero, preso dentro de um Do-While
        //Apenas saindo do loop quando gerar um número diferente de zero
        do
        {
            try
            {
                numero1 = rand.Next(0, 100);
                numero2 = rand.Next(0, 100);

                while (numero1 % numero2 != 0)
                {
                    numero1 = rand.Next(0, 100);
                    numero2 = rand.Next(0, 100);
                }

            }
            catch (DivideByZeroException ex)
            {
                return;
            }
        } while (numero1 == 0 || numero2 == 0);

        string expressao = $"{numero1} / {numero2}";

        Console.Write($"Qual o resultado de {numero1} / {numero2}: ");
        string? escolha = Console.ReadLine();

        string msg = ((int.TryParse(escolha, out int resposta) && resposta == (numero1 / numero2)))
                  ? "Parabéns! Você acertou!"
                  : "Que pena! Você errou :( A resposta era " + (numero1 / numero2);
        Console.WriteLine(msg);
        Thread.Sleep(1200);

        jogo.Pergunta = expressao;
        jogo.Resposta = resposta;
        historico.historicoDeJogos.Add(jogo);
    }


    //Gera dois números aleatórios, questinando da multiplicação e validando posteriormente com o input do usuário, adicionando a lista do histórico
    public void Multiplicar()
    {
        Jogo jogo = new Jogo();
        Random rand = new Random();
        int numero1 = rand.Next(1, 30);
        int numero2 = rand.Next(1, 30);
        string expressao = $"{numero1} * {numero2}";

        Console.Write($"Qual o resultado de {numero1} * {numero2}: ");
        string? escolha = Console.ReadLine();

        string msg = ((int.TryParse(escolha, out int resposta) && resposta == (numero1 * numero2)))
            ? "Parabéns! Você acertou!"
            : "Que pena! Você errou :( A resposta era " + (numero1 * numero2);
        Console.WriteLine(msg);
        Thread.Sleep(1200);

        jogo.Pergunta = expressao;
        jogo.Resposta = resposta;
        historico.historicoDeJogos.Add(jogo);
    }

    public class Historico
    {

        //Instância da lista do histórico, que recebe o tipo Jogo
        public List<Jogo> historicoDeJogos = new List<Jogo>();


        //Fuunção para imprimir a lista, imprimindo tanto a pergunta quanto resposta.
        public void ImprimirLista()
        {
            foreach (Jogo jogo in historicoDeJogos)
            {
                Console.WriteLine("Pergunta: " + jogo.Pergunta);
                Console.WriteLine("Resposta: " + jogo.Resposta);
            }
        }
    }

    public class Jogo
    {

        //Propriedades da classe jogo, a qual recebem tanto a pergunta, que seria a operação
        //Quanto a resposta, que seria o input do usuário
        public string Pergunta { get; set; }
        public int Resposta { get; set; }
    }
}