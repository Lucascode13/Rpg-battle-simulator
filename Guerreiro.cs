namespace Personagens;

public class Guerreiro : Personagem
{
    public int Armadura { get; set; }

    public Guerreiro(string nome, int vida, int dano, int armadura = 10) : base(nome, vida, dano)
    {
        Armadura = armadura;
    }

    public override void Atacar(Personagem alvo)
    {
        Random rng = new Random();
        bool critico = rng.Next(0, 100) < 25;
        int danoFinal = GerarDano();
        if (critico) danoFinal = (int)(danoFinal * 1.8);

        alvo.TomarDano(danoFinal);

        if (critico)
            Console.WriteLine($"  ** GOLPE CRITICO! ** {Nome} acerta {alvo.Nome} com {danoFinal} de dano!");
        else
            Console.WriteLine($"  {Nome} usa Ataque Forte em {alvo.Nome}! Dano: {danoFinal}.");
    }

    public override void TomarDano(int dano)
    {
        int danoReduzido = Math.Max(1, dano - Armadura);
        int absorvido = dano - danoReduzido;
        Vida = Math.Max(0, Vida - danoReduzido);
        if (absorvido > 0)
            Console.WriteLine($"     (Armadura de {Nome} absorveu {absorvido} de dano)");
    }

    public override void ExibirStatus()
    {
        string barra = GerarBarraDeVida();
        Console.WriteLine($"  [{TipoPersonagem(),-10}] {Nome,-12} | Vida: {barra} {Vida,3}/{VidaMaxima} | Armadura: {Armadura}");
    }

    public override string TipoPersonagem() => "GUERREIRO";
}
