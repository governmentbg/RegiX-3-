using System;

namespace Infosys.RegiX.CRCAdapter.CRC
{
    public class CRCResponse
    {
        public Int64 uid { get; set; }
        public String code { get; set; }
        public String status { get; set; }
        public String ip { get; set; }
        public String city { get; set; }
        public String region { get; set; }
        public String provider { get; set; }
        public String networkType { get; set; }
        public String platform { get; set; }
        public String model { get; set; }
        public String hostname { get; set; }
        public String geoLocation { get; set; }
        public String testUuid { get; set; }
        public String clientUuid { get; set; }
        public String openTestUuid { get; set; }
        public Int32 testDuration { get; set; }
        public Int64? speedUpload { get; set; }
        public Int64? speedDownload { get; set; }
        public Int64? ping { get; set; }
        public Int32? signalStrength { get; set; }
        public Int16? packetLoss { get; set; }
        public String modelVersion { get; set; }
        public String blockedPorts { get; set; }
        public string time { get; set; }
        public String loopModeLoopUid { get; set; }
        public Int32? loopModeUid { get; set; }
        public String networkTypeGroup { get; set; }
        public String imei{ get; set; }
    }
}
