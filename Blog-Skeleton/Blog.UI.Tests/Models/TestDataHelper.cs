using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Models
{
    public class TestDataHelper
    {
        private static Random random = new Random();

        public static string GenerateEmailAddress()
        {
            return string.Format("velizar.velikov{0}@gmail.com", random.Next(10000, 99999));
        }

    }
}
