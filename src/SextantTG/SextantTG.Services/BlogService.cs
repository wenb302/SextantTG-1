﻿using SextantTG.IDAL;
using SextantTG.IServices;
using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;


namespace SextantTG.Services
{
    public class BlogService : IBlogService
    {
        private IDataContext dataContext = null;
        private IBlogDAL blogDal = null;
        private IPictureDAL picDal = null;

        public BlogService()
        {
            dataContext = DALFactory.CreateDAL<IDataContext>();
            blogDal = DALFactory.CreateDAL<IBlogDAL>();
            picDal = DALFactory.CreateDAL<IPictureDAL>();
        }

        public List<Blog> GetBlogsForUser(string userId)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogsForSights(string sightsId)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogsForSubTour(string tourId, string subTourId)
        {
            throw new NotImplementedException();
        }

        public bool CreateBlog(Blog blog, List<Picture> pics, string userId, out string message)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBlog(Blog blog, List<Picture> pics, string userId, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        blogDal.UpdateBlog(blog, trans);
                        foreach (Picture pic in pics)
                        {
                            picDal.InsertPicture(pic, trans);
                        }

                        trans.Commit();
                        message = "";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        message = ex.Message;
                        return false;
                    }
                }
            }
        }

        public bool DeleteBlog(string blogId, bool deletePictures, bool deleteComments, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        blogDal.DeleteBlogById(blogId, trans);
                        trans.Commit();
                        message = "";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        message = ex.Message;
                        return false;
                    }
                }
            }
        }

        public void Dispose()
        {
            this.dataContext.Dispose();
            this.blogDal.Dispose();
            this.picDal.Dispose();

            this.dataContext = null;
            this.blogDal = null;
            this.picDal = null;
        }
    }
}
