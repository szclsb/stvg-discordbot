using System.Collections.ObjectModel;
using Discord;

namespace client.data
{
    public class RootModel : AbstractModel
    {
        public ObservableCollection<ServerModel> Servers { get; }
        public ObservableCollection<MessageModel> Messages { get; }

        private int _selectedMessageIndex;
        public int SelectedMessageIndex
        {
            get => _selectedMessageIndex;
            set
            {
                _selectedMessageIndex = value;
                OnPropertyChanged();
            }
        }

        public RootModel()
        {
            Servers = new ObservableCollection<ServerModel>();
            Messages = new ObservableCollection<MessageModel>();
        }
    }
}