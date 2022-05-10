using Admin.Model;
using AutoMapper;
using Admin.Dto.Admin.GenCode.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Dto.Admin.GenCode
{
    public class MapConfig:Profile
    {
        public MapConfig() {
            CreateMap<gen_table,GenCodeListOutput>();
        }
    }
}
