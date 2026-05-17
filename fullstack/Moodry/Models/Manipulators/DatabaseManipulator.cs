using MongoDB.Bson;
using MongoDB.Driver;

namespace Moodry.Models.Manipulators {
    public static class DatabaseManipulator {
        private static IConfiguration? config;
        private static string? databaseName;
        private static string? host;

        private static MongoServerAddress? address;
        private static MongoClientSettings? settings;
        private static MongoClient? client;

        public static IMongoDatabase? database;

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
            if (database == null) {
                Console.WriteLine("Database is null!");
                return obj;
            }

            var collectionName = typeof(T).Name;
            var collection = database.GetCollection<T>(collectionName);

            try {
                collection.InsertOne(obj);
            } catch (Exception ex) { Console.WriteLine($"MongoDB insert error: {ex.Message}"); }

            return obj;
        }

        public static void UpdateUser(User user) {
            var collection = database.GetCollection<User>(nameof(User));
            collection.ReplaceOne(u => u._id == user._id, user);
        }

        public static List<Activity> GetDefaultActivities() {
            return new List<Activity> {
                new Activity { title = "Video games", svg = "video-games.svg", userID = null },
                new Activity { title = "Music", svg = "music.svg", userID = null },
                new Activity { title = "Reading", svg = "reading.svg", userID = null },
                new Activity { title = "Friends", svg = "friends.svg", userID = null },
                new Activity { title = "Movies", svg = "movies.svg", userID = null },
                new Activity { title = "Travel", svg = "travel.svg", userID = null },
                new Activity { title = "Work", svg = "work.svg", userID = null },
                new Activity { title = "Shopping", svg = "shopping.svg", userID = null },
                new Activity { title = "Beach", svg = "beach.svg", userID = null },
                new Activity { title = "Study", svg = "study.svg", userID = null }
            };
        }

        public static List<T> GetAll<T>(string? table = null) {
            table ??= typeof(T).Name;
            var collection = database.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }

        public static T? GetSingleByParameter<T>(string table, string attribute, string value) {
            var collection = database.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq(attribute, value);
            var results = collection.Find(filter);

            if (results.CountDocuments() > 0) { return results.First(); }

            return default;
        }

        public static List<T> GetManyByParameter<T>(string table, string attribute, string value) {
            var collection = database.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq(attribute, value);
            var results = collection.Find(filter);

            if (results.CountDocuments() > 0) { return results.ToList(); }

            return new List<T>();
        }
    }
}