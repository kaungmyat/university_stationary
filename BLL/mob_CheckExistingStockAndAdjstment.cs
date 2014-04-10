using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    //Author - Nyo Mi Han
    public class mob_CheckExistingStockAndAdjstment
    {
 
        StationaryCatalogueEnt statCatEnt = new StationaryCatalogueEnt();
        public List<string> getCataloge() 
        {
            List<string> catList = statCatEnt.getStatCatGrpByCat();
            return catList.ToList<string>();
        }

        public List<Stationary_Catalogue> getItemName(String statCat)
        {
            Stationary_Catalogue sCat = new Stationary_Catalogue();
            sCat.Category = statCat;
            List<Stationary_Catalogue> itemName = statCatEnt.getStatCat(sCat);
            return itemName;
        }

        public List<view_Check_Existing_Stock> getUnitQtyByName(String desc, String Cat)
        {
            Stationary_Catalogue stCt=new Stationary_Catalogue();
            stCt.Description= desc;
            stCt.Category= Cat;
            List<view_Check_Existing_Stock> qtyUnit= statCatEnt.getExistingStock(stCt);
            return qtyUnit;
        }


        public List<view_Check_Existing_Stock> getBalanceByItemCode(string itCode)
        {
            Stationary_Catalogue stCat = new Stationary_Catalogue();
            stCat.Item_Code = itCode;
            List<view_Check_Existing_Stock> balance = statCatEnt.getExistingStock(stCat);
            return balance;
        }

        public void saveAdjustedInfo(String userID, String itemCode, int qty, String reason, DateTime dateIssue)
        {
            String voucherID, subject, msgBody, mailFrom, mailTo, authId, authBy;
            Double price, amount;
            List<User> authUser;

            NotificationMsg noti = new NotificationMsg();
            TenderEnt tendEnt = new TenderEnt();
            Tender tender = new Tender();

           
            mailFrom=getFromMail(userID);
            subject="Adjustment Voucher";
            msgBody="This is msg from clerk informing Adjusted Item Quantity. You can check from this link <a href='listOfPendingReq.aspx'>click here!</a>";
           voucherID = getVoucherId("Adjustment_Voucher");
            tender.Item_Code = itemCode;
            List<Tender> tendInfo= tendEnt.getTender(tender);
            price = Convert.ToDouble(tendInfo.First().Price.ToString());
            amount = price * Convert.ToDouble(qty);
            
            if (amount <= 250.00)
            {
                authUser = getAuthIDAndNameEmail("Sup");
                authId = authUser.First().Emp_ID;
                authBy = authUser.First().Emp_Name;
                mailTo = authUser.First().Email;
                saveVoucherInfo(voucherID, dateIssue, authId, authBy);
                noti.sendAuthUserNotification(mailFrom, mailTo, subject,msgBody);
            }
            else if (amount > 250.00)
            {
                authUser = getAuthIDAndNameEmail("Mgr");
                authId = authUser.First().Emp_ID; ;
                authBy = authUser.First().Emp_Name;
                mailTo = authUser.First().Email;
                saveVoucherInfo(voucherID, dateIssue, authId, authBy);
                noti.sendAuthUserNotification(mailFrom, mailTo, subject, msgBody);
            }

            saveAdjustedQty(voucherID, itemCode, qty, reason);
        }

        public void saveVoucherInfo(String voucherId, DateTime issueDate, string authID, String authrizedBy)
        {
            Inventory_Adjustment_Voucher inventVoucher = new Inventory_Adjustment_Voucher();
            Inv_Adjustment_Voucher_Ent invenEnt = new Inv_Adjustment_Voucher_Ent();
            inventVoucher.Voucher_ID = voucherId;
            inventVoucher.Date_Issue = issueDate;
            inventVoucher.AuthorizedBy_ID = authID;
            inventVoucher.Authorized_By = authrizedBy;
            invenEnt.createInvAdjVoc(inventVoucher);
        }

        public void saveAdjustedQty(String voucherID, String itemCode, int qty, String reason)
        {
            Inventory_Adjustment_Voucher_Detail invAdj = new Inventory_Adjustment_Voucher_Detail();
            Inv_Adjustment_Voucher_DetailEnt invEnt = new Inv_Adjustment_Voucher_DetailEnt();
            invAdj.Voucher_ID = voucherID;
            invAdj.Item_Code = itemCode;
            invAdj.Qty_Adjust = qty;
            invAdj.Reason = reason;
            invAdj.Status = false;
            invEnt.createInvAdjVocDetail(invAdj);
        }

       

        public String getFromMail(String userId)
        {
            UsersEnt userEnt=new UsersEnt();
            User user= new User();
            user.Emp_ID=userId;
            User fromMail = userEnt.getUser(user);
            return fromMail.Email.ToString();
        }

 

        public List<User> getAuthIDAndNameEmail(String toUserRole)
        {
            UsersEnt userEnt2 = new UsersEnt();
            User user2=new User();
            user2.Role = toUserRole;
            List<User> authUser = userEnt2.getEmp(user2);
            return authUser;
        }
         
        public String getVoucherId(String tableName)
        {
            DALUtilities utilId = new DALUtilities();
            return utilId.Generate_ID(tableName);
        }
        public List<string> getItemCode()
        {
            StationaryCatalogueEnt statCatEnt = new StationaryCatalogueEnt();
            List<string> stCat = statCatEnt.getAllItemCode();
            return stCat;
        }
    }
}
