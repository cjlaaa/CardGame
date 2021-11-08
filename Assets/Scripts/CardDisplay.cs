using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Text nameText;
    public Text attackText;
    public Text healthText;
    public Text effectText;

    public Image backgroundImage;

    public Card card;
    
    // Start is called before the first frame update
    void Start()
    {
        ShowCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCard()
    {
        nameText.text = card.CardName;
        if (card is MonsterCard)
        {
            var monster = card as MonsterCard;
            attackText.text = monster.Attack.ToString();
            healthText.text = monster.HealthPoint.ToString();
            
            effectText.gameObject.SetActive(false);
        }
        else if (card is SpellCard)
        {
            var spell = card as SpellCard;
            effectText.text = spell.Effect;
            
            attackText.gameObject.SetActive(false);
            healthText.gameObject.SetActive(false);
        }
    }
}
