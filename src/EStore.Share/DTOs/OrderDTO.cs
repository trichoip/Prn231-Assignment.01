namespace EStore.Share.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public decimal Freight { get; set; }

        public virtual ICollection<OrderDetailDTO>? OrderDetails { get; set; }
    }
}
