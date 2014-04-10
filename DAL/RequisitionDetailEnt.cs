using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class RequisitionDetailEnt
    {
        LOGIC_UniversityEntities ContextDB;

        public RequisitionDetailEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public void createReqDetail(Requisition_Detail reqDet)
        {
            ContextDB.Requisition_Detail.AddObject(reqDet);
            ContextDB.SaveChanges();
        }

        public List<Requisition_Detail> getReqDetail(Requisition_Detail reqDet)
        {
            var q = from rd in ContextDB.Requisition_Detail
                    where rd.Req_Form_No == reqDet.Req_Form_No
                    select rd;

            return q.ToList<Requisition_Detail>();
        }

        public bool updateReqDetail(Requisition_Detail reqDet)
        {
            try
            {   
                Requisition_Detail rd = new Requisition_Detail();
                
                rd.Item_Code = reqDet.Item_Code;
                rd.Description = reqDet.Description;
                rd.Qty = reqDet.Qty;

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteReqDetail(Requisition_Detail reqDet)
        {
            try
            {
                ContextDB.Requisition_Detail.DeleteObject(reqDet);
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
