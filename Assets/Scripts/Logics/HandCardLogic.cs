using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Asset/New Logic/New HandCardLogic")]
public class HandCardLogic : Logic
{
    public override void OnClick(Card card)
    {
        if (Settings.main.currentPlayer == card.OwnerPlayer)
        {
            card.OwnerPlayer.DropCard(card);
        }
    }

    public override void OnHover(Card card)
    {
    }
}
