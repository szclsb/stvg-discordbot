using System;
using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using client.data;

namespace client
{
    public class Bot
    {
        private readonly DiscordSocketClient _client;
        private readonly SemaphoreSlim _signal;
        private string _dir;

        public readonly ulong UserId;

        public Bot()
        {
            // todo: implement config file
            _dir = $"D:\\Projects\\zx-stvg-discordbot\\secret";
            _client = new DiscordSocketClient();
            UserId = ulong.Parse(File.ReadAllText($"{_dir}/user_id"));
            _signal = new SemaphoreSlim(0, 1);

            _client.Ready += () =>
            {
                _signal.Release();
                return null;
            };
        }

        public async Task<IReadOnlyCollection<SocketGuild>> Login()
        {
            var token = File.ReadAllText($"{_dir}/bot_token");
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await _signal.WaitAsync();
            return _client.Guilds;
        }
    }
}