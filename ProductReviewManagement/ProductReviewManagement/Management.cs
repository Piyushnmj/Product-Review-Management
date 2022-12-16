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

        /// <summary>
        /// UC3
        /// </summary>
        /// <param name="objProductReviewList">The object product review list.</param>
        public void SelectedRecords(List<ProductReview> objProductReviewList)
        {
            var recordedData = from productReviews in objProductReviewList
                               where (productReviews.ProductID == 1 || productReviews.ProductID == 4 || productReviews.ProductID == 9) &&
                               productReviews.Rating > 3
                               select productReviews;

            Console.WriteLine("**********Selected Reviews**********\n");
            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductID : {list.ProductID}\n" +
                                  $"UserID    : {list.UserID}\n" +
                                  $"Rating    : {list.Rating}\n" +
                                  $"Review    : {list.Review}\n" +
                                  $"isLike    : {list.isLike}\n");
            }
        }

        public void CountOfReviewForEachProductID(List<ProductReview> objProductReviewList)
        {
            var recordedData = (from productReviews in objProductReviewList
                              group productReviews by productReviews.ProductID into product
                              select new { ProductID = product.Key, Count = product.Count() });

            Console.WriteLine("**********Count Of Review For Each ProductID**********\n");
            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductID : {list.ProductID}\n" +
                                  $"Count     : {list.Count}\n");
            }
        }
    }
}
