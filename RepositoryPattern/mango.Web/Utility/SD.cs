namespace mango.Web.Utility
{
    public class SD
    {
        public static string CouponApiBase { get; set; }
        public static string ProductApiBase {  get; set; }
        public static string AuthApiBase { get; set; }
        public const string RoleAdmin = "ADMIN";
        public const string RoleCutomer = "CUSTOMER";
        public const string TockenCookie = "JWTTocken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE

        }
    }
}
