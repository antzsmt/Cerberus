﻿using System.Collections.Generic;
using System.Linq;
using BL.Servers.CoC.Core;
using BL.Servers.CoC.Core.Networking;
using BL.Servers.CoC.Extensions.Binary;
using BL.Servers.CoC.Logic;
using BL.Servers.CoC.Packets.Messages.Server;

namespace BL.Servers.CoC.Packets.Messages.Client
{
    internal class Add_Global_Chat : Message 
    {
        internal string Message = string.Empty;
        
        public Add_Global_Chat(Device Device, Reader Reader) : base(Device, Reader)
        {
        }
        
        internal override void Decode()
        {
            this.Message = this.Reader.ReadString();
        }
        
        internal override void Process()
        {
            new Global_Chat_Entry(this.Device) { Message = this.Message, Message_Sender = this.Device.Player.Avatar, Sender = true}.Send();

            foreach (var _Device in Resources.GChat.Get_Chat(this.Device).Values.SkipWhile(device => device == this.Device))
            {
              new Global_Chat_Entry (_Device){ Message = this.Message, Message_Sender = this.Device.Player.Avatar }.Send();
            }
        }
    }
}
