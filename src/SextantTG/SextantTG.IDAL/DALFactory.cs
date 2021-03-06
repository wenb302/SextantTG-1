﻿/*********************************************************
 * 
 *        Author: 郭旭
 * Last Modified: 2013-03-05
 *     File Name: DALFactory.cs
 *   Description: 提供静态方法，实例化DAL的工厂类
 * 
 * ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace SextantTG.IDAL
{
    public sealed class DALFactory
    {
        //private static readonly string DAL = "SextantTG.SQLiteDAL"; 
        //private static readonly string BLOG = "SextantTG.SQLiteDAL.BlogDAL";

        private static readonly string DAL = ConfigurationManager.AppSettings["DAL"];
        private static readonly string BLOG_DAL = ConfigurationManager.AppSettings["BLOG_DAL"];
        private static readonly string CITY_DAL = ConfigurationManager.AppSettings["CITY_DAL"];
        private static readonly string COUNTRY_DAL = ConfigurationManager.AppSettings["COUNTRY_DAL"];
        private static readonly string FAVORITE_DAL = ConfigurationManager.AppSettings["FAVORITE_DAL"];
        private static readonly string PERMISSION_DAL = ConfigurationManager.AppSettings["PERMISSION_DAL"];
        private static readonly string PICTURE_DAL = ConfigurationManager.AppSettings["PICTURE_DAL"];
        private static readonly string PICTURECOMM_DAL = ConfigurationManager.AppSettings["PICTURECOMM_DAL"];
        private static readonly string PROVINCE_DAL = ConfigurationManager.AppSettings["PROVINCE_DAL"];
        private static readonly string SIGHTS_DAL = ConfigurationManager.AppSettings["SIGHTS_DAL"];
        private static readonly string SIGHTSCOMM_DAL = ConfigurationManager.AppSettings["SIGHTSCOMM_DAL"];
        private static readonly string SUBTOUR_DAL = ConfigurationManager.AppSettings["SUBTOUR_DAL"];
        private static readonly string TOUR_DAL = ConfigurationManager.AppSettings["TOUR_DAL"];
        private static readonly string TOURCOMM_DAL = ConfigurationManager.AppSettings["TOURCOMM_DAL"];
        private static readonly string USER_DAL = ConfigurationManager.AppSettings["USER_DAL"];
        private static readonly string USERCOMM_DAL = ConfigurationManager.AppSettings["USERCOMM_DAL"];
        private static readonly string DATA_CONTEXT = ConfigurationManager.AppSettings["DATA_CONTEXT"];

        //public static IBlogDAL CreateBlogDAL()
        //{
        //    return (IBlogDAL)Assembly.Load(DAL).CreateInstance(BLOG_DAL);
        //}


        public static T CreateDAL<T>() where T : IBaseDAL
        {
            Type t = typeof(T);
            if (t.Equals(typeof(IBlogDAL))) { return (T)Assembly.Load(DAL).CreateInstance(BLOG_DAL); }
            else if (t.Equals(typeof(IBlogDAL))) { return (T)Assembly.Load(DAL).CreateInstance(BLOG_DAL); }
            else if (t.Equals(typeof(ICityDAL))) { return (T)Assembly.Load(DAL).CreateInstance(CITY_DAL); }
            else if (t.Equals(typeof(ICountryDAL))) { return (T)Assembly.Load(DAL).CreateInstance(COUNTRY_DAL); }
            else if (t.Equals(typeof(IFavoriteDAL))) { return (T)Assembly.Load(DAL).CreateInstance(FAVORITE_DAL); }
            else if (t.Equals(typeof(IPermissionDAL))) { return (T)Assembly.Load(DAL).CreateInstance(PERMISSION_DAL); }
            else if (t.Equals(typeof(IPictureDAL))) { return (T)Assembly.Load(DAL).CreateInstance(PICTURE_DAL); }
            else if (t.Equals(typeof(IPictureCommentDAL))) { return (T)Assembly.Load(DAL).CreateInstance(PICTURECOMM_DAL); }
            else if (t.Equals(typeof(IProvinceDAL))) { return (T)Assembly.Load(DAL).CreateInstance(PROVINCE_DAL); }
            else if (t.Equals(typeof(ISightsDAL))) { return (T)Assembly.Load(DAL).CreateInstance(SIGHTS_DAL); }
            else if (t.Equals(typeof(ISightsCommentDAL))) { return (T)Assembly.Load(DAL).CreateInstance(SIGHTSCOMM_DAL); }
            else if (t.Equals(typeof(ISubTourDAL))) { return (T)Assembly.Load(DAL).CreateInstance(SUBTOUR_DAL); }
            else if (t.Equals(typeof(ITourDAL))) { return (T)Assembly.Load(DAL).CreateInstance(TOUR_DAL); }
            else if (t.Equals(typeof(ITourCommentDAL))) { return (T)Assembly.Load(DAL).CreateInstance(TOURCOMM_DAL); }
            else if (t.Equals(typeof(IUserDAL))) { return (T)Assembly.Load(DAL).CreateInstance(USER_DAL); }
            else if (t.Equals(typeof(IUserCommentDAL))) { return (T)Assembly.Load(DAL).CreateInstance(USERCOMM_DAL); }
            else if (t.Equals(typeof(IDataContext))) { return (T)Assembly.Load(DAL).CreateInstance(DATA_CONTEXT); }
            else { throw new ArgumentException("Type of T is unkown"); }
        }
    }
}
