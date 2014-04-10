using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class SupplierEnt
    {
        LOGIC_UniversityEntities ContextDB;
        public SupplierEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public List<Supplier> getAllSupplier()
        {
            var query = (from sps in ContextDB.Suppliers select sps);
            return query.ToList<Supplier>();
        }

        public List<string> getAllSupplierData()
        {
            var query = (from sps in ContextDB.Suppliers select sps.Supplier_ID);
            return query.ToList<string>();
        }

         public List<Supplier> getSupplier(Supplier supplierVal)
        {
            var sp = from s in ContextDB.Suppliers
                     where (s.Supplier_ID == supplierVal.Supplier_ID || supplierVal.Supplier_ID == null)
                     && (s.Supplier_Name == supplierVal.Supplier_Name || supplierVal.Supplier_Name == null)
                     && (s.Context_Name == supplierVal.Context_Name || supplierVal.Context_Name == null)
                     && (s.Phone_No == supplierVal.Phone_No || supplierVal.Phone_No == null)
                     && (s.Fax_No == supplierVal.Fax_No || supplierVal.Fax_No == null)
                     && (s.Address == supplierVal.Address || supplierVal.Address == null)
                     &&(s.Email==supplierVal.Email||supplierVal.Email==null)
                     select s;

            return sp.ToList<Supplier>();
        }

         public Supplier getSupplierForMob(Supplier supplierVal)
         {
             var sp = from s in ContextDB.Suppliers
                      where (s.Supplier_ID == supplierVal.Supplier_ID || supplierVal.Supplier_ID == null)
                      && (s.Supplier_Name == supplierVal.Supplier_Name || supplierVal.Supplier_Name == null)
                      && (s.Context_Name == supplierVal.Context_Name || supplierVal.Context_Name == null)
                      && (s.Phone_No == supplierVal.Phone_No || supplierVal.Phone_No == null)
                      && (s.Fax_No == supplierVal.Fax_No || supplierVal.Fax_No == null)
                      && (s.Address == supplierVal.Address || supplierVal.Address == null)
                      select s;

             return sp.First();
         }

         public string getMaxPO()
         {
             var max_Query = (from pod in ContextDB.Purchase_Order_Detail select pod.Purchase_Order_No).Max();
             return max_Query;
         }

        public void createSupplier(Supplier s)
        {
            ContextDB.Suppliers.AddObject(s);
            ContextDB.SaveChanges();
        }

        public bool updateSupplier(Supplier supplierUpdate)
        {
            try
            {
                //Supplier s = getSupplierSingle(supplierUpdate);
                Supplier s = new Supplier();
                s.Supplier_ID = supplierUpdate.Supplier_ID;
                s.Supplier_Name = supplierUpdate.Supplier_Name;
                s.Context_Name = supplierUpdate.Context_Name;
                s.Phone_No = supplierUpdate.Phone_No;
                s.Fax_No = supplierUpdate.Fax_No;
                s.Address = supplierUpdate.Address;
                s.Email = supplierUpdate.Email;
                ContextDB.SaveChanges();
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
                     

        }

        //public Supplier getSupplier(Supplier supplierVal)
        //{
        //    var sp = from s in ContextDB.Suppliers
        //             where (s.Supplier_ID == supplierVal.Supplier_ID || supplierVal.Supplier_ID == null)
        //             && (s.Supplier_Name == supplierVal.Supplier_Name || supplierVal.Supplier_Name == null)
        //             && (s.Context_Name == supplierVal.Context_Name || supplierVal.Context_Name == null)
        //             && (s.Phone_No == supplierVal.Phone_No || supplierVal.Phone_No == null)
        //             && (s.Fax_No == supplierVal.Fax_No || supplierVal.Fax_No == null)
        //             && (s.Address == supplierVal.Address || supplierVal.Address == null)
        //             select s;

        //    return sp.First();
        //}

        public bool updateSupplierData(Supplier supplier)
        {
            Supplier sp = ContextDB.Suppliers.SingleOrDefault(p => p.Supplier_ID == supplier.Supplier_ID);
            sp.Supplier_ID = supplier.Supplier_ID;
            sp.Supplier_Name = supplier.Supplier_Name;
            sp.Phone_No = supplier.Phone_No;
            sp.Fax_No = supplier.Fax_No;
            sp.Address = supplier.Address;
            sp.Email = sp.Email;
            ContextDB.SaveChanges();

            return true;           

        }

        public Supplier getSupplierSingle(Supplier supplierVal)
        {
            var sp = from s in ContextDB.Suppliers
                     where (s.Supplier_ID == supplierVal.Supplier_ID || supplierVal.Supplier_ID == null)
                     && (s.Supplier_Name == supplierVal.Supplier_Name || supplierVal.Supplier_Name == null)
                     && (s.Context_Name == supplierVal.Context_Name || supplierVal.Context_Name == null)
                     && (s.Phone_No == supplierVal.Phone_No || supplierVal.Phone_No == null)
                     && (s.Fax_No == supplierVal.Fax_No || supplierVal.Fax_No == null)
                     && (s.Address == supplierVal.Address || supplierVal.Address == null)
                     select s;

            return sp.First();

        }

        public bool deleteSupplier(Supplier sDel)
        {
            try
            {
               Supplier s = getSupplier(sDel).First();
                ContextDB.Suppliers.DeleteObject(s);

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteAllSupplier()
        {
            try
            {
                var q = from s in ContextDB.Suppliers
                        select s;

                foreach (var v in q)
                {
                    ContextDB.Suppliers.DeleteObject(v);
                }

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
