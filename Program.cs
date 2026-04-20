using Personagens;

class Program
{
    static List<Personagem> personagens = new();
    static Random rng = new Random();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        ExibirTitulo();
        MontarElenco();

        bool rodando = true;
        while (rodando)
        {
            ExibirMenu();
            string opcao = Console.ReadLine() ?? "";

            switch (opcao.Trim())
            {
                case "1": ExibirTodosStatus(); break;
                case "2": RealizarAtaque(); break;
                case "3": BatalhaAutomatica(); break;
                case "4": DemonstrarPolimorfismo(); break;
                case "5": DemonstrarDowncasting(); break;
                case "0": rodando = false; break;
                default:
                    Console.WriteLine("\n  Opcao invalida. Tente novamente.");
                    break;
            }
        }

        Console.WriteLine("\n  Obrigado por jogar! Encerrando...\n");
    }

    static void MontarElenco()
    {
        personagens.Add(new Guerreiro("Thorin",   150, 35, armadura: 15));
        personagens.Add(new Guerreiro("Aragorn",  120, 30, armadura: 10));
        personagens.Add(new Mago("Gandalf",        80, 45, mana: 120));
        personagens.Add(new Mago("Merlin",         70, 50, mana: 100));
        personagens.Add(new Arqueiro("Legolas",   100, 40, flechas: 15));
        personagens.Add(new Arqueiro("Robin",      90, 35, flechas: 12));
        personagens.Add(new Personagem("Aldeao",   30, 5));
    }

    static void ExibirTitulo()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("  ================================================");
        Console.WriteLine("       SIMULADOR DE BATALHA RPG - C# .NET 8       ");
        Console.WriteLine("  ================================================");
        Console.WriteLine("  Conceitos: Heranca | Polimorfismo | Downcasting ");
        Console.WriteLine("  ================================================");
        Console.WriteLine();
    }

    static void ExibirMenu()
    {
        Console.WriteLine();
        Console.WriteLine("  -------- MENU PRINCIPAL --------");
        Console.WriteLine("  [1] Ver status de todos");
        Console.WriteLine("  [2] Realizar ataque manual");
        Console.WriteLine("  [3] Batalha automatica");
        Console.WriteLine("  [4] Demonstrar polimorfismo");
        Console.WriteLine("  [5] Demonstrar downcasting");
        Console.WriteLine("  [0] Sair");
        Console.Write("\n  Escolha: ");
    }

    static void ExibirTodosStatus()
    {
        Console.WriteLine("\n  ===== STATUS DOS PERSONAGENS =====");
        foreach (var p in personagens)
        {
            p.ExibirStatus();
        }
        Console.WriteLine("  ==================================");
    }

    static void RealizarAtaque()
    {
        var vivos = personagens.Where(p => p.EstaVivo).ToList();
        if (vivos.Count < 2)
        {
            Console.WriteLine("\n  Personagens insuficientes para batalha.");
            return;
        }

        Console.WriteLine("\n  === ESCOLHA O ATACANTE ===");
        for (int i = 0; i < vivos.Count; i++)
            Console.WriteLine($"  [{i + 1}] {vivos[i].Nome} ({vivos[i].TipoPersonagem()}) - Vida: {vivos[i].Vida}");

        Console.Write("\n  Atacante: ");
        if (!int.TryParse(Console.ReadLine(), out int idxAtacante) || idxAtacante < 1 || idxAtacante > vivos.Count)
        {
            Console.WriteLine("  Opcao invalida.");
            return;
        }
        var atacante = vivos[idxAtacante - 1];

        Console.WriteLine("\n  === ESCOLHA O ALVO ===");
        var alvos = vivos.Where(p => p != atacante).ToList();
        for (int i = 0; i < alvos.Count; i++)
            Console.WriteLine($"  [{i + 1}] {alvos[i].Nome} ({alvos[i].TipoPersonagem()}) - Vida: {alvos[i].Vida}");

        Console.Write("\n  Alvo: ");
        if (!int.TryParse(Console.ReadLine(), out int idxAlvo) || idxAlvo < 1 || idxAlvo > alvos.Count)
        {
            Console.WriteLine("  Opcao invalida.");
            return;
        }
        var alvo = alvos[idxAlvo - 1];

        Console.WriteLine($"\n  --- {atacante.Nome} ataca {alvo.Nome}! ---");
        atacante.Atacar(alvo);

        if (!alvo.EstaVivo)
        {
            Console.WriteLine($"\n  *** {alvo.Nome} foi derrotado! ***");
            personagens.Remove(alvo);
        }
    }

    static void BatalhaAutomatica()
    {
        // Reseta personagens para batalha limpa
        personagens.Clear();
        MontarElenco();

        Console.WriteLine("\n  ===== BATALHA AUTOMATICA =====");
        Console.WriteLine("  Todos os personagens comecam a batalhar!\n");

        int rodada = 1;
        while (personagens.Count(p => p.EstaVivo) > 1)
        {
            Console.WriteLine($"  --- Rodada {rodada} ---");

            var vivos = personagens.Where(p => p.EstaVivo).ToList();
            var atacante = vivos[rng.Next(vivos.Count)];
            var alvo = vivos.Where(p => p != atacante).ElementAt(rng.Next(vivos.Count - 1));

            atacante.Atacar(alvo);

            if (!alvo.EstaVivo)
            {
                Console.WriteLine($"  *** {alvo.Nome} foi eliminado! ***");
                personagens.Remove(alvo);
            }

            rodada++;
            System.Threading.Thread.Sleep(400);

            if (rodada > 50) break;
        }

        var vencedor = personagens.FirstOrDefault(p => p.EstaVivo);
        Console.WriteLine("\n  ===== RESULTADO =====");
        if (vencedor != null)
        {
            Console.WriteLine($"  VENCEDOR: {vencedor.Nome} ({vencedor.TipoPersonagem()})");
            vencedor.ExibirStatus();
        }
        Console.WriteLine("  =====================");

        // Restaura para uso no menu
        personagens.Clear();
        MontarElenco();
    }

    static void DemonstrarPolimorfismo()
    {
        Console.WriteLine("\n  ===== POLIMORFISMO =====");
        Console.WriteLine("  Mesma chamada ExibirStatus(), comportamentos diferentes:\n");

        List<Personagem> lista = new()
        {
            new Guerreiro("Thorin", 150, 35),
            new Mago("Gandalf", 80, 45),
            new Arqueiro("Legolas", 100, 40),
            new Personagem("Aldeao", 30, 5)
        };

        foreach (var p in lista)
            p.ExibirStatus();

        Console.WriteLine("\n  Mesma chamada Atacar(), comportamentos diferentes:\n");
        var alvo = new Personagem("Boneco de Treino", 999, 0);
        foreach (var p in lista)
            p.Atacar(alvo);

        Console.WriteLine("  ========================");
    }

    static void DemonstrarDowncasting()
    {
        Console.WriteLine("\n  ===== DOWNCASTING =====");

        Personagem p1 = new Guerreiro("Boromir", 100, 30);

        // Downcasting seguro com is
        if (p1 is Guerreiro g)
        {
            Console.WriteLine($"\n  [OK] Downcasting com 'is': {g.Nome} e um Guerreiro com Armadura {g.Armadura}");
        }

        // Downcasting seguro com as
        Mago? m = p1 as Mago;
        if (m == null)
            Console.WriteLine("  [OK] Downcasting com 'as': p1 nao e um Mago (retornou null, sem excecao)");

        // Downcasting inseguro com cast direto
        Console.WriteLine("\n  Tentando cast direto (Mago)p1 onde p1 e Guerreiro...");
        try
        {
            Mago mErro = (Mago)p1;
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine($"  [ERRO capturado] {ex.Message}");
        }

        Console.WriteLine("\n  Conclusao: prefira 'is' ou 'as' ao inves de cast direto!");
        Console.WriteLine("  ========================");
    }
}
