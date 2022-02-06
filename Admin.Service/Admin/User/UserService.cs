using Admin.Common.Attributes;
using Admin.Model.Admin;
using Admin.Repository.Admin.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql;
using Admin.Common.Output;

namespace Admin.Service.Admin.User
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UnitOfWorkManager _unitOfWorkManager;

        public UserService(IUserRepository userRepository,UnitOfWorkManager unitOfWorkManager)
        {
            _userRepository = userRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public IResponseOutput test() {
            using (IUnitOfWork unitOfWork = _unitOfWorkManager.Begin()) {
                try
                {
                    var obj = _userRepository;
                    var list = _userRepository.Select.ToList();
                    var userentity = new UserEntity { name = "111", sex = "222", bz = "333" };
                    _userRepository.Insert(userentity);
                    unitOfWork.Commit();
                   
                }
                catch {
                    unitOfWork.Rollback();
                }
            }
           
            return ResponseOutput.Ok();
        }

        public async Task<IResponseOutput> Add() {
            var list = new UserEntity { };
            var test = list.bz.ToString();
            var obj = _userRepository;
            var userentity = new UserEntity{ name = "111", sex = "222", bz = "333" };
            await _userRepository.InsertAsync(userentity);
            return ResponseOutput.Ok();
        }
    }
}
