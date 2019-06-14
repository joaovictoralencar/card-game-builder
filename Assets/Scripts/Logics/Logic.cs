using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Logic : ScriptableObject
{
    public abstract void OnClick(Card card);
    public abstract void OnHover(Card card); 
}
