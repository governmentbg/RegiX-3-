using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.AVTRAdapter.Helpers
{
    public static class ActualStateV3Helper
    {
        private static XmlElement DeedElementV3 = (new ActualStateV3.DeedType()).XmlSerialize().ToXmlElement();

        private static XmlElement ConvertRecordDataToXmlElementV3(string recordData)
        {
            XmlElement elemWithoutXmlDeclaration = DeedElementV3.OwnerDocument.CreateElement("record");
            elemWithoutXmlDeclaration.InnerXml = recordData;
            string recordTemplate = "<record xmlns=\"" + DeedElementV3.NamespaceURI + "\">" + elemWithoutXmlDeclaration.ChildNodes.OfType<XmlElement>().FirstOrDefault().OuterXml + "</record>";
            XmlElement elem_WithoutXmlDeclaration_WithProperNamespace = DeedElementV3.OwnerDocument.CreateElement("record2", DeedElementV3.OwnerDocument.DocumentElement.NamespaceURI);
            elem_WithoutXmlDeclaration_WithProperNamespace.InnerXml = recordTemplate;
            return (XmlElement)elem_WithoutXmlDeclaration_WithProperNamespace.FirstChild.FirstChild;
        }

        public static void SetRecordValueV3(DataRow row, List<ActualStateV3.Record> recordsList)
        {
            XmlElement propElem = ConvertRecordDataToXmlElementV3(row["record_data"].ToString());
            ActualStateV3.Record rec = new ActualStateV3.Record();
            rec.RecordData = propElem;
            rec.RecordId = Convert.ToInt32(row["record_id"]);
            //rec.GroupId = Convert.ToInt32(row["group_id"]);
            rec.IncomingId = row["incoming_id"] != DBNull.Value ? Convert.ToInt32(row["incoming_id"]) : 0;
            rec.FieldIdent = row["field_ident"] != DBNull.Value ? row["field_ident"].ToString() : null;

            rec.MainField = new ActualStateV3.Field();

            rec.MainField.GroupId = row["main_field_GROUP_id"] != DBNull.Value ? Convert.ToInt32(row["main_field_GROUP_id"]) : 0;
            rec.MainField.GroupIdSpecified = row["main_field_GROUP_id"] != DBNull.Value ? true : false;
            rec.MainField.GroupName = row["main_field_group_name"] != DBNull.Value ? row["main_field_group_name"].ToString() : null;

            rec.MainField.SectionId = row["main_field_section_id"] != DBNull.Value ? Convert.ToInt32(row["main_field_section_id"]) : 0;
            rec.MainField.SectionIdSpecified = row["main_field_section_id"] != DBNull.Value ? true : false;
            rec.MainField.SectionName = row["main_field_section_name"] != DBNull.Value ? row["main_field_section_name"].ToString() : null;

            rec.MainField.MainFieldCode = row["main_field_code"] != DBNull.Value ? row["main_field_code"].ToString() : null;

            rec.MainField.MainFieldIdent = row["main_field_ident"] != DBNull.Value ? row["main_field_ident"].ToString() : null;

            //rec.MainField.MainFieldIdentSpecified = row["main_field_ident"] != DBNull.Value;
            //if(row["main_field_ident"] != DBNull.Value)
            //{
            //    rec.MainField.MainFieldIdent = (ActualStateV3.FieldCodes)Enum.Parse(typeof(ActualStateV3.FieldCodes), row["main_field_ident"].ToString());
            //}
            //rec.MainField.MainFieldIdentSpecified = row["main_field_ident"] != DBNull.Value ? true : false;

            rec.MainField.MainFieldName = row["main_field_name"] != DBNull.Value ? row["main_field_name"].ToString() : null;
            rec.FieldEntryNumber = row["entry_number"] != DBNull.Value ? row["entry_number"].ToString() : null;
            rec.FieldActionDate = row["action_date"] != DBNull.Value ? Convert.ToDateTime(row["action_date"]) : DateTime.MinValue;
            recordsList.Add(rec);
        }

        public static ActualStateV3.SubUICType GetSubUICTypeEnumValue(DataRow deedrow)
        {
            string subUICType = Convert.ToString(deedrow["sub_uic_type"]);
            switch (subUICType)
            {
                case "1": return ActualStateV3.SubUICType.Item1;
                case "2": return ActualStateV3.SubUICType.Item2;
                case "3": return ActualStateV3.SubUICType.Item3;
                case "4": return ActualStateV3.SubUICType.Item4;
                case "5": return ActualStateV3.SubUICType.Item5;
                case "6": return ActualStateV3.SubUICType.Item6;
                case "7": return ActualStateV3.SubUICType.Item7;
                case "500": return ActualStateV3.SubUICType.Item500;
                case "8": return ActualStateV3.SubUICType.Item8;
                case "9": return ActualStateV3.SubUICType.Item9;
                case "10": return ActualStateV3.SubUICType.Item10;
                case "11": return ActualStateV3.SubUICType.Item11;
                case "13": return ActualStateV3.SubUICType.Item13;
                case "15": return ActualStateV3.SubUICType.Item15;
                default:
                    {
                        throw new Exception("Заявката връща тип раздел, който не присъства в номенклатурата SubUICType. Стойност на връщания тип раздел: " + subUICType);
                    }
            }
        }


        public static ActualStateV3.LegalFormType GetLegalFormEnumV3(DataRow deedrow)
        {
            switch (Convert.ToInt32(deedrow["legal_form_id"]))
            {
                case 1: return ActualStateV3.LegalFormType.ЕТ;
                case 2: return ActualStateV3.LegalFormType.СД;
                case 3: return ActualStateV3.LegalFormType.КД;
                case 4: return ActualStateV3.LegalFormType.ООД;
                case 5: return ActualStateV3.LegalFormType.АД;
                case 6: return ActualStateV3.LegalFormType.КДА;
                case 7: return ActualStateV3.LegalFormType.Кооперация;
                case 8: return ActualStateV3.LegalFormType.КЧТ;
                case 9: return ActualStateV3.LegalFormType.ТПП;
                case 10: return ActualStateV3.LegalFormType.ЕООД;
                case 11: return ActualStateV3.LegalFormType.ЕАД;
                case 12: return ActualStateV3.LegalFormType.АДСИЦ;
                case 13: return ActualStateV3.LegalFormType.ДП;
                case 14: return ActualStateV3.LegalFormType.ОП;
                case 15: return ActualStateV3.LegalFormType.ЕАДСИЦ;
                case 16: return ActualStateV3.LegalFormType.ЕОИИ;
                case 17: return ActualStateV3.LegalFormType.ПоделениенаЕОИИ;
                case 18: return ActualStateV3.LegalFormType.ЕД;
                case 19: return ActualStateV3.LegalFormType.ЕКД;
                case 20: return ActualStateV3.LegalFormType.ЕКДОО;
                case 21: return ActualStateV3.LegalFormType.ЧДПР;
                case 22: return ActualStateV3.LegalFormType.ЧЮЛ;
                case 23: return ActualStateV3.LegalFormType.ЧФЛ;
                case 24: return ActualStateV3.LegalFormType.Сдружение;
                case 25: return ActualStateV3.LegalFormType.Фондация;
                case 26: return ActualStateV3.LegalFormType.КлоннаЧЮЛНЦ;
                case 27: return ActualStateV3.LegalFormType.НЧ;
                case -1: return ActualStateV3.LegalFormType.Неизвестно;
                default: return ActualStateV3.LegalFormType.Неизвестно;

            }
        }

    }
}
