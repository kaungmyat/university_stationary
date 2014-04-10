using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace DAL
{
    //Author - ZhangNa
    public class EntityBrokerClerk
    {
        LOGIC_UniversityEntities entity = new LOGIC_UniversityEntities();

        //get Requisition Form
        public IQueryable getRequisitionForm()
        {
            var v = from rm in entity.Requisitions
                    where rm.Approval_Status == 1
                    join rdm in entity.Requisition_Detail on rm.Req_Form_No equals rdm.Req_Form_No
                    select new
                    {
                        RequisitionFormNo = rm.Req_Form_No,
                        ItemCode = rdm.Item_Code,
                        Description = rdm.Description,
                        Quantity = rdm.Qty,
                        Approval_Status = rm.Approval_Status,
                        //Prior = rm.Prior
                    };
            return v;
        }

        //auto check stockItem balance 
        //---------Retrieval
        //-------------------OutStanding
        //.........
        public int getBalance_From_ItemCode(string itemCode)
        {
            var v = (from bals in entity.getBalFromItemCodes
                    where bals.Item_Code == itemCode
                    select bals).FirstOrDefault();
            return (int)v.Balance;
        }
        //==============
        public string getSCIDFromItemCode(string itemCode) {
            var v = (from ids in entity.getBalFromItemCodes
                     where ids.Item_Code == itemCode
                     select ids).FirstOrDefault();
            return v.StockCard_ID;
        }

        //----------------OutStanding
        public int checkItemAvail(string itemCode, int qty) {
            var v = (from sc in entity.StockCards
                     where sc.Item_Code == itemCode
                     join scd in entity.StockCard_Detail on sc.StockCard_ID equals scd.StockCard_ID
                     select scd).FirstOrDefault();
            int os = (int)v.Balance - qty;
            return os;
        }

        //setPrior
        //-----------Requisition
        public void setPriorByReqFormNo(string Req_FormNo)
        {
            Requisition rm = entity.Requisitions.Where(x => x.Req_Form_No == Req_FormNo).FirstOrDefault();
            rm.Prior = true;
            entity.SaveChanges();
        }

        //get disbursement list
        public IQueryable getDisbursementList()
        {
            var v = from dm in entity.Disbursements
                    join dept in entity.Departments on dm.Dept_ID equals dept.Dept_ID
                    where dm.Disburse_Status == 1
                    select new
                    {
                        RequisitionFormNo = dm.Req_Form_No,
                        DepartmentName = dept.Dept_Name,
                        DisbursementNumber = dm.Disbursement_ID
                    };
            return v;
        }

        //get disbursement Detail list
        public IQueryable getDisbursementDetail(string req_No)
        {
            var v = from dm in entity.Disbursements
                    where dm.Disburse_Status == 1 && dm.Req_Form_No == req_No
                    join ddm in entity.Disbursement_Detail on dm.Disbursement_ID equals ddm.Disbursement_ID
                    join sc in entity.Stationary_Catalogue on ddm.Item_Code equals sc.Item_Code
                    select new
                    {
                        ItemCode = ddm.Item_Code,
                        StationaryDescription = sc.Description,
                        RequestedQuantity = ddm.Qty_Required,
                        DisbursedQuantity = ddm.Qty_Retrieved
                    };
            return v;
        }

        //click submit update_status at disbursement List Details biz logic(Qty_R - Qty_D = 0) need here
        public int updateDisbursementStatus_1to2(string disbursement_ID)
        {
            var row = entity.Disbursements.Where(x => x.Disbursement_ID == disbursement_ID).SingleOrDefault();//string can ==??
            row.Disburse_Status = 2;
            int i = entity.SaveChanges();
            return i;
        }

        //click submit update_status at disbursement List Details biz logic(Qty_R - Qty_D > 0) need here
        public int updateDisbursementStatus_1to3(string disbursement_ID)
        {
            var row = entity.Disbursements.Where(x => x.Disbursement_ID == disbursement_ID).SingleOrDefault();//string can ==??
            row.Disburse_Status = 3;
            int i = entity.SaveChanges();
            return i;
        }

        //click submit update_disbursedQty at disbursement List Details(use foreach loop)
        public int updateQty_Disbursed(string disN, string itemCode)
        {
            var v = (from dd in entity.Disbursement_Detail
                    where dd.Disbursement_ID == disN && dd.Item_Code == itemCode
                    orderby dd.Disbursement_ID
                    select dd).FirstOrDefault();
            v.Qty_Disbursed = v.Qty_Required;
            int i = entity.SaveChanges();
            return i;
        }
        //===================Out..............
        public bool checkOutS(string disN){
            var v = from ddm in entity.Disbursement_Detail
                    where ddm.Disbursement_ID == disN
                    select ddm;
            int count = 0;
            foreach (Disbursement_Detail dd in v) {
                if (dd.Qty_Retrieved != dd.Qty_Disbursed) count++;
            }
            if (count == 0) return false;
            else return true;
        }

        
        //for disbursementList to get Department Name using req_Form_No.???
        public string getDeptName_From_ReqFormNo(string reqFormNo)
        {
            var deptm = entity.Departments.Where(x => x.Dept_ID == reqFormNo.Substring(0, 3)).SingleOrDefault();
            return deptm.Dept_Name;
        }

        //get retrieval_dept form
        //-----------Retrival
        public IQueryable getRetrievalDeptForm(string itemCode)
        {
            var v= from rdm in entity.Requisition_Detail where rdm.Item_Code == itemCode
                   join rm in entity.Requisitions on rdm.Req_Form_No equals rm.Req_Form_No
                   where rm.Approval_Status == 3
                   orderby rm.Prior
                   select new
                   {
                       DeptID = rdm.Req_Form_No.Substring(0,3),
                       Needed = rdm.Qty,
                       Actual = rdm.Qty
                   };
            return v;
        }

        public IQueryable getRetrievalDeptList() {
            var v = from rdlm in entity.Retrieval_Dept
                    orderby rdlm.Item_Code,rdlm.prior
                    select new { 
                        ItemCode = rdlm.Item_Code,
                        DeptID = rdlm.Req_Form_No.Substring(0,3),
                        Needed = rdlm.Needed,
                        Retrieved = rdlm.Retrieved
                    };
            return v;
        }

        //get retrieval_item form
        public IQueryable getRetrievalItemForm()
        {
            var v = from rdm in entity.Requisition_Detail 
                    select new
                    {
                        ItemCode = rdm.Item_Code,
                        Needed = rdm.Qty,
                        Retrieved = rdm.Qty
                    };
           // var v = from rdsp in entity.Retrieval_Item select rdsp;          
           return v;
        }

        public Retrieval_Item getRetrievalItem() {
            Retrieval_Item retriItemlist = new Retrieval_Item();
            return retriItemlist;
        }

        //update requisition status after click 'Submit' btn at Retrieval Form UI
        //----------Retrival
        public int updateApproval_Status(string reqNo)
        {
            var rmRow = entity.Requisitions.Where(x => x.Req_Form_No == reqNo).SingleOrDefault();
            rmRow.Req_Status = true;
            rmRow.Approval_Status = 4;
            int i = entity.SaveChanges();
            return i;
        }
        public List<string> getReqNoFromRm() {
            var v = (from rm in entity.Requisitions
                     where rm.Approval_Status == 3
                     select rm).SingleOrDefault();
            List<string> rNolist = new List<string>();//
            rNolist.Add(v.Req_Form_No);//
            return rNolist;
        }

        //insert/create new row to disbursement when click 'Submit' at retrieval UI
        //----------Retrieval
        public int insertDisbursement(string reqNo, string newDisID)
        {
            Disbursement newDis = new Disbursement();
            newDis.Disbursement_ID = newDisID;
            newDis.Req_Form_No = reqNo;
            newDis.Dept_ID = reqNo.Substring(0, 3);
            newDis.Date = DateTime.Today;
            newDis.Disburse_Status = 1;
            entity.Disbursements.AddObject(newDis);     
            int i = entity.SaveChanges();
            return i;
        }

        //=========Retrieval..........

        public int insertDis(Disbursement newDis) {
            entity.Disbursements.AddObject(newDis);
            int i = entity.SaveChanges();
            return i;
        }

        //==========Retrival..........
        public int insertDisD(Disbursement_Detail newDisD) {
            entity.Disbursement_Detail.AddObject(newDisD);
            int i = entity.SaveChanges();
            return i;
        }
        //========retrieval...............
        public List<Requisition_Detail> getItemCodeFromReq(string reqNo)
        {
            List<Requisition_Detail> rdli= new List<Requisition_Detail>();
            var v = from rdm in entity.Requisition_Detail 
                    where rdm.Req_Form_No == reqNo 
                    select rdm;
            foreach (Requisition_Detail rd in v) {
                rdli.Add(rd);
            }
            return rdli;
        }
        //=========out..............
        public List<Disbursement_Detail> getDDItemFromDisN(string disN) {
            List<Disbursement_Detail> ddli = new List<Disbursement_Detail>();
            var v = from ddm in entity.Disbursement_Detail
                    where ddm.Disbursement_ID == disN
                    select ddm;
            foreach (Disbursement_Detail dd in v) {
                ddli.Add(dd);
            }
            return ddli;
        }

       /* public List<int> getQtyFromReq(string reqNo) {
            List<int> qtyli = new List<int>();
            var v = from rdm in entity.Requisition_Detail
                    where rdm.Req_Form_No == reqNo
                    select rdm;
        }*/

        //insert/create new row to disbursement detail when click 'Submit at retrieval UI
        //-----------Retrieval
        public int insertDisbursementDetail(string reqNo,string itemCode,string newDisID,int Qty_Req, int Qty_Retrieved)
        {
            var v = (from dm in entity.Disbursements 
                     where dm.Req_Form_No == reqNo 
                     join rdm in entity.Requisition_Detail on dm.Req_Form_No equals rdm.Req_Form_No
                     where rdm.Item_Code == itemCode
                     select new
                     {
                         Disbursement_ID = newDisID,
                         Item_Code = itemCode,
                         Qty_Required = Qty_Req,
                         Qty_Retrieved = Qty_Retrieved,
                         Qty_Disburse = Qty_Retrieved
                     }).SingleOrDefault();

            Disbursement_Detail newDisD = new Disbursement_Detail();
            newDisD.Disbursement_ID = newDisID;
            newDisD.Item_Code = itemCode;
            newDisD.Qty_Required = Qty_Req;
            newDisD.Qty_Retrieved = Qty_Retrieved;
            newDisD.Qty_Disbursed = Qty_Retrieved;
            entity.Disbursement_Detail.AddObject(newDisD);
            int i = entity.SaveChanges();
            return i;
        }

        public int insertDisbursementDetail(Disbursement_Detail ddm)//should be update
        {
            var disbursement_Detail = new Disbursement_Detail
            {
                Item_Code = ddm.Item_Code,
                Qty_Required = ddm.Qty_Required - ddm.Qty_Disbursed,
            };
            entity.Disbursement_Detail.AddObject(disbursement_Detail);

            int i = entity.SaveChanges();
            return i;
        }

        //view OutStanding Requisition
        //--------------OutStanding
        public IQueryable getOutStandingList()
        {
            var osList = from os in entity.Disbursements
                         where os.Disburse_Status == 3
                         join ddm in entity.Disbursement_Detail on os.Disbursement_ID equals ddm.Disbursement_ID
                         //join sc in entity.Stationary_Catalogue on ddm.Item_Code equals sc.Item_Code
                         select new
                         {
                             ItemCOde = ddm.Item_Code,
                             OutstandingQuangtity = ddm.Qty_Required - ddm.Qty_Disbursed,
                             DisbursementFormNumber = os.Disbursement_ID
                         };
            return osList;
        }
        //when click 'submit'
        //------------OutStanding
        public void fulfillInsertDis(string disNo) {
            var v = (from dm in entity.Disbursements
                     where dm.Disbursement_ID == disNo
                     join rm in entity.Requisitions on dm.Req_Form_No equals rm.Req_Form_No
                     select new
                     {
                         Disbursement_ID = dm.Disbursement_ID + "F",
                         Req_Form_No = dm.Req_Form_No,
                         Dept_ID = dm.Dept_ID,
                         Date = DateTime.Today,
                         Disburse_Status = 1
                     }).FirstOrDefault();
            Disbursement newDis = new Disbursement();
            newDis.Disbursement_ID = v.Disbursement_ID;
            newDis.Req_Form_No = v.Req_Form_No;
            newDis.Dept_ID = v.Dept_ID;
            newDis.Date = v.Date;
            newDis.Disburse_Status = v.Disburse_Status;
            entity.Disbursements.AddObject(newDis);
        }

        public int fulfillInsertDisDetail(string itemCode, string disNo) {
            var v = (from ddm in entity.Disbursement_Detail
                     where ddm.Item_Code == itemCode
                     join dm in entity.Disbursements on ddm.Disbursement_ID equals dm.Disbursement_ID
                     select new
                     {
                         Disbursement_ID = ddm.Disbursement_ID + "F",
                         Item_Code = ddm.Item_Code,
                         Qty_Required = ddm.Qty_Required - ddm.Qty_Disbursed,
                         Qty_Retrieved = ddm.Qty_Required - ddm.Qty_Disbursed,
                         Qty_Disbursed = ddm.Qty_Required - ddm.Qty_Disbursed
                     }).FirstOrDefault();
            Disbursement_Detail newDisD = new Disbursement_Detail();
            newDisD.Disbursement_ID = v.Disbursement_ID;
            newDisD.Item_Code = v.Item_Code;
            newDisD.Qty_Retrieved = v.Qty_Retrieved;
            newDisD.Qty_Disbursed = v.Qty_Disbursed;
            entity.Disbursement_Detail.AddObject(newDisD);
            int i = entity.SaveChanges();
            return i;
        }

        //---------------OutStanding
        public int fulfillOutStanding(string reqNo,string itemCode){
            var v = (from ddm in entity.Disbursement_Detail
                     where ddm.Item_Code == itemCode
                     join dm in entity.Disbursements on ddm.Disbursement_ID equals dm.Disbursement_ID
                     //join rdm in entity.Requisition_Detail on ddm.Item_Code equals rdm.Item_Code
                     //where rdm.Req_Form_No == reqNo
                     //join dm in entity.Disbursements on rdm.Req_Form_No equals dm.Req_Form_No
                     //orderby dm.Date descending
                     select new
                     {
                         Disbursement_ID = dm.Disbursement_ID + "F",
                         Item_Code = itemCode,
                         Qty_Required = ddm.Qty_Required - ddm.Qty_Disbursed,
                         Qty_Retrieved = ddm.Qty_Required - ddm.Qty_Disbursed,
                         Qty_Disbursed = ddm.Qty_Required - ddm.Qty_Disbursed,
                     }).FirstOrDefault();
            Disbursement_Detail newDisD = new Disbursement_Detail();
            newDisD.Disbursement_ID = v.Disbursement_ID;
            newDisD.Item_Code = v.Item_Code;
            newDisD.Qty_Required = v.Qty_Required;
            newDisD.Qty_Retrieved = v.Qty_Retrieved;
            newDisD.Qty_Disbursed = v.Qty_Disbursed;
            entity.Disbursement_Detail.AddObject(newDisD);
            entity.Disbursement_Detail.AddObject(newDisD);
            int i = entity.SaveChanges();
            return i;
        }
        //for fulfil outstanding get var
        //----------------------OutStanding------------
        public string getReqNo_From_DisID(string disID) {
            var v = (from dm in entity.Disbursements
                    where dm.Disbursement_ID == disID
                    select dm).SingleOrDefault();
            string ReqNo = v.Req_Form_No;
            return ReqNo;
        }

        //--------------OutStanding--------
        public int updateDisburse_Status3to2(string disID)
        {
            var v = entity.Disbursements.Where(x => x.Disbursement_ID == disID).SingleOrDefault();
            v.Disburse_Status = 2;
            int i = entity.SaveChanges();
            return i;         
        }

        //---------------UpdateStock
        public IQueryable getStockCardItem(string itemCode)
        {
            var v = (from sc in entity.StockCards
                    where sc.Item_Code == itemCode
                    join scd in entity.StockCard_Detail on sc.StockCard_ID equals scd.StockCard_ID
                    join scm in entity.Stationary_Catalogue on sc.Item_Code equals scm.Item_Code
                    //group scd by scd.StockCard_ID into 
                    select new
                    {
                        ItemCode = itemCode,
                        Description = scm.Description,
                        UOM = scm.UOM,
                        FirstSupplier = sc.first_Supplier,
                        SecondSupplier = sc.second_Supplier,
                        ThirdSupplier = sc.third_Supplier
                    }).Take(1);
            return v;
        }

        //----------UpdateStock
        public IQueryable getAllStockCardItem()
        {
            var v = (from sc in entity.StockCards 
                    join scd in entity.StockCard_Detail on sc.StockCard_ID equals scd.StockCard_ID
                    join scm in entity.Stationary_Catalogue on sc.Item_Code equals scm.Item_Code
                    select new
                    {
                        ItemCode = sc.Item_Code,
                        Description = scm.Description,
                        UOM = scm.UOM,
                        FirstSupplier = sc.first_Supplier,
                        SecondSupplier = sc.second_Supplier,
                        ThirdSupplier = sc.third_Supplier
                    }).Take(1);
            return v;
        }

        //--------------UpdateStock
        public IQueryable getStockCardItemRecord(string itemCode)
        {
            var v = from sc in entity.StockCards
                    where sc.Item_Code == itemCode
                    join scd in entity.StockCard_Detail on sc.StockCard_ID equals scd.StockCard_ID
                    select new
                    {
                        //StockCardID = scd.StockCard_ID,
                        Date = scd.Date,
                        Description = scd.Dept_Supplier,
                        Quantity = scd.Qty,
                        Balance = scd.Balance
                    };
            return v;
        }
        //update stock card by item code
        public int updateStock(StockCard scm)
        {
            var rmRow = entity.StockCards.Where(x => x.Item_Code == scm.Item_Code).SingleOrDefault();
            rmRow = scm;
            int i = entity.SaveChanges();
            return i;
        }
        //update stock card detail by Tran_ID(one item has many record)
        public int updateStockRecord(string tranID)
        {
            var rmRow = entity.StockCard_Detail.Where(x => x.Tran_ID == tranID).SingleOrDefault();
            int i = entity.SaveChanges();
            return i;
        }
        //----------------
        public int updateStock_Detail(string itemCode,int qty) {

            var v = (from sm in entity.StockCards
                    where sm.Item_Code == itemCode
                    join sdm in entity.StockCard_Detail on sm.StockCard_ID equals sdm.StockCard_ID
                    select new
                    {
                        Qty = sdm.Balance
                    }).SingleOrDefault();
            StockCard_Detail newsdm = new StockCard_Detail();
            newsdm.Balance = newsdm.Balance - v.Qty;
            int i = entity.SaveChanges();
            return i;
        }
        //------Outstanding
        //------Retrieval................
        public int insertStock_Detail(StockCard_Detail newSD) {
            entity.StockCard_Detail.AddObject(newSD);
            int i = entity.SaveChanges();
            return i;
        }

        public string getDeptIdFromDisId(string disID)
        {
            var v = (from dm in entity.Disbursements
                     where dm.Disbursement_ID == disID
                     select dm).SingleOrDefault();
            string DeptId = v.Dept_ID;
            return DeptId;
        }

        public IQueryable getReorderRData() { 
            var v = (from st in entity.Stationary_Catalogue where st.Item_Code == "C002"
                    join sc in entity.StockCards on st.Item_Code equals sc.Item_Code
                    join scd in entity.StockCard_Detail on sc.StockCard_ID equals scd.StockCard_ID
                    orderby sc.Item_Code,scd.Date descending
                    select new {
                        ItemCode = sc.Item_Code,
                        //Description = st.Description,
                        QuantityOnHand = scd.Balance,
                        ReorderLevel = st.Reorder_Level,
                        ReorderQuantity = st.Reorder_Qty
                    }).Take(1);
            return v;
        }
    }
}
