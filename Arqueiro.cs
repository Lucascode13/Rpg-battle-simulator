namespace Personagens;

public class Arqueiro : Personagem
{
    private int _flechas;

    public Arqueiro(string nome, int vida, int dano, int flechas = 10) : base(nome, vida, dano)
    {
        _flechas = flechas;
    }

    public override void Atacar(Personagem alvo)
    {
        if (_flechas > 0)
        {
            Random rng = new Random();
            bool acertou = rng.Next(0, 100) < 80;
            _flechas--;

            if (acertou)
            {
                int danoFinal = GerarDano();
                alvo.TomarDano(danoFinal);
                Console.WriteLine($"  {Nome} atira uma flecha em {alvo.Nome}! Dano: {danoFinal}. (Flechas: {_flechas})");
            }
            else
            {
                Console.WriteLine($"  {Nome} errou o tiro! (Flechas: {_flechas})");
            }
        }
        else
        {
            int danoFinal = GerarDano() / 3;
            alvo.TomarDano(danoFinal);
            Console.WriteLine($"  {Nome} sem flechas! Usa o arco como clava em {alvo.Nome}. Dano: {danoFinal}.");
        }
    }

    public override void ExibirStatus()
    {
        string barra = GerarBarraDeVida();
        Console.WriteLine($"  [{TipoPersonagem(),-10}] {Nome,-12} | Vida: {barra} {Vida,3}/{VidaMaxima} | Flechas: {_flechas}");
    }

    public override string TipoPersonagem() => "ARQUEIRO";
}
