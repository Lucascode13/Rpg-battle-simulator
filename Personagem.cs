namespace Personagens;

public class Personagem
{
    public string Nome { get; set; }
    public int Vida { get; set; }
    public int VidaMaxima { get; private set; }
    public int Dano { get; set; }

    public bool EstaVivo => Vida > 0;

    public Personagem(string nome, int vida, int dano)
    {
        Nome = nome;
        Vida = vida;
        VidaMaxima = vida;
        Dano = dano;
    }

    public virtual void Atacar(Personagem alvo)
    {
        int danoFinal = GerarDano();
        alvo.TomarDano(danoFinal);
        Console.WriteLine($"  {Nome} ataca {alvo.Nome} causando {danoFinal} de dano!");
    }

    public virtual void TomarDano(int dano)
    {
        Vida = Math.Max(0, Vida - dano);
    }

    protected int GerarDano()
    {
        return new Random().Next((int)(Dano * 0.8), (int)(Dano * 1.2) + 1);
    }

    public virtual void ExibirStatus()
    {
        string barra = GerarBarraDeVida();
        Console.WriteLine($"  [{TipoPersonagem(),-10}] {Nome,-12} | Vida: {barra} {Vida,3}/{VidaMaxima}");
    }

    public virtual string TipoPersonagem() => "ALDEAO";

    protected string GerarBarraDeVida()
    {
        int total = 10;
        int cheio = (int)Math.Round((double)Vida / VidaMaxima * total);
        return "[" + new string('=', cheio) + new string('-', total - cheio) + "]";
    }
}
