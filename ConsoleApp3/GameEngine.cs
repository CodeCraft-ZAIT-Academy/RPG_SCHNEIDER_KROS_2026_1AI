internal class GameEngine
{
    public Player Player { get; set; }
    public Monster[] Monsters { get; set; }

    Random random = new Random();

    public GameEngine()
    {
        Player = new Player(1000, 50);
        Monsters = new Monster[50];

        for (int i = 1; i < 51; i++)
        {
            Monsters[i - 1] = new Monster(i * 10, 10, i * 5);
        }
    }

    internal void GameStart()
    {
        Console.WriteLine("========== HRA ==========");
        Console.WriteLine("Tvoje HP: " + Player.Hp);
        Console.WriteLine("Tvoje zlato: " + Player.Gold);
        Console.WriteLine("=========================");

        for (int i = 0; i < Monsters.Length; i++)
        {
            Console.WriteLine("\nBojuješ s príšerou číslo: " + (i + 1));

            while (Player.Hp > 0 && Monsters[i].Hp > 0)
            {
                // Prvý útok hráča
                Player.Attack(Monsters[i]);

                // Šanca na druhý útok
                double chance = Player.Speed - 1;

                if (random.NextDouble() < chance && Monsters[i].Hp > 0)
                {
                    Player.Attack(Monsters[i]);
                    Console.WriteLine("Hráč zaútočil 2x!");
                }

                // Príšera zaútočí
                if (Monsters[i].Hp > 0)
                {
                    Monsters[i].Attack(Player);
                }

                Console.WriteLine("-------------------------");
                Console.WriteLine("Player HP: " + Player.Hp);
                Console.WriteLine("Monster HP: " + Monsters[i].Hp);
                Console.WriteLine("Tvoje zlato: " + Player.Gold);
            }

            // Hráč vyhral
            if (Player.Hp > 0 && Monsters[i].Hp <= 0)
            {
                Console.WriteLine("\nHráč vyhral!");
                Player.Gold += Monsters[i].Gold;

                Console.WriteLine("Získal si zlato: " + Monsters[i].Gold);
                Console.WriteLine("CELKOVÉ ZLATO: " + Player.Gold);
            }

            // Príšera vyhrala
            if (Player.Hp <= 0)
            {
                Console.WriteLine("\nPríšera vyhrala!");
                break;
            }
        }
        Console.WriteLine("================================");
        Console.WriteLine("Tvoje HP: " + Player.Hp);
        Console.WriteLine("Tvoje celkové zlato: " + Player.Gold);

    }
}
