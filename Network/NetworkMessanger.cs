using AharHighLevel.Bootstrapper;
using AharHighLevel.EventAggregator;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Timers;

namespace AharHighLevel.Network
{
    public class NetworkMessenger : INotifyPropertyChanged, INetworkMessenger
    {
        #region ' Public Property '
        public Action<bool> MessengerStatusChanged { get; set; }
        public string localIpAddress;
        public IPAddress Address { get; set; }
        public int Port { get; set; }

        public bool IsConnected => (_socket != null && _socket.Connected);


        #endregion
        #region ' Private Property '

        //private int _port = 28881;
        private IPEndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
        private string _localSubMask;
        private string _localBroadcastAddress;
        private Socket _socket;
        private ReceivePacket _receiver;
        private bool alreadyDisconnected;
        private Timer connectionTimer;
        #endregion
        #region ' Public Methods '
        public NetworkMessenger()
        {
            GetLocalIPAddress();
            alreadyDisconnected = true;
            var ip = Properties.Settings.Default.ip;
            var port = Properties.Settings.Default.port;
            
            var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
            var sendEa = eventAggregator.GetEvent<FormsSendEa>();
            sendEa.Subscribe(this.SendEaHandler, true);
            //_port = port;
            connectionTimer=new Timer(1000);
            connectionTimer.Elapsed += (sender, args) =>
            {
                App.Current?.Dispatcher.Invoke(() =>
                {
                    MessengerStatusChanged?.Invoke(_socket.Connected);
                    if (!_socket.Connected)
                    {
                        this.Disconnect();
                    }
                });
               
            };
            connectionTimer.Start();
            StartConnection(Address, Port);

        }

        ~NetworkMessenger()
        {
            connectionTimer.Stop();
            connectionTimer.Dispose();
        }

        public void SendEaHandler(NetworkPacket packet)
        {


            try
            {
                if (_socket.Connected)
                {
                    SendData(packet);
                }
                else
                {
                    Disconnect();
                }
            }
            catch { }
        }

        public string GetIpAddress()
        {
            return _socket.Connected ? Address.ToString() + Port : "";
        }

        public bool SendData(NetworkPacket packet)
        {
            if (packet == null)
            {
                return false;
            }

            try
            {
                var SocketData = new byte[packet.DataNumber + 10];
                var index = 0;
                //Header
                SocketData[index++] = 0x55;
                SocketData[index++] = 0xAA;
                //PacketLength
                SocketData[index++] = (byte)SocketData.Length;
                //PacketTypeCSD
                SocketData[index++] = (byte)((short)packet.PacketType + packet.CSD);
                //SourceDestination
                SocketData[index++] = (byte)(((int)packet.Source << 4) + (int)packet.Destination);
                //DataNumber
                SocketData[index++] = packet.DataNumber;
                //Data
                if (packet.Data != null && packet.Data.Count > 0)
                {
                    Array.Copy(packet.Data.ToArray(), 0, SocketData, index, packet.Data.Count);
                    index += packet.Data.Count;
                }

                //ZeroCheckSum
                SocketData[index++] = 0;
                SocketData[index++] = 0;
                //Trailer
                SocketData[index++] = 0x23;
                SocketData[index++] = 0x24;
                UInt16 sum = 0;
                for (int i = 0; i < packet.DataNumber + 10; i++)
                {
                    sum += SocketData[i];
                }

                byte[] checksum = BitConverter.GetBytes(sum);
                Array.Reverse(checksum);

                index -= 4;
                Array.Copy(checksum, 0, SocketData, index, 2);
                var len = _socket.Send(SocketData);
                return true;
            }
            catch (Exception _ex)
            {
                return false;
            }
        }

        public void StartConnection(IPAddress address, int port)
        {

            Connect();
        }

        public void Disconnect()
        {
            try
            {
                if (_socket != null && _socket.Connected)
                {
                    _socket.Disconnect(true);
                    _receiver.EndReceiving();
                    _socket.Dispose();
                    var state = new AppState
                    {
                        Message = $"disconnected from address:{Address} port:{Port} protocol type: {ProtocolType.Tcp}",
                        State = (int)AppStates.SocketDisconnected,
                        ShortMessage = $"Disconnected"
                    };
                    var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                    var formStat = eventAggregator.GetEvent<FormStatusEa>();
                    formStat.Publish(254);
                    state.SendAppState(AppStatics.Container);
                    if (AppStatics.IsProjectLoaded)
                    {
                        AppStatics.FileHandler.GenerateLog(new []{ " => Disconnected Successfully." });
                        
                    }
                }

                if (_socket != null && !IsConnected && !alreadyDisconnected)
                {
                    var state = new AppState
                    {
                        Message = $"disconnected from address:{Address} port:{Port} protocol type: {ProtocolType.Tcp}",
                        State = (int)AppStates.SocketDisconnected,
                        ShortMessage = $"Disconnected"
                    };
                    var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                    var formStat = eventAggregator.GetEvent<FormStatusEa>();
                    formStat.Publish(254);
                    state.SendAppState(AppStatics.Container);
                    if (AppStatics.IsProjectLoaded)
                    {
                        AppStatics.FileHandler.GenerateLog(new[] { " => Disconnected Successfully." });
                    }

                    alreadyDisconnected = true;
                }
            

                //TryToReconnect();
            }
            catch (Exception ex)
            {
                _socket?.Dispose();


                var state = new AppState
                {
                    Message = $"disconnected from address:{Address} port:{Port} protocol type: {ProtocolType.Tcp}",
                    State = (int)AppStates.SocketDisconnected,
                    ShortMessage = $"Disconnected"
                };
                state.SendAppState(AppStatics.Container);
                if (AppStatics.IsProjectLoaded)
                {
                    if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        File.Create(AppStatics.projectFolder + "\\Log.txt");
                    }

                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Disconnect Failed.");
                        sw.Flush();
                        sw.Close();
                    }
                }

                //TryToReconnect();
            }
        }

        public int Connect()
        {
            try
            {
                if (_socket == null || !_socket.Connected)
                {
                    alreadyDisconnected = false;
                    _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    {
                        ReceiveTimeout = 5,
                        SendTimeout = 5
                    };

                    _receiver = new ReceivePacket(_socket, Address, Port);
                    _socket.Connect(Address, Port);
                    _receiver.StartReceiving();
                    return 1;
                }

                return 0;

            }
            catch (Exception ex)
            {

                //_receiver.EndReceiving();
                if (_socket != null && _socket.Connected)
                {
                    _socket.Disconnect(true);
                }

                var state = new AppState
                {
                    Message = $"cant connect to address:{Address} port:{Port} protocol type: {ProtocolType.Tcp}" +
                        "\r\n" +
                        ex.Message,
                    ShortMessage = $"Connection Failed",
                    State = (int)AppStates.SocketError
                };
                state.SendAppState(AppStatics.Container);
                if (AppStatics.IsProjectLoaded)
                {
                    if (!File.Exists(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        File.Create(AppStatics.projectFolder + "\\Log.txt");
                    }
                    using (StreamWriter sw = File.AppendText(AppStatics.projectFolder + "\\Log.txt"))
                    {
                        sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " => Connection Failed.");
                        sw.WriteLine("\t" + ex.Message);
                        sw.Flush();
                        sw.Close();
                    }
                }
                return -1;
            }


        }

        //public void TryToReconnect()
        //{
        //    Timer t = new Timer(10000);
        //    t.Enabled = true;
        //    t.Elapsed += (sender, args) =>
        //    {
        //        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        //        {
        //            ReceiveTimeout = 5,
        //            SendTimeout = 5
        //        };
        //        Connect();
        //        ((Timer)sender).Enabled = false;
        //        ((Timer)sender).Dispose();
        //    };
        //}




        //public void AcceptCallback(IAsyncResult ar)
        //{
        //    try
        //    {
        //        var state = new AppState
        //        {
        //            Message = $"Accept CallBack port:{_port} protocol type: {ProtocolType.Tcp}",
        //            State = (int)AppStates.AcceptCallBack
        //        };
        //        state.SendAppState(AppStatics.Container);
        //        Socket acceptedSocket = ListenerSocket.EndAccept(ar);
        //        ClientController.AddClient(acceptedSocket, AppStatics.Container);

        //        ListenerSocket.BeginAccept(AcceptCallback, ListenerSocket);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Base Accept error" + ex);
        //    }
        //}

        // Socket
        public void SentMessage(Client user, string msg, int port = 28880)
        {

            var data = Encoding.ASCII.GetBytes(msg);
            user._socket.Send(data);

        }

        #endregion
        #region ' Private Methods '

        private void GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIpAddress = ip.ToString();
                    _localSubMask = GetSubnetMask(ip).ToString();
                    _localBroadcastAddress = GetBroadcastAddress(ip, IPAddress.Parse(_localSubMask)).ToString();
                    return;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        private IPAddress GetBroadcastAddress(IPAddress address, IPAddress subnetMask)
        {

            byte[] ipAdressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");

            byte[] broadcastAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] | (subnetMaskBytes[i] ^ 255));
            }
            return new IPAddress(broadcastAddress);
        }
        private IPAddress GetSubnetMask(IPAddress address)
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (address.Equals(unicastIPAddressInformation.Address))
                        {
                            return unicastIPAddressInformation.IPv4Mask;
                        }
                    }
                }
            }
            throw new ArgumentException(string.Format("Can't find subnetmask for IP address '{0}'", address));
        }

        #endregion
        #region ' Other '

        // Notify change
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
