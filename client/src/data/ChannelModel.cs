using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Discord;

namespace client.data
{
    public class ChannelModel : AbstractModel
    {
        private readonly ITextChannel _channel;

        public string Name => _channel.Name;

        public ChannelModel(ITextChannel channel)
        {
            _channel = channel;
        }
    }
}