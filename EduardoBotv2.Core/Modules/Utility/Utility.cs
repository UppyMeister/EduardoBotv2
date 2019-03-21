﻿using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using EduardoBotv2.Core.Models;
using EduardoBotv2.Core.Modules.Utility.Services;

namespace EduardoBotv2.Core.Modules.Utility
{
    public class Utility : ModuleBase<EduardoContext>
    {
        private readonly UtilityService service;

        public Utility(UtilityService service)
        {
            this.service = service;
        }

        [Command("clear", RunMode = RunMode.Async), Alias("cleanup", "clean")]
        [Summary("Cleans messages.")]
        [Remarks("10")]
        [RequireUserPermission(ChannelPermission.ManageMessages), RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task CleanCommand([Summary("The number of messages to delete")] uint count)
        {
            await service.CleanMessages(Context, count);
        }

        [Command("invite", RunMode = RunMode.Async)]
        [Summary("Retrieves the invite link for the bot.")]
        [Remarks("")]
        public async Task InviteCommand()
        {
            await service.DisplayInvite(Context);
        }
    }
}