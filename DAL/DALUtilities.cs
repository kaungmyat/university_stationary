using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace DAL
{
    //Author - Kaung Myat 
    public class DALUtilities
    {
        LOGIC_UniversityEntities ContextDB;

        public DALUtilities()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public bool update_GenID(string tablename)
        {
            try
            {
                Generate_ID gen = (from g in ContextDB.Generate_ID
                                   where g.Table_Name == tablename
                                   select g).First();
                gen.Last_ID = gen.Last_ID + 1;

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception = " + e);
                return false;
            }
        }

        public string Generate_ID(string tablename)
        {
            string ret = null;
            string val1 = null;
            string val2 = null;
            Generate_ID gen = new Generate_ID();
            Generate_IDEnt genE = new Generate_IDEnt();


            switch (tablename)
            {
                case "Requisition":
                    {
                        gen = (from g in ContextDB.Generate_ID
                               where g.Table_Name == tablename
                               select g).First();

                        if (gen.Seg1 < 99)
                        {
                            val1 = (gen.Seg1 + 1).ToString();
                        }
                        else
                        {
                            val2 = (gen.Last_ID + 1).ToString();
                            gen.Last_ID = 10;
                        }

                        //val1 = (gen.Last_ID + 1).ToString();
                        //val2 = (gen.Seg1 + 1).ToString();
                        ret = val2 + "/" + val1;

                        //gen.Last_ID = gen.Last_ID + 1;
                        //gen.Seg2 = gen.Seg2 + 1;

                        //genE.updateGenerateID(gen);

                        break;
                    }

                case "Purchase_Order":
                    {
                        gen = (from g in ContextDB.Generate_ID
                                where g.Table_Name == tablename
                                select g).First();
                        ret = (gen.Last_ID + 1).ToString();

                        //gen.Last_ID = gen.Last_ID + 1;

                        //genE.updateGenerateID(gen);

                        break;
                    }

                case "StockCard_Detail":
                    {
                        gen = (from g in ContextDB.Generate_ID
                               where g.Table_Name == tablename
                               select g).First();
                        ret = "TND" + (gen.Last_ID + 1).ToString();

                        break;
                    }
                 case "Disbursement":
                    {
                        gen = (from g in ContextDB.Generate_ID
                               where g.Table_Name == tablename
                               select g).First();
                        ret = (gen.Last_ID + 1).ToString();

                        break;
                    }

                 case "Adjustment_Voucher":
                    {
                        gen = (from g in ContextDB.Generate_ID
                               where g.Table_Name == tablename
                               select g).First();
                        

                        if (gen.Last_ID < 99)
                        {
                            val1 = (gen.Last_ID + 1).ToString();
                        }
                        else
                        {
                            val2 = (gen.Seg1 + 1).ToString();
                            gen.Last_ID = 10;
                        }

                        break;

                    }

                default :
                    return "xxx";
            }
            return ret;
        }

        public bool Increament_GenID(int id)
        {
            try
            {
                Generate_IDEnt gEnt = new Generate_IDEnt();
                Generate_ID gid = new Generate_ID();
                gid.ID = id;
                gid.Last_ID = (from g in ContextDB.Generate_ID
                               where g.ID == id
                               select g.Last_ID).SingleOrDefault() + 1;
                gEnt.updateGenerateID(gid);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
