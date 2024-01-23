namespace AutoInvest.Shared.DTO.Request
{
    public record ReviewRequestDto
    {
        public string Subject { get; init; }
        public bool CarPurchased { get; init; }
        public string Comment { get; init; }
        public string ShopId { get; init; }
        public string ReviewerId { get; init; }
        //I was thinking though to declare a user id property and a usertype property
        //to show and confirm if the user making a comment is a registered client user. Or 
        //do you think this should be made anonymous reveiwer
        
    }
}
