﻿using Models.Login;
using Models.Settings;
using MongoDB.Bson;
using MongoDB.Driver;
using Repository.Common;
using Repository.Settings.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Settings.Class
{
    public class GroupsRepository : IGroupsRepository
    {
        private readonly IMongoCollection<Groups> _admincollection;
        public GroupsRepository(MongoDbRepository context) 
        {
            _admincollection = context.Groups;
        }
        public async Task InsertAsync(Groups model)
        {
            await _admincollection.InsertOneAsync(model);
        }

        public async Task UpdateByIdAsync(Groups model)
        {
            var filter = Builders<Groups>.Filter.Eq("_id", model.Id);
            await _admincollection.ReplaceOneAsync(filter, model);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var filter = Builders<Groups>.Filter.Eq("_id", id);
            await _admincollection.DeleteOneAsync(filter);
        }

        public async Task<List<Groups>> GetAllAsync()
        {
            return await _admincollection.Find(_ => true).ToListAsync();
        }
        public async Task<Groups> GetGroupsById(int id)
        {
            return await _admincollection.Find(user => user.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Groups> GetGroupsByGroupName(string groupName)
        {
            return await _admincollection.Find(user => user.GroupName == groupName).FirstOrDefaultAsync();
        }
        public async Task<bool?> GetAccessKey(string apiType, string accessType, string groupName)
        {   
            var filter = Builders<Groups>.Filter.And(
                Builders<Groups>.Filter.Eq($"{apiType}.{accessType}", true),
                Builders<Groups>.Filter.Eq("GroupName", groupName)  
            );
            var user = await _admincollection.Find(filter).FirstOrDefaultAsync();
            if (user != null)
            {
                var bsonDocument = user.ToBsonDocument();
                if (bsonDocument.Contains(apiType) && bsonDocument[apiType].AsBsonDocument.Contains(accessType))
                {
                    return bsonDocument[apiType][accessType].AsBoolean;
                }
            }
            return null;
        }
        public async Task<string> GetGroupIdByGroupName(string groupName)
        {
            var group = await _admincollection
                .Find(user => user.GroupName == groupName)
                .FirstOrDefaultAsync();
            return group?.GroupId;
        }
        public async Task<string> GetByGroupNameGroupId(string groupId)
        {
            var group = await _admincollection
                .Find(user => user.GroupId == groupId)
                .FirstOrDefaultAsync();
            return group?.GroupName;
        }
        public async Task<List<GroupDetails>> GetAllGroupNameAndID()
        {
            var employeeDetails = await _admincollection
             .Find(_ => true) // No filter, fetch all records
             .Project(user => new GroupDetails
             {
                 GroupId = user.GroupId, 
                 GroupName = user.GroupName,
             })
             .ToListAsync();

            return employeeDetails;
        }
    }
}
