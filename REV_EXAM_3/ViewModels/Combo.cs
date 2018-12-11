using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REV_EXAM_3.ViewModels
{
    public class Combo
    {
        
        //So what is a View Model?
        /*
         * Well its basically the same thing as a model, but that allows you to combine one 
         * or more models in one. Again, it's basically an object that you can populate
         * like ny other other object.
         * In my example, my 2 tables have no relationship between them, 
         * so I will have to populate them maually.
         * However, the teacher's example has a reference in between them, go check her for an concrete example.
         */

        //Here Ide cide the fields I want to display, I can call them diferently from their name in the model

            //it will reference value1 from DBFirstDemo
        public string xyz { get; set; }

        //will reference value2 from DBFirstDemo --> you got the point
        public int abc { get; set; }

        //will refenrece name1 from BasicDemoClass
        public string name1 { get; set; }

        //will reference randomeDate from BasicDemoClass
        public DateTime randomeDate { get; set; }
    }
}