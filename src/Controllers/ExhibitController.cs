/*
 * Exhibit controller handles backend processing for:
 * CreateExhibit
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ARTchive.Models;
using ARTchive.DBManagers;

namespace ARTchive.Controllers
{
    [Route("api/exhibit")]
    public class ExhibitController : Controller
    {
        [HttpPost("[action]")]
        public void CreateExhibit([FromBody] Exhibit exhibit)
        {
          
            //create the exhibit manager
           ExhibitDBManager exhibitDBManager = new ExhibitDBManager();

            //insert exhibit into database
            exhibitDBManager.Insert(exhibit);
          
        }

        //get request to get a list of all exhibits in the database
        //TODO: pass Exhibit object and pagination to limit the number of exhibits queried
        [HttpGet("[action]")]
        public string GetAllExhibits()
        {
            //get list of exhibits
            ExhibitDBManager exhibitDBManager = new ExhibitDBManager();
            List<Exhibit> exhibitsArr = exhibitDBManager.getExhibits();

            //IEnumerable<Exhibit> temp = exhibitsArr;
          //  string json =  Newtonsoft.Json.JsonConvert.SerializeObject(temp);
            string jsonExhibitsArr = Newtonsoft.Json.JsonConvert.SerializeObject(exhibitsArr);
            
            return jsonExhibitsArr;
        }

        [HttpPost("[action]")]
        public void UpdateExhibit([FromBody] Exhibit exhibit)
        {

            //create the exhibit manager
            ExhibitDBManager exhibitDBManager = new ExhibitDBManager();

            //insert exhibit into database
            exhibitDBManager.Update(exhibit);

        }

        [HttpPost("[action]")]
        public void DeleteExhibit([FromBody] Exhibit exhibitData)
        {
            //create the exhibit manager
            ExhibitDBManager exhibitDBManager = new ExhibitDBManager();

            int exhibitID = exhibitData.getId();

            //update exhibit and add it to the database
            exhibitDBManager.Delete(exhibitID);
        }
    }


}
