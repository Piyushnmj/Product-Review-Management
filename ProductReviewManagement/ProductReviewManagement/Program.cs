namespace ProductReviewManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Review Management Program");

            //UC1
            List<ProductReview> objProductReviewList = new List<ProductReview>()
            {
                new ProductReview() {ProductID = 1, UserID= 1, Rating=5, Review="Good", isLike=true},
                new ProductReview() {ProductID = 2, UserID= 1, Rating=4, Review="Good", isLike=true},
                new ProductReview() {ProductID = 3, UserID= 2, Rating=4.5, Review="Good", isLike=true},
                new ProductReview() {ProductID = 4, UserID= 2, Rating=3, Review="Nice", isLike=true},
                new ProductReview() {ProductID = 5, UserID= 3, Rating=3.5, Review="Nice", isLike=true},
                new ProductReview() {ProductID = 6, UserID= 4, Rating=3.5, Review="Nice", isLike=true},
                new ProductReview() {ProductID = 7, UserID= 5, Rating=1, Review="Bad", isLike=false},
                new ProductReview() {ProductID = 8, UserID= 4, Rating=2.5, Review="Bad", isLike=false},
                new ProductReview() {ProductID = 9, UserID= 6, Rating=1, Review="Bad", isLike=false},
                new ProductReview() {ProductID = 10, UserID= 3, Rating=1, Review="Bad", isLike=false},
            };

            Console.WriteLine("\n**********All Product Reviews**********\n");
            foreach (var list in objProductReviewList)
            {
                Console.WriteLine($"ProductID : {list.ProductID}\n" +
                                  $"UserID    : {list.UserID}\n" +
                                  $"Rating    : {list.Rating}\n" +
                                  $"Review    : {list.Review}\n" +
                                  $"isLike    : {list.isLike}\n");
            }

            Management objManagement = new Management();
            objManagement.TopRecords(objProductReviewList);
            objManagement.SelectedRecords(objProductReviewList);
            objManagement.CountOfReviewForEachProductID(objProductReviewList);
            objManagement.RetriveOnlyProductIdAndReview(objProductReviewList);
            objManagement.SkipTopFiveRecords(objProductReviewList);
            objManagement.CreateProductReviewTable(objProductReviewList);
            objManagement.AverageRatingForEachProductID(objProductReviewList);
        }
    }
}