using System;
using banco_pokemon.Enum;

namespace banco_pokemon.Classes
{
    public class Conta
    {
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private string Nome { get; set; }
		public int Pokemon { get; set; }

		// Métodos
		public Conta(TipoConta tipoConta, double saldo, double credito, string nome, int pokemon)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
			this.Pokemon = pokemon;
		}

		public bool Sacar(double valorSaque)
		{
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

            return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
			retorno += "Pokemons " + this.Pokemon + " | ";
			return retorno;
		}

		public bool SacarPokemon(int pokemonSacado)
		{
			if(this.Pokemon < pokemonSacado){
				Console.WriteLine("Pokemons insuficientes!");
				return false;
			}
            this.Pokemon -= pokemonSacado;

            Console.WriteLine("Pokemons atuais da conta de {0} são {1}", this.Nome, this.Pokemon);

            return true;
		}

		public void DepositarPokemon(int pokemonDepositado)
		{
			this.Pokemon += pokemonDepositado;

            Console.WriteLine("Pokemons atuais da conta de {0} são {1}", this.Nome, this.Pokemon);
		}

		public void TransferirPokemon(int pokemonTrasferido, Conta contaDestino)
		{
			if (this.SacarPokemon(pokemonTrasferido)){
                contaDestino.DepositarPokemon(pokemonTrasferido);
            }
		}

		public void VenderPokemon(int pokemonVendido,double valorTransferencia, Conta contaDestino)
		{
			if (this.SacarPokemon(pokemonVendido)){
                contaDestino.DepositarPokemon(pokemonVendido);
            }
			if (contaDestino.Sacar(valorTransferencia)){
                this.Depositar(valorTransferencia);
            }
			

		}


				
        
    }
}