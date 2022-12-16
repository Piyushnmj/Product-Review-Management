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

        /// <summary>
        /// UC4
        /// </summary>
        /// <param name="objProductReviewList">The object product review list.</param>
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

        /// <summary>
        /// UC5, UC7
        /// </summary>
        /// <param name="objProductReviewList">The object product review list.</param>
        public void RetriveOnlyProductIdAndReview(List<ProductReview> objProductReviewList)
        {
            var recordedData = (from productReviews in objProductReviewList select (productReviews.ProductID, productReviews.Review));
            Console.WriteLine("**********ProductId And Review**********\n");
            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductID : {list.ProductID}\n" +
                                  $"Review    : {list.Review}\n");
            }
        }

        /// <summary>
        /// UC6
        /// </summary>
        /// <param name="objProductReviewList">The object product review list.</param>
        public void SkipTopFiveRecords(List<ProductReview> objProductReviewList)
        {
            var recordedData = (from productReviews in objProductReviewList orderby productReviews.ProductID ascending select productReviews).Skip(5);
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

        /// <summary>
        /// UC8
        /// </summary>
        /// <param name="objProductReviewList">The object product review list.</param>
        public void CreateProductReviewTable(List<ProductReview> objProductReviewList)
        {
            dataTable.Columns.Add("ProductID", typeof(Int32));
            dataTable.Columns.Add("UserID", typeof(Int32));
            dataTable.Columns.Add("Rating", typeof(double));
            dataTable.Columns.Add("Review", typeof(string));
            dataTable.Columns.Add("isLike", typeof(bool));
            Console.WriteLine("**********Product Review Table**********\n");
            foreach (ProductReview product in objProductReviewList)
            {
                dataTable.Rows.Add(product.ProductID, product.UserID, product.Rating, product.Review, product.isLike);
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Console.WriteLine($"ProductID : {dataRow[0]}\n" +
                                  $"UserID    : {dataRow[1]}\n" +
                                  $"Rating    : {dataRow[2]}\n" +
                                  $"Review    : {dataRow[3]}\n" +
                                  $"isLike    : {dataRow[4]}\n");
            }
        }

        /// <summary>
        /// UC10
        /// </summary>
        /// <param name="objProductReviewList">The object product review list.</param>
        public void AverageRatingForEachProductID(List<ProductReview> objProductReviewList)
        {
            var recordedData = (from productReviews in objProductReviewList group productReviews by (productReviews.ProductID) into product select new { ProductID = product.Key, AverageRating = product.Average(Key => Key.Rating) });
            Console.WriteLine("**********Average Rating**********\n");
            foreach (var list in recordedData)
            {
                Console.WriteLine($"ProductID      : {list.ProductID}\n" +
                                  $"Average Rating : {list.AverageRating}\n");
            }
        }

        /// <summary>
        /// UC11
        /// </summary>
        /// <param name="objProductReviewList">The object product review list.</param>
        public void RetrieveReviewMessageNice(List<ProductReview> objProductReviewList)
        {
            var recordedData = (from productReviews in objProductReviewList where productReviews.Review.Contains("Nice") select productReviews);
            Console.WriteLine("**********Nice Review**********\n");
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
        /// UC12
        /// </summary>
        /// <param name="objProductReviewList">The object product review list.</param>
        public void RetriveRecordsWithUserID10AndOrderByRating(List<ProductReview> objProductReviewList)
        {
            var recordedData = (from productReviews in objProductReviewList orderby productReviews.Rating descending where productReviews.UserID == 10 select productReviews);
            Console.WriteLine("\n**********All Records With UserId = 10 and order By Rating**********\n");
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
