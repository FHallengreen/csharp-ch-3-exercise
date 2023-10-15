namespace Domain;

public class Deck
{
    private Random _random;
    protected IList<BlackJackCard> _cards;


    public Deck()
    {
        _random = new Random();
        _cards = new List<BlackJackCard>(52);

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            foreach (FaceValue faceValue in Enum.GetValues(typeof(FaceValue)))
                _cards.Add(new BlackJackCard(suit, faceValue));

        Shuffle();
    }

    public BlackJackCard Draw()
    {
        if (_cards.Count == 0)
        {
            throw new InvalidOperationException("Cannot draw card from empty deck");
        }
        else
        {
            var card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        };
    }

    private void Shuffle()
    {
        for (int i = 0; i < _cards.Count * 3; i++)
        {
            int randPos = _random.Next(0, _cards.Count);
            var card = _cards[randPos];
            _cards.RemoveAt(randPos);
            _cards.Add(card);

        }
    }

}