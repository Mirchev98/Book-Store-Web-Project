using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Common
{
    public static class DataConstants
    {
        //Author Data Constants
        public const int AuthorMinNameLen = 5;
        public const int AuthorMaxNameLen = 50;

        public const int AuthorBiographyMinLen = 5;
        public const int AuthorBiographyMaxLen = 10000;

        //Book Data Constants
        public const int BookTitleMinLen = 5;
        public const int BookTitleMaxLen = 100;

        public const int BookDesMinLen = 10;
        public const int BookDesMaxLen = 2000;

        //Review Data Constants
        public const int ReviewMinLen = 2;
        public const int ReviewMaxLen = 150;
        public const int ReviewStarsMin = 1;
        public const int ReviewStarsMax = 5;

        //Category Data Constants
        public const int CategoryMinNameLen = 3;
        public const int CategoryMaxNameLen = 20;

        //General Constants
        public const int PhotoUrlMaxLen = 2050;

        //Admin Constraints
        public const string AdminRoleName = "Admin";
        public const string AdminEmail = "admin@admin.com";
        public const string AdminPass = "12345a";
    }
}
