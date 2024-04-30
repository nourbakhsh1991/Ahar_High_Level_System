using AharHighLevel.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using AharHighLevel.EventAggregator;
using FirstFloor.ModernUI.Presentation;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace AharHighLevel.Network
{
    public class ReceivePacket
    {
        public bool IsConnected { get; set; }
        private byte[] _buffer;
        private Socket _receiveSocket;
        private IPAddress _address;
        private int _port;
        private IAsyncResult _receiveAsyncResult;

        public ReceivePacket(Socket receiveSocket, IPAddress address, int port)
        {
            _receiveSocket = receiveSocket;
            _address = address;
            _port = port;
            
        }

        public void StartReceiving()
        {
            try
            {
                if (_receiveSocket.Connected)
                {

                    _buffer = new byte[6];
                    _receiveAsyncResult = _receiveSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
                }
            }
            catch { }
        }

        public void EndReceiving()
        {
            try
            {
                if (_receiveAsyncResult != null)
                {
                    _receiveSocket.EndReceive(_receiveAsyncResult);
                }
            }
            catch (Exception e)
            {

            }


        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                ushort sum = 0;
                // bytes are less than 1 , client disconnected.
                if (_receiveSocket.EndReceive(AR) > 1)
                {
                    // Check the first 2 Bytes for Header
                    if (_buffer[0] != 0x55 || _buffer[1] != 0xAA)
                    {
                        // Send Error Header is not Right
                        StartReceiving();
                        return;
                    }
                    sum += 0x55 + 0xAA;
                    var packetLength = (int)_buffer[2];
                    if (packetLength < 10)
                    {
                        // send Error Minimum packet length is 10
                        StartReceiving();
                        return;
                    }
                    sum += (ushort)packetLength;
                    var packetTypeCsd = (int)_buffer[3];
                    var packetType = PacketTypes.None;
                    var packetCsd = packetTypeCsd & 63;
                    if ((packetTypeCsd & 192) == (int)PacketTypes.Data)
                    {
                        packetType = PacketTypes.Data;

                    }
                    else if ((packetTypeCsd & 192) == (int)PacketTypes.Command)
                    {
                        packetType = PacketTypes.Command;
                    }
                    else if ((packetTypeCsd & 192) == (int)PacketTypes.Status)
                    {
                        packetType = PacketTypes.Status;
                    }
                    else if ((packetTypeCsd & 192) == (int)PacketTypes.Calibration)
                    {
                        packetType = PacketTypes.Calibration;
                    }
                    sum += (ushort)packetTypeCsd;
                    var deviceCode = (int)_buffer[4];
                    var sourceCode = (deviceCode & 240) >> 4;
                    var destinationCode = deviceCode & 15;
                    var source = Devices.NONE;
                    var destination = Devices.NONE;
                    if ((sourceCode & ((int)Devices.Ahar1)) == 2)
                    {
                        source = Devices.Ahar1;
                    }
                    else if ((sourceCode & ((int)Devices.Ahar2)) == 4)
                    {
                        source = Devices.Ahar2;
                    }
                    else if ((sourceCode & ((int)Devices.Ahar3)) == 8)
                    {
                        source = Devices.Ahar3;
                    }
                    else
                    {
                        StartReceiving();
                        return;
                    }
                    if ((destinationCode & ((int)Devices.HighLevelSystem)) == 1)
                    {
                        destination = Devices.HighLevelSystem;
                    }
                    else
                    {
                        // Send Error Wrong destination
                        StartReceiving();
                        return;
                    }
                    sum += (ushort)deviceCode;
                    var dataNumber = (int)_buffer[5];
                    if (dataNumber != packetLength - 10 /*|| dataNumber > 123*/)
                    {
                        //// send Error wrong data number
                        //StartReceiving();
                        //return;
                    }
                    sum += (ushort)dataNumber;
                    var totalLen = packetLength - 6; // still need to recive checksum & trailer
                    _buffer = new byte[totalLen];
                    var start = 0;
                    var len = 0;
                    var TryCount = 0;
                    while (len < totalLen)
                    {
                        if (TryCount > 20)
                        {
                            var state = new AppState
                            {
                                Message = $"Tcp Read Failed After Maximum Number of Try(s).",
                                State = (int)AppStates.ReadFailAfterMaxTry,
                                ShortMessage = $"Tcp Failed"
                            };
                            state.SendAppState(AppStatics.Container);
                            //Disconnect();
                            return;
                        }
                        var tmpLen = _receiveSocket.Receive(_buffer, start, totalLen - len, SocketFlags.None);
                        len += tmpLen;
                        TryCount++;
                        start = len;
                    }
                    for (var i = 0; i < totalLen - 4; i++)
                        sum += _buffer[i];
                    sum += _buffer[totalLen - 1];
                    sum += _buffer[totalLen - 2];
                    // TODO checksum
                    var checksum = BitConverter.ToUInt16(_buffer, totalLen - 4);

                    byte[] sumByte = BitConverter.GetBytes(sum);
                    Array.Reverse(sumByte);

                    sum = BitConverter.ToUInt16(sumByte, 0);
                    if (sum != checksum)
                    {
                        // send Error checksum
                        StartReceiving();
                        return;
                    }
                    var trailer = Encoding.ASCII.GetString(_buffer, totalLen - 2, 2);
                    if (trailer != "#$")
                    {
                        // send Error wrong trailer
                        StartReceiving();
                        return;
                    }
                    // TODO Handel Data
                    
                    {
                        var eventAggregator = AppStatics.Container.Resolve<IEventAggregator>();
                        var formEa = eventAggregator.GetEvent<FormDataEA>();
                        var commandEa = eventAggregator.GetEvent<FormsCommands>();
                        commandEa.Publish(AppCommands.NewPacket);
                        List<byte> data = new List<byte>();
                            for (var i = 0; i < totalLen - 4; i++)
                                data.Add(_buffer[i]);
                            formEa.Publish(new NetworkPacket()
                            {
                                PacketType = packetType,
                                CSD = (short)packetCsd,
                                Data = data,
                                DataNumber = (byte)dataNumber,
                                Destination = destination,
                                Source = source
                            });
                            
                        
                    }
                    StartReceiving();
                }
                else
                {
                    // Disconnect();
                    StartReceiving();
                }
            }
            catch(Exception ex)
            {
                if (!_receiveSocket.Connected)
                {
                    //Disconnect();
                }
                else
                {
                    StartReceiving();
                }
            }
        }


    }
}
