using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "all", ResponseFormat = WebMessageFormat.Json)]
        List<Area> all();

        [WebInvoke(Method = "GET", UriTemplate = "show/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Area show(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "store", ResponseFormat = WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json)]
        bool store(Area area);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool update(Area area);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool delete(Area area);
   
    }
}
