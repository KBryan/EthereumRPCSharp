using System.Numerics;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Web3Dots.RPC.Transactions;
using Block = Web3Dots.RPC.Blocks.Block;
using BlockWithTransactions = Web3Dots.RPC.Blocks.BlockWithTransactions;
using TransactionReceipt = Web3Dots.RPC.Transactions.TransactionReceipt;

namespace Web3Dots.RPC.Providers
{
    public interface IProvider
    {
        // Network
        public Task<Network.Network> DetectNetwork();
        public Network.Network Network { get; }
        public Task<Network.Network> GetNetwork();

        // Account
        public Task<HexBigInteger> GetBalance(string address, BlockParameter blockTag = null);
        public Task<string> GetCode(string address, BlockParameter blockTag = null);
        public Task<string> GetStorageAt(string address, BigInteger position, BlockParameter blockTag = null);
        public Task<HexBigInteger> GetTransactionCount(string address, BlockParameter blockTag = null);

        // Queries
        public Task<HexBigInteger> GetBlockNumber();
        public Task<Block> GetBlock(BlockParameter blockTag = null);
        public Task<Block> GetBlock(string blockHash);
        public Task<BlockWithTransactions> GetBlockWithTransactions(BlockParameter blockTag = null);
        public Task<BlockWithTransactions> GetBlockWithTransactions(string blockHash);
        public Task<TransactionResponse> GetTransaction(string transactionHash);
        public Task<TransactionReceipt> GetTransactionReceipt(string transactionHash);

        // Fees
        public Task<HexBigInteger> GetGasPrice();
        public Task<FeeData> GetFeeData();

        // Execution
        public Task<string> Call(TransactionRequest transaction, BlockParameter blockTag = null);
        public Task<HexBigInteger> EstimateGas(TransactionRequest transaction);
        public Task<TransactionResponse> SendTransaction(string signedTx);

        public Task<TransactionReceipt> WaitForTransactionReceipt(string transactionHash,
            uint confirmations = 1,
            uint timeout = 30);

        // Bloom-filter Queries
        public Task<FilterLog[]> GetLogs(NewFilterInput filter);

        // ENS

        public Task<T> Perform<T>(string method, object[] parameters = null);
    }
}