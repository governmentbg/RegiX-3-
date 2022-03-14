using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace RegiX.Adapters.Common.Tests
{
    [TestClass]
    public class SelfMapperTests
    {
        [TestMethod]
        public void SelfMapTest()
        {
            var selfMapper =  new SelfMapper<RelationsResponseType>(AccessMatrix.CreateForType(typeof(RelationsResponseType)));
            RelationsResponseType source = new RelationsResponseType()
            {
                PersonRelations = new List<PersonRelationType>() {
                    new PersonRelationType()
                    {
                        RelationCode = RelationType.Баща,
                        RelationCodeSpecified = true
                    },
                    new PersonRelationType()
                    {
                        RelationCode = RelationType.Майка,
                        RelationCodeSpecified = true
                    },
                    new PersonRelationType()
                    {
                        RelationCode = RelationType.Осиновителка,
                        RelationCodeSpecified = true
                    },
                }
            };
            RelationsResponseType dest = new RelationsResponseType();
            selfMapper.Map(source, dest);
            Assert.IsTrue(dest.PersonRelations.Count == 3);
            Assert.IsTrue(dest.PersonRelations[0].RelationCode == RelationType.Баща);
            Assert.IsTrue(dest.PersonRelations[0].RelationCodeSpecified);
            Assert.IsFalse(dest.PersonRelations[0].BirthDateSpecified);
            Assert.IsTrue(dest.PersonRelations[1].RelationCode == RelationType.Майка);
            Assert.IsTrue(dest.PersonRelations[1].RelationCodeSpecified);
            Assert.IsFalse(dest.PersonRelations[1].BirthDateSpecified);
            Assert.IsTrue(dest.PersonRelations[2].RelationCode == RelationType.Осиновителка);
            Assert.IsTrue(dest.PersonRelations[2].RelationCodeSpecified);
            Assert.IsFalse(dest.PersonRelations[2].BirthDateSpecified);
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.21752")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://egov.bg/RegiX/GRAO/NBD/RelationsResponse")]
    [System.Xml.Serialization.XmlRootAttribute("RelationsResponse", Namespace = "http://egov.bg/RegiX/GRAO/NBD/RelationsResponse", IsNullable = false)]
    public partial class RelationsResponseType
    {

        private List<PersonRelationType> personRelationsField;

        /// <summary>
        /// RelationsResponseType class constructor
        /// </summary>
        public RelationsResponseType()
        {
            this.personRelationsField = new List<PersonRelationType>();
        }

        /// <summary>
        /// Списък с родственици
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("PersonRelations", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Списък с родственици")]
        public List<PersonRelationType> PersonRelations
        {
            get
            {
                return this.personRelationsField;
            }
            set
            {
                this.personRelationsField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29860")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://egov.bg/RegiX/GRAO/NBD")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://egov.bg/RegiX/GRAO/NBD", IsNullable = true)]
    public partial class Gender
    {

        private int genderCodeField;

        private bool genderCodeFieldSpecified;

        private GenderNameType genderNameField;

        private bool genderNameFieldSpecified;

        /// <summary>
        /// Код на пол
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Код на пол")]
        public int GenderCode
        {
            get
            {
                return this.genderCodeField;
            }
            set
            {
                this.genderCodeField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GenderCodeSpecified
        {
            get
            {
                return this.genderCodeFieldSpecified;
            }
            set
            {
                this.genderCodeFieldSpecified = value;
            }
        }

        /// <summary>
        /// Пол
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Пол")]
        public GenderNameType GenderName
        {
            get
            {
                return this.genderNameField;
            }
            set
            {
                this.genderNameField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GenderNameSpecified
        {
            get
            {
                return this.genderNameFieldSpecified;
            }
            set
            {
                this.genderNameFieldSpecified = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29860")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://egov.bg/RegiX/GRAO/NBD")]
    public enum GenderNameType
    {

        /// <remarks/>
        Мъж,

        /// <remarks/>
        Жена,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29860")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://egov.bg/RegiX/GRAO/NBD")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://egov.bg/RegiX/GRAO/NBD", IsNullable = true)]
    public partial class PersonNames
    {

        private object firstNameField;

        private object surNameField;

        private object familyNameField;

        /// <summary>
        /// Собствено име
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Собствено име")]
        public object FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <summary>
        /// Бащино име
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Бащино име")]
        public object SurName
        {
            get
            {
                return this.surNameField;
            }
            set
            {
                this.surNameField = value;
            }
        }

        /// <summary>
        /// Фамилно име
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Фамилно име")]
        public object FamilyName
        {
            get
            {
                return this.familyNameField;
            }
            set
            {
                this.familyNameField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29860")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://egov.bg/RegiX/GRAO/NBD")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://egov.bg/RegiX/GRAO/NBD", IsNullable = true)]
    public partial class Nationality
    {

        private string nationalityCodeField;

        private string nationalityNameField;

        private string nationalityCode2Field;

        private string nationalityName2Field;

        /// <summary>
        /// Код на гражданство
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Код на гражданство")]
        public string NationalityCode
        {
            get
            {
                return this.nationalityCodeField;
            }
            set
            {
                this.nationalityCodeField = value;
            }
        }

        /// <summary>
        /// Гражданство
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Гражданство")]
        public string NationalityName
        {
            get
            {
                return this.nationalityNameField;
            }
            set
            {
                this.nationalityNameField = value;
            }
        }

        /// <summary>
        /// Код на второ гражданство
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Код на второ гражданство")]
        public string NationalityCode2
        {
            get
            {
                return this.nationalityCode2Field;
            }
            set
            {
                this.nationalityCode2Field = value;
            }
        }

        /// <summary>
        /// Второ гражданство
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Второ гражданство")]
        public string NationalityName2
        {
            get
            {
                return this.nationalityName2Field;
            }
            set
            {
                this.nationalityName2Field = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29860")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://egov.bg/RegiX/GRAO/NBD")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://egov.bg/RegiX/GRAO/NBD", IsNullable = true)]
    public partial class PersonRelationType
    {

        private RelationType relationCodeField;

        private bool relationCodeFieldSpecified;

        private string eGNField;

        private System.DateTime birthDateField;

        private bool birthDateFieldSpecified;

        private string firstNameField;

        private string surNameField;

        private string familyNameField;

        private Gender genderField;

        private Nationality nationalityField;

        private System.DateTime deathDateField;

        private bool deathDateFieldSpecified;

        /// <summary>
        /// PersonRelationType class constructor
        /// </summary>
        public PersonRelationType()
        {
            this.nationalityField = new Nationality();
            this.genderField = new Gender();
        }

        /// <summary>
        /// Код на родство
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Код на родство")]
        public RelationType RelationCode
        {
            get
            {
                return this.relationCodeField;
            }
            set
            {
                this.relationCodeField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RelationCodeSpecified
        {
            get
            {
                return this.relationCodeFieldSpecified;
            }
            set
            {
                this.relationCodeFieldSpecified = value;
            }
        }

        /// <summary>
        /// ЕГН на лицето
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("ЕГН на лицето")]
        public string EGN
        {
            get
            {
                return this.eGNField;
            }
            set
            {
                this.eGNField = value;
            }
        }

        /// <summary>
        /// Дата на раждане
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Дата на раждане")]
        public System.DateTime BirthDate
        {
            get
            {
                return this.birthDateField;
            }
            set
            {
                this.birthDateField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BirthDateSpecified
        {
            get
            {
                return this.birthDateFieldSpecified;
            }
            set
            {
                this.birthDateFieldSpecified = value;
            }
        }

        /// <summary>
        /// Собствено име
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Собствено име")]
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <summary>
        /// Бащино име
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Бащино име")]
        public string SurName
        {
            get
            {
                return this.surNameField;
            }
            set
            {
                this.surNameField = value;
            }
        }

        /// <summary>
        /// Фамилно име
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Фамилно име")]
        public string FamilyName
        {
            get
            {
                return this.familyNameField;
            }
            set
            {
                this.familyNameField = value;
            }
        }

        /// <summary>
        /// Пол
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Пол")]
        public Gender Gender
        {
            get
            {
                return this.genderField;
            }
            set
            {
                this.genderField = value;
            }
        }

        /// <summary>
        /// Гражданство
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Гражданство")]
        public Nationality Nationality
        {
            get
            {
                return this.nationalityField;
            }
            set
            {
                this.nationalityField = value;
            }
        }

        /// <summary>
        /// Дата на смърт
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Дата на смърт")]
        public System.DateTime DeathDate
        {
            get
            {
                return this.deathDateField;
            }
            set
            {
                this.deathDateField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DeathDateSpecified
        {
            get
            {
                return this.deathDateFieldSpecified;
            }
            set
            {
                this.deathDateFieldSpecified = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.29860")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://egov.bg/RegiX/GRAO/NBD")]
    public enum RelationType
    {

        /// <remarks/>
        Баща,

        /// <remarks/>
        Осиновител,

        /// <remarks/>
        Майка,

        /// <remarks/>
        Осиновителка,

        /// <remarks/>
        Син,

        /// <remarks/>
        Дъщеря,

        /// <remarks/>
        Брат,

        /// <remarks/>
        Сестра,
    }


}
