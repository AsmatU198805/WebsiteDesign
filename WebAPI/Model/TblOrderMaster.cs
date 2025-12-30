using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class TblOrderMaster
    {
        [Key]
        public int OrderId { get; set; }

        public string OrderNo { get; set; } = "";
        public int? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<TblOrderDetail> OrderDetails { get; set; } = new();
    }
}
