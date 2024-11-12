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
    
    private int food;
    private int currency;

    private int price;
    
    public void Initizlie()
    {
        food = 100;
        currency = 100;
        price = 1;
    }

    public void PurchaseFood()
    {
        if( currency < price)
        {
            return;
        }
        food += 1;
        currency -= price;
    }

    public string GetCurrentFood()
    {
        return food.ToString();
    }

    public string GetCurrentCurrency()
    {
        return currency.ToString();
    }

    public string GetFoodDetails()
    {
        string ret = "식량 배급 : 2 \n" +
                     $"농부가 0 식량을 생산했습니다.\n";

        return ret;
    }

    public string GetCurrencyDetails()
    {
        string ret = "작업자가 2 원 벌었습니다.\n" +
                     $"기술자가 0 원 벌었습니다.\n";

        return ret;
    }
}