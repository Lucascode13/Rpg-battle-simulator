namespace Personagens;

public class Mago : Personagem
{
    public int Mana { get; set; }
    public int ManaMaxima { get; private set; }
    private const int CUSTO_FEITICO = 20;

    public Mago(string nome, int vida, int dano, int mana = 100) : base(nome, vida, dano)
    {
        Mana = mana;
        ManaMaxima = mana;
    }

    public override void Atacar(Personagem alvo)
    {
        if (Mana >= CUSTO_FEITICO)
        {
            int danoFinal = (int)(GerarDano() * 1.5);
            Mana -= CUSTO_FEITICO;
            alvo.TomarDano(danoFinal);
            Console.WriteLine($"  {Nome} lanca Feitico de Fogo em {alvo.Nome}! Dano magico: {danoFinal}. (Mana: {Mana}/{ManaMaxima})");
        }
        else
        {
            int danoFinal = GerarDano() / 2;
            alvo.TomarDano(danoFinal);
            Console.WriteLine($"  {Nome} sem mana! Usa cajado em {alvo.Nome}. Dano: {danoFinal}.");
        }
    }

    public override void ExibirStatus()
    {
        string barraVida = GerarBarraDeVida();
        string barraMana = GerarBarraMana();
        Console.WriteLine($"  [{TipoPersonagem(),-10}] {Nome,-12} | Vida: {barraVida} {Vida,3}/{VidaMaxima} | Mana: {barraMana} {Mana}/{ManaMaxima}");
    }

    public override string TipoPersonagem() => "MAGO";

    private string GerarBarraMana()
    {
        int total = 6;
        int cheio = (int)Math.Round((double)Mana / ManaMaxima * total);
        return "[" + new string('*', cheio) + new string('-', total - cheio) + "]";
    }
}
