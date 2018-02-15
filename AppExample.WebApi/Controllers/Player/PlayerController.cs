using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppExample.Entities;
using AppExample.Repository;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace AppExample.WebApi.Controllers
{
    [Route("api/player")]
    public class PlayerController : Controller
    {

        private IPlayerRepository _repo = RepositoryFactory.GetPlayerRepository();

        [HttpGet]
        public async Task<IActionResult> Get(int? index)
        {
            var response = _repo.ReadAllPlayer(index);
            return await Task.Run(() => Ok(new { player = response.Item1, total = response.Item2 }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
            => await Task.Run(() => Ok(new { player = _repo.ReadPlayer(ExtensionUtility.ParseID(id)) }));


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Player player)
            => await Task.Run(() => Ok(new { player = _repo.CreatePlayer(player: player) }));


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Player player)
            => await Task.Run(() => Ok(new { player = _repo.UpdatePlayer(ExtensionUtility.ParseID(id), player) }));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
           => await Task.Run(() => Ok(new { player = _repo.DeletePlayer(ExtensionUtility.ParseID(id)) }));

    }
}
