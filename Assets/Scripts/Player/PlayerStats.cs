using UnityEngine;

[CreateAssetMenu(menuName = "Card Asset/New Player")]
public class PlayerStats : ScriptableObject
{
    public string playerName;
    public int initialLife;
    public int initialMana;
    public Deck InitialDeck;
    public HandCardLogic handCardLogic;
    public FieldCardLogic fieldCardLogic;
    public DeckCardLogic deckCardLogic;
    public CemiteryCardLogic cemiteryCardLogic;
    public PlayerState normalState;
    public Sprite portrait;

}