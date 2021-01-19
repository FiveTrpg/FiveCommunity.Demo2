﻿using Autofac;
using FiveCore.Community.Gameplay;
using FiveCore.Community.Gameplay.Npcs;
using FiveCore.Community.Gameplay.Parties;

namespace FiveCore.Test.Community.Gameplay
{
    public class GameplayEnviroment
    {
        protected ContainerBuilder GameBuilder { get; set; }

        public void SetupEnviroment()
        {
            GameBuilder = new ContainerBuilder();
            GameBuilder.RegisterType<Lobby>().As<ILobby>().SingleInstance();
            GameBuilder.RegisterType<Core>().AsSelf().SingleInstance();
            GameBuilder.RegisterType<PartyFactory>().As<IPartyFactory>().SingleInstance();
            GameBuilder.RegisterType<Player>().As<IPlayer>().InstancePerDependency();
        }

        public IContainer Build()
        {
            return GameBuilder.Build();
        }
    }
}