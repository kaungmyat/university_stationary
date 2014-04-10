using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class EmployeeRequisitionControl
    {
        string RequisitionID = null;

        public String generateID(String department)
        {
            DALUtilities util = new DALUtilities();

            RequisitionID = department + "/" + util.Generate_ID("Requisition");

            return RequisitionID;
        }

        public Boolean checkBeforeAddingItem(string item, string Description, string qty)
        {
            string x = item;
            string y = Description;
            string z = qty;
            if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y) || string.IsNullOrEmpty(z))
                return false;
            else
                return true;
        }

        public List<string> getItemsCategory()
        {
            StationaryCatalogueEnt ent = new StationaryCatalogueEnt();
            List<string> items = ent.getStatCatGrpByCat();
            return items;
        }

        public List<Stationary_Catalogue> getItemDescription(string category)
        {
            StationaryCatalogueEnt ent = new StationaryCatalogueEnt();
            Stationary_Catalogue searchCat = new Stationary_Catalogue();
            searchCat.Category = category;
            List<Stationary_Catalogue> desc = ent.getStatCat(searchCat);
            return desc;
        }
        public List<Stationary_Catalogue> getItemCode(string description)
        {
            StationaryCatalogueEnt ent = new StationaryCatalogueEnt();
            Stationary_Catalogue searchCat = new Stationary_Catalogue();
            searchCat.Description = description;
            List<Stationary_Catalogue> code = ent.getStatCat(searchCat);
            return code;
        }

        public void submitRequisition(Requisition req)
        {
            RequisitionEnt reqEnt = new RequisitionEnt();
            reqEnt.createRequisition(req);
        }

        public void submitRequisitionDetails(Requisition_Detail rd)
        {
            RequisitionDetailEnt rdEntity = new RequisitionDetailEnt();
            rdEntity.createReqDetail(rd);
        }

        public void updateRejectedRequisition(Requisition req)
        {
            RequisitionEnt reqEnt = new RequisitionEnt();
            reqEnt.updateRequisition( req);
        }

        public void sendEmailToDeptHead(User user)
        {
            UsersEnt ent = new UsersEnt();
            User usr = ent.getUser(user);
            string Body = usr.Emp_Name + "has Submitted a requisition form for your Approval";
            string subject = "Requisition Form for Approval";
            NotificationMsg msg = new NotificationMsg();
            msg.sendSingleNotification(user, subject, Body);
        }
    }
}
