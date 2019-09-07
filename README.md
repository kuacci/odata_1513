# odata_1513
This is repo for odata.net issue 1513. 
* <https://github.com/OData/odata.net/issues/1513>

Please rebuild project after cloned and pulled down. Browse http://localhost:64019/$metadata, then you will see the output like below:
```xml
<?xml version="1.0" encoding="ISO-8859-1"?>
<edmx:Edmx xmlns:edmx="http://docs.oasis-open.org/odata/ns/edmx" Version="4.0">
<edmx:DataServices>
<Schema xmlns="http://docs.oasis-open.org/odata/ns/edm" Namespace="OdataTest">
<EntityType Name="Dataset1">
<Key>
<PropertyRef Name="ID"/>
</Key>
<Property Name="ID" Nullable="false" Type="Edm.Int32"/>
<Property Name="Number" Nullable="false" Type="Edm.Int32"/>
<Property Name="String" Type="Edm.String" MaxLength="30"/>
</EntityType>
<EntityContainer Name="Dataset1Entities">
<EntitySet Name="Dataset1" EntityType="OdataTest.Dataset1"/>
</EntityContainer>
</Schema>
</edmx:DataServices>
</edmx:Edmx>
```
