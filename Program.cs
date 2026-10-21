// --- Gerenciador de tarefas ---

List<string> aFazer = new List<string>();
List<string> emAndamento = new List<string>();
List<string> concluido = new List<string>();

string? readResult;

bool rodando = true;
while (rodando)
{
    ExibirKanban();

    Console.WriteLine("\n[1]. Adicionar | [2]. Mover | [3]. Sair");
    Console.Write("Escolha uma opção: ");
    readResult = Console.ReadLine();

    switch (readResult)
    {
        case "1":
            AdicionarTarefa();
            break;

        case "2":
            MoverTarefa();
            break;

        case "3":
            rodando = false;
            break;

        default:
            Console.WriteLine("Opção inválida! pressione qualquer tecla para sair");
            Console.ReadKey();
            break;
    }
}

void ExibirKanban()
{
    Console.Clear();

    Console.WriteLine("=== MEU KABAN CONSOLE ===");

    Console.WriteLine("\n--- A FAZER ---");
    foreach (var tarefa in aFazer)
        Console.WriteLine($"- {tarefa}");

    Console.WriteLine("\n--- EM ANDAMENTO ---");
    foreach(var tarefa in emAndamento)
        Console.WriteLine($"- {tarefa}");

    Console.WriteLine("\n--- CONCLUIDO ---");
    foreach (var tarefa in concluido)
        Console.WriteLine($"- {tarefa}");

    Console.WriteLine("==========================");
}

void AdicionarTarefa()
{
    Console.Write("Adicionar nome da tarefa: ");
    readResult = Console.ReadLine()!.Trim();

    if (!string.IsNullOrWhiteSpace(readResult))
        aFazer.Add(readResult);
}

void MoverTarefa()
{
    Console.Clear();

    Console.Write("\nDigite a tarefa que você quer mover: ");
    string? itemParaMover = Console.ReadLine()!.Trim();

    List<string> listaOrigem = null;

    if (aFazer.Contains(itemParaMover))
        listaOrigem = aFazer;

    else if (emAndamento.Contains(itemParaMover))
        listaOrigem = emAndamento;

    else if (concluido.Contains(itemParaMover))
        listaOrigem = concluido;

    if (listaOrigem == null) {
        Console.WriteLine("Erro! essa tarefa não existe em nenhuma lista");
        Console.ReadLine();
        return;
    }


    Console.WriteLine("\nEcontrada! Para qual lista deve ir?");
    Console.WriteLine("[1]. A FAZER | [2]. EM ANDAMENTO | [3]. CONCLUÍDO");

    readResult = Console.ReadLine();
    List<string> listaDestino = null;

    if (readResult == "1")
        listaDestino = aFazer;

    else if (readResult == "2")
        listaDestino = emAndamento;

    else if (readResult == "3")
        listaDestino = concluido;

    if (listaDestino == null) {
        Console.WriteLine("Erro! Destino inválido");
        return;
    }

    listaDestino.Add(itemParaMover!);
    listaOrigem.Remove(itemParaMover!);

}

