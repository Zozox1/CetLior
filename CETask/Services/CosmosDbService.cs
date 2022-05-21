using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CETask.Interfaces;
using CETask.Models;
using Microsoft.Azure.Cosmos;

namespace CETask.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;
        public CosmosDbService(
            CosmosClient cosmosDbClient,
            string databaseName,
            string containerName)
        {
            _container = cosmosDbClient.GetContainer(databaseName, containerName);
        }
        public async Task AddAsync(Item item)
        {
            await _container.CreateItemAsync(item, new PartitionKey(item.EntryID));
        }
        public async Task DeleteAsync(string EntryID)
        {
            await _container.DeleteItemAsync<Item>(EntryID, new PartitionKey(EntryID));
        }
        public async Task<Item> GetAsync(string EntryID)
        {
            try
            {
                var response = await _container.ReadItemAsync<Item>(EntryID, new PartitionKey(EntryID));
                return response.Resource;
            }
            catch (CosmosException) //For handling item not found and other exceptions
            {
                return null;
            }
        }
        public async Task<IEnumerable<Item>> GetMultipleAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<Item>(new QueryDefinition(queryString));
            var results = new List<Item>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
        public async Task UpdateAsync(string EntryID, Item item)
        {
            await _container.UpsertItemAsync(item, new PartitionKey(EntryID));
        }
    }
}
