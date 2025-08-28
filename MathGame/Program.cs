using System.ComponentModel;
using System.Linq.Expressions;

public class Game
{
    public static void Main(string[] args)
    {
        Operadores operador = new Operadores();
        bool valido = false;
        int opcao;
        int i = 0;
        Console.Write("Escolha entre:\n" +
                    "1 - Adição \n2 - Subtração\n" +
                    "3 - Divisão \n4 - Multiplicação\n");
        string? escolha = Console.ReadLine();


        do {
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
            }
        } while (i<11);
    }



}

public class Operadores
{
    public Historico lista = new Historico();
        public void Somar()
    {

        bool valido = false;
        Random rand = new Random();
        int numero1 = rand.Next(0, 100);
        int numero2 = rand.Next(0, 100);
        string expressao = $"{numero1} + {numero2}";

        Console.Write($"Qual o resultado de {numero1} + {numero2}: ");
        string? escolha = Console.ReadLine();

        if (valido =  int.TryParse(escolha,out int resposta) && resposta == (numero1 + numero2))
        {
            Console.Write("Parabéns! Você acertou!");
            lista.operacoesRealizadas.Add(expressao);
            foreach (string exp in lista.operacoesRealizadas)
            {
                Console.WriteLine(exp);
            }
            ;
        }
        else 
        {
            Console.Write("Que pena! Você errou :(");
            lista.operacoesRealizadas.Add(expressao);
        }

    }

    public void Subtrair()
    {
        bool valido = false;
        Random rand = new Random();
        int numero1 = rand.Next(0, 100);
        int numero2 = rand.Next(0, 100);

        Console.Write($"Qual o resultado de {numero1} - {numero2}: ");
        string? escolha = Console.ReadLine();
        if (valido = int.TryParse(escolha, out int resposta) && resposta == (numero1 - numero2))
        {
            Console.Write("Parabéns! Você acertou!");
        }
        else
        {
            Console.Write("Que pena! Você errou :(");
        }
    }

    public void Dividir()
    {
        bool valido = false;
        Random rand = new Random();
        int numero1 = rand.Next(0, 100);
        int numero2 = rand.Next(0, 100);

        Console.Write($"Qual o resultado de {numero1} / {numero2}: ");
        string? escolha = Console.ReadLine();
        if (valido = int.TryParse(escolha, out int resposta) && resposta == (numero1 / numero2))
        {
            Console.Write("Parabéns! Você acertou!");
            
            
        }
        else
        {
            Console.Write("Que pena! Você errou :(");
        }
    }

    public void Multiplicar()
    {
        bool valido = false;
        Random rand = new Random();
        int numero1 = rand.Next(0, 100);
        int numero2 = rand.Next(0, 100);

        while (numero1 % numero2 != 0)
        {
            numero1 = rand.Next(0, 100);
            numero2 = rand.Next(0, 100);
        }

        Console.Write($"Qual o resultado de {numero1} * {numero2}: ");
        string? escolha = Console.ReadLine();
        if (valido = int.TryParse(escolha, out int resposta) && resposta == (numero1 * numero2))
        {
            Console.Write("Parabéns! Você acertou!");
        }
        else
        {
            Console.Write("Que pena! Você errou :(");
        }
    }
}

public class Historico
{
    public List<string> operacoesRealizadas = new List<string>();

}