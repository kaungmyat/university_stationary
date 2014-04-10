using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{

    public class SupplierController
    {
       // LOGIC_UniversityEntities context = new LOGIC_UniversityEntities();
        SupplierEnt entity = new SupplierEnt();
        public List<Supplier> getAllSupplier()
        {
            SupplierEnt supE = new SupplierEnt();
            return supE.getAllSupplier();

        }

        public bool update(Supplier supplier)
        {
            return (entity.updateSupplierData(supplier));
            
        }
    }
}
