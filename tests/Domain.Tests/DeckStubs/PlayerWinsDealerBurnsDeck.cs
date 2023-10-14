using System.Collections.Generic;

namespace Domain.Tests.DeckStubs {
    class PlayerWinsDealerBurnsDeck : Deck {

        public PlayerWinsDealerBurnsDeck()
        {
            _cards = new List<BlackJackCard>
            {
                // Dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
            
                // Player
                new BlackJackCard(Suit.Clubs, FaceValue.Nine),
                new BlackJackCard(Suit.Clubs, FaceValue.Nine),

                // Dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Ten),
            };
        }
    }
}
