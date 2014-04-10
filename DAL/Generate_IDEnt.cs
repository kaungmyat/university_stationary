using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class Generate_IDEnt
    {
        LOGIC_UniversityEntities ContextDB;

        public Generate_IDEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public List<Generate_ID> getGenerateID(Generate_ID gid)
        {
            var q = from gd in ContextDB.Generate_ID
                    where (gd.ID == gid.ID || gid.ID == null)
                    && (gd.Table_Name == gid.Table_Name || gid.Table_Name == null)
                    select gd;

            return q.ToList<Generate_ID>();
        }

        public bool updateGenerateID(Generate_ID gid)
        {
            try
            {
                Generate_ID gn = (Generate_ID)getGenerateID(gid).First();
                gn.ID = gid.ID == null ? gn.ID : gid.ID;
                gn.Last_ID = gid.Last_ID == null ? gn.Last_ID : gid.Last_ID;
                gn.Seg1 = gid.Seg1 == null ? gn.Seg1 : gid.Seg1;
                gn.Seg2 = gid.Seg2 == null ? gn.Seg2 : gid.Seg2;

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
