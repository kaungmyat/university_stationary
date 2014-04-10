using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class EmployeeRequisitionControl_bk
    {
        static int x1 = 10, x2 = 10, x3 = 10, x4 = 10, x5 = 10;
        static int y;
        static Boolean flag1 = false;
        static Boolean flag2 = false;
        static Boolean flag3 = false;
        static Boolean flag4 = false;
        static Boolean flag5 = false;
        string RequisitionID = null;
        public String generateID(String department)
        {

            switch (department)
            {
                case "COMM":
                    if (flag1 == false)
                        y = 100;

                    if (x1 == 99)
                    {
                        flag1 = true;
                        y = y + 1;
                        x1 = 10;
                    }

                    RequisitionID = department + "/" + Convert.ToString(y) + "/" + Convert.ToString(x1++);
                    break;

                case "CPSC":
                    if (flag2 == false)
                        y = 200;

                    if (x2 == 99)
                    {
                        flag2 = true;
                        y = y + 1;
                        x2 = 10;
                    }
                    RequisitionID = department + "/" + Convert.ToString(y) + "/" + Convert.ToString(x2++);
                    break;

                case "ENGL":
                    if (flag3 == false)
                        y = 300;
                    if (x3 == 99)
                    {
                        flag3 = true;
                        y = y + 1;
                        x3 = 10;
                    }
                    RequisitionID = department + "/" + Convert.ToString(y) + "/" + Convert.ToString(x3++);
                    break;

                case "REGR":
                    if (flag4 == false)
                        y = 400;
                    if (x4 == 99)
                    {
                        flag4 = true;
                        y = y + 1;
                        x4 = 10;
                    }
                    RequisitionID = department + "/" + Convert.ToString(y) + "/" + Convert.ToString(x4++);
                    break;
                case "ZOOL":
                    if (flag5 == false)
                        y = 500;
                    if (x5 == 99)
                    {
                        flag5 = true;
                        y = y + 1;
                        x5 = 10;
                    }
                    RequisitionID = department + "/" + Convert.ToString(y) + "/" + Convert.ToString(x5++);
                    break;
            }

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
    }
}
