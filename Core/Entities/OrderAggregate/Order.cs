﻿namespace Core.Entities.OrderAggregate;

public class Order : BaseEntity
{
    public Order()
    {

    }
    public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail, Address shipToAddress,
      DeliveryMethod deliveryMethod, decimal subTotal, string paymentIntentId)
    {
        ShipToAddress = shipToAddress;
        BuyerEmail = buyerEmail;
        OrderItems = orderItems;
        SubTotal = subTotal;
        DeliveryMethod = deliveryMethod;
        PaymentIntentId = paymentIntentId;
    }

    public Address ShipToAddress { get; set; }
    public string BuyerEmail { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public IReadOnlyList<OrderItem> OrderItems { get; set; }
    public decimal SubTotal { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public string PaymentIntentId { get; set; }

    public DeliveryMethod DeliveryMethod { get; set; }


    public decimal GetTotal()
    {
        return SubTotal + DeliveryMethod.Price;
    }
}
