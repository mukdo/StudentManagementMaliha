using StudentManagementTest.Data;

using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementTest.Framework
{
    public class BlogUnitOfWork : UnitOfWork, IBlogUnitOfWork
    {
       // public ICommentRepository CommentRepository { get; set; }

        public BlogUnitOfWork( SMDbContext frameworkContext )// , ICategoryRepository categoryRepository, 
                                                                 // ICommentRepository  commentRepository,
                                                                //  IBlogComposeRepository composeRepository)
            :base(frameworkContext)
        {
            //CategoryRepository = categoryRepository;
         
        }
    }
}
