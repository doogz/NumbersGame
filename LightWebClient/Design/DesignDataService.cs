using System;
using LightWebClient.Model;

namespace LightWebClient.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("DesignDataService");
            callback(item, null);
        }
    }
}