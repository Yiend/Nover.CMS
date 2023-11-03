namespace Nover.CMS.Application.Contracts.Dtos;

public class GetOpenIddictListInput : PagedRequestDto
{
    public string? Keywords { get; set; }
}