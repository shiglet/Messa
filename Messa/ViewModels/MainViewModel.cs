using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Messa.API.Core;
using Messa.API.Gamedata.D2i;
using Messa.API.Gamedata.D2o;
using Messa.API.Gamedata.D2p;
using Messa.API.Gamedata.Icons;
using Messa.API.Messages;
using Messa.API.Protocol;
using Messa.Properties;

namespace Messa.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IAccount _account;
        private MainWindow Main;
        //private FullSocket.FullSocket _fullSocket;
        private ObservableCollection<TabItem> _tabs;
        private bool loaded;

        public ObservableCollection<TabItem> Tabs
        {
            get => _tabs;
            set
            {
                _tabs = value;
                OnPropertyChanged("Tabs");
            }
        }

        public ICommand AddTabCommand { get; set; }

        public MainViewModel(MainWindow main)
        {
            Main = main;
            Tabs = new ObservableCollection<TabItem>();
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            AddTabCommand = new RelayCommand.RelayCommand(async o =>
            {
                try
                {
                    /*
                    GlobalConfiguration.Instance.Initialize();

                    AccountConfiguration accountToConnect;

                    using (var af = new AccountsForm())
                    {
                        if (af.ShowDialog() != DialogResult.OK)
                            Environment.Exit(-1);

                        accountToConnect = af.AccountToConnect;
                    }

                    var task = Task.Factory.StartNew(() =>
                    {
                        if (!loaded)
                        {
                            UserData.RegisterAssembly();
                            Messabot.Commands.Managers.CommandManager.Build();
                            ProtocolTypeManager.Initialize();



                            Settings.Default.DofusPath = GlobalConfiguration.Instance.DofusPath;
                            Settings.Default.Save();

                            MapsManager.Init(Settings.Default.DofusPath + @"\app\content\maps");
                            IconsManager.Instance.Initialize(Settings.Default.DofusPath + @"\app\content\gfx\items");
                            ObjectDataManager.Instance.AddReaders(Settings.Default.DofusPath + @"\app\data\common");

                            FastD2IReader.Instance.Init(Settings.Default.DofusPath + @"\app\data\i18n" +
                                                        "\\i18n_fr.d2i");

                            ImageManager.Init(Settings.Default.DofusPath);
                            loaded = true;
                        }
                    }).ContinueWith(p =>
                    {
                        var fullSocketConfiguration = new FullSocketConfiguration
                        {
                            RealAuthHost = "213.248.126.40",
                            RealAuthPort = 443
                        };

                        var messageReceiver = new MessageReceiver();
                        messageReceiver.Initialize();
                        _fullSocket = new FullSocket.FullSocket(fullSocketConfiguration, messageReceiver);
                        var dispatcherTask = new DispatcherTask(new MessageDispatcher(), _fullSocket);
                        _account = _fullSocket.Connect(accountToConnect.Username, accountToConnect.Password, null);
                        LogWelcomeMessage();
                    });
                    await task;
                    Tabs.Add(new TabItem()
                    {
                        Content = new BotView(_account as Account),
                        Header = _account.Login
                    });*/
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    Environment.Exit(-1);
                }
            });
        }

        private void LogWelcomeMessage()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
