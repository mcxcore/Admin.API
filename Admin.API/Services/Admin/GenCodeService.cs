using Admin.Common.Helpers;
using Admin.Common.Page;
using Admin.Common.ResponseOutput;
using Admin.Dto.Admin.GenCode.Input;
using Admin.Dto.Admin.GenCode.Output;
using Admin.Repository.Admin.GenCode;
using AutoMapper;
using Masuit.Tools.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Services.Admin
{
    public class GenCodeService:BaseService
    {
        private readonly IGenTableRepository _genTableRepository;
        private readonly IFreeSql _freeSql;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public GenCodeService(IGenTableRepository genTableRepository,IFreeSql freeSql,IWebHostEnvironment env,IMapper mapper)
        {
            _genTableRepository = genTableRepository;
            _freeSql = freeSql;
            _env = env;
            _mapper = mapper;
        }

        /// <summary>
        /// 查询数据库表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> GetList([FromBody] PageInput<GenCodeSearchInput> input) {
            var list = await _genTableRepository.Select.Count(out long count).Page(input.pageIndex,input.pageSize)
                .ToListAsync();
            var data = new PageOutput<GenCodeListOutput>()
            {
                rows = _mapper.Map<List<GenCodeListOutput>>(list),
                total = count
            };
            return ResponseOutput.Ok(data);
        }

        /// <summary>
        /// 同步数据库表
        /// </summary>
        /// <returns></returns>
        public async Task<IResponseOutput> syncDatabaseTable() {
            var tableInfos = _freeSql.GetTables(_env);
            foreach (var item in tableInfos)
            {
                if (!await _genTableRepository.Where(t => t.tableName == item.Name).AnyAsync()) {
                    await _genTableRepository.InsertAsync(new Model.gen_table() { tableName = item.Name, tableComment = item.Comment });
                }
            }
            return ResponseOutput.Ok("同步成功!");
        }
    }
}
