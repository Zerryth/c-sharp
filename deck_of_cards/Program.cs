using System;
using System.Collections.Generic;
using System.Linq;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck1 = new Deck();
            deck1.shuffle().displayDeck();
            // deck1.dealTopCard();
            // deck1.displayDeck();
            deck1.getDeckCount();
            // deck1.reset().displayDeck().getDeckCount();

            Player jill = new Player("Jill");
            jill.drawCard(deck1);
            jill.drawCard(deck1);
            jill.showHand();
            deck1.getDeckCount();
            jill.discardCard(1);
            jill.showHand();

            List<Card> AllHeartCards = deck1.cards.Where(card => card.suit == "Hearts").OrderBy(card => card.val).ToList();

            int highestVal = AllHeartCards.Max(c => c.val);
            AllHeartCards.First(c => c.val == highestVal);
        }
    }
}
