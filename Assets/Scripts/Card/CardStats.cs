using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Card Asset/New Card")]
public class CardStats : ScriptableObject
{
    public string cardName;
    public int power;
    public int cost;
    public string effect;
    public string flavorText;
    public CardType type;
    public Sprite art;
    public Sprite template;
}
