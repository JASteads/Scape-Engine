using System;
using System.Collections.Generic;
using UnityEngine;

public class CombatCard : Card
{
    public List<DieRoll> diceList;

    public CombatCard(string name, string desc, 
        Transform parent, List<int> dice)
        : base(name, desc, parent)
    {
        diceList = new List<DieRoll>();

        dice.ForEach(d => diceList.Add(new DieRoll(d)));
    }

    public override void OnClick()
    {
        CombatCardEventArgs args = new CombatCardEventArgs
        {
            diceResult = new List<int>()
        };

        diceList.ForEach(d => args.diceResult.Add(d.Roll()));
        EventHandler<CombatCardEventArgs> handler = PlayCard;
        handler?.Invoke(this, args);
    }

    public event EventHandler<CombatCardEventArgs> PlayCard;
}

public class CombatCardEventArgs : EventArgs
{
    public List<int> diceResult;
}