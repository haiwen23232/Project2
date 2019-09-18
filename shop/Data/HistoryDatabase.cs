using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarcTron.Plugin;
using shop.Model;
using SQLite;

namespace shop.Data
{
    public class HistoryDatabase
    {
        public SQLiteAsyncConnection History_database { get; private set; }

        public HistoryDatabase()
        {
            History_database = MtSql.Current.GetConnectionAsync("shop.db");
            History_database.CreateTableAsync<SearchHistory>().Wait();
        }

        public async Task<List<SearchHistory>> GetHistoryByUserAsync(int userId)
        {
            return await History_database.Table<SearchHistory>().Where(s => s.UserId == userId).ToListAsync();
        }

        public async Task AddHistoryAsync(SearchHistory history)
        {
            await History_database.InsertAsync(history);
        }

        public async Task DeleteByUser(int userId) {
            await History_database.Table<SearchHistory>().DeleteAsync(s => s.UserId == userId);
        }

    }
}
