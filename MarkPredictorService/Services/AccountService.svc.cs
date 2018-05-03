using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MarkPredictorService.ApiModels;
using MarkPredictor.Shared.Models;
using MarkPredictorService.Common;
using AutoMapper;
using MarkPredictor.Shared.Entites;

namespace MarkPredictorService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountService.svc or AccountService.svc.cs at the Solution Explorer and start debugging.
    public class AccountService : IAccountService
    {
        private readonly StudentModel _studentModel;
        public AccountService()
        {
            _studentModel = InstanceFactory.GetStudentModel();
        }

        /// <summary>
        ///  Login method
        /// </summary>
        /// <param name="studentApiModel"> Loging request object</param>
        /// <returns></returns>

        public BaseApiModel Login(StudentApiModel studentApiModel)
        {
            var student = _studentModel.Login(Mapper.Map<Student>(studentApiModel));
            if (student != null)
            {
                return Mapper.Map<StudentApiModel>(student);
            }
            return new StudentApiModel() ;
        }

        /// <summary>
        /// Register service method
        /// </summary>
        /// <param name="studentApiModel"> Regisgter requet object</param>
        /// <returns></returns>
        public int Register(StudentApiModel studentApiModel)
        {
            try
            {
                return _studentModel.AddStudent(Mapper.Map<Student>(studentApiModel));
            }
            catch (Exception)
            {
                return 0;
            }
           
        }
    }
}
