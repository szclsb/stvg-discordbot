using System.Collections.ObjectModel;
using Discord;

namespace client.data
{
    public class RootModel : AbstractModel
    {
        public ObservableCollection<ServerModel> Servers { get; }

        public RootModel()
        {
            Servers = new ObservableCollection<ServerModel>();
        }
    }
}