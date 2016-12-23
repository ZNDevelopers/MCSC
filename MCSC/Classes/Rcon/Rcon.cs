using System;
using MinecraftServerRCON;

namespace MCSC.Classes.Rcon
{
    public class Rcon
    {

        private readonly RCONClient _client = RCONClient.INSTANCE;

        public readonly bool RconConnected;

        public Rcon(string password, int port)
        {
            _client.setupStream("127.0.0.1", port, password);
            RconConnected = true;
        }

        public string SendCommand(string command)
        {
            if (!RconConnected)
            {
                throw new InvalidOperationException();
            }
            return RconConnected ? _client.sendMessage(RCONMessageType.Command, command) : null;
        }

    }
}