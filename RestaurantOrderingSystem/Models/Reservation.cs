using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantOrderingSystem.Models {
    public class Reservation {
        public int ReservationID { get; set; }
        
        public Table? Table { get; set; }
        public DateTime ReservationTime { get; set; }

        [ForeignKey("ApplicationUserID")]
        public ApplicationUser User { get; set; }
    }
}