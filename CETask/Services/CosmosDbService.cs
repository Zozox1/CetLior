using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CETask.Interfaces;
using CETask.Models;
using Microsoft.Azure.Cosmos;

namespace CETask.Services
{
    //Cosmos Service 
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
        public async Task AddTeacherAsync(Teacher item)
        {
            try
            {
                await _container.CreateItemAsync(item, new PartitionKey(item.EntryID));
            }
            catch (CosmosException) //For handling item not found and other exceptions
            {

            }
        }
            public async Task DeleteTeacherAsync(string EntryID)
        {
            try
            {
                await _container.DeleteItemAsync<Teacher>(EntryID, new PartitionKey(EntryID));
            }
            catch (CosmosException) //For handling item not found and other exceptions
            {
               
            }
        }
        public async Task<Teacher> GetTeacherAsync(string EntryID)
        {
            try
            {
                var response = await _container.ReadItemAsync<Teacher>(EntryID, new PartitionKey(EntryID));
                return response.Resource;
            }
            catch (CosmosException) //For handling item not found and other exceptions
            {
                return null;
            }
        }
        public async Task<IEnumerable<Teacher>> GetMultipleTeachersAsync()
        {
            string queryString = "SELECT * FROM c Where c.Type=\"Teacher\"";
            try
            {
                var query = _container.GetItemQueryIterator<Teacher>(new QueryDefinition(queryString));
            var results = new List<Teacher>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
            }
            catch (CosmosException) //For handling item not found and other exceptions
            {
                return null;
            }
        }
        public async Task UpdateTeacherAsync(string EntryID, Teacher item)
        {
            try
            {
                await _container.UpsertItemAsync(item, new PartitionKey(EntryID));
            }
            catch (CosmosException) //For handling item not found and other exceptions
            {
               
            }
        }

        public async Task AddPupilsync(Pupil item)
        {
            try
            {
                await _container.CreateItemAsync(item, new PartitionKey(item.EntryID));
            }
            catch (CosmosException) //For handling item not found and other exceptions
            {

            }
        }
        public async Task DeletePupilAsync(string EntryID)
        {
            try
            {
                await _container.DeleteItemAsync<Pupil>(EntryID, new PartitionKey(EntryID));
            }
            catch (CosmosException) //For handling item not found and other exceptions
            {

            }
        }
        public async Task<Pupil> GetPupilAsync(string EntryID)
        {
            try
            {
                var response = await _container.ReadItemAsync<Pupil>(EntryID, new PartitionKey(EntryID));
                return response.Resource;
            }
            catch (CosmosException) //For handling item not found and other exceptions
            {
                return null;
            }
        }
        public async Task<IEnumerable<Pupil>> GetMultiplePupilsAsync()
        {
            string queryString = "SELECT * FROM c Where c.Type=\"Pupil\"";
            try
            {
                var query = _container.GetItemQueryIterator<Pupil>(new QueryDefinition(queryString));
                var results = new List<Pupil>();
                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    results.AddRange(response.ToList());
                }
                return results;
            }
            catch (CosmosException ex) //For handling item not found and other exceptions
            {
                return null;
            }
        }
        public async Task UpdatePupilAsync(string EntryID, Pupil item)
        {
            try
            {
                await _container.UpsertItemAsync(item, new PartitionKey(EntryID));
            }
            catch (CosmosException) //For handling item not found and other exceptions
            {

            }
        }
    }
}
