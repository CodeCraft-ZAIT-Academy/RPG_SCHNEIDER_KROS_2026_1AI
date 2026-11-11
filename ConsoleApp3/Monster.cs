internal class Monster
{
    public int Hp { get; set; }
    public int Damage { get; set; }
    public int Gold { get; set; }

    public Monster(int hp, int damage, int gold)
    {
        Hp = hp;
        Damage = damage;
        Gold = gold;
    }

    internal void Attack(Player player)
    {
        player.Hp -= Damage;
    }
}