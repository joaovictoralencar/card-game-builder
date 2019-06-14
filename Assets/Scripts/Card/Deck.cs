using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Asset/New Deck")]
public class Deck : ScriptableObject {
   public List<string> deckCards; 
   public void Shuffle()
    {
        for (int i = deckCards.Count - 1; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = Random.Range(0, i);

            // Save the value of the current i, otherwise it'll overright when we swap the values
            string temp = deckCards[i];

            // Swap the new and old values
            deckCards[i] = deckCards[rnd];
            deckCards[rnd] = temp;
        }
    }
}