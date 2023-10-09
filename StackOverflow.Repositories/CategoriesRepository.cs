using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using StackOverFlowProject.DomainModel;

namespace StackOverflow.Repositories
{
    public interface ICategoriesRepository
    {
        void InsertCategory(Category c);
        void UpdateCategory(Category c);
        void DeleteCategory(int cid);
        List<Category> GetCategories();
        List<Category> GetCategoryByCategoryID(int CategoryID);
    }
    public class CategoriesRepository : ICategoriesRepository
    {
        StackOverflowDataDbContext stackOverflowDataDbContext;
        public CategoriesRepository()
        {
            stackOverflowDataDbContext=new StackOverflowDataDbContext();
        }
        public void DeleteCategory(int cid)
        {
        Category category= stackOverflowDataDbContext.Categories.Where(temp=>temp.CategoryID==cid).FirstOrDefault();
        stackOverflowDataDbContext.Categories.Remove(category);

        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();   
            categories=stackOverflowDataDbContext.Categories.ToList();
            return categories;
        }

        public List<Category> GetCategoryByCategoryID(int CategoryID)
        {
            List<Category> categories   =new List<Category>();
            categories=stackOverflowDataDbContext.Categories.Where(temp=>temp.CategoryID==CategoryID).ToList();
            return categories;
        }

        public void InsertCategory(Category c)
        {
           stackOverflowDataDbContext.Categories.Add(c);
            stackOverflowDataDbContext.SaveChanges();
        }

        public void UpdateCategory(Category c)
        {
            Category category=stackOverflowDataDbContext.Categories.Where(temp=>temp.CategoryID==c.CategoryID).FirstOrDefault();
            if (category != null)
            {
                category.CategoryName = c.CategoryName;
                stackOverflowDataDbContext.SaveChanges();
            }
        }
    }
}
