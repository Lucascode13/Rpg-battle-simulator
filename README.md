# Simulador de Batalha RPG - C# .NET 8

Simulador de batalha RPG em C# demonstrando herança, polimorfismo e downcasting.

Projeto desenvolvido para demonstrar na prática os conceitos de **Orientação a Objetos** em C#.

## Conceitos aplicados

| Conceito | Onde é usado |
|---|---|
| **Herança** | `Guerreiro`, `Mago` e `Arqueiro` herdam de `Personagem` |
| **Polimorfismo** | Cada classe sobrescreve `Atacar()` e `ExibirStatus()` com comportamento próprio |
| **Override / Virtual** | `Atacar()` e `TomarDano()` são virtuais na base e sobrescritos nas subclasses |
| **Downcasting** | Demonstrado com `is`, `as` e cast direto + tratamento de `InvalidCastException` |
| **Encapsulamento** | Propriedades com getters/setters e atributos privados (`_flechas`, `ManaMaxima`) |

## Personagens disponíveis

- **Guerreiro** — alta armadura, chance de golpe crítico (25%), redução de dano recebido
- **Mago** — sistema de mana, dano mágico amplificado (x1.5), ataque básico quando sem mana
- **Arqueiro** — 80% de chance de acerto, sistema de flechas, fallback sem munição
- **Aldeão** — personagem base sem habilidades especiais

## Como executar

```bash
dotnet run
```

## Menu do programa

```
[1] Ver status de todos
[2] Realizar ataque manual
[3] Batalha automática
[4] Demonstrar polimorfismo
[5] Demonstrar downcasting
[0] Sair
```

## Estrutura do projeto

```
Personagens/
├── Personagem.cs    # Classe base
├── Guerreiro.cs     # Herda de Personagem
├── Mago.cs          # Herda de Personagem
├── Arqueiro.cs      # Herda de Personagem
├── Program.cs       # Menu principal e lógica de batalha
└── Personagens.csproj
```

## Tecnologias

- C# 12
- .NET 8
- IDE: JetBrains Rider

---

*Projeto desenvolvido durante o curso Técnico em Desenvolvimento de Sistemas — SENAI-MG*
