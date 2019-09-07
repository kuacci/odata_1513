using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Xml;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm.Csdl;
using Microsoft.OData.Edm.Validation;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using odata.portal.Models;

namespace odata.portal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute(routeName:"OdataTest",
                routePrefix:null,
                model:GetEdmModel());

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");

            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

            config.EnsureInitialized();
        }


        private static IEdmModel GetEdmModel()
        {
            IEdmModel edmModel = null;
            try
            {
                //Hard coded for demo purpose  

                //Edmx version 4.01 not working - Edm error is generated saying invalid version
                //As per OData - both version 4.0 and 4.01 are accepted - Refer http://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/cs01/schemas/edmx.xsd
                string xml = "<edmx:Edmx xmlns:edmx=\"http://docs.oasis-open.org/odata/ns/edmx\" Version=\"4.01\">\r\n  <edmx:DataServices>\r\n    <Schema xmlns=\"http://docs.oasis-open.org/odata/ns/edm\" Namespace=\"OdataTest\">\r\n      <EntityType Name=\"Dataset1\">\r\n        <Key>\r\n          <PropertyRef Name=\"ID\" />\r\n        </Key>\r\n        <Property Name=\"ID\" Type=\"Edm.Int32\" Nullable=\"false\" />\r\n        <Property Name=\"Number\" Type=\"Edm.Int32\" Nullable=\"false\" />\r\n        <Property Name=\"String\" Type=\"Edm.String\" MaxLength=\"30\" />\r\n      </EntityType>\r\n      <EntityContainer Name=\"Dataset1Entities\">\r\n        <EntitySet Name=\"Dataset1\" EntityType=\"OdataTest.Dataset1\" />\r\n      </EntityContainer>\r\n    </Schema>\r\n  </edmx:DataServices>\r\n</edmx:Edmx>";

                //Edmx version 4.0 is working
                //string xml = "<edmx:Edmx xmlns:edmx=\"http://docs.oasis-open.org/odata/ns/edmx\" Version=\"4.0\">\r\n  <edmx:DataServices>\r\n    <Schema xmlns=\"http://docs.oasis-open.org/odata/ns/edm\" Namespace=\"OdataTest\">\r\n      <EntityType Name=\"Dataset1\">\r\n        <Key>\r\n          <PropertyRef Name=\"ID\" />\r\n        </Key>\r\n        <Property Name=\"ID\" Type=\"Edm.Int32\" Nullable=\"false\" />\r\n        <Property Name=\"Number\" Type=\"Edm.Int32\" Nullable=\"false\" />\r\n        <Property Name=\"String\" Type=\"Edm.String\" MaxLength=\"30\" />\r\n      </EntityType>\r\n      <EntityContainer Name=\"Dataset1Entities\">\r\n        <EntitySet Name=\"Dataset1\" EntityType=\"OdataTest.Dataset1\" />\r\n      </EntityContainer>\r\n    </Schema>\r\n  </edmx:DataServices>\r\n</edmx:Edmx>";


                var stringReader = new StringReader(xml);
                var xmlReader = XmlReader.Create(stringReader);

                IEnumerable<EdmError> edmErrors;
                CsdlReader.TryParse(xmlReader, out edmModel, out edmErrors);
                

                if (edmErrors != null && edmErrors.Count() > 0)
                {
                    edmModel = null;
                }
                if (edmModel != null && edmModel.EntityContainer == null)
                {
                    edmModel = null;
                }
                return edmModel;
            }
            catch (Exception ex)
            {
                return edmModel;
            }
        }
    }
}
