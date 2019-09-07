using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using odata.portal.Models;


namespace odata.portal.Controllers
{
    public class TestController : ODataController
    {

        [EnableQuery]
        public IHttpActionResult GetTestResult()
        {
            try
            {

                //product data 
                string rawJson = "[{\"Name\":\"Paper\",\"ProductID\":\"001\",\"Amount\":\"100\",\"TaxRate\":\"2\",\"NumberOfProducts\":\"10\",\"Category\":{\"CategoryName\":\"Non-Food\",\"Country\":\"USA\"}},{\"Name\":\"Pen\",\"ProductID\":\"002\",\"Amount\":\"200\",\"TaxRate\":\"2\",\"NumberOfProducts\":\"12\",\"Category\":{\"CategoryName\":\"Non-Food\",\"Country\":\"USA\"}},{\"Name\":\"Tea\",\"ProductID\":\"003\",\"Amount\":\"250\",\"TaxRate\":\"2\",\"NumberOfProducts\":\"6\",\"Category\":{\"CategoryName\":\"Food\",\"Country\":\"USA\"}},{\"Name\":\"Sugar\",\"ProductID\":\"004\",\"Amount\":\"300\",\"TaxRate\":\"4\",\"NumberOfProducts\":\"4\",\"Category\":{\"CategoryName\":\"Food\",\"Country\":\"New Zealand\"}},{\"Name\":\"Coffee\",\"ProductID\":\"005\",\"Amount\":\"500\",\"TaxRate\":\"4\",\"NumberOfProducts\":\"8\",\"Category\":{\"CategoryName\":\"Food\",\"Country\":\"New Zealand\"}}]";
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<Product> productData = serializer.Deserialize<List<Product>>(rawJson); //list of product values
                                                                                            //for time being the data is hard coded

                return Ok(productData.AsQueryable());
            } catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}