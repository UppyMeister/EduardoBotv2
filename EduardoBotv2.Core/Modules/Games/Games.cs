﻿using System.Threading.Tasks;
using Discord.Commands;
using EduardoBotv2.Core.Modules.Games.Services;
using EduardoBotv2.Core.Services;

namespace EduardoBotv2.Core.Modules.Games
{
    public class Games : EduardoModule<GamesService>
    {
        public Games(GamesService service)
            : base(service) { }

        [Command("pokemon")]
        [Summary("Discover a wild Pokemon")]
        public async Task PokemonCommand()
        {
            await _service.GetPokemonAsync(Context);
        }

        [Command("inventory")]
        [Alias("inv")]
        [Summary("View your Pokemon")]
        public async Task InventoryCommand()
        {
            await _service.ShowInventoryAsync(Context);
        }

        [Command("coin")]
        [Alias("toss")]
        [Summary("Flip a coin")]
        public async Task CoinCommand()
        {
            await _service.FlipCoin(Context);
        }

        [Command("8ball")]
        [Summary("Determine your fate")]
        [Remarks("Will I die tomorrow?")]
        public async Task EightBallCommand([Summary("The (optional) question or statement you want an answer to.")] string question = null)
        {
            await _service.DisplayEightBall(Context, question);
        }
    }
}