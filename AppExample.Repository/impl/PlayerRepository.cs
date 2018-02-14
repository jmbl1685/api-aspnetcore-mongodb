using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppExample.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AppExample.Repository.impl
{
    public class PlayerRepository : IPlayerRepository
    {

        private MongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<Player> collection;

        /// <summary>
        /// Constructor
        /// MongoDB - Public Credentials 
        /// </summary>
        public PlayerRepository()
        {
            
            client = new MongoClient("mongodb://root:root@ds217360.mlab.com:17360/example-dotnetcore");
            database = client.GetDatabase("example-dotnetcore");
            collection = database.GetCollection<Player>("players");
        }

        #region CreatePlayer  
        public async Task<Player> CreatePlayer(Player player)
        {
            try
            {
                await collection.InsertOneAsync(player);
                player = await ReadPlayer(player.PlayerID);
                return player;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region DeletePlayer
        public async Task<Player> DeletePlayer(ObjectId playerID)
        {
            try
            {
                var filter = Builders<Player>.Filter.Eq("_id", playerID);
                var player = ReadPlayer(playerID);
                await collection.DeleteOneAsync(filter);
                return await player;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        #endregion

        #region ReadAllPlayer

        public Tuple<List<Player>, long> ReadAllPlayer(int? index = 0, int limit = 5)
        {
            try
            {
                return new Tuple<List<Player>, long>(
                    item1: collection.Find(new BsonDocument()).Skip(index * limit).Limit(limit).ToList(),
                    item2: collection.Count(new BsonDocument())
                );
            }
            catch (Exception e)
            {
                return null;
            }

        }
        #endregion

        #region ReadPlayer
        public async Task<Player> ReadPlayer(ObjectId playerID)
        {
            try
            {
                var filter = Builders<Player>.Filter.Eq("_id", playerID);
                return await collection.Find(filter).FirstAsync();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        #endregion

        #region UpdatePlayer
        public async Task<Player> UpdatePlayer(ObjectId playerID, Player player)
        {
            try
            {
                var filter = Builders<Player>.Filter.Eq("_id", playerID);

                var update = Builders<Player>.Update
                                .Set("name", player.Name)
                                .Set("team", player.Team)
                                .Set("dorsal", player.Dorsal)
                                .Set("nationality", player.Nationality)
                                .Set("position", player.Position)
                                .Set("photo", player.PhotoURL);

                await collection.UpdateOneAsync(filter, update);
                return await ReadPlayer(playerID);
            }
            catch (Exception e)
            {
                return null;
            }

        }
        #endregion

    }
}
