<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="BooksVisualInfoCloud" generation="1" functional="0" release="0" Id="7e21d337-13cb-40d1-8ffa-04040be4d10a" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="BooksVisualInfoCloudGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="BookVisualInfoWeb:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/BooksVisualInfoCloud/BooksVisualInfoCloudGroup/LB:BookVisualInfoWeb:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="BookVisualInfoWeb:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/BooksVisualInfoCloud/BooksVisualInfoCloudGroup/MapBookVisualInfoWeb:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="BookVisualInfoWebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/BooksVisualInfoCloud/BooksVisualInfoCloudGroup/MapBookVisualInfoWebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:BookVisualInfoWeb:Endpoint1">
          <toPorts>
            <inPortMoniker name="/BooksVisualInfoCloud/BooksVisualInfoCloudGroup/BookVisualInfoWeb/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapBookVisualInfoWeb:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/BooksVisualInfoCloud/BooksVisualInfoCloudGroup/BookVisualInfoWeb/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapBookVisualInfoWebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/BooksVisualInfoCloud/BooksVisualInfoCloudGroup/BookVisualInfoWebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="BookVisualInfoWeb" generation="1" functional="0" release="0" software="C:\Users\mhighstead\Documents\GitHub\MacHack\BooksVisualInfoCloud\BooksVisualInfoCloud\csx\Debug\roles\BookVisualInfoWeb" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;BookVisualInfoWeb&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;BookVisualInfoWeb&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/BooksVisualInfoCloud/BooksVisualInfoCloudGroup/BookVisualInfoWebInstances" />
            <sCSPolicyUpdateDomainMoniker name="/BooksVisualInfoCloud/BooksVisualInfoCloudGroup/BookVisualInfoWebUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/BooksVisualInfoCloud/BooksVisualInfoCloudGroup/BookVisualInfoWebFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="BookVisualInfoWebUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="BookVisualInfoWebFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="BookVisualInfoWebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="463f32ca-e61e-4094-9fc8-a62598937eea" ref="Microsoft.RedDog.Contract\ServiceContract\BooksVisualInfoCloudContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="5fefc8d8-4b7c-4097-80ce-900752495e80" ref="Microsoft.RedDog.Contract\Interface\BookVisualInfoWeb:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/BooksVisualInfoCloud/BooksVisualInfoCloudGroup/BookVisualInfoWeb:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>