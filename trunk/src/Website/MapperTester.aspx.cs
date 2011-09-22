using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class MapperTester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetProduct(object sender, EventArgs e)
        {
            var mapperTester = new CSUtilities.Samples.Queries.MapperTester();
            var product = mapperTester.GetProduct("TestCatalog", ProductId.Text);
        }
    }
}