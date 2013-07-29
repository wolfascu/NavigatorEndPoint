<Query Kind="Expression">
  <Connection>
    <ID>c5440a86-f230-415c-a292-621b615908c0</ID>
    <Persist>true</Persist>
    <Driver Assembly="RavenLinqpadDriver" PublicKeyToken="585b2b0c3c4c2d89">RavenLinqpadDriver.RavenDriver</Driver>
    <CustomAssemblyPathEncoded>&lt;CommonApplicationData&gt;\LINQPad\Drivers\DataContext\4.0\RavenLinqpadDriver (585b2b0c3c4c2d89)\RavenLinqpadDriver.dll</CustomAssemblyPathEncoded>
    <CustomAssemblyPath>C:\ProgramData\LINQPad\Drivers\DataContext\4.0\RavenLinqpadDriver (585b2b0c3c4c2d89)\RavenLinqpadDriver.dll</CustomAssemblyPath>
    <CustomTypeName>RavenLinqpadDriver.RavenContext</CustomTypeName>
    <DriverData>
      <RavenConnectionInfo>{"Name":"FlickrFeed","Url":"http://localhost:8081","DefaultDatabase":"FlickrFeed","ApiKey":null,"ResourceManagerId":null,"Username":null,"Password":null,"AssemblyPaths":null,"Namespaces":null,"IsInDesignMode":false}</RavenConnectionInfo>
    </DriverData>
  </Connection>
  <Reference>D:\Applications\NavigatorDataStore\NavigatorDataStore\NavigatorApplication.Domain\bin\Debug\NavigatorApplication.Domain.dll</Reference>
  <Namespace>NavigatorApplication.Domain.DTO</Namespace>
</Query>

//Get Predicate
var predicate =  Load<Predicate>("Predicates/1");
predicate.Dump();

var feed = from FlickrFeed
