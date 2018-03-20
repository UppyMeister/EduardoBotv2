﻿using Discord;
using Discord.Commands;
using EduardoBot.Services;
using EduardoBot.Common.Data;
using System.Threading.Tasks;

namespace EduardoBot.Modules
{
    public class Utility : ModuleBase<EduardoContext>
    {
        private readonly UtilityService _service;

        public Utility(UtilityService service)
        {
            this._service = service;
        }

        [Command("clear", RunMode = RunMode.Async), Alias("cleanup", "clean")]
        [Summary("Cleans messages.")]
        [Remarks("10")]
        [RequireUserPermission(ChannelPermission.ManageMessages), RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task CleanCommand([Summary("The number of messages to delete")] uint count)
        {
            await _service.CleanMessages(Context, count);
        }

        [Command("invite", RunMode = RunMode.Async)]
        [Summary("Retrieves the invite link for the bot.")]
        [Remarks("")]
        public async Task InviteCommand()
        {
            await _service.DisplayInvite(Context);
        }
    }
}