using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoData
{
    public class myHelperData
    {

        ALFABETOEntities mycontex;
        public myHelperData()
        {
           
            mycontex = new ALFABETOEntities();

        }

        public List<TaAlfabeto> GeTAlfabeto()
        {
            return mycontex.TaAlfabeto.ToList();
        }

        
    }
}
