using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class CommentStatistic
    {
        public int countGoodComment;
        public int countNormalComment;
        public int countBadComment;
        public int countClassified;
        public int countNonClassify;
        public int countTotal;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="listComment">list of comments</param>
        public CommentStatistic(List<Comment> listComment)
        {
            countGoodComment = 0;
            countNormalComment = 0;
            countBadComment = 0;
            countClassified = 0;
            countNonClassify = 0;
            countTotal = 0;
            if(listComment.Count > 0)
            {
                foreach (Models.Comment comment in listComment)
                {
                    switch (comment.status)
                    {
                        case 1:
                            countGoodComment += 1;
                            countClassified += 1;
                            break;
                        case 2:
                            countBadComment += 1;
                            countClassified += 1;
                            break;
                        case 3:
                            countNormalComment += 1;
                            countClassified += 1;
                            break;
                        default:
                            countNonClassify += 1;
                            break;
                    }
                }
                countTotal = listComment.Count;
            }
        }


    }


}
