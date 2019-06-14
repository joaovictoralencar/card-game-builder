using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Asset/New Logic/New DeckCardLogic")]
public class DeckCardLogic : Logic
{
    public override void OnClick(Card card)
    {
        if (Settings.main.currentPlayer == card.OwnerPlayer)
        {
            card.OwnerPlayer.DrawCard();
        }
    }

    public override void OnHover(Card card)
    {
    }
}
