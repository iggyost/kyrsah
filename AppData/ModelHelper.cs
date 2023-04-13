using kyrsah.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsah.AppData
{
    class ModelHelper
    {
        private static Kurs_PankEntities context;

        public static Kurs_PankEntities GetContext()
        {
            if (context == null)
            {
                context = new Kurs_PankEntities();
            }
            return context;
        }
    }
}
