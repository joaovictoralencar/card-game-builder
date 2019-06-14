using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public GameObject cardBackground;
    CardStats stats;
    CardType type;
    Sprite art;
    Attack attack;
    Logic currentLogic;
    Player ownerPlayer;
    string cardName;
    int power;
    int cost;
    string effect;
    string flavorText;
    bool canAttack, canBeAttacked;
    public string FlavorText { get => flavorText; set => flavorText = value; }
    public string Effect { get => effect; set => effect = value; }
    public int Cost { get => cost; set => cost = value; }
    public int Power { get => power; set => power = value; }
    public string CardName { get => cardName; set => cardName = value; }
    public CardType Type { get => type; set => type = value; }
    public Sprite Art { get => art; set => art = value; }
    public CardStats Stats { get => stats; set => stats = value; }
    public Player OwnerPlayer { get => ownerPlayer; set => ownerPlayer = value; }
    public Logic CurrentLogic { get => currentLogic; set => currentLogic = value; }
    public Text textCardName, textPower, textCost, textEffect, textFlavor;
    public Image artImage, template;

    public void CreateCard(CardStats stats)//Create a card according to a card stats
    {
        Stats = stats;
        CardName = Stats.cardName;
        Power = Stats.power;
        Cost = Stats.cost;
        Effect = Stats.effect;
        FlavorText = Stats.flavorText;
        Type = Stats.type;
        Art = Stats.art;
        UpdateCardStats();
    }
    public void UpdateCardStats()//Updates the card's values
    {
        template.sprite = Stats.template;
        textCardName.text = cardName;
        textPower.text = power.ToString();
        if (type.hasPower)
        {
            textPower.gameObject.SetActive(true);
        }
        else//if the card hasn't power, hide the number
        {
            textPower.gameObject.SetActive(false);
        }
        textCost.text = cost.ToString();
        textEffect.text = effect;
        textFlavor.text = '"' + flavorText + '"';
        artImage.sprite = art;
    }

    public void CheckCardPower()//checks if the card's power is equal or less than 0
    {
        if (power <= 0)
            ownerPlayer.KillCard(this);//if true, kills the card
    }
    public void OnClick()//calls the OnClick of the current logic
    {
        if (currentLogic != null)
            currentLogic.OnClick(this);
    }

    public void OnHover()//calls the OnHover of the current logic
    {
        if (currentLogic != null)
            currentLogic.OnHover(this);
    }
}
