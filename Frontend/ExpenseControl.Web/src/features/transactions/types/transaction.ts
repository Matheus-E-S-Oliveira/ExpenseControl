/**
 * Transaction
 *
 * Representa uma transação financeira no sistema.
 *
 * Campos:
 *  - id: string
 *      Identificador único da transação
 *  - description: string
 *      Descrição detalhada da transação
 *  - value: number
 *      Valor da transação (positivo)
 *  - type: number
 *      Tipo da transação: 1 = Despesa, 2 = Receita
 *  - person?: object (opcional)
 *      Pessoa associada à transação
 *      - id: string
 *          Identificador da pessoa
 *      - name: string
 *          Nome da pessoa
 *  - category?: object (opcional)
 *      Categoria da transação
 *      - id: string
 *          Identificador da categoria
 *      - description: string
 *          Descrição da categoria
 *      - purpose: number
 *          Finalidade da categoria: 1 = Despesa, 2 = Receita, 3 = Ambas
 */
export type Transaction = {
  id: string;
  description: string;
  value: number;
  type: number; 
  person?: {
    id: string;
    name: string;
  };
  category?: {
    id: string;
    description: string;
    purpose: number;
  };
};