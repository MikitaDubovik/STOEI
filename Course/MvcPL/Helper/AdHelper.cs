using System;
using System.Collections.Generic;
using System.Linq;
using MvcPL.Models;

namespace MvcPL.Helper
{
    public static class AdHelper
    {
        public static IEnumerable<ImageViewModel> AdPosts { get; set; }

        public static ImageViewModel GetAd()
        {
            var randomizer = new Random();
            var index = randomizer.Next(AdPosts.Count());
            return AdPosts.ElementAt(index);
        }
    }
}