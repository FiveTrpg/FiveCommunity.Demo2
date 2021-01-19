﻿using Autofac;
using FiveCore.Community.Gameplay;
using FiveCore.Community.Gameplay.Npcs;
using FiveCore.Community.Gameplay.Parties;
using NUnit.Framework;
using System;

namespace FiveCore.Test.Community.Gameplay
{
    public class LobbyTestForLobbyNotCreated : GameplayEnviroment
    {
        private IPlayer player { get; set; }
        private ILobby lobby { get; set; }
        private IContainer game { get; set; }
        private ICore core { get; set; }

        [SetUp]
        public void Setup()
        {
            SetupEnviroment();
            game = Build();
            lobby = game.Resolve<ILobby>();

            player = game.Resolve<IPlayer>();
            player.Identity = Guid.NewGuid().ToString();
            player.Name = "Remilia";

            core = game.Resolve<ICore>();
            Assert.That(core.NpcType, Is.EqualTo(NpcType.Observer));
        }

        [Test]
        public void PlayerCanJoinWhenLobbyPartyCreated()
        {
            core.CreateLobbyParty();
            Assert.AreEqual(lobby.Login(player), PartyJoinResult.Success);
        }

        [Test]
        public void PlayerCantJoinWhenLobbyPartyCreated()
        {
            Assert.AreEqual(lobby.Login(player), PartyJoinResult.PartyNotExist);
        }
    }
}
