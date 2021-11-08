
public class Card
{
    public int Id;
    public string CardName;

    public Card(int id, string cardName)
    {
        this.Id = id;
        this.CardName = cardName;
    }
}

public class MonsterCard : Card
{
    public int Attack;
    public int HealthPoint;
    public int HealthPointMax;

    public MonsterCard(int id, string cardName, int attack, int healthPointMax):base (id,cardName)
    {
        this.Attack = attack;
        this.HealthPoint = healthPointMax;
        this.HealthPointMax = healthPointMax;
    }
}

public class SpellCard : Card
{
    public string Effect;
    
    public SpellCard(int id, string cardName, string effect):base (id,cardName)
    {
        this.Effect = effect;
    }
}