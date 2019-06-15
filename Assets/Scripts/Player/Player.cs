using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlayerStats stats;
    PlayerState state;
    public Transform handTransform, deckTransform, fieldTransform, cemeteryTransform;
    public Text lifeText,manaText, playerNameText;

    string playerName;
    public Image portrait;
    int life, mana;
    bool canAttack, canBeAttacked, canUseEffect;
    Deck deck;
    List<Card> deckCards, handCards, fieldCards, cemeteryCards;
    public Deck Deck { get => deck; set => deck = value; }
    public bool CanAttack { get => canAttack; set => canAttack = value; }
    public bool CanBeAttacked { get => canBeAttacked; set => canBeAttacked = value; }
    public bool CanUseEffect { get => canUseEffect; set => canUseEffect = value; }
    public int Life { get => life; set => life = value; }
    public int Mana { get => mana; set => mana = value; }
    public List<Card> CemeteryCards { get => cemeteryCards; set => cemeteryCards = value; }
    public List<Card> CemeteryCards1 { get => cemeteryCards; set => cemeteryCards = value; }
    public List<Card> DeckCards { get => deckCards; set => deckCards = value; }
    public List<Card> HandCards { get => handCards; set => handCards = value; }
    public PlayerState State { get => state; set => state = value; }
    public List<Card> FieldCards { get => fieldCards; set => fieldCards = value; }
    public string PlayerName { get => playerName; set => playerName = value; }

    public void InitiatePlayer()//Initiates a player according to the stats variable
    {
        if (stats != null)//if there is a stats to be based
        {
            //Create a new Deck to maintain the original intact
            deck = ScriptableObject.CreateInstance("Deck") as Deck;
            deck.deckCards = stats.InitialDeck.deckCards;
            //the same with name, life and mana
            playerName = stats.playerName;
            life = stats.initialLife;
            mana = stats.initialMana;
            //Initiate the lists
            deckCards = new List<Card>();
            handCards = new List<Card>();
            fieldCards = new List<Card>();
            CemeteryCards = new List<Card>();
            //set the player to be able to attack
            canAttack = true;
            state = stats.normalState;
            portrait.sprite = stats.portrait;
            UpdateStats();
        }
    }

    public void UpdateStats(){
        lifeText.text = life.ToString();
        manaText.text = mana.ToString();
        playerNameText.text = playerName;
    }
    public void CreateDeck()//Creates all the cards according to the deck value
    {
        if (deck != null)
        {
            deck.Shuffle();//Shuffles the deck
            for (int i = 0; i < deck.deckCards.Count; i++)
            {
                CreateCardToDeck(deck.deckCards[i]);
            }
        }
    }

    public void CreateCardToDeck(string cardName)//Creates one card based on its name
    {
        GameObject objectCard = Instantiate(Settings.main.prefabCard, deckTransform);
        Card card = objectCard.GetComponent<Card>();
        card.cardBackground.SetActive(true);//cards inside the deck has its background active
        card.CreateCard(Settings.main.Rm.GetCardByName(cardName));//create the card using the resources manager which has the dictionary
        card.CurrentLogic = stats.deckCardLogic;//define it's logic
        card.OwnerPlayer = this;
        deckCards.Add(card);
    }

    public void DrawInitialCards()//Draw cards according to the main's maxNumHandCards value
    {
        for (int i = 0; i < Settings.main.maxNumHandCards; i++)
        {
            DrawCard();
        }
    }
    public void DrawCard()//Draw the last (on top) card in the deck to the players hand
    {
        if (deckCards.Count > 0 && handCards.Count < Settings.main.maxNumHandCards)
        {
            Card pulledCard = deckCards[deckCards.Count - 1];
            pulledCard.transform.SetParent(handTransform);//Moves the card physically to the hand
            pulledCard.cardBackground.SetActive(false);//cards outside the deck has its background active
            handCards.Add(pulledCard);
            deckCards.Remove(pulledCard);//Removes the card from the deck
            pulledCard.CurrentLogic = stats.handCardLogic;//changes the logic
        }
    }

    public void DropCard(Card card)//Drop a hand card on the field
    {
        if (fieldCards.Count < Settings.main.maxNumFieldCards && mana >= card.Cost)
        {
            card.transform.SetParent(fieldTransform);//Moves the card physically to the field
            fieldCards.Add(card);
            handCards.Remove(card);//Removes the card from the hand
            card.CurrentLogic = stats.fieldCardLogic;//changes the logic
            mana -= card.Cost;
            UpdateStats();
        }
    }
    public void DropRandomCard()
    {
        //Creates a list of droppable cards
        if (handCards.Count > 0)
        {
            List<Card> dropableCards = new List<Card>();
            foreach (Card c in handCards)//runs for all the cards on the player's hand
            {
                if (c.Cost <= mana)
                {//if the card is droppable, adds to the list
                    dropableCards.Add(c);
                }
            }
            if (dropableCards.Count > 0)
            {
                Card card = dropableCards[Random.Range(0, dropableCards.Count - 1)];//Selects a random card from droppable cards
                if (fieldCards.Count < Settings.main.maxNumFieldCards && mana >= card.Cost)
                {
                    card.transform.SetParent(fieldTransform);//Moves the card physically to the field
                    fieldCards.Add(card);
                    handCards.Remove(card);//Removes the card from the hand
                    card.CurrentLogic = stats.fieldCardLogic;//changes the logic
                    mana -= card.Cost;
                }
            }
        }
    }
    public void KillCard(Card card)//Kills a field's card by putting on the cemetery
    {
        if (fieldCards.Contains(card))
        {
            card.transform.SetParent(cemeteryTransform);//Moves the card physically to the cemetery
            CemeteryCards.Add(card);
            fieldCards.Remove(card);//Removes the card from the field
            card.CurrentLogic = stats.cemeteryCardLogic;//changes the logic
            card.CreateCard(card.Stats);
        }
    }

    public void Attack(Card attackingCard, Card targetCard)
    {
        int attackingCardPower = attackingCard.Power;
        int targetCardPower = targetCard.Power;
        targetCard.Power -= attackingCardPower;
        attackingCard.Power -= targetCardPower;
        targetCard.UpdateCardStats();
        attackingCard.UpdateCardStats();
        targetCard.CheckCardPower();
        attackingCard.CheckCardPower();
        state = stats.normalState;
        Settings.main.UpdateUI();

    }

    public void Attack(Card attackingCard, Player targetPlayer)
    {
        if (targetPlayer.canBeAttacked)
            targetPlayer.Life -= attackingCard.Power;
    }

}