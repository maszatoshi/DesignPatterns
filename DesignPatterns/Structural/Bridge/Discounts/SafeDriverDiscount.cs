namespace DesignPatterns.Structural.Bridge.Discounts
{
    // ConcreteImplementorA
    internal class SafeDriverDiscount : Discount
    {
        public override int GetDiscount()
        {
            return 10;
        }
    }
}
