﻿using BlazorWasm1.Models;
using Domain;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWasm1.Pages;

public partial class Home
{
    private IEnumerable<Trail> trails;

    private Trail selectedTrail;

    [Inject]
    public HttpClient Http { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            trails = await Http.GetFromJsonAsync<IEnumerable<Trail>>("trails/trail-data.json");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"There was a problem loading trail data: {ex.Message}");
        }
    }

    private void HandleTrailSelected(Trail trail) => selectedTrail = trail;
}
