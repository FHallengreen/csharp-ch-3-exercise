namespace Domain;

public class BlackJack
{
    public bool FaceDown = false;
    public bool FaceUp = true;

    private Deck _deck;
    public Hand DealerHand { get; private set; }
    public Hand PlayerHand { get; private set; }
    public GameState GameState { get; private set; }

    public BlackJack() : this(new Deck()) { }


    public BlackJack(Deck deck)
    {
        _deck = deck;
        DealerHand = new Hand();
        PlayerHand = new Hand();
        Deal();
    }

    private void Deal()
    {
        AddCardToHand(PlayerHand, FaceUp);
        AddCardToHand(DealerHand, FaceDown);
        AddCardToHand(PlayerHand, FaceUp);
        AddCardToHand(DealerHand, FaceUp);
    }

    public void PassToDealer()
    {
        throw new NotImplementedException();
    }

    public string GameSummary()
    {
        throw new NotImplementedException();
    }

    public void GivePlayerAnotherHand()
    {
        throw new NotImplementedException();
    }

    private void AddCardToHand(Hand hand, bool faceUp)
    {
        throw new NotImplementedException();
    }

    private void AdjustGameState(GameState? gameState = null)
    {
        throw new NotImplementedException();
    }


    private void LetDealerFinalize()
    {
        throw new NotImplementedException();
    }


}