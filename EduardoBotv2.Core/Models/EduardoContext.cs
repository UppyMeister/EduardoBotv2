﻿using System;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace EduardoBotv2.Core.Models
{
    public class EduardoContext : ICommandContext
    {
        // Default
        public SocketUser User { get; }

        public SocketGuild Guild { get; }

        public SocketUserMessage Message { get; }

        public DiscordSocketClient Client { get; }

        public ISocketMessageChannel Channel { get; }

        public IServiceProvider Provider { get; set; }

        public Credentials EduardoCredentials { get; set; }

        public EduardoContext(DiscordSocketClient client, SocketUserMessage msg, IServiceProvider provider, Credentials credentials)
        {
            Client = client;
            Guild = (msg.Channel as SocketGuildChannel)?.Guild;
            Channel = msg.Channel;
            User = msg.Author;
            Message = msg;

            Provider = provider;
            EduardoCredentials = credentials;
        }

        #region ICommandContext implementation
        IDiscordClient ICommandContext.Client => Client;
        IGuild ICommandContext.Guild => Guild;
        IMessageChannel ICommandContext.Channel => Channel;
        IUser ICommandContext.User => User;
        IUserMessage ICommandContext.Message => Message;
        #endregion
    }
}