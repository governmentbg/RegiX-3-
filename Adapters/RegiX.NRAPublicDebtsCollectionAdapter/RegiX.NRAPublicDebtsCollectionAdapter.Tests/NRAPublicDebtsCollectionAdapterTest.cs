using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System;
using System.IO;

namespace TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter.Tests
{
    [TestClass]
    public class NRAPublicDebtsCollectionAdapterTest : AdapterTest<TechnoLogica.RegiX.NRAPublicDebtsCollectionAdapter.AdapterService.NRAPublicDebtsCollectionAdapter, INRAPublicDebtsCollectionAdapter>
    {
        //[TestMethod]
        //public void RQ01_SendDataForNewIOAndCollectionTest()
        //{
        //    NRAPublicDebtsCollectionAdapter adapter = new NRAPublicDebtsCollectionAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(SendDataForNewIOAndCollectionResponseType));
        //    SendDataForNewIOAndCollectionRequestType searchCriteria = new SendDataForNewIOAndCollectionRequestType()
        //    {
        //        IO = new NewIOAndCollectionType()
        //        {
        //            ActIssurerID = 1111111110,
        //            SubdivisionID = 123456789,
        //            SubdivisionEIK = "123456789",
        //            TitulID = 1111111110,
        //            EIK = "1111111110",
        //            EIKType = EIKTypeEnumeration.BULSTAT,
        //            DocumentType = "test_type",
        //            DocumentNo = "12354-45",
        //            DocumentSeries = "123K123",
        //            IssueDate = DateTime.Now,
        //            EnforcementDate = DateTime.Now,
        //            EnforceInAdvance = false,
        //            DeedType = "test_deed_type",
        //            DeedID = "123456789",
        //            DeedYear = 2020,
        //            DeedYearSpecified = true
        //        },
        //        Collections = new System.Collections.Generic.List<CollectionType>
        //        {
        //            new CollectionType()
        //            {
        //                CollectibleID = 123456,
        //                BeneficiaryCode = 4534,
        //                DepartmentCode = 15641,
        //                BeneficiaryEIK = "1111111110",
        //                CollectibleType = "coll_type",
        //                PeriodFrom = DateTime.Now.AddMonths(-3),
        //                PeriodTo = DateTime.Now.AddMonths(3),
        //                UnforcedPaymentDate = DateTime.Now.AddMonths(4),
        //                PrincipalAmountInterest = 120,
        //                PrincipalAmountInterestSpecified = true,
        //                InterestAmount = 8,
        //                InterestAmountSpecified = true,
        //                PrincipalAmountNoInterest = 80,
        //                PrincipalAmountNoInterestSpecified = true,
        //                Currency = "BGN",
        //                InterestFromDate = DateTime.Now.AddMonths(4),
        //                InterestType = "interest_type",
        //                Liabilities = new System.Collections.Generic.List<LiabilityRequestType>()
        //                {
        //                    new LiabilityRequestType()
        //                    {
        //                        JointLiabilityEIK = "1111111110",
        //                        JointLiabilityEIKType = EIKTypeEnumeration.BULSTAT,
        //                        JointLiabilityEIKTypeSpecified = true
        //                    }
        //                }

        //            }
        //        }
        //    };
        //    TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters additionalParameters = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //    {
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //        {
        //            AdministrationOId = "2.16.0.55.12.14"
        //        }
        //    };
        //    try
        //    {
        //        var result = adapter.SendDataForNewIOAndCollection(searchCriteria, accessMatrix, additionalParameters);
        //        string xml = result.XmlSerialize();
        //        using (StreamWriter outfile = new StreamWriter("NRAPublicDebtsCollection_SendDataForNewIOAndCollection.xml", false, System.Text.Encoding.UTF8))
        //        {
        //            outfile.Write(xml);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null && ex.InnerException.Message.StartsWith("StatusCode:"))
        //        {
        //            Assert.IsTrue(true);
        //        }
        //        else
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        //[TestMethod]
        //public void RQ02_SendDataForCollectionAdditionToIOTest()
        //{
        //    NRAPublicDebtsCollectionAdapter adapter = new NRAPublicDebtsCollectionAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(SendDataForCollectionAdditionToIOResponseType));
        //    SendDataForCollectionAdditionToIORequestType searchCriteria = new SendDataForCollectionAdditionToIORequestType()
        //    {
        //        IO = new IOCollectionAdditionType()
        //        {
        //            ActIssurerID = 1111111110,
        //            SubdivisionID = 123456789,
        //            SubdivisionEIK = "123456789",
        //            TitulID = 1111111110
        //        },
        //        Collection = new CollectionType
        //        {

        //            CollectibleID = 123456,
        //            BeneficiaryCode = 4534,
        //            DepartmentCode = 15641,
        //            BeneficiaryEIK = "1111111110",
        //            CollectibleType = "coll_type",
        //            PeriodFrom = DateTime.Now.AddMonths(-3),
        //            PeriodTo = DateTime.Now.AddMonths(3),
        //            UnforcedPaymentDate = DateTime.Now.AddMonths(4),
        //            PrincipalAmountInterest = 120,
        //            PrincipalAmountInterestSpecified = true,
        //            InterestAmount = 8,
        //            InterestAmountSpecified = true,
        //            PrincipalAmountNoInterest = 80,
        //            PrincipalAmountNoInterestSpecified = true,
        //            Currency = "BGN",
        //            InterestFromDate = DateTime.Now.AddMonths(4),
        //            InterestType = "interest_type",
        //            Liabilities = new System.Collections.Generic.List<LiabilityRequestType>()
        //                {
        //                    new LiabilityRequestType()
        //                    {
        //                        JointLiabilityEIK = "1111111110",
        //                        JointLiabilityEIKType = EIKTypeEnumeration.BULSTAT,
        //                        JointLiabilityEIKTypeSpecified = true
        //                    }
        //                }
        //        }
        //    };
        //    TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters additionalParameters = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //    {
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //        {
        //            AdministrationOId = "2.16.0.55.12.14"
        //        }
        //    };
        //    try
        //    {
        //        var result = adapter.SendDataForCollectionAdditionToIO(searchCriteria, accessMatrix, additionalParameters);
        //        string xml = result.XmlSerialize();
        //        using (StreamWriter outfile = new StreamWriter("NRAPublicDebtsCollection_SendDataForCollectionAdditionToIO.xml", false, System.Text.Encoding.UTF8))
        //        {
        //            outfile.Write(xml);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null && ex.InnerException.Message.StartsWith("StatusCode:"))
        //        {
        //            Assert.IsTrue(true);
        //        }
        //        else
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        //[TestMethod]
        //public void RQ03_SendDataForCollectionDataCorrectionTest()
        //{
        //    NRAPublicDebtsCollectionAdapter adapter = new NRAPublicDebtsCollectionAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(SendDataForCollectionDataCorrectionResponseType));
        //    SendDataForCollectionDataCorrectionRequestType searchCriteria = new SendDataForCollectionDataCorrectionRequestType()
        //    {
        //        Collection = new CollectionDataCorrectionType()
        //        {
        //            ActIssurerID = 1111111110,
        //            SubdivisionID = 123456789,
        //            SubdivisionEIK = "123456789",
        //            CollectibleID = 123456,
        //            CollectibleType = "coll_type",
        //            PeriodFrom = DateTime.Now.AddMonths(-3),
        //            PeriodTo = DateTime.Now.AddMonths(3),
        //            PrincipalAmountInterest = 120,
        //            PrincipalAmountInterestSpecified = true,
        //            InterestAmount = 8,
        //            InterestAmountSpecified = true,
        //            PrincipalAmountNoInterest = 80,
        //            PrincipalAmountNoInterestSpecified = true,
        //        }
        //    };
        //    TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters additionalParameters = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //    {
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //        {
        //            AdministrationOId = "2.16.0.55.12.14"
        //        }
        //    };
        //    try
        //    {
        //        var result = adapter.SendDataForCollectionDataCorrection(searchCriteria, accessMatrix, additionalParameters);
        //        string xml = result.XmlSerialize();
        //        using (StreamWriter outfile = new StreamWriter("NRAPublicDebtsCollection_SendDataForCollectionDataCorrection.xml", false, System.Text.Encoding.UTF8))
        //        {
        //            outfile.Write(xml);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null && ex.InnerException.Message.StartsWith("StatusCode:"))
        //        {
        //            Assert.IsTrue(true);
        //        }
        //        else
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        //[TestMethod]
        //public void RQ04_SendDataForCollectionAppealToIOTest()
        //{
        //    NRAPublicDebtsCollectionAdapter adapter = new NRAPublicDebtsCollectionAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(SendDataForCollectionAppealToIOResponseType));
        //    SendDataForCollectionAppealToIORequestType searchCriteria = new SendDataForCollectionAppealToIORequestType()
        //    {
        //        Collection = new CollectionAppealToIOType()
        //        {
        //            ActIssurerID = 1111111110,
        //            SubdivisionID = 123456789,
        //            SubdivisionEIK = "123456789",
        //            CollectibleID = 123456,
        //            AppealDocNo = "1234685",
        //            AppealDocDate = DateTime.Now,
        //            AppealStatus = "success",
        //            AppealDate = DateTime.Now,
        //            AppealDateSpecified = true,
        //            EnforcementDate = DateTime.Now,
        //            EnforcementDateSpecified = true
        //        }
        //    };
        //    TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters additionalParameters = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //    {
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //        {
        //            AdministrationOId = "2.16.0.55.12.14"
        //        }
        //    };
        //    try
        //    {
        //        var result = adapter.SendDataForCollectionAppealToIO(searchCriteria, accessMatrix, additionalParameters);
        //        string xml = result.XmlSerialize();
        //        using (StreamWriter outfile = new StreamWriter("NRAPublicDebtsCollection_SendDataForCollectionAppealToIO.xml", false, System.Text.Encoding.UTF8))
        //        {
        //            outfile.Write(xml);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null && ex.InnerException.Message.StartsWith("StatusCode:"))
        //        {
        //            Assert.IsTrue(true);
        //        }
        //        else
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        //[TestMethod]
        //public void RQ05_SendDataForCollectedAmountUpdateTest()
        //{
        //    NRAPublicDebtsCollectionAdapter adapter = new NRAPublicDebtsCollectionAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(SendDataForCollectedAmountUpdateResponseType));
        //    SendDataForCollectedAmountUpdateRequestType searchCriteria = new SendDataForCollectedAmountUpdateRequestType()
        //    {
        //        Payment =
        //            new PaymentType()
        //            {
        //                ActIssurerID = 1111111110,
        //                SubdivisionID = 123456789,
        //                SubdivisionEIK = "123456789",
        //                CollectibleID = 123456,
        //                PaymentDate = DateTime.Now.AddDays(15),
        //                TotalAmount = 580,
        //                PrincipalAmountPaid = 450,
        //                InterestAmountPaid = 4,
        //                InterestAmountPaidSpecified = true,
        //                Currency = "BGN",
        //                OutstandingAmount = 130
        //            }
        //    };
        //    TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters additionalParameters = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //    {
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //        {
        //            AdministrationOId = "2.16.0.55.12.14"
        //        }
        //    };
        //    try
        //    {
        //        var result = adapter.SendDataForCollectedAmountUpdate(searchCriteria, accessMatrix, additionalParameters);
        //        string xml = result.XmlSerialize();
        //        using (StreamWriter outfile = new StreamWriter("NRAPublicDebtsCollection_SendDataForCollectedAmountUpdate.xml", false, System.Text.Encoding.UTF8))
        //        {
        //            outfile.Write(xml);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null && ex.InnerException.Message.StartsWith("StatusCode:"))
        //        {
        //            Assert.IsTrue(true);
        //        }
        //        else
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        //[TestMethod]
        //public void RQ06_SendDataForCollectionProceedingsTerminationTest()
        //{
        //    NRAPublicDebtsCollectionAdapter adapter = new NRAPublicDebtsCollectionAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(SendDataForCollectionProceedingsTerminationResponseType));
        //    SendDataForCollectionProceedingsTerminationRequestType searchCriteria = new SendDataForCollectionProceedingsTerminationRequestType()
        //    {
        //        Collection = new CollectionProceedingsType()
        //        {
        //            ActIssurerID = 1111111110,
        //            SubdivisionID = 123456789,
        //            SubdivisionEIK = "123456789",
        //            CollectibleID = 123456,
        //            CancelDocNo = "56456456",
        //            CancelDocDate = DateTime.Now.AddYears(-2),
        //            CancelDate = DateTime.Now.AddYears(-1),
        //            CancelDateSpecified = true,
        //            CancelDocDateSpecified = true,
        //            CollectibleReason = "test_reason"
        //        }
        //    };
        //    TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters additionalParameters = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //    {
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //        {
        //            AdministrationOId = "2.16.0.55.12.14"
        //        }
        //    };
        //    try
        //    {
        //        var result = adapter.SendDataForCollectionProceedingsTermination(searchCriteria, accessMatrix, additionalParameters);
        //        string xml = result.XmlSerialize();
        //        using (StreamWriter outfile = new StreamWriter("NRAPublicDebtsCollection_SendDataForCollectionProceedingsTermination.xml", false, System.Text.Encoding.UTF8))
        //        {
        //            outfile.Write(xml);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null && ex.InnerException.Message.StartsWith("StatusCode:"))
        //        {
        //            Assert.IsTrue(true);
        //        }
        //        else
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        //[TestMethod]
        //public void RQ09_GetActualStateForIOOrCollectionTest()
        //{
        //    NRAPublicDebtsCollectionAdapter adapter = new NRAPublicDebtsCollectionAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(GetActualStateForIOOrCollectionResponseType));
        //    GetActualStateForIOOrCollectionRequestType searchCriteria = new GetActualStateForIOOrCollectionRequestType()
        //    {
        //        ActIssurerID = 1111111110,
        //        SubdivisionID = 123456789,
        //        TitulID = 1521651544,
        //        TitulIDSpecified = true,
        //        CollectibleIDSpecified = true,
        //        CollectibleID = 123456,

        //    };
        //    TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters additionalParameters = new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters()
        //    {
        //        CallContext = new TechnoLogica.RegiX.Common.TransportObject.CallContext()
        //        {
        //            AdministrationOId = "2.16.0.55.12.14"
        //        }
        //    };
        //    try
        //    {
        //        var result = adapter.GetActualStateForIOOrCollection(searchCriteria, accessMatrix, additionalParameters);
        //        string xml = result.XmlSerialize();
        //        using (StreamWriter outfile = new StreamWriter("NRAPublicDebtsCollection_GetActualStateForIOOrCollection.xml", false, System.Text.Encoding.UTF8))
        //        {
        //            outfile.Write(xml);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null && ex.InnerException.Message.StartsWith("StatusCode:"))
        //        {
        //            Assert.IsTrue(true);
        //        }
        //        else
        //        {
        //            throw ex;
        //        }
        //    }
        //}

    }
}
