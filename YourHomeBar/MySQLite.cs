using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourHomeBar
{

    class MySQLRecipe
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CategoryType { get; set; }
        public string GlassType { get; set; }
        public string Ingredient { get; set; }

        private async void CreateTable()
        {

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("RecipeList");
            await conn.CreateTableAsync<MySQLRecipe>();

        }

        public async void InsertRecipe(MySQLRecipe recipe)
        {

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("RecipeList");
            await conn.InsertAsync(recipe);

        }

        public async Task<MySQLRecipe> GetRecipe(int id)
        {

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("RecipeList");

            var query = conn.Table<MySQLRecipe>().Where(x => x.ID == id);
            var result = await query.ToListAsync();

            return result.FirstOrDefault();

        }

        public async Task<List<MySQLRecipe>> GetRecipe()
        {

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("RecipeList");

            var query = conn.Table<MySQLRecipe>();
            var result = await query.ToListAsync();

            return result;

        }

        public async void UpdateRecipe(MySQLRecipe recipe)
        {

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("RecipeList");
            await conn.UpdateAsync(recipe);

        }

        public async void DeleteRecipe(MySQLRecipe recipe)
        {

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("RecipeList");
            await conn.DeleteAsync(recipe);

        }

    }

}
