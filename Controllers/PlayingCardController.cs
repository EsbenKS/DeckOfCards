using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace deckOfCards.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayingCardController : ControllerBase
{

    private static readonly string[] Suits = new[]
    {
        "Spades", "Hearts", "Diamonds","Clubs"
    };

    private static readonly string[] FaceCards = new[]
{
         "Jack", "Queen", "King", "Joker"
    };


    private readonly ILogger<PlayingCardController> _logger;

    public PlayingCardController(ILogger<PlayingCardController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCard")]
    public ActionResult<PlayingCard> Get()
    {

        String suit = Suits[Random.Shared.Next(Suits.Length)];
        int value = Random.Shared.Next(1, 14);
        String faceCard = "";

        if (value > 10)
        {
            faceCard = FaceCards[value - 10];
        }
        if (value == 1)
        {
            faceCard = "Ace";
        }

        return new PlayingCard
        {
            Suit = suit,
            Value = value,
            FaceCard = faceCard
        };
    }
}

