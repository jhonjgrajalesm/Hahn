using System.Reflection;

namespace HahnTest.Server.Helpers
{
    public class UtilitiesHelper
    {
        public string BaseLocation
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); 
            }
        }


        public string NewId
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }        
    }
}
