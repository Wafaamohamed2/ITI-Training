using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace ITI_Day4
{
    public abstract class Shap
     {

        public Shap() { }

        public Raylib_cs.Color Color { get; set; }
        public abstract void Draw();
        

     }
}
