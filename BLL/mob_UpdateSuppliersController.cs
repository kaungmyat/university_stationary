using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    //Author - Nyo Mi Han
    public class mob_UpdateSuppliersController
    {
        SupplierEnt supplierEntity = new SupplierEnt();

        public void updateSupplier(string supId, string supName, string contactName, string phoneNo, string faxNo, string adddress, string email)
        {
            Supplier sup = new Supplier();
            sup.Supplier_ID = supId;
            sup.Supplier_Name = supName;
            sup.Context_Name = contactName;
            sup.Phone_No = phoneNo;
            sup.Fax_No = faxNo;
            sup.Address =adddress;
            sup.Email = email;
            supplierEntity.updateSupplier(sup);  
        }

        public List<Supplier> getSupplierID()
        {
            List<Supplier> supList = supplierEntity.getAllSupplier();
            return supList;
        }

        public Supplier findSupplier(string supId)
        {
            SupplierEnt supEnt = new SupplierEnt();
            Supplier sup = new Supplier();
            sup.Supplier_ID = supId;
            return supEnt.getSupplierForMob(sup);
           
        }

        public void createSupplier(string supId, string supName, string contact, string phone, string fax, string address, string email)
        {
            Supplier sup = new Supplier();
            sup.Supplier_ID = supId;
            sup.Supplier_Name = supName;
            sup.Context_Name = contact;
            sup.Phone_No = phone;
            sup.Fax_No = fax;
            sup.Address = address;
            sup.Email = email;
            supplierEntity.createSupplier(sup);
        }
    }
}
