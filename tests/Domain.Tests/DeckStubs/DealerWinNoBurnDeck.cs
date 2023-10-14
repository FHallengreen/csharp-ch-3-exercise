using System.Collections.Generic;

namespace Domain.Tests.DeckStubs {
    public class DealerWinNoBurnDeck : Deck {

        public DealerWinNoBurnDeck() {
            _cards = new List<BlackJackCard>
            {
                // Dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Five),
            
                // Player
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),

                // Dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Three),
            };
        }
    }
}
