using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Asset/New Resource Manager")]
public class ResourcesManager : ScriptableObject
{
    public CardStats[] allCards;//todas as cartas que estão em jogo
    Dictionary<string, CardStats> cardsDictionary = new Dictionary<string, CardStats>();//um dicionário para referenciar as cartas mais facilmente
    public void OnStart()
    {
        cardsDictionary.Clear();//limpa o dicionário
        for (int i = 0; i < allCards.Length; i++)
        {
            //adds all the cards to the dicitonary, setting the key as their names
            cardsDictionary.Add(allCards[i].cardName, allCards[i]);
        }
    }
    public CardStats GetCardByName(string name)//returns a cardStats according to its id in the dictionary
    {
        CardStats originalCard = null;
        cardsDictionary.TryGetValue(name, out originalCard);//searches for the cardName of the dictionary
        if (originalCard == null)//if doesn't exists return null and finishes the function
            return null;
        CardStats newInstance = Instantiate(originalCard);//se does exists, instantiates it
        newInstance.name = originalCard.cardName;//to make sure the name is going to be the same
        return newInstance;//returns the cardStats
    }

}