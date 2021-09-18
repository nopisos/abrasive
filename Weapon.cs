
class Weapon
{
    private readonly int _damage;
    private int _bullets;

    public Weapon(int damage, int bullets)
    {
        _damage = damage;
        _bullets = bullets;
    }

    public void Fire(Player player)
    {
        if (_bullets <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        player.Health -= _damage;
        _bullets -= 1;
    }
}

class Player
{
    private int _health;

    public Player(int health)
    {
        _health = health;
    }

    public int Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = value;

            if (Health < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}

class Bot
{
    public Weapon Weapon;

    public void OnSeePlayer(Player player)
    {
        Weapon.Fire(player);
    }
}