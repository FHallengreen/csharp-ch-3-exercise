using System.Collections.Generic;

namespace Domain.Tests.DeckStubs {
    class DealerWinsPlayerBurnsDeck : Deck {

        public DealerWinsPlayerBurnsDeck()
        {
            _cards = new List<BlackJackCard>
            {
                // Dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
            
                // Player
                new BlackJackCard(Suit.Clubs, FaceValue.Nine),
                new BlackJackCard(Suit.Clubs, FaceValue.Nine),

                // Player
                new BlackJackCard(Suit.Clubs, FaceValue.Ten),
            };
        }
    }
}
