import axios from "axios";

/**
 * URL base da API do dashboard
 */
const API_URL = "http://localhost:5186/api/dashboard";

/**
 * Tipos de dados utilizados pelo Dashboard
 */

/** Resumo financeiro de uma pessoa */
export type PersonSummary = {
  name: string;
  age: number;
  totalIncome: number;
  totalExpenses: number;
  balance: number;
};

/** Resumo financeiro de uma categoria */
export type CategorySummary = {
  description: string;
  totalIncome: number;
  totalExpenses: number;
  balance: number;
};

/** Resumo de uma transação recente */
export type TransactionSummary = {
  description: string; // descrição da transação
  personName: string;  // pessoa responsável
  type: number;        // 2 = Receita, 1 = Despesa
  value: number;       // valor da transação
};

/** Resumo completo do dashboard */
export type DashboardSummary = {
  totalIncome: number;
  totalExpenses: number;
  balance: number;
  people: PersonSummary[];
  categories: CategorySummary[];
  recentTransactions: TransactionSummary[];
};

/** Estrutura padrão da resposta da API */
type ApiResponse<T> = {
  success: boolean;
  statusCode: number;
  data: T;
  message: string;
  errors?: any;
};

/**
 * getDashboardSummary - busca resumo completo do dashboard
 *
 * Retorna um objeto contendo:
 * - totalIncome, totalExpenses, balance
 * - pessoas cadastradas
 * - categorias
 * - transações recentes
 *
 * @returns {Promise<DashboardSummary>} resumo completo do dashboard
 */
export const getDashboardSummary = async (): Promise<DashboardSummary> => {
  const response = await axios.get<ApiResponse<DashboardSummary>>(API_URL);
  return response.data.data;
};