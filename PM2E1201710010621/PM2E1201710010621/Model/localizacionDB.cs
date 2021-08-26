using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2E1201710010621;

namespace PM2E1201710010621.Model
{
    class localizacionDB
    {
        public string Latitud   { get; set; }
        [MaxLength(200)]
        public string Longitud { get; set; }
        [MaxLength(200)]

        public string Descripcion
        { 
            get; set;
        }
        [MaxLength(100)]
        public string NomUbicacion
        {
            get; set;
        }


    }
}
