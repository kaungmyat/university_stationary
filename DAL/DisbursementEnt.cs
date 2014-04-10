using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class DisbursementEnt
    {
        LOGIC_UniversityEntities ContextDB;

        public DisbursementEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public void createDisbursement(Disbursement disburse)
        {
            ContextDB.Disbursements.AddObject(disburse);
            ContextDB.SaveChanges();
        }

        public List<Disbursement> getAllDisbursement()
        {
            var q = from d in ContextDB.Disbursements
                    select d;

            return q.ToList<Disbursement>();
        }

        public Disbursement getDisbursement(Disbursement dis)
        {
            var query = from d in ContextDB.Disbursements
                        where (d.Disbursement_ID == dis.Disbursement_ID || dis.Disbursement_ID == null)
                        && (d.Req_Form_No == dis.Req_Form_No || dis.Req_Form_No == null)
                        && (d.Dept_ID == dis.Dept_ID || dis.Dept_ID == null)
                        && (d.Date == dis.Date || dis.Date == null)
                        && (d.Disburse_Status == dis.Disburse_Status || dis.Disburse_Status == null)
                        select d;

            return query.First();
        }

        public bool updateDisbursement(Disbursement updDis)
        {
            try
            {
                Disbursement dis = getDisbursement(updDis);
                dis.Disburse_Status = updDis.Disburse_Status;

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteDisbursement(Disbursement delDis)
        {
            try
            {
                ContextDB.Disbursements.DeleteObject(delDis);
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
