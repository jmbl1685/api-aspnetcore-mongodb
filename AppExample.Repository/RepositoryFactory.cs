using AppExample.Repository.impl;
using System;

namespace AppExample.Repository
{
    public static class RepositoryFactory
    {
        public static PlayerRepository GetPlayerRepository()
        {
            return new PlayerRepository();
        }
    }
}
