using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CETask.Models;

namespace CETask.Interfaces
{
  
        public interface ICosmosDbService
        {
            Task<IEnumerable<Teacher>> GetMultipleTeachersAsync();
            Task<Teacher> GetTeacherAsync(string id);
            Task AddTeacherAsync(Teacher item);
            Task UpdateTeacherAsync(string id, Teacher item);
            Task DeleteTeacherAsync(string id);
            Task AddPupilsync(Pupil item);
            Task DeletePupilAsync(string EntryID);
            Task<Pupil> GetPupilAsync(string EntryID);
            Task<IEnumerable<Pupil>> GetMultiplePupilsAsync();
            Task UpdatePupilAsync(string EntryID, Pupil item);

        }
    
}
