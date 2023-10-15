using Domain;
using Xunit;

namespace Domain.Tests
{
    public class HandTest
    {
        private Hand _hand;

        public HandTest()
        {
            _hand = new Hand();
        }

        [Fact]
        public void NewHand_HasNoCards()
        {
            Assert.Equal(0, _hand.NrOfCards);
        }

        [Fact(Skip="Not yet implemented")]
        public void AddCard_EmptyHand_ResultsInHandWithOneCard()
        {
        }

        [Fact(Skip="Not yet implemented")]
        public void AddCard_AHandWithCards_AddsACard()
        {
        }

        [Fact]
        public void TurnAllCardsFaceUp_TurnsAllCardsFaceUp()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            card.TurnCard();
            _hand.AddCard(card);
            _hand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _hand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _hand.TurnAllCardsFaceUp();
            foreach (BlackJackCard c in _hand.Cards)
                Assert.True(c.FaceUp);
        }

        [Fact(Skip = "Not yet implemented")]
        public void Value_EmptyHand_IsZero()
        {
        }

        [Fact(Skip = "Not yet implemented")]
        public void Value_HandWith6and5_Is11()
        {
        }

        [Fact(Skip = "Not yet implemented")]
        public void Value_HandWith5AndKing_Is15()
        {
        }

        [Fact(Skip = "Not yet implemented")]
        public void Value_HandWithCardsFacingDown_DoesNotAddValuesOfCardsFacingDown()
        {
        }

        [Fact(Skip = "Not yet implemented")]
        public void Value_HandWithAceAndNotExceeding21_TakesAceAs11()
        {
            _hand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Seven));
            _hand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Ace));
            _hand.TurnAllCardsFaceUp();

            Assert.Equal(18, _hand.Value);
        }

        [Fact(Skip = "Not yet implemented")]
        public void ValueHandWithAceAndExceeding21_TakesAceAs1()
        {
        }

        [Fact]
        public void Value_HandWithAceFaceDown_DoesNotCountAce()
        {
            _hand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _hand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _hand.TurnAllCardsFaceUp();
            _hand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Ace));
            Assert.Equal(4, _hand.Value);
        }
    }
}
