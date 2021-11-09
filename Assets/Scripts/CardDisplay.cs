using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Text NameText;
    public Text AttackText;
    public Text HealthText;
    public Text EffectText;

    public Image BackgroundImage;

    public Card Card;
    
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
        NameText.text = Card.CardName;
        if (Card is MonsterCard)
        {
            var monster = Card as MonsterCard;
            AttackText.text = monster.Attack.ToString();
            HealthText.text = monster.HealthPoint.ToString();
            
            EffectText.gameObject.SetActive(false);
        }
        else if (Card is SpellCard)
        {
            var spell = Card as SpellCard;
            EffectText.text = spell.Effect;
            
            AttackText.gameObject.SetActive(false);
            HealthText.gameObject.SetActive(false);
        }
    }
}
