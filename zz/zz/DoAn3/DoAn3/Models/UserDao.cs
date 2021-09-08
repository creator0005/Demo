using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAn3.Common;
using DoAn3.Models;

namespace DoAn3.Models
{
    public class UserDao
    {
        ModelPhone db = null;
        public UserDao()
        {
            db = new ModelPhone();
        }
        public Ngdung GetById(string userName)
        {
            return db.Ngdung.SingleOrDefault(x => x.taikhoan == userName);
        }
        public string Insert(Ngdung entity)
        {
            db.Ngdung.Add(entity);
            db.SaveChanges();
            return entity.mand;
        }
        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.Ngdung.SingleOrDefault(x => x.taikhoan == userName);
            if (isLoginAdmin == true)
            {
                if (result == null)
                {
                    return 0;
                }
                else
                {
                    if (userName == "admin@gmail.com")
                        if (result.matkhau == passWord)
                            return 1;
                        else
                            return -2;
                    else
                        return -3;
                }
            }
            if (result != null)
            {


                if (result == null)
                {
                    return 0;
                }
                else
                {
                    if (result.matkhau == passWord && result.taikhoan == userName)
                        return 1;
                    else
                        return -2;
                }
            }
            else
                return 0;
            //    {
            //        if (isLoginAdmin == true)
            //        {

            //            if (result.taikhoan !="")
            //            {
            //                return -1;
            //            }
            //            else
            //            {
            //                if (result.matkhau == passWord)
            //                    return 1;
            //                else
            //                    return -2;
            //            }
            //        }


            //        else
            //        {
            //            if (result.taikhoan!="")
            //            {
            //                return -1;
            //            }
            //            else
            //            {
            //                if (result.matkhau == passWord)
            //                    return 1;
            //                else
            //                    return -2;
            //            }
            //        }
            //    }
            
        }
       
        public bool CheckUserName(string userName)
        {
            return db.Ngdung.Count(x => x.taikhoan == userName) > 0;
        }
        //public bool CheckDiachi(string diachi)
        //{
        //    return db.Ngdung.Count(x => x.diachi == diachi) > 0;
        //}
    }
}