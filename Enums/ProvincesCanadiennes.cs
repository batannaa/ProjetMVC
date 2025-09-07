namespace ProjetMVC.Enums
{
    public enum ProvincesCanadiennes
    {
        Alberta = 1,
        ColombieBritannique = 2,
        Manitoba = 3,
        NouveauBrunswick = 4,
        TerreNeuveEtLabrador = 5,
        NouvelleEcosse = 6,
        Ontario = 7,
        ÎleDuPrinceÉdouard = 8,
        Québec = 9,
        Saskatchewan = 10,
        TerritoiresDuNordOuest = 11,
        Nunavut = 12,
        Yukon = 13
    }

    public static class ProvinceHelper
    {

            public static string GetProvinceName(int provinceValue)
            {
                if (Enum.IsDefined(typeof(ProvincesCanadiennes), provinceValue))
                {
                var x = ((ProvincesCanadiennes)provinceValue).ToString();
                return x;
                }
                else
                {
                    return "Inconnu";
                }
            }
        
    }

}
