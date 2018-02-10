using AppExample.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppExample.Repository
{
    public interface IPlayerRepository
    {
        Task<Player> CreatePlayer(Player player);
        Task<Player> ReadPlayer(ObjectId playerID);
        Task<Player> UpdatePlayer(ObjectId playerID, Player player);
        Task<Player> DeletePlayer(ObjectId playerID);
        Tuple<List<Player>,long> ReadAllPlayer(int? index = 0 ,int limit= 5);
    }
}
