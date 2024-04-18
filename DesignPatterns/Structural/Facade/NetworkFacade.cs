using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Facade
{
    public class NetworkFacade
    {
        private Packet _packet;
        private Socket _socket;
        private Transmission _transmission;

        public NetworkFacade(string ip, string protocol)
        {
            this._packet = new Packet(ip);
            this._socket = new Socket(protocol);
            this._transmission = new Transmission(protocol);
        }

        public void BuildNetworkLayer()
        {
            _packet.PacketBuilt();
            _socket.BuildSocket();
        }

        public void SendPacketOverNetwork()
        {
            BuildNetworkLayer();
            _transmission.SendTransmission();
        }
    }
}
