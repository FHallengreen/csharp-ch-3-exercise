using System.Collections.Generic;

namespace Domain.Tests.DeckStubs {
    public class EqualValuesDeck : Deck {

        public EqualValuesDeck()
        {
            _cards = new List<BlackJackCard>
            {
                // Dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Five),
            
                // Player
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),
                new BlackJackCard(Suit.Clubs, FaceValue.Seven),

                // Dealer
                new BlackJackCard(Suit.Clubs, FaceValue.Two),
            };
        }
    }
}
