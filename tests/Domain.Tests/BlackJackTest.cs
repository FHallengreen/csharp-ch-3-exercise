using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Tests.DeckStubs;
using Xunit;

namespace Domain.Tests {

    public class BlackJackTest
    {
        [Fact]
        public void NewBlackJack_GivesDealerAndPlayerTwoCards()
        {
            BlackJack game = new BlackJack(new EqualValuesDeck());
            Assert.Equal(2, game.DealerHand.NrOfCards);
            Assert.Equal(2, game.PlayerHand.NrOfCards);
        }

        [Fact]
        public void NewBlackJack_GivesDealerFirstCardFaceUpAndSecondCardFaceDown()
        {
            BlackJack game = new BlackJack(new EqualValuesDeck());
            List<BlackJackCard> dealerCards = game.DealerHand.Cards.ToList();
            Assert.True(dealerCards[0].FaceUp);
            Assert.False(dealerCards[1].FaceUp);
        }

        [Fact]
        public void NewBlackJack_GivesPlayerTwoCardsFacingUp()
        {
            BlackJack game = new BlackJack(new EqualValuesDeck());
            List<BlackJackCard> playerCards = game.PlayerHand.Cards.ToList();
            Assert.True(playerCards[0].FaceUp);
            Assert.True(playerCards[1].FaceUp);
        }

        [Fact]
        public void NewBlackJack_HasStatePlayerPlaysWhenNoBlackJack()
        {
            BlackJack game = new BlackJack(new PlayerWinsDealerBurnsDeck());
            Assert.Equal(GameState.PlayerPlays, game.GameState);
        }

        [Fact]
        public void GivePlayerAnotherCard_GivesACardToPlayer()
        {
            BlackJack game = new BlackJack(new DealerWinsPlayerBurnsDeck());
            game.GivePlayerAnotherCard();
            Assert.Equal(3, game.PlayerHand.NrOfCards);
        }

        [Fact]
        public void GivePlayerAnotherCard_GameStateIsNotPlayerPlays_ThrowsAnException()
        {
            BlackJack game = new BlackJack(new PlayerBlackJackWinDeck());
            Assert.Throws<InvalidOperationException>(() => game.GivePlayerAnotherCard());
        }

        [Fact]
        public void PassToDealer_LeadsToGameOverState()
        {
            BlackJack game = new BlackJack(new PlayerWinsDealerBurnsDeck());
            game.PassToDealer();
            Assert.Equal(GameState.GameOver, game.GameState);
        }

        [Fact]
        public void GameSummary_BeforeGameIsOver_ReturnsNull()
        {
            BlackJack game = new BlackJack(new PlayerWinsDealerBurnsDeck());
            Assert.Null(game.GameSummary());
        }

        [Fact]
        public void GameSummary_BlackJackIsDealt_EndsWithBlackJack()
        {
            BlackJack game = new BlackJack(new PlayerBlackJackWinDeck());
            Assert.Equal(GameState.GameOver, game.GameState);
            Assert.Equal("BLACKJACK", game.GameSummary());
        }

        [Fact]
        public void GameSummary_BlackJackEndsCorrect_PlayerWinsDealerBurns()
        {
            BlackJack game = new BlackJack(new PlayerWinsDealerBurnsDeck());
            game.PassToDealer();
            Assert.Equal(GameState.GameOver, game.GameState);
            Assert.Equal("Dealer burned, player wins", game.GameSummary());
        }

        [Fact]
        public void GameSummary_BlackJackEndsCorrect_DealerWinsplayerBurns()
        {
            BlackJack game = new BlackJack(new DealerWinsPlayerBurnsDeck());
            game.GivePlayerAnotherCard();
            Assert.Equal(GameState.GameOver, game.GameState);
            Assert.Equal("Player burned, dealer wins", game.GameSummary());
        }

        [Fact]
        public void GameSummary_BlackJackEndsCorrect_DealerWinsWithoutPlayerBurning()
        {
            BlackJack game = new BlackJack(new DealerWinNoBurnDeck());
            game.PassToDealer();
            Assert.Equal(GameState.GameOver, game.GameState);
            Assert.Equal("Dealer wins", game.GameSummary());
        }

        [Fact]
        public void GameSummary_BlackJackWithEqualValues_DealerWins() {
            BlackJack game = new BlackJack(new EqualValuesDeck());
            game.PassToDealer();
            Assert.Equal(GameState.GameOver, game.GameState);
            Assert.Equal("Equal, dealer wins", game.GameSummary());
        }
    }
}
