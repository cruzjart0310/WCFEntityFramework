using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service.svc o Service.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service : IService
    {
        public List<Area> all()
        {
            using (DBEntities en = new DBEntities())
            {
                return en.areaEntities.Select(a => new Area { 
                    Id = a.id,
                    Name = a.name
                }).ToList();
            }
        }

        public Area show(string id)
        {
            using (DBEntities en = new DBEntities())
            {
                int idn = Convert.ToInt32(id);
                return en.areaEntities.Where(a => a.id == idn).Select(a => new Area
                {
                    Id = a.id,
                    Name = a.name
                }).First();
            }
        }

        public bool store(Area area)
        {
            using (DBEntities en = new DBEntities())
            {
                try
                {
                    areaEntity obj = new areaEntity();
                    obj.name = area.Name;
                    en.areaEntities.Add(obj);
                    en.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    
                    return false;
                }
            }
        }

        public bool update(Area area)
        {
            using (DBEntities en = new DBEntities())
            {
                try
                {
                    int id = Convert.ToInt32(area.Id);
                    areaEntity obj = en.areaEntities.Single( p => p.id == id);
                    obj.name = area.Name;
                    en.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public bool delete(Area area)
        {
            using (DBEntities en = new DBEntities())
            {
                try
                {
                    int id = Convert.ToInt32(area.Id);
                    areaEntity obj = en.areaEntities.Single(p => p.id == id);
                    en.areaEntities.Remove(obj);
                    en.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
    }
}
