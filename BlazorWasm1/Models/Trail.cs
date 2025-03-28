﻿using Domain;
using System;
using System.Collections.Generic;

namespace BlazorWasm1.Models;

public sealed record Trail
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int TimeInMinutes { get; set; }
    public string TimeFormatted => $"{TimeInMinutes / 60}h {TimeInMinutes % 60}m";
    public int Length { get; set; }
    public List<Domain.TrailDto.RouteInstruction> Route { get; set; } = new List<Domain.TrailDto.RouteInstruction>();
}
