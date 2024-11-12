public class SupplyManager
{
    
    private static SupplyManager instance;
    
    public static SupplyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SupplyManager();
            }

            return instance;
        }
    }

    public void PurchaseFood()
    {
        throw new System.NotImplementedException();
    }

    public string GetCurrentFood()
    {
        throw new System.NotImplementedException();
    }

    public string GetCurrentCurrency()
    {
        throw new System.NotImplementedException();
    }

    public string GetFoodDetails()
    {
        throw new System.NotImplementedException();
    }

    public string GetCurrencyDetails()
    {
        throw new System.NotImplementedException();
    }
}