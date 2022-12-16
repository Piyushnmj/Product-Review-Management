using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class Management
    {
        public readonly DataTable dataTable = new DataTable();

        /// <summary>
        /// UC2
        /// </summary>
        /// <param name="reviews">The reviews.</param>
        /// <returns></returns>
        public void TopRecords(List<ProductReview> objProductReviewList)
        {
            var recordedData = (from productReviews in objProductReviewList
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);

            Console.WriteLine("**********Top 3 Reviews**********\n");
            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductID : {list.ProductID}\n" +
                                  $"UserID    : {list.UserID}\n" +
                                  $"Rating    : {list.Rating}\n" +
                                  $"Review    : {list.Review}\n" +
                                  $"isLike    : {list.isLike}\n");
            }
        }
    }
}
