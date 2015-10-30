using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cabesp.SGA.Infra.CrossCutting.Dtos
{
    [DataContract(IsReference = true)]
    //[KnownType(typeof(TB_FaseStatus))]
    //[KnownType(typeof(TB_Projeto))]
    public partial class FasesDto
    {
        public FasesDto()
        {
            //TB_FaseStatus = new List<TB_FaseStatus>();
            //TB_Projeto = new List<TB_Projeto>();
        }


        //[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
        [DataMember]
        public int IdFase { get; set; }
      

        //[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
        [StringLength(50, ErrorMessage = "validation_FieldMaxLenght")]
        [DataMember]
        public string Descricao { get; set; }
       
        [Required(ErrorMessage = "validation_FieldMaxLenght")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataMember]
        public DateTime DataCadastro { get; set; }
        
        
        //[DataMember]
        //public virtual List<TB_FaseStatus> TB_FaseStatus { get { return _tB_FaseStatus; } set { if (!Equals(value, _tB_FaseStatus)) { _tB_FaseStatus = value; } } }
        //private List<TB_FaseStatus> _tB_FaseStatus;

        //[DataMember]
        //public virtual List<TB_Projeto> TB_Projeto { get { return _tB_Projeto; } set { if (!Equals(value, _tB_Projeto)) { _tB_Projeto = value; } } }
        //private List<TB_Projeto> _tB_Projeto;
    }
}
