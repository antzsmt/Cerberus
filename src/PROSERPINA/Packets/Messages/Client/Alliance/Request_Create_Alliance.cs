﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Servers.CR.Core;
using BL.Servers.CR.Core.Network;
using BL.Servers.CR.Extensions.Binary;
using BL.Servers.CR.Files;
using BL.Servers.CR.Files.CSV_Logic;
using BL.Servers.CR.Logic;
using BL.Servers.CR.Logic.Enums;
using BL.Servers.CR.Packets.Messages.Server.Alliance;
using Resources = BL.Servers.CR.Core.Resources;

namespace BL.Servers.CR.Packets.Messages.Client.Alliance
{
    internal class Request_Create_Alliance : Message
    {
        internal string Name = string.Empty;
        internal string Description = string.Empty;

        internal int Badge = 0;
        internal int Origin = 0;
        internal int Required_Score = 0;
        internal int Type = 0;

        internal Clan Clan = Resources.Clans.New(0, Constants.Database, true);

        public Request_Create_Alliance(Device Device, Reader Reader) : base(Device, Reader)
        {
        }

        internal override void Decode()
        {
            this.Clan.Name = this.Reader.ReadString();
            this.Clan.Description = this.Reader.ReadString();
            this.Reader.ReadVInt();
            this.Clan.Badge = this.Reader.ReadVInt();
            this.Clan.Type = (Hiring)this.Reader.ReadVInt();
            this.Clan.Required_Score = this.Reader.ReadVInt();
            this.Reader.ReadVInt();
            this.Clan.Origin = this.Reader.ReadVInt();
        }

        internal override void Process()
        {
            int Cost = (CSV.Tables.Get(Gamefile.Globals).GetData("ALLIANCE_CREATE_COST") as Globals).NumberValue;

            if (this.Device.Player.Avatar.HasEnoughResources(Resource.Gold, Cost))
            {
                this.Device.Player.Avatar.Resources.Minus(Resource.Gold, Cost);

                this.Device.Player.Avatar.ClanId = this.Clan.ClanID;

                this.Clan.Members.Add(this.Device.Player.Avatar);

                new Response_Create_Alliance(this.Device, this.Clan, 142, true).Send();
            }

            Resources.Clans.Save(this.Clan);
        }
    }
}
