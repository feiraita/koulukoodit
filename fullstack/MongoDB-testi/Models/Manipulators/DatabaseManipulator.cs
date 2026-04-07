using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB_testi.Models.Manipulators {

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

        public static T SaveAuto<T>(T obj) where T : SaveableObject {
            if (database == null) return obj;

            var collection = database.GetCollection<T>(obj.GetType().Name);

            try {
                if(obj._id == ObjectId.Empty) {
                    collection.InsertOne(obj);

                } else {
                    collection.ReplaceOne(
                        new BsonDocument("_id", obj._id),
                        obj,
                        new ReplaceOptions { IsUpsert = true });
                }

            } catch { Console.WriteLine("Lol"); }

            return obj;
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
