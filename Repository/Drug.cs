using MailOrderPharmacy_DrugService.Controllers;
using MailOrderPharmacy_DrugService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOrderPharmacy_DrugService.Repository
{
    public class Drug : IDrug
    {

        public static List<DrugDetails> ls = new List<DrugDetails>
        {
            new DrugDetails
            {
                DrugId = 1,
                Name = "Paracetamol",
                Manufacturer = "Jonsons",
                ManufacturedDate = new DateTime(2020, 09, 21),
                ExpiryDate = new DateTime(2021, 07, 12),
                cost = 100.00,
                UnitPackage = 100,
                //Location = "Pune",
                Quantity = 100

            }
            };
        public DrugDetails searchDrugsByID(int Id)
        {
            var item = ls.Where(x => x.DrugId == Id).FirstOrDefault();
            return item;
        }
        public DrugDetails searchDrugsByName(string name)
        {
            var item = ls.Where(x => x.Name == name).FirstOrDefault();
            return item;
        }
        public IEnumerable<DrugDetails> getDispatchableDrugStock(int Id, string location)
        {
            var obj = DrugLocController.list;
            // List<DrugDetails> item = new List<DrugDetails>();
            var obj1 = Drug.ls;
           foreach(DrugDetails x in obj1)
            {
                x.drugLocation = obj.Where(c => c.Drug_Id == Id && c.Location==location).FirstOrDefault();
            }
            return obj1;
        }
    }
}
