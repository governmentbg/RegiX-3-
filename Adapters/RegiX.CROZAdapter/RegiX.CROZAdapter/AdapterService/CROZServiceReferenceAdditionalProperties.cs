using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.CROZAdapter.CROZServiceReference
{
    public partial class OA 
    {
        private string imgFaceTypeField;
        private byte[] imgFaceField;
        private string imgBackTypeField;
        private byte[] imgBackField;

        /// <summary>
        /// Тип на запис - лице
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string imgFaceType
        {
            get
            {
                return this.imgFaceTypeField;
            }
            set
            {
                this.imgFaceTypeField = value;
            }
        }

        /// <summary>
        /// Съдържание на запис - лице
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public byte[] imgFace
        {
            get
            {
                return this.imgFaceField;
            }
            set
            {
                this.imgFaceField = value;
            }
        }

        /// <summary>
        /// Тип на запис - гръб
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string imgBackType
        {
            get
            {
                return this.imgBackTypeField;
            }
            set
            {
                this.imgBackTypeField = value;
            }
        }

        /// <summary>
        /// Съдържание на запис - гръб
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public byte[] imgBack
        {
            get
            {
                return this.imgBackField;
            }
            set
            {
                this.imgBackField = value;
            }
        }

    }
}
