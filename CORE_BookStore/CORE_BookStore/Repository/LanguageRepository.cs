using CORE_BookStore.Data;
using CORE_BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_BookStore.Repository
{
    public class LanguageRepository
    {
        //lets resolve dependecies
        private readonly BookStoreContext db = null;

        public LanguageRepository(BookStoreContext model)
        {
            db = model;
        }

        //....................................................Language access methods...........................................................//
       
        //Language list
        public async Task<List<LanguageModel>> GetLanguageList()
        {
            //lets create a list and fill it 
            var languages = await db.Languages.Select(x=> new LanguageModel() { 
            LanguageID = x.LanguageID,
            Name = x.Name,
            Discription= x.Discription
            }).ToListAsync();
           
            return languages;
        }

    }
}
