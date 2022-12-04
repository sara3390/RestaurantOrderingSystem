namespace RestaurantOrderingSystem.Models {
    public class MenuItem {
        public enum Category {
            Breakfast, Lunch, Dinner, Salad, Appetizer, Dessert
        }

        public int menuItemID {get; set;}
        public float price {get; set;}
        public string? name {get; set;}
        public string? description {get; set;}
        public Category category {get; set;}
        
        public List<Ingredient> ingredients { get; set; }
    }
}