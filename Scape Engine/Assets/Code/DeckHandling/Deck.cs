using System;
using System.Collections.Generic;

public class Deck
{
    public List<CombatCard> drawPile, discardPile, hand;
    public DeckUI dUI;

    public Deck(List<CombatCard> cards, Player p)
    {
        drawPile = new List<CombatCard>(cards);
        dUI = new DeckUI(p.cam.transform.parent);

        drawPile.ForEach(c => c.PlayCard += PlayCombatCard);
    }

    public void PlayCard(object sender, CombatCardEventArgs e)
    {
        EventHandler<CombatCardEventArgs> handler = PlayCombatCard;
        handler?.Invoke(sender as CombatCard, e);
    }

    public void DrawCard()
    {
        int target = drawPile.Count - 1;

        hand.Add(drawPile[target]);
        drawPile.RemoveAt(target);
    }

    public void DiscardCard(Card c)
    {

    }

    public void ShuffleDrawPile()
    {
        Random r = new Random();
        List<CombatCard> shuffledDeck = new List<CombatCard>();
        int drawSize = drawPile.Count;

        for (int i = 0; drawPile.Count > 0 && i < drawSize; i++)
        {
            int randCardIndex = r.Next(drawPile.Count - 1);
            shuffledDeck.Add(drawPile[randCardIndex]);
        }

        drawPile = shuffledDeck;
    }

    public event EventHandler<CombatCardEventArgs> PlayCombatCard;
}