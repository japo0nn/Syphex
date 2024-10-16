namespace Syphex.Domain.Entities;

public class Network : BaseEntity
{
    public string Coin { get; set; }
    public string ContractAddress { get; set; }
    public string ChainId { get; set; }
    public decimal Fee { get; set; }
    public bool WithdrawEnabled { get; set; }
    public bool DepositEnabled { get; set; }

    public Guid ExchangerId { get; set; }

    private Network(
        string coin,
        string contractAddress,
        string chainId,
        bool withdrawEnabled,
        bool depositEnabled,
        Guid exchangerId,
        decimal fee
    )
    {
        Coin = coin;
        ContractAddress = contractAddress;
        ChainId = chainId;
        WithdrawEnabled = withdrawEnabled;
        DepositEnabled = depositEnabled;
        ExchangerId = exchangerId;
        Fee = fee;
    }

    public static Network Create(
        string coin,
        string contractAddress,
        string chainId,
        bool withdrawEnabled,
        bool depositEnabled,
        Guid exchangerId,
        decimal fee = 0
    )
    {
        return new Network(
            coin,
            contractAddress,
            chainId,
            withdrawEnabled,
            depositEnabled,
            exchangerId,
            fee
        );
    }
}

public static class NetworkExtensions
{
    public static Network Update(
        this Network network,
        string chainId,
        bool withdrawEnabled,
        bool depositEnabled,
        decimal fee = 0
    )
    {
        network.ChainId = chainId;
        network.WithdrawEnabled = withdrawEnabled;
        network.DepositEnabled = depositEnabled;
        network.Fee = fee;
        network.Update();

        return network;
    }
}
