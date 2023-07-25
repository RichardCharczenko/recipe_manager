using Amazon.DynamoDBv2.DataModel;

namespace recipeAPI.Models;

[DynamoDBTable("CookBook")]
    public class CookBook
    {
        [DynamoDBHashKey("recipe_id")]
        public string recipe_id { get; set; }

        [DynamoDBProperty("calories")]
        public int calories { get; set; }

        [DynamoDBProperty("name")]
        public string name { get; set; }

        [DynamoDBProperty("rating")]
        public float rating { get; set; }

        [DynamoDBProperty("ingredients")]
        public string[] ingredients {get; set;}
    }