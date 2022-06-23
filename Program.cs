namespace EditTexts
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("-----Bem vindo ao editor de texto c#-----");
            Console.WriteLine("Qual operação deseja realizar?");
            Console.WriteLine("1 - Abrir aqrquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");

            short option = Convert.ToInt16(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                default: Menu(); break;

            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string? path = Console.ReadLine();

            //ler o arquivo
            using (var file = new StreamReader(path!))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo! (ESC para sair)");
            Console.WriteLine("-----------------------");

            string text = "";

            // Armazenando o que o usuario digita na variavel
            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            // Enquanto o usuario nao digitar o ESC para sair o console continuara pegando as informaçoes digitadas
            // A primeira parte do codigo significa que ele pega a tecla, a segunda parte e a tecla declarada
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Save(text);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            // Usando o using para que ele possa abri e fechar o StreamWriter, sem que precisamos colocar o close() no final do programa e cair no risco de esquecer.
            //usando ele para salvar nosso arquivo
            using (var file = new StreamWriter(path!))
            {
                file.Write(text);
            }
            Console.WriteLine($"Arquivo salvo com sucesso em: {path}");
            Console.ReadLine();
            Menu();
        }
    }
}