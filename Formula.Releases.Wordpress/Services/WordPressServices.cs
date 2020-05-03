using Formula.Releases.Domain;
using System.Collections.Generic;
using System.Numerics;

namespace Formula.Releases.Wordpress.Services
{
    public class WordPressServices
    {
        public List<string> GetPosts()
        {
            return FilterPosts(null);
        }

        public void Post(Release release)
        {

        }

        private List<string> FilterPosts(List<string> list)
        {
            List<string> filtered = new List<string>();

            foreach (var item in list)
            {
                if (int.Parse(item[1].ToString()) >= 4)
                    filtered.Add(item);
            }

            return filtered;
        }
    }
}
