﻿namespace OnlineStore.Core.Models;

public class Country
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Code { get; set; }
}