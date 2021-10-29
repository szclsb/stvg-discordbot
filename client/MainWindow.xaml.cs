using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using client.data;
using Discord;

namespace client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bot _bot;
        private RootModel _model;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private async void OnStartup(object sender, EventArgs e)
        {
            _model = FindResource("Model") as RootModel;
            if (_model == null) throw new Exception("Cannot find model");
            _bot = new Bot();
            var guilds = await _bot.Login();
            foreach (var guild in guilds)
            {
                var botUser = guild.GetUser(_bot.UserId);
                var role = guild.Roles.FirstOrDefault(role1 => role1.Name.Equals(botUser.Username));
                if (role == null) continue;
                var server = new ServerModel(guild);
                foreach (var channel in guild.Channels)
                {
                    if (channel is ITextChannel textChannel
                        && channel.PermissionOverwrites.Count > 0
                        && channel.PermissionOverwrites.Any(permission => permission.TargetId == role.Id))
                    {
                        server.Channels.Add(new ChannelModel(textChannel));
                    }
                }
                _model.Servers.Add(server);
            }
        }
    }
}