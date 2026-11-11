internal class Player
{
    public int Hp { get; set; }
    public int Damage { get; set; }
    public int Gold { get; set; }
    public double Speed { get; set; }

    public Player(int hp, int damage)
    {
        Hp = hp;
        Damage = damage;
        Gold = 0;
        Speed = 1.5;
    }

    internal void Attack(Monster monster)
    {
        monster.Hp -= Damage;
    }
}