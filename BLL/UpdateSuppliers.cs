using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    //Author - Nyo Mi Han
  public class UpdateSuppliers
    {
        SupplierEnt supplierEntity = new SupplierEnt();
        public String supplierName, contactName, phoneNo, faxNo, address, Email;
        public Boolean flag;
        public Boolean IsEmptyDataInput(String supName, String email, String contact, String phone, String fax, String add)
        {
            supplierName = supName;
            Email=email;
            contactName = contact;
            phoneNo = phone;
            faxNo = fax;
            address = add;
            if(string.IsNullOrEmpty(supplierName) && string.IsNullOrEmpty(contactName) && string.IsNullOrEmpty(phoneNo) && string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(faxNo) && string.IsNullOrEmpty(address))
            {
                flag=true;
            }
            else 
            {
                flag=false;
            }
            return flag;
        }

        public Supplier getSingleSupplierData(Supplier sup)
        {
            return supplierEntity.getSupplierSingle(sup);
        }

        public void updateSupplier(String supName, String contactName, String phoneNO, String faxNo, String adddress)
        {
            Supplier supplier = new Supplier();

            supplier.Supplier_Name = supplierName;
            supplier.Context_Name = contactName;
            supplier.Email = Email;
            supplier.Phone_No = phoneNo;
            supplier.Fax_No = faxNo;
            supplier.Address = adddress;
            if (!flag)
            {
                supplierEntity.createSupplier(supplier);
            }
        }
             //SupplierEnt supplierEntity = new SupplierEnt();

        public void updateSupplier(string supId, string supName, string contactName, string phoneNo, string faxNo, string adddress, string email)
        {
            Supplier sup = new Supplier();
            sup.Supplier_ID = supId;
            sup.Supplier_Name = supName;
            sup.Context_Name = contactName;
            sup.Phone_No = phoneNo;
            sup.Fax_No = faxNo;
            sup.Address = adddress;
            sup.Email = email;
            supplierEntity.updateSupplier(sup);  
        }

        public List<Supplier> getSupplierID()
        {
            List<Supplier> supList = supplierEntity.getAllSupplier();
            return supList;
        }

        public List<string> getSupplierData()
        {
            List<string> supList = supplierEntity.getAllSupplierData();
            return supList;
        }

        public List<Supplier> findSupplier(string supId)
        {
            SupplierEnt supEnt = new SupplierEnt();
            Supplier sup = new Supplier();
            sup.Supplier_ID = supId;
            return supEnt.getSupplier(sup);
           
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
