using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string? CardName { get; } = default!;
    public string CardNumber { get; }= default!;
    public string Expiration { get; }=default!;
    public string CVV { get; } = default!;
    public int PaymentMethod { get; } = default!;
    protected Payment()
    {
    }
    private Payment(string cardName,string cardNumber,string expiration,string cvv, int paymentMethond)
    {
        CardName = cardName; 
        CardNumber = cardNumber; 
        Expiration = expiration; 
        CVV = cvv; 
        PaymentMethod = paymentMethond;
    }

    public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethond)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

        return new Payment(cardName, cardNumber, expiration, cvv, paymentMethond);
    }
}
