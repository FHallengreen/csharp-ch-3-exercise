using System.Collections.Generic;

namespace Domain.Tests.DeckStubs {
    class PlayerBlackJackWinDeck : Deck {

        public PlayerBlackJackWinDeck()
        {
            _cards = new List<BlackJackCard>
            {
                // Dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
            
                // Player
                new BlackJackCard(Suit.Clubs, FaceValue.Ace),
                new BlackJackCard(Suit.Clubs, FaceValue.Ten),

                // Dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Ten),
            };
        }
    }
}
