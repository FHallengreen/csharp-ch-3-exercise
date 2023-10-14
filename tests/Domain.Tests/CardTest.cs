using Domain;
using Xunit;

namespace Domain.Tests
{
    public class CardTest
    {
         [Fact]
        public void NewCardIsCreatedCorrectly()
        {
            Card card = new Card(Suit.Hearts, FaceValue.Ace);
            Assert.Equal(Suit.Hearts, card.Suit);
            Assert.Equal(FaceValue.Ace, card.FaceValue);
        }
    }
}
