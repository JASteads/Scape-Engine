using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class DeckUI
{
    public Transform tf;
    public readonly Deck deck;
    public RectTransform drawSection, discardSection, handSection;
    int drawCount, discardCount;

    public DeckUI(Transform parent)
    {
        InterfaceTool.CanvasSetup("Deck UI", parent, out Canvas c);
        tf = c.transform;
    }

    void UpdateUI()
    {
        drawCount = deck.drawPile.Count;
        discardCount = deck.discardPile.Count;
    }
}