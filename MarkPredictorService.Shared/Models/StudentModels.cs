using MarkPredictor.Shared.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MarkPredictor.Shared.Models
{
    public class StudentModel
    {
        private readonly MarkPredictorDbContext _markPredictorDbContext;

        public StudentModel(MarkPredictorDbContext markPredictorDbContext)
        {
            _markPredictorDbContext = markPredictorDbContext;
        }

        public Student Login(Student student)
        {
            var studentEntity = _markPredictorDbContext.Student.Where(s => s.UserName == student.UserName).FirstOrDefault();
            if (student != null)
            {
                if (studentEntity.Password == GetPasswordHash(student.Password))
                {
                    return studentEntity;
                }
            }

            return null;
        }

        public int AddStudent(Student student)
        {
            student.Password = GetPasswordHash(student.Password);
            _markPredictorDbContext.Student.Add(student);
           return _markPredictorDbContext.SaveChanges();
        }

        public  string GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1Managed())
            {
                var hash = Encoding.UTF8.GetBytes(password);
                var generatedHash = sha1.ComputeHash(hash);
                var generatedHashString = Convert.ToBase64String(generatedHash);
                return generatedHashString;
            }
        }
    }
}
