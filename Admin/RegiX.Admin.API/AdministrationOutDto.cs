using System;

public class AdministrationOutDto
{
    public decimal AdministrationId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal? ParentAuthorityId { get; set; }
    
    public string PathToRoot { get; set; }

    public int? Depth { get; set; }

    public string Acronym { get; set; }

    public string Code { get; set; }

    public string PathToRootNames { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string UpdatedBy { get; set; }

    public bool? PubliclyVisible { get; set; }

    public decimal? AdministrationTypeId { get; set; }
}
