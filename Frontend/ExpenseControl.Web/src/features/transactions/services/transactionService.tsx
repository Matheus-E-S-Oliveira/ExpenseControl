import axios from "axios";

// URL base da API de transações
const API_URL = "http://localhost:5186/api/transaction";

/**
 * getTransactions
 *
 * Busca todas as transações cadastradas.
 *
 * Retorna um array de objetos de transações.
 *
 * Exemplo de uso:
 * const transactions = await getTransactions();
 */
export const getTransactions = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

/**
 * createTransaction
 *
 * Cria uma nova transação.
 *
 * @param data Objeto contendo:
 *  - description: string (descrição da transação)
 *  - value: number (valor da transação)
 *  - type: number (1 = Despesa, 2 = Receita)
 *  - personId: string (ID da pessoa associada)
 *  - categoryId: string (ID da categoria associada)
 *
 * Retorna a transação criada (ou mensagem de sucesso).
 *
 * Exemplo de uso:
 * const newTransaction = await createTransaction({
 *   description: "Compra mercado",
 *   value: 150.5,
 *   type: 1,
 *   personId: "abc123",
 *   categoryId: "cat456"
 * });
 */
export const createTransaction = async (data: {
  description: string;
  value: number;
  type: number;
  personId: string;
  categoryId: string;
}) => {
  const response = await axios.post(API_URL, data);
  return response.data;
};