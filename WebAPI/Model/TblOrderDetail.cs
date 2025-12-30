using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class TblOrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public string OrderNo { get; set; } = "";
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
