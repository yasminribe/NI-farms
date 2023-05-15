bool telaMenu = true;
Fazenda fazenda = new Fazenda();

while (telaMenu)
{
    Console.Clear();
    Console.WriteLine("=== Menu Principal ===");
    Console.WriteLine("1. Iniciar jogo");
    Console.WriteLine("2. Créditos");
    Console.WriteLine("3. Sair");
    Console.WriteLine("============");

    Console.Write("Digite o número da opção desejada: ");
    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("Iniciando o jogo...");
            fazenda.IniciarJogo();
            Console.ReadLine();
            break;
        case "2":
            Console.WriteLine("*** Participantes: ***");
            Console.WriteLine("Gustavo");
            Console.WriteLine("Kaique");
            Console.WriteLine("Vinicius");
            Console.WriteLine("Yasmin");
            Console.ReadLine();
            break;
        case "3":
            telaMenu = false;
            break;
        default:
            Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
            Console.ReadLine();
            break;
    }
}

class Fazenda
{
    int areaPlantada;
    int quantidadeTrabalhadores;
    int dinheiro;
    int nivelFertilidade;
    int nivelIrrigacao;
    int[] estoqueSementes;
    int[] estoqueProdutos;
    int[] quantidadeAnimais;
    int[] precoSementes = { 10, 20, 30 };
    int[] precoProdutos = { 50, 80, 120, 15, 20, 40 };
    Dictionary<int, string> sementesPorNivel = new Dictionary<int, string>()
    {
        { 1, "Milho" },
        { 2, "Trigo" },
        { 3, "Soja" }
    };
    Dictionary<int, string> animaisPorNivel = new Dictionary<int, string>()
    {
        { 1, "Vaca" },
        { 2, "Galinha" },
        { 3, "Porco" }
    };

    public Fazenda()
    {
        this.areaPlantada = 50;
        this.quantidadeTrabalhadores = 2;
        this.dinheiro = 1000;
        this.nivelFertilidade = 1;
        this.nivelIrrigacao = 1;
        this.estoqueSementes = new int[] { 0, 0, 0 };
        this.estoqueProdutos = new int[] { 0, 0, 0, 0, 0, 0 };
        this.quantidadeAnimais = new int[] { 1, 1, 1 };
    }
    public void IniciarJogo()
    {
        bool jogando = true;

        while (jogando)
        {
            Console.Clear();
            Console.WriteLine("=== Farms Game ===");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Ver status da fazenda");
            Console.WriteLine("2 - Comprar sementes");
            Console.WriteLine("3 - Plantar e colher sementes");
            Console.WriteLine("4 - Animais");
            Console.WriteLine("5 - Vender produtos");
            Console.WriteLine("6 - Melhorar a fazenda");
            Console.WriteLine("0 - Sair do jogo");
            Console.WriteLine("================");

            Console.Write("Digite o número da opção desejada: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("=== Status da Fazenda ===");
                    VerStatusFazenda();
                    Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("=== Comprar Sementes ===");
                    ComprarSementes();
                    Console.ReadLine();
                    break;

                case "3":
                    Console.WriteLine("=== Plantar e Colher Sementes ===");
                    PlantarColherSementes();
                    Console.ReadLine();
                    break;

                case "4":
                    Console.WriteLine("=== Animais ===");
                    TrabalharComAnimais();
                    Console.ReadLine();
                    break;

                case "5":
                    Console.WriteLine("=== Vender Produtos ===");
                    VenderProdutos();
                    Console.ReadLine();
                    break;

                case "6":
                    Console.WriteLine("=== Melhorar a Fazenda ===");
                    MelhorarFazenda();
                    Console.ReadLine();
                    break;

                case "0":
                    jogando = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    void VerStatusFazenda()
    {
        Console.WriteLine($"Área Plantada: {areaPlantada}m²");
        Console.WriteLine($"Quantidade de Trabalhadores: {quantidadeTrabalhadores}");
        Console.WriteLine($"Dinheiro: {dinheiro} moedas");
        Console.WriteLine($"Nível de Fertilidade: {nivelFertilidade}");
        Console.WriteLine($"Nível de Irrigação: {nivelIrrigacao}");

        Console.WriteLine("Estoque de Sementes Plantadas:");
        for (int i = 0; i < estoqueSementes.Length; i++)
        {
            Console.WriteLine($"{sementesPorNivel[i + 1]}: {estoqueSementes[i]}");
        }

        Console.WriteLine("Estoque de Produtos:");
        Console.WriteLine($"Leite (Vaca): {estoqueProdutos[0]}");
        Console.WriteLine($"Ovo (Galinha): {estoqueProdutos[1]}");
        Console.WriteLine($"Carne (Porco): {estoqueProdutos[2]}");
        Console.WriteLine($"Milho: {estoqueProdutos[3]}");
        Console.WriteLine($"Trigo: {estoqueProdutos[4]}");
        Console.WriteLine($"Soja: {estoqueProdutos[5]}");

        Console.WriteLine("Quantidade de Animais:");
        Console.WriteLine($"Vaca: {quantidadeAnimais[0]}");
        Console.WriteLine($"Galinha: {quantidadeAnimais[1]}");
        Console.WriteLine($"Porco: {quantidadeAnimais[2]}");
    }

    void ComprarSementes()
    {
        Console.WriteLine("Escolha o tipo de semente que deseja comprar:");

        for (int i = 0; i < sementesPorNivel.Count; i++)
        {
            int nivel = i + 1;
            string semente = sementesPorNivel[nivel];
            int preco = precoSementes[i];

            Console.WriteLine($"{nivel}. {semente} - Preço: {preco} moedas");
        }

        Console.Write("Digite o número da opção desejada: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int opcao))
        {
            if (opcao >= 1 && opcao <= sementesPorNivel.Count)
            {
                int nivelIndex = opcao - 1;
                int precoSemente = precoSementes[nivelIndex];

                Console.Write("Digite a quantidade de sementes que deseja comprar: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out int quantidade))
                {
                    int precoTotal = precoSemente * quantidade;

                    if (dinheiro >= precoTotal)
                    {
                        estoqueSementes[nivelIndex] += quantidade;
                        dinheiro -= precoTotal;
                        Console.WriteLine($"Você comprou {quantidade} sementes de {sementesPorNivel[opcao]} por {precoTotal} moedas.");
                    }
                    else
                    {
                        Console.WriteLine("Você não tem dinheiro suficiente para comprar essa quantidade de sementes.");
                    }
                }
                else
                {
                    Console.WriteLine("Quantidade inválida.");
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
        else
        {
            Console.WriteLine("Opção inválida.");
        }
    }

    void PlantarColherSementes()
    {
        Console.WriteLine("Escolha o tipo de semente que deseja plantar ou colher:");
        for (int i = 0; i < sementesPorNivel.Count; i++)
        {
            int nivel = i + 1;
            string semente = sementesPorNivel[nivel];
            int estoque = estoqueSementes[i];
            Console.WriteLine($"{nivel}. {semente} - Estoque: {estoque}");
        }

        Console.Write("Digite o número da opção desejada: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int opcao))
        {
            if (opcao >= 1 && opcao <= sementesPorNivel.Count)
            {
                int nivelIndex = opcao - 1;

                if (nivelIndex <= nivelFertilidade - 1)
                {
                    int estoqueSemente = estoqueSementes[nivelIndex];

                    if (estoqueSemente > 0)
                    {
                        int areaNecessaria = nivelIndex + 1;
                        if (areaPlantada >= areaNecessaria)
                        {
                            Console.Write("Digite a quantidade de sementes que deseja plantar ou colher: ");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out int quantidade))
                            {
                                if (quantidade > 0 && quantidade <= estoqueSemente)
                                {
                                    if (quantidade <= areaPlantada)
                                    {
                                        int quantidadeProdutos = quantidade * (nivelIndex + 1);
                                        estoqueProdutos[nivelIndex + 3] += quantidadeProdutos;
                                        estoqueSementes[nivelIndex] -= quantidade;
                                        Console.WriteLine($"Você plantou ou colheu {quantidade} {sementesPorNivel[opcao]} e obteve {quantidadeProdutos} produtos.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("A quantidade de sementes excede a área plantada disponível.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Quantidade inválida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Quantidade inválida.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Você não possui área suficiente para plantar essa quantidade de sementes.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Você não possui sementes desse tipo para plantar ou colher.");
                    }
                }
                else
                {
                    Console.WriteLine("Você não pode plantar ou colher sementes de um nível superior ao da fertilidade da fazenda.");
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
        else
        {
            Console.WriteLine("Opção inválida.");
        }
    }



    void TrabalharComAnimais()
    {
        Console.WriteLine("Escolha o tipo de animal com o qual deseja trabalhar:");
        for (int i = 0; i < animaisPorNivel.Count; i++)
        {
            int nivel = i + 1;
            string animal = animaisPorNivel[nivel];
            int estoque = quantidadeAnimais[i];
            Console.WriteLine($"{nivel}. {animal} - Estoque: {estoque}");
        }

        Console.Write("Digite o número da opção desejada: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int opcao))
        {
            if (opcao >= 1 && opcao <= animaisPorNivel.Count)
            {
                int nivelIndex = opcao - 1;

                int estoqueAnimal = quantidadeAnimais[nivelIndex];

                if (estoqueAnimal > 0)
                {
                    Console.WriteLine($"Digite a quantidade de {animaisPorNivel[opcao]} com a qual deseja trabalhar:");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int quantidadeTrabalhar))
                    {
                        if (quantidadeTrabalhar > 0 && quantidadeTrabalhar <= estoqueAnimal)
                        {
                            int quantidadeProdutos = ObterProdutosAnimais(nivelIndex, quantidadeTrabalhar);
                            Console.WriteLine($"Você trabalhou com {quantidadeTrabalhar} {animaisPorNivel[opcao]} e obteve {quantidadeProdutos} produtos.");

                            estoqueProdutos[nivelIndex] += quantidadeProdutos;

                            if (quantidadeTrabalhar < estoqueAnimal)
                            {
                                quantidadeAnimais[nivelIndex] -= quantidadeTrabalhar;
                            }
                            else
                            {
                                quantidadeAnimais[nivelIndex] = 1;
                            }

                            if (nivelIndex == 0)
                            {
                                RealizarSorteioAnimais();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Quantidade inválida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Quantidade inválida.");
                    }
                }
                else
                {
                    Console.WriteLine("Você não possui animais desse tipo para trabalhar.");
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
        else
        {
            Console.WriteLine("Opção inválida.");
        }
    }


    void RealizarSorteioAnimais()
    {
        Random random = new Random();
        int sorteio = random.Next(100);
        if (sorteio < 30)
        {
            int quantidadeAtual = quantidadeAnimais[0];
            int novaQuantidade = random.Next(quantidadeAtual + 1, quantidadeAtual + 6);
            quantidadeAnimais[0] = novaQuantidade;
            Console.WriteLine($"O estoque de produtos foi atualizado para {novaQuantidade}.");
        }
    }


    int ObterProdutosAnimais(int nivelIndex, int quantidadeTrabalhar)
    {
        Random random = new Random();
        int minProdutos = quantidadeTrabalhar;
        int maxProdutos = quantidadeTrabalhar * 3;
        int quantidadeProdutos = random.Next(minProdutos, maxProdutos + 1);
        return quantidadeProdutos;
    }


    void VenderProdutos()
    {
        Console.WriteLine("Escolha o tipo de produto que deseja vender:");
        for (int i = 0; i < estoqueProdutos.Length; i++)
        {
            string produto = "";
            int quantidade = estoqueProdutos[i];
            int preco = precoProdutos[i];

            switch (i)
            {
                case 0:
                    produto = "Leite (Vaca)";
                    break;
                case 1:
                    produto = "Ovo (Galinha)";
                    break;
                case 2:
                    produto = "Carne (Porco)";
                    break;
                case 3:
                    produto = "Milho";
                    break;
                case 4:
                    produto = "Trigo";
                    break;
                case 5:
                    produto = "Soja";
                    break;
                default:
                    break;
            }

            Console.WriteLine($"{i + 1}. {produto} - Estoque: {quantidade} - Preço: {preco} moedas");
        }

        Console.Write("Digite o número da opção desejada: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int opcao))
        {
            if (opcao >= 1 && opcao <= estoqueProdutos.Length)
            {
                int estoqueIndex = opcao - 1;
                int quantidadeEstoque = estoqueProdutos[estoqueIndex];

                if (quantidadeEstoque > 0)
                {
                    string produto = "";

                    switch (estoqueIndex)
                    {
                        case 0:
                            produto = "Leite (Vaca)";
                            break;
                        case 1:
                            produto = "Ovo (Galinha)";
                            break;
                        case 2:
                            produto = "Carne (Porco)";
                            break;
                        case 3:
                            produto = "Milho";
                            break;
                        case 4:
                            produto = "Trigo";
                            break;
                        case 5:
                            produto = "Soja";
                            break;
                        default:
                            break;
                    }

                    Console.Write("Digite a quantidade de produtos que deseja vender: ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int quantidadeVender))
                    {
                        if (quantidadeVender > 0 && quantidadeVender <= quantidadeEstoque)
                        {
                            int precoProduto = precoProdutos[estoqueIndex];
                            int valorTotal = precoProduto * quantidadeVender;

                            dinheiro += valorTotal;
                            estoqueProdutos[estoqueIndex] -= quantidadeVender;

                            Console.WriteLine($"Você vendeu {quantidadeVender} {produto} por {valorTotal} moedas.");
                        }
                        else
                        {
                            Console.WriteLine("Quantidade inválida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Quantidade inválida.");
                    }
                }
                else
                {
                    Console.WriteLine("Você não possui produtos desse tipo para vender.");
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
        else
        {
            Console.WriteLine("Opção inválida.");
        }
    }


    void MelhorarFazenda()
    {
        Console.WriteLine("Escolha o aspecto da fazenda que deseja melhorar:");
        Console.WriteLine("1. Fertilidade do solo");
        Console.WriteLine("2. Sistema de irrigação");
        Console.WriteLine("3. Contratar trabalhadores");
        Console.WriteLine("4. Ampliar área plantada");
        Console.WriteLine("0. Voltar");

        Console.Write("Digite o número da opção desejada: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int opcao))
        {
            switch (opcao)
            {
                case 1:
                    if (nivelFertilidade < 3)
                    {
                        int precoFertilidade = (nivelFertilidade + 1) * 100;
                        if (dinheiro >= precoFertilidade)
                        {
                            nivelFertilidade++;
                            dinheiro -= precoFertilidade;
                            Console.WriteLine("Você melhorou a fertilidade do solo!");
                        }
                        else
                        {
                            Console.WriteLine("Você não tem dinheiro suficiente para melhorar a fertilidade do solo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("A fertilidade do solo já está no nível máximo.");
                    }
                    break;

                case 2:
                    if (nivelIrrigacao < 3)
                    {
                        int precoIrrigacao = (nivelIrrigacao + 1) * 100;
                        if (dinheiro >= precoIrrigacao)
                        {
                            nivelIrrigacao++;
                            dinheiro -= precoIrrigacao;
                            Console.WriteLine("Você melhorou o sistema de irrigação!");
                        }
                        else
                        {
                            Console.WriteLine("Você não tem dinheiro suficiente para melhorar o sistema de irrigação.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("O sistema de irrigação já está no nível máximo.");
                    }
                    break;

                case 3:
                    int precoTrabalhador = quantidadeTrabalhadores * 100;
                    if (dinheiro >= precoTrabalhador)
                    {
                        quantidadeTrabalhadores++;
                        dinheiro -= precoTrabalhador;
                        Console.WriteLine("Você contratou mais um trabalhador!");
                    }
                    else
                    {
                        Console.WriteLine("Você não tem dinheiro suficiente para contratar mais trabalhadores.");
                    }
                    break;

                case 4:
                    int precoAmpliacao = areaPlantada * 10;
                    if (dinheiro >= precoAmpliacao)
                    {
                        areaPlantada += 50;
                        dinheiro -= precoAmpliacao;
                        Console.WriteLine("Você ampliou a área plantada!");
                    }
                    else
                    {
                        Console.WriteLine("Você não tem dinheiro suficiente para ampliar a área plantada.");
                    }
                    break;

                case 0:
                   
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Opção inválida.");
        }
    }

}
