namespace Addresh_Book5th.DAL
{
    public class DAL_Helper
    {
        #region
        public static string myConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyConnectingString");
        #endregion
    }
}
