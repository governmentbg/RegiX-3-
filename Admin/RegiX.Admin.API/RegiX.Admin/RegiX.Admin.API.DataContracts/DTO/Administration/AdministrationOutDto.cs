using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.BaseDtos;

public class AdministrationOutDto : BaseOutDto
{
    public string PathToRoot { get; set; }
    public int? Depth { get; set; }
    public string Acronym { get; set; }
    public string Code { get; set; }
    public string PathToRootNames { get; set; }
    public bool? PubliclyVisible { get; set; }
    public DisplayValue AdministrationType { get; set; }
    public DisplayValue ParentAuthority { get; set; }
}