public class OrderProcessor
{
    private const decimal TaxRate = 0.1m; 
    private const decimal DiscountRate = 0.9m; 

    private readonly AppDbContext _dbContext;
    private readonly EmailService _emailService;

    public OrderProcessor(AppDbContext dbContext, EmailService emailService)
    {
        _dbContext = dbContext;
        _emailService = emailService;
    }

    public void ProcessOrder(Order order)
    {
        ValidateOrder(order);
        decimal total = CalculateTotal(order);
        ApplyDiscountIfNeeded(order, ref total);
        SaveOrderToDb(order, total);
        SendConfirmationEmail(order, total);
    }

    private void ValidateOrder(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        if (order.Items.Count == 0) throw new InvalidOperationException("Order cannot be empty");
    }

    private decimal CalculateTotal(Order order)
    {
        decimal total = 0;
        foreach (var item in order.Items)
        {
            total += item.Price * item.Quantity;
            if (item.IsTaxable)
            {
                total += item.Price * TaxRate;
            }
        }
        return total;
    }

    private void ApplyDiscountIfNeeded(Order order, ref decimal total)
    {
        if (order.Customer.IsPremium)
        {
            total *= DiscountRate;
        }
    }

    private void SaveOrderToDb(Order order, decimal total)
    {
        using (_dbContext)
        {
            order.Total = total;
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }

    private void SendConfirmationEmail(Order order, decimal total)
    {
        _emailService.Send(order.Customer.Email, "Order Confirmed", $"Total: ${total}");
    }
}
