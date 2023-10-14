namespace Domain;

public class Hand
{

        private IList<BlackJackCard> _cards;

        public IEnumerable<BlackJackCard> Cards => _cards;
        public int NrOfCards => _cards.Count;
        public int value => CalculateValue();

        public Hand()
        {
                _cards = new List<BlackJackCard>();
        }

        public void AddCard(BlackJackCard card)
        {
                _cards.Add(card);

        }

        public void TurnAllCardsFaceUp()
        {
                foreach (var card in Cards)
                {
                        if (!card.FaceUp)
                        {
                                card.TurnCard();
                        }
                }
        }

    private int CalculateValue()
    {
        var sum = 0;
        bool hasAce = false;

        foreach (var card in Cards)
        {
            sum += card.Value;
            if (card.FaceValue == FaceValue.Ace)
            {
                hasAce = true;
            }

        }
        if (hasAce && (sum + 10) <= 21)
        {
            sum += 10;
        }
        return sum;
    }
        }