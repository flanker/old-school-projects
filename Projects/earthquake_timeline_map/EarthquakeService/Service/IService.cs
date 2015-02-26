using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace EarthquakeService
{
    [ServiceContract(Namespace = "http://timecomet/service")]
    interface IService
    {
        [OperationContract(Name = "GetEvents")]
        [WebGet(UriTemplate = "GetEvents/{Time}")]
        Event[] GetEvents(string Time);
    }
}
