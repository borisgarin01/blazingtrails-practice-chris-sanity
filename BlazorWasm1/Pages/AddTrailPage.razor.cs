using BlazorWasm1.Models;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;
using Shared.Features.ManagerTrails;
using System.Threading.Tasks;

namespace BlazorWasm1.Pages;

public partial class AddTrailPage
{
    private TrailDto trail = new TrailDto();
    private bool submitSuccessfull;
    private string errorMessage;

    [Inject]
    public IMediator Mediator { get; set; }

    private async Task SubmitForm()
    {
        var response = await Mediator.Send(new AddTrailRequest(trail));
        if (response.TrailId == -1)
        {
            errorMessage = "There was a problem saving your trail.";
            submitSuccessfull = false;
            return;
        }

        trail = new TrailDto();
        errorMessage = null;
        submitSuccessfull = true;
    }
}
