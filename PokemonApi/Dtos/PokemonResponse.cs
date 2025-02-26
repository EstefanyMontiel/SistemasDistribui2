namespace  PokemonApi.Dtos
{
public class PokemonResponseDto
{
public Guid id {get; set;}
public string name {get; set;}

public string type {get; set;}

public int level {get; set;}

public StatsDto stats {get; set;}


}}