namespace Domain;

public class BlackJack
{
    public static bool FaceUp = true;
    public static bool FaceDown = false;

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
        
        AddCardToHand(DealerHand, FaceUp);
        AddCardToHand(DealerHand, FaceDown);
        AddCardToHand(PlayerHand, FaceUp);
        AddCardToHand(PlayerHand, FaceUp);
        AdjustGameState(GameState.PlayerPlays);
    }

    public void PassToDealer()
    {
        DealerHand.TurnAllCardsFaceUp();
        AdjustGameState(GameState.DealerPlays);
        LetDealerFinalize();

    }

    public string GameSummary()
    {
        if (GameState != GameState.GameOver)
            return null;
        else if (PlayerHand.Value == 21 && PlayerHand.NrOfCards == 2 && DealerHand.Value != 21)
            return "BLACKJACK";
        else if (PlayerHand.Value > 21)
            return "Player burned, dealer wins";
        else if (DealerHand.Value > 21)
            return "Dealer burned, player wins";
        else if (PlayerHand.Value == DealerHand.Value)
            return "Equal, dealer wins";
        else if (DealerHand.Value >= PlayerHand.Value)
            return "Dealer wins";
       
        else return "Player wins";
    }

    public void GivePlayerAnotherCard()
    {
        if (GameState != GameState.PlayerPlays)
            throw new InvalidOperationException("You cannot take a card now...");
        AddCardToHand(PlayerHand, FaceUp);
        AdjustGameState();
    }

    private void AddCardToHand(Hand hand, bool faceUp)
    {
        BlackJackCard newCard = _deck.Draw();

        if (faceUp)
            newCard.TurnCard();

        hand.AddCard(newCard);
    }

    private void AdjustGameState(GameState? gameState = null)
    {
        if (gameState.HasValue)
            GameState = gameState.Value;
        if (GameState == GameState.PlayerPlays && PlayerHand.Value >= 21)
            PassToDealer();
        if (GameState == GameState.DealerPlays && (PlayerHand.Value > 21 || DealerHand.Value >= 21 || DealerHand.Value >= PlayerHand.Value))
            GameState = GameState.GameOver;

    }


    private void LetDealerFinalize()
    {
        while (GameState == GameState.DealerPlays)
        {
            AddCardToHand(DealerHand, FaceUp);
            AdjustGameState();
        }

    }
}