﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.AVTRAdapter.XMLSchemas
{
    public static class Constants
    {
        public static Dictionary<string, string> SubDeedFieldsPropertiesDict =
         new Dictionary<string, string>()
         {
                {"00010","UIC"},
                {"00011","NumberNationalRegister"},
                {"00012","NumberNationalRegister1b"},
                {"00020","Company"},
                {"00030","LegalForm"},
                {"00040","Transliteration"},
                {"00050","Seat"},
                {"00051","SeatForCorrespondence"},
                {"00060","SubjectOfActivity"},
                {"00061","SubjectOfActivityNKID"},
                {"00070","Managers"},
                {"00071","AssignedManagers"},
                {"00080","WayOfManagement"},
                {"00090","ChairMan"},
                {"00100","Representatives"},
                {"00101","Representatives101"},
                {"00102","Representatives102"},
                {"00110","WayOfRepresentation"},
                {"00120","BoardOfDirectors"},
                {"00121","BoardOfManagers3"},
                {"00122","AdministrativeBoard"},
                {"00123","AdministrativeBoardSupporters"},
                {"00130","BoardOfManagers"},
                {"00131","BoardOfManagersSupporters"},
                {"00132","BoardOfManagers2"},
                {"00133","LeadingBoard"},
                {"00134","BoardOfManagersSupporters2"},
                {"00140","SupervisingBoard"},
                {"00142","SupervisingBoard2"},
                {"00143","SupervisingBoardSupporters"},
                {"00150","ControllingBoard"},
                {"00151","ControllingBoardSupporters"},
                {"00160","TermsOfPartnership"},
                {"00161","TermOfExisting"},
                {"00162","TermOfExistingEUIE"},
                {"00170","SpecialConditions"},
                {"00180","PhysicalPersonTrader"},
                {"00190","Partners"},
                {"00200","UnlimitedLiabilityPartners"},
                {"00201","UnlimitedLiabilityPartnersEUIE"},
                {"00210","LimitedLiabilityPartners"},
                {"00220","ForeignTraders"},
                {"00221","DiscontinuanceOfForeignTrader"},
                {"00222","InsolvenciesOfForeignTrader"},
                {"00223","EuropeanEconomicInterestGrouping"},
                {"00224","DiscontinuanceOfTheEUIE"},
                {"00225","InsolvenciesOfEUIE"},
                {"00230","SoleCapitalOwner"},
                {"00231","Owner"},
                {"00232","EuropeanHoldingCompanysAsShareholders"},
                {"00240","ShareTransfers"},
                {"00241","HiddenNonMonetaryDeposit"},
                {"00250","SharePaymentResponsibility"},
                {"00251","ConcededEstateValue"},
                {"00260","CessationOfTrade"},
                {"00270","AddemptionOfTrader"},
                {"00271","AddemptionOfTraderSeatChange"},
                {"00273","AddemptionOfTraderEraseForeignTrader"},
                {"00280","ClosureBranchOfForeignTrader"},
                {"00281","AddemptionOfEUIE"},
                {"00290","PersonConcerned"},
                {"00291","EntryDate"},
                {"00300","TermsOfProtection"},
                {"00310","Funds"},
                {"00311","Shares"},
                {"00312","MinimumAmount"},
                {"00320","DepositedFunds"},
                {"00330","NonMonetaryDeposits"},
                {"00340","BuyBackDecision"},
                {"00410","Procurators"},
                {"00420","SepcialPowers"},
                {"00430","WayOfRepresentation43"},
                {"00440","EraseProcura"},
                {"00510","BranchSeat"},
                {"00511","BranchFirm"},
                {"00512","BranchIdentifier"},
                {"00520","BranchSubjectOfActivity"},
                {"00521","MainActivityNKID"},
                {"00530","BranchManagers"},
                {"00540","VolumeOfRepresentationPower"},
                {"00541","VolumeOfRepresentationPower541"},
                {"00550","BranchClosure"},
                {"00600","DivisionsOfEuropeanUnification"},
                {"00700","WayOfEstablishingEuropeanCompany"},
                {"00701","WayOfEstablishingEuropeanCooperativeSociety"},
                {"00710","SeatChange"},
                {"01010","LimitSubjectOfActivity101"},
                {"01020","License102"},
                {"01021","PutUnderParticularSupervision"},
                {"01030","Authorization"},
                {"01040","Suquestrators104"},
                {"01050","OtherCircumstances105"},
                {"01060","LimitSubjectOfActivity106"},
                {"01070","ManageOrganizationAssets107"},
                {"01080","License108"},
                {"01090","Suquestrators109"},
                {"01100","OtherCircumstances110"},
                {"01110","LimitSubjectOfActivity111"},
                {"01120","ManageOrganizationAssets112"},
                {"01130","Suquestrators113"},
                {"01140","OtherCircumstances114"},
                {"01150","RefusalOfLicense"},
                {"01160","SpecialManager"},
                {"01170","OtherCircumstances117"},
                {"02000","PledgeDDIdentifier"},
                {"02010","Pledgors"},
                {"02030","SecuredClaimDebtors"},
                {"02050","PledgeCreditors"},
                {"02070","SecuredClaimReason"},
                {"02080","SecuredClaimSubject"},
                {"02090","SecuredClaimAmount"},
                {"02100","SecuredClaimInterests"},
                {"02110","SecuredClaimDelayInterests"},
                {"02120","PledgeMoney"},
                {"02130","PledgePropertyDescription"},
                {"02140","PledgePropertyPrice"},
                {"02150","ModalityDate"},
                {"02160","ModalityCondition"},
                {"02170","PledgeExecutionClaim"},
                {"02180","Partners218"},
                {"02190","PledgeExecutionDepozitar"},
                {"02200","Depozitar"},
                {"02210","DepozitarDistraintRemove"},
                {"02220","StopOfExecutionSize"},
                {"02230","StopOfExecutionProperty"},
                {"02240","PledgeRenewDate"},
                {"02250","PledgeAddemption"},
                {"03000","ForfeitCompanyIdentifier"},
                {"03010","DebtorOverSecureClaims"},
                {"03030","AtPawnCreditors"},
                {"03050","Reason"},
                {"03060","Object306"},
                {"03070","Size307"},
                {"03080","Interest"},
                {"03090","InterestAndDefaultForDelay"},
                {"03100","Size310"},
                {"03110","Description"},
                {"03120","Price312"},
                {"03130","Term"},
                {"03140","Circumstances"},
                {"03150","PartOfClaimwhatIsSeek"},
                {"03160","PropertyOverExecution"},
                {"03170","Depositor"},
                {"03180","InvitationForAppointingOfManager"},
                {"03190","ManagerOfTradeEnterprise"},
                {"03200","RestoringManagementRight"},
                {"03210","DistraintData"},
                {"03220","RaiseDistraint"},
                {"03230","Size323"},
                {"03240","StopExecutionOverProperty"},
                {"03250","EraseDistraint"},
                {"03251","PartialEraseDistraint"},
                {"03260","DateOfRenewingDistraint"},
                {"04000","DistraintIdentifier"},
                {"04010","Distraints"},
                {"04030","Reason403"},
                {"04040","Size404"},
                {"04041","MoratoryRate"},
                {"04050","Interests"},
                {"04060","Descriptions"},
                {"04080","LiftingDistraint"},
                {"04090","Size409"},
                {"04100","StopExecutionOverProperty410"},
                {"05010","TermsOfLiquidation"},
                {"05020","Liquidators"},
                {"05030","Representative503"},
                {"05040","ContinuingTradeActivity"},
                {"05050","StopOfLiquidation"},
                {"05300","OffshoreIdentifier"},
                {"05310","OffshoreCompany"},
                {"05320","OffshoreTransliteration"},
                {"05330","OffshoreSeat"},
                {"005331","OffshoreSeatForCorrespondence"},
                {"05340","OffshoreRepresentatives"},
                {"05350","OffshoreWayOfRepresentation"},
                {"05360","OffshoreSpecialConditions"},
                {"05400","CircumstanceArticle4"},
                {"05500","ActualOwners"},
                {"05510","EraseActualOwner"},
                {"05060","ResumeOfLiquidation"},
                {"06000","TransferringTypeOfTradeEnterprise"},
                {"06010","TransferringEnterprise"},
                {"06020","AcquisitionEnterprises"},
                {"07010","FormOfTransforming701"},
                {"07020","TransformingCompanys"},
                {"07021","TransformingCompanys2"},
                {"07030","Successors703"},
                {"07040","Branches704"},
                {"07050","StoppingEntry"},
                {"07060","NumberApplication"},
                {"08010","FormOfTransforming801"},
                {"08011","FormOfTransforming801a"},
                {"08020","ReorganizeCoOperatives"},
                {"08021","ReorganizeCoOperatives2"},
                {"08030","Successors803"},
                {"08040","Branches804"},
                {"09010","OpenProccedings"},
                {"09012","OpenProccedingsSecIns"},
                {"09013","OpenProccedingsThirdIns"},
                {"09020","InsolvencyDate"},
                {"09021","InsolvencyData"},
                {"09022","InsolvencyDataSecIns"},
                {"09023","InsolvencyDataThirdIns"},
                {"09030","DebtorBodies"},
                {"09032","DebtorBodiesSecIns"},
                {"09033","DebtorBodiesThirdIns"},
                {"09040","HoldProceedings"},
                {"09042","HoldProceedingsSecIns"},
                {"09043","HoldProceedingsThirdIns"},
                {"09050","ReOpenProceedings"},
                {"09052","ReOpenProceedingsSecIns"},
                {"09053","ReOpenProceedingsThirdIns"},
                {"09060","SuspendProceedings"},
                {"09062","SuspendProceedingsSecIns"},
                {"09063","SuspendProceedingsThirdIns"},
                {"09061","TraverseOfRecoverPlan"},
                {"09064","TraverseOfRecoverPlanSecIns"},
                {"09065","TraverseOfRecoverPlanThirdIns"},
                {"09070","RestrictDebtorOrderPower"},
                {"09072","RestrictDebtorOrderPowerSecIns"},
                {"09073","RestrictDebtorOrderPowerThirdIns"},
                {"09080","GeneralSeizure"},
                {"09082","GeneralSeizureSecIns"},
                {"09083","GeneralSeizureThirdIns"},
                {"09090","CashIn"},
                {"09092","CashInSecIns"},
                {"09093","CashInThirdIns"},
                {"09100","DeclareBankrupt"},
                {"09102","DeclareBankruptSecIns"},
                {"09103","DeclareBankruptThirdIns"},
                {"09110","Reinstatements"},
                {"09112","ReinstatementsSecIns"},
                {"09113","ReinstatementsThirdIns"},
                {"09111","ReinstatementsDisallowPetition"},
                {"09114","ReinstatementsDisallowPetitionSecIns"},
                {"09115","ReinstatementsDisallowPetitionThirdIns"},
                {"09120","Trustees"},
                {"09122","TrusteesSecIns"},
                {"09123","TrusteesThirdIns"},
                {"09150","SupervisionBody"},
                {"09151","SupervisionBodyFull"},
                {"09152","SupervisionBodyFullSecIns"},
                {"09153","SupervisionBodyFullThirdIns"},
                {"10019A","StatementsA"},
                {"10019B","StatementsB"},
                {"10019C","StatementsC"},
                {"10019D","StatementsD"},
                {"10019E","StatementsE"},
                {"10019F","StatementsF"},
                {"10019G","StatementsG"},
                {"10019H","StatementsH"},
                {"10019I","StatementsI"},
                {"10019J","StatementsJ"},
                {"10019K","StatementsK"},
                {"10019L","StatementsL"},
                {"10019M","StatementsM"},
                {"10019N","StatementsN"},
                {"10019O","StatementsO"},
                {"10019P","StatementsP"},
                {"10019Q","StatementsQ"},
                {"10019R","StatementsR"},
                {"10019S","StatementsS"},
                {"10019T","StatementsT"},
                {"10019U","StatementsU"},
                {"10019V","StatementsV"},
                {"10019W","StatementsW"},
                {"10019X","StatementsX"},
                {"10019Y","StatementsY"},
                {"10019Z","StatementsZ"},
                {"1001AA","StatementsAA"},
                {"1001AB","StatementsAB"},
                {"1001AC","StatementsAC"},
                {"1001AI","StatementsAI"},
                {"1001AJ","StatementsAJ"},
                {"1001AK","StatementsAK"},
                {"1001AL","StatementsAL"},
                {"1001AM","StatementsAM"},
                {"X1080","ContestationAct"}

         };
    }
}
