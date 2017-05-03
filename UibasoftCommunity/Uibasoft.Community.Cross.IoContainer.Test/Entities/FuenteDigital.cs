using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Cross.IoContainer.Test.Entities
{
    public class FuenteDigital : IClase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public void Guardar()
        {
            throw new NotImplementedException();
        }
        public void Eliminar()
        {
            throw new NotImplementedException();
        }
    }
}
