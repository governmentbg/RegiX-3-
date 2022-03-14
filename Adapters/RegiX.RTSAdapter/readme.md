# RegiX.RTSAdapter

MetadataUtils need to be updated to create xmls with timeStamp

<!-- RTSAdapter
Expected:
<<RoutesSearch xmlns="http://egov.bg/RegiX/MTITC/Rts"><ForwardFirstStopMunicipality>Столична</ForwardFirstStopMunicipality><BackwardFirstStopMunicipality>Долна Баня</BackwardFirstStopMunicipality><ForwardTime>00:00:00.0</ForwardTime><BackwardTime>00:00:00.0</BackwardTime><Seasonal><IsSeasonal>false</IsSeasonal></Seasonal><Schedule><IsDaily>false</IsDaily><Monday>false</Monday><Tuesday>false</Tuesday><Wednesday>false</Wednesday><Thursday>false</Thursday><Friday>false</Friday><Saturday>false</Saturday><Sunday>false</Sunday><BeforeHoliday>false</BeforeHoliday><Holiday>false</Holiday></Schedule></RoutesSearch>>.
 Actual:
<?xml version="1.0" encoding="UTF-8"?>
<RoutesSearch xmlns="http://egov.bg/RegiX/MTITC/Rts">
   <ForwardFirstStopMunicipality>Столична</ForwardFirstStopMunicipality>
   <BackwardFirstStopMunicipality>Долна Баня</BackwardFirstStopMunicipality>
   <ForwardTime>0001-01-01</ForwardTime>
   <BackwardTime>0001-01-01</BackwardTime>
   <Seasonal>
      <IsSeasonal>false</IsSeasonal>
      <SeasonStartDay />
      <SeasonStartMonth />
      <SeasonEndDay />
      <SeasonEndMonth />
   </Seasonal>
   <Schedule>
      <IsDaily>false</IsDaily>
      <Monday>false</Monday>
      <Tuesday>false</Tuesday>
      <Wednesday>false</Wednesday>
      <Thursday>false</Thursday>
      <Friday>false</Friday>
      <Saturday>false</Saturday>
      <Sunday>false</Sunday>
      <BeforeHoliday>false</BeforeHoliday>
      <Holiday>false</Holiday>
   </Schedule>
</RoutesSearch> -->
