using Discord;

namespace client.data
{
    public class MessageModel: AbstractModel
    {
        private readonly IUserMessage _message;

        public string Text => _message.Content;

        public MessageModel(IUserMessage message)
        {
            _message = message;
        }
    }
}