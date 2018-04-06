using System;
using System.Collections.Generic;

namespace card_hackathon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many players?");
            string InputLine = Console.ReadLine();
            int playerCount = 0;
            bool isInt = Int32.TryParse(InputLine, out playerCount);
            Console.WriteLine(Int32.TryParse(InputLine, out playerCount));
            while (!isInt || playerCount > 4 || playerCount < 2)
            {
                if (!isInt)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                else if (playerCount < 2)
                {
                    Console.WriteLine("Games have to have at least 2 players! Please enter a valid number of players.");
                }
                else
                {
                    Console.WriteLine("Game capacity is 4 max. Please enter valid number of players.");
                }   
                InputLine = Console.ReadLine();
                isInt = Int32.TryParse(InputLine, out playerCount);
            }
            Player[] players = new Player[playerCount];
            for (var i = 1; i <= playerCount; i++)
            {
                Console.WriteLine($"Enter name of Player {i}");
                InputLine = Console.ReadLine();
                players[i -1] = new Player(InputLine);
                players[i -1].showPlayerInfo();
            }

            Deck deck = new Deck();
            Card activeCard;
            // game loop
            // round
            while(!checkPoints(players))
            {
                deck.reset();
                foreach(Player player in players)
                {
                    player.discardHand();
                    player.drawCard(deck, 8);
                    player.showHand();
                }
                activeCard = deck.dealTopCard();
                int activeTurnPlayer = 0;

                // CURRENT ROUND
                while(!checkHand(players) && deck.getDeckCount() != 0)
                {
                    Console.WriteLine($"Currently it's {players[activeTurnPlayer].getName()}'s turn.");
                    InputLine = "";
                    while (InputLine != "p")
                    {
                        Console.WriteLine($"There are {deck.getDeckCount()} cards left in the deck.");
                        Console.WriteLine($"{players[activeTurnPlayer].getName()}'s");
                        players[activeTurnPlayer].showHand();
                        Console.WriteLine($"ACTIVE CARD is {activeCard.showCard()}. \n PLAY or DRAW a card.(p/d)");
                        InputLine = Console.ReadLine();
                        while (InputLine != "p" && InputLine != "d")
                        {
                            Console.WriteLine("Command not found. Do you want to draw a card (d) or play a card (p)?");
                            InputLine = Console.ReadLine();
                        }
                        if (InputLine == "d")
                        {
                            players[activeTurnPlayer].drawCard(deck);
                            if (deck.getDeckCount() == 0)
                            {
                                break;
                            }
                        }
                        if (InputLine == "p")
                        {
                            if (!hasValidPlays(players[activeTurnPlayer], activeCard))
                            {
                                Console.WriteLine("YOU DON'T HAZ VALID PLAYZ! Draw a card.");
                                InputLine = "";
                            }
                        }
                        if (deck.getDeckCount() == 0)
                        {
                            break;
                        }
                    }
                     if (deck.getDeckCount() == 0)
                    {
                        break;
                    }
                    Console.WriteLine("Which card would you like to play?");
                    InputLine = Console.ReadLine();
                    int cardId = 0;
                    while (!Int32.TryParse(InputLine, out cardId) || 
                        cardId <= 0 || 
                        cardId > players[activeTurnPlayer].getHandSize() || 
                        (activeCard.val != players[activeTurnPlayer].getValFromHand(cardId -1) &&
                            players[activeTurnPlayer].getValFromHand(cardId -1) != 8 && 
                            activeCard.suit != players[activeTurnPlayer].getSuitFromHand(cardId - 1))
                    )
                    {
                        Console.WriteLine("Not a valid choice. Please enter the ID of the card you wish to play.");
                        InputLine = Console.ReadLine();
                    }

                    activeCard = players[activeTurnPlayer].discardCard(cardId - 1);
                    if (activeCard.val == 8)
                    {
                        Console.WriteLine("CRAZY 8! What suit would do you declare? (Spades, Clubs, Hearts, Diamonds)");
                        do {
                            InputLine = Console.ReadLine();
                            if (InputLine != "Spades" && InputLine != "Clubs" && InputLine != "Hearts" && InputLine != "Diamonds")
                            {
                                Console.WriteLine("Not a valid suit. Which suit would you like to declare? (Spades, Clubs, Hearts, Diamonds)");
                            }
                        } while (InputLine != "Spades" && InputLine != "Clubs" && InputLine != "Hearts" && InputLine != "Diamonds");
                        activeCard.suit = InputLine;
                    }
                    activeTurnPlayer = (activeTurnPlayer + 1) % playerCount; // stay within bounds & loop thru players
                    

                    // prompt players[activeTurnPlayer] to play or draw a card
                        // activeTurnPlayer's played card must be of same suit or value or 8
                    // if 8 card played, must ask player to declare a suit
                    // if player does not have any cards that can be played
                        // => draw card from deck if getDeckCount > 0
                        // prompt user to play or draw card once again
                    
                    // to change turns => activeTurnPlayer++;
                    
                    // END GAME STUFFS
                    
                }

                // when round over (cards are out either in a player's hand or the deck) => calculate points
                List<Player> lowest = new List<Player>();
                

                foreach (Player player in players)
                {
                    int handPoints = player.calculateHandPts();
                    if (lowest.Count != 0)
                    {
                       if (handPoints == lowest[0].calculateHandPts())
                       {
                           lowest.Add(player);
                       }
                       else if (handPoints < lowest[0].calculateHandPts())
                       {
                           lowest.Clear();
                           lowest.Add(player);
                       }
                    }
                    else 
                    {
                        lowest.Add(player);
                    }
                }

                foreach (Player winner in lowest)
                {
                    foreach(Player loser in players)
                    {
                        winner.addPoints(loser.calculateHandPts() - winner.calculateHandPts());
                    }
                }

                foreach (Player player in players)
                {
                    Console.WriteLine($"{player.getName()} has {player.getPlayerPoints()} points!!!");
                }
                Console.WriteLine("The round is over. Type anything when ready to continue.");
                Console.ReadLine(); 

            }
        }
        public static bool checkPoints(Player[] players)
        {
            bool victory = false;
            foreach(Player player in players)
            {
                if (player.getPlayerPoints() >= 50 * players.Length)
                {
                    victory = true;
                    Console.WriteLine($"{player.getName()} is the VICTOR!");
                }
            }
            return victory;
        }

        public static bool checkHand(Player[] players)
        {
            bool empty = false;
            foreach (Player player in players)
            {
                if (player.getHandSize() == 0)
                {
                    empty = true;
                }
            }
            return empty; 
        }

        public static bool hasValidPlays(Player player, Card activeCard)
        {
            bool isValid = false;
            foreach (Card card in player.getHand())
            {
                if (card.val == 8 || activeCard.val == card.val || activeCard.suit == card.suit)
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}
