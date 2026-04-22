using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Phase7.Models.Manipulators {

    //staattisella luokalla ei ole konstruktoria eli ei voi luoda oliota
    public static class DatabaseManipulator {
        private static IConfiguration? config;
        private static string? databaseName;
        private static string? host;

        //Ladataan Project > Manage NuGet packages osiosta 
        //MongoDB.Bson, MongoDB.Driver.Core and MongoDB.Driver paketit

        private static MongoServerAddress? address;
        private static MongoClientSettings? settings;
        private static MongoClient? client;

        public static IMongoDatabase? database;

        //Kun softa käynnistyy
        public static void Initialize(IConfiguration configuration) {
            config = configuration;

            var connectionStrings = config.GetSection("ConnectionStrings");

            databaseName = connectionStrings.GetValue<string>("DatabaseName");
            host = connectionStrings.GetValue<string>("MongoConnection");
            address = new MongoServerAddress(host);
            settings = new MongoClientSettings() { Server = address };
            client = new MongoClient(settings);

            database = client.GetDatabase(databaseName);
        }

        public static T SaveItem<T>(T obj) {
            if (database == null) return obj;

            var collection = database.GetCollection<T>(typeof(T).Name);

            try {
                collection.InsertOne(obj);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return obj;
        }

        public static void UpdateCategory(Category updatedCategory) {
            if (database == null) return;

            var collection = database.GetCollection<Category>(nameof(Category));

            var filter = Builders<Category>.Filter.Eq(c => c._id, updatedCategory._id);

            var update = Builders<Category>.Update
                .Set(c => c.name, updatedCategory.name)
                .Set(c => c.monthlyLimit, updatedCategory.monthlyLimit)
                .Set(c => c.amount, updatedCategory.amount ?? 0)
                .Set(c => c.total, updatedCategory.total ?? 0);

            collection.UpdateOne(filter, update);
        }

        public static void UpdateSavingGoal(SavingGoal updatedSaving) {
            var collection = database.GetCollection<SavingGoal>(nameof(SavingGoal));

            var filter = Builders<SavingGoal>.Filter.Eq(c => c._id, updatedSaving._id);

            var update = Builders<SavingGoal>.Update
                .Set(c => c.name, updatedSaving.name)
                .Set(c => c.goal, updatedSaving.goal)
                .Set(c => c.recurring, updatedSaving.recurring)
                .Set(c => c.date, updatedSaving.date)
                .Set(c => c.payments, updatedSaving.payments)
                .Set(c => c.total, updatedSaving.total);

            collection.UpdateOne(filter, update);
        }

        public static void UpdateUser(User user) {
            var collection = database.GetCollection<User>(nameof(User));

            collection.ReplaceOne(u => u._id == user._id, user);
        }

        public static List<Category> GetDefaultCategories() {
            return new List<Category> {
                new Category { name = "Food & Drinks", monthlyLimit = true, amount = 100, total = 0 },
                new Category { name = "Transportation", monthlyLimit = true, amount = 250, total = 0 },
                new Category { name = "Miscellanous", monthlyLimit = true, amount = 50, total = 0 },
                new Category { name = "Entertainment", monthlyLimit = true, amount = 150, total = 0 },
                new Category { name = "Other", monthlyLimit = false, amount = null, total = 0 }
            };
        }

        public static List<T> GetAll<T>(string? table = null) {
            table ??= typeof(T).Name;
            var mongotable = database.GetCollection<T>(table);

            return mongotable.Find(new BsonDocument()).ToList();
        }

        public static T? GetSingleByParameter<T>(string table, string attribute, string value) {
            var mongotable = database.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq(attribute, value);
            var results = mongotable.Find(filter);

            if (results.CountDocuments() > 0) {
                return results.First();

            } else return default;
        }

        public static List<T> GetManyByParameter<T>(string table, string attribute, string value) {
            var mongotable = database.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq(attribute, value);
            var results = mongotable.Find(filter);

            if (results.CountDocuments() > 0 && results != null) {
                return results.ToList();

            } else return new List<T>();
        }
    }
}