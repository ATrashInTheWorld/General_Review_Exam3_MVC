using REV_EXAM_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Angela.Core;
using REV_EXAM_3;
using REV_EXAM_3.ViewModels;

namespace REV_EXAM_3.Controllers
{
    public class MainController : Controller
    {
        // import the models in order to access the Context/DB
       private REV_EXAM_3Context db = new REV_EXAM_3Context();

        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SpecificTemplates()
        {
            // Basically, when I will access the view, I will retrieve
            // all BasicDemoClasse instances in the DB
            return View(db.BasicDemoClasses.ToList());
        }


        public static ICollection<DBFirstDemo> myListOfItems = new List<DBFirstDemo>();
        public ActionResult ANGELA()
        {
            // What is Angela Smith? Angela Smith is an extension that insert dumb data in the DB
            // In order to make it work, follow thos exact same steps, don't do anything else
            /*
             * 1)  In nugget console type: Install-Package AngelaSmith –Version 1.0.1
             *          !!!!!!!!! don't install the newest one else it won't work !!!!!!!!!
             * 2) import Angela.Core: using Angela.Core;
             * 3) create an ICollection of the model you want (see above this methode)
             *      !!!!! To make sure it works, you have to make sure that your Table,!!!!
             *      !!!!! if you have a date field, it has to be of type: dateTime2 !!!!
             *      !!!!! Else, it won't work if you want to generate a date !!!!!!
             *      !!!2! Also, Do not allow nullable in the model !!!!
             */
            
           //How Angela works. 
           List<DBFirstDemo> new2Rec = Angie.Configure<DBFirstDemo>() //This line is just how it is
                           .Fill(x => x.value1).AsFirstName() // I add a value to my value1 in my model that is filled with what Angela considers a first name
                           .Fill(y => y.value2).WithinRange((int)1, (int)500) // I set an integer in between 1 and 500 for my value2 in my model
                           .Fill(z => z.value4).AsPastDate() // I set a date for my value4 in the model
                           .MakeList<DBFirstDemo>(2); // I tell him to make of them everytime I call this methode and to add them in the List

           //So Right now I just created a list with 2 new records

           // Now lets say we want to save them in the DB and save them in the myListOfItems
           foreach(DBFirstDemo x in new2Rec)
           {
               // For some reason, you have to create a new object that will be added
               DBFirstDemo newRecord = new DBFirstDemo {
                      value1 = x.value1,
                      value2 = x.value2,
                      value4 = x.value4
               };

                // To be able to acces them, if code first, you need to scafold them
               db.DBFirstDemoes.Add(newRecord); //Adds the object to the table
               db.SaveChanges(); // Save the table


                
                myListOfItems.Add(newRecord); // Adds the record to the List

           }
           
            // Here we are only returning the list
            //return View(myListOfItems);


            //Or we could have had return the list from DB (uncomment and comment line 77)
            return View(db.DBFirstDemoes.ToList());

        }

        //creating a list of records to display, dont forget to import ViewModels
        public List<Combo> someFusion = new List<Combo>();
        public ActionResult ComboOf2Models()
        {
            // LINQ to select all records in BasicDemoClass Table
            // then puts them in a table
            var allBasicDemoClass = (from x in db.BasicDemoClasses
                                     select x).ToList();

            //LINQ select all records in DBFirstDemo Table
            var allDBFirstDemo = (from x in db.DBFirstDemoes
                                  select x).ToList();


            // initilizating an enumerator in order to keep track of the posisiton
            // of the record in BasicDemoClass (All this because I have less record in that table than in DBFirstDemo)
            int enumarator = 0;
            foreach(var rec in allBasicDemoClass)
            {
                enumarator++;
                Combo fusion = new Combo {
                    // set xyz from the Combo View Model to the value of the DBFirstDemo
                    // value1 that is at the enumerator position
                       xyz = allDBFirstDemo.ElementAt(enumarator).value1,
                       abc = allDBFirstDemo.ElementAt(enumarator).value2,

                    // set value of name1 in Combo View Model as the one in the allBasicDemoClass 
                       name1 = rec.name1,
                       randomeDate = rec.randomeDate
                };

                // Add to the list
                someFusion.Add(fusion);
            }
            // Yes my example makes no sense, but its just to show you hpw you can combine
            // the values of multiple models in one, that is called a View Model
            
            // Return the list
            return View(someFusion);
        }
    }
}