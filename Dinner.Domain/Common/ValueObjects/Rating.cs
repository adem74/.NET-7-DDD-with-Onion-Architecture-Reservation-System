namespace Dinner.Domain.Common.ValueObjects;
public class Rating
{
    public float Value {get;set;}
    public Rating(float value){
        Value = value;
    } 
    
}