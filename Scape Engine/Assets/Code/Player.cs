using UnityEngine;
using System;
using System.Collections.Generic;

public class Player
{
    const int DEFAULT_HAND_CAPACITY = 5;
    const int DEFAULT_DECK_CAPACITY = 10;

    public Board board;
    public Camera cam;
    public Deck deck;

    public List<Card> cardCollection;
    public List<BoardObject> selectedObjects;
    
    public int handCapacity;
    bool isSpawning;

    public Player()
    {
        cardCollection = new List<Card>();
        selectedObjects = new List<BoardObject>();
        handCapacity = DEFAULT_HAND_CAPACITY;

        isSpawning = false;
    }

    public void ResetCamera()
    {

    }

    public void PrepareSpawn(BoardObject obj)
    {
        selectedObjects.Add(obj);
        isSpawning = true;
    }

    public void StartDeckBuilding()
    {
        // Create a random combat deck from the existing card
        // collection.
        System.Random r = new System.Random();
        List<Card> combatCards = cardCollection.FindAll(
            c => c.GetType() == typeof(CombatCard));
        List<CombatCard> newDeck = new List<CombatCard>();

        for (int i = 0; combatCards.Count > 0 && 
            i < DEFAULT_DECK_CAPACITY; i++)
        {
            int randCardIndex = r.Next(combatCards.Count - 1);

            CombatCard c = combatCards[randCardIndex] as CombatCard;

            newDeck.Add(c);
        }

        deck = new Deck(newDeck, this);
        deck.PlayCombatCard += DeclareCombatResult;
    }

    public void DeclareCombatResult(object card, CombatCardEventArgs e)
    {
        board.BroadcastMessage(e.diceResult.ToString());
        Debug.Log((card as CombatCard).name);
    }

    public void TranslateCam()
    {

    }

    public void RotateCam()
    {

    }

    public void ZoomCam()
    {

    }

    public void SpawnObject()
    {

    }

    public void ReleaseSelected()
    {
        selectedObjects.Clear();
    }

    public void TranslateSelected()
    {

    }

    public void RotateSelected()
    {

    }
}